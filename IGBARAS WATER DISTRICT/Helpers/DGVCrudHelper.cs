using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT.Helpers
{
    public class DGVCrudHelper
    {
        private DataGridView dgv;
        private string tableName;
        private List<string> columns;
        private string primaryKeyColumn;
        private Dictionary<int, object> oldCellValues = new Dictionary<int, object>();

        private int pageSize = 100;
        private int currentPage = 1;
        private int totalRecords = 0;
        private int totalPages = 0;

        private Label pageInfoLabel;

        public DGVCrudHelper(DataGridView dgv, string tableName, List<string> columns, string primaryKeyColumn)
        {
            this.dgv = dgv;
            this.tableName = tableName;
            this.columns = columns;
            this.primaryKeyColumn = primaryKeyColumn;

            dgv.CellBeginEdit -= Dgv_CellBeginEdit;
            dgv.CellBeginEdit += Dgv_CellBeginEdit;

            dgv.CellEndEdit -= Dgv_CellEndEdit;
            dgv.CellEndEdit += Dgv_CellEndEdit;

            dgv.UserDeletingRow -= Dgv_UserDeletingRow;
            dgv.UserDeletingRow += Dgv_UserDeletingRow;
        }

        #region Pagination
        public int CurrentPage => currentPage;
        public int TotalPages => totalPages;

        public void SetPageInfoLabel(Label label)
        {
            pageInfoLabel = label;
        }

        private void UpdatePageInfoLabel()
        {
            if (pageInfoLabel != null)
                pageInfoLabel.Text = $"Page {currentPage} of {totalPages}";
        }

        public void NextPage()
        {
            if (currentPage < totalPages)
                LoadData(currentPage + 1);
        }

        public void PreviousPage()
        {
            if (currentPage > 1)
                LoadData(currentPage - 1);
        }
        #endregion

        #region Load Data
        public void LoadData(int page = 1)
        {
            try
            {
                currentPage = page;

                using (var conn = new OleDbConnection(DbConfig.ConnectionString))
                {
                    conn.Open();
                    using (var cmdCount = new OleDbCommand($"SELECT COUNT(*) FROM {tableName}", conn))
                    {
                        totalRecords = Convert.ToInt32(cmdCount.ExecuteScalar());
                    }
                }

                totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRecords / pageSize));
                int topRecords = page * pageSize;

                string columnsString = string.Join(",", columns.Select(c => $"[{c}]"));
                string sql = $@"
                    SELECT * FROM (
                        SELECT TOP {pageSize} * FROM (
                            SELECT TOP {topRecords} {columnsString}, [{primaryKeyColumn}]
                            FROM [{tableName}]
                            ORDER BY [{primaryKeyColumn}] ASC
                        ) AS sub
                        ORDER BY [{primaryKeyColumn}] DESC
                    ) AS sub2
                    ORDER BY [{primaryKeyColumn}] ASC;
                ";

                using (var conn = new OleDbConnection(DbConfig.ConnectionString))
                using (var adapter = new OleDbDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;
                }

                UpdatePageInfoLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CRUD Events
        private void Dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                oldCellValues[e.RowIndex] = cell.Value;
            }
            catch { /* ignore */ }
        }

        private void Dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                object oldValue = oldCellValues.ContainsKey(e.RowIndex) ? oldCellValues[e.RowIndex] : null;

                if ((cell.Value == null && oldValue != null) || (cell.Value != null && !cell.Value.Equals(oldValue)))
                {
                    DialogResult result = MessageBox.Show(
                        $"Do you want to save changes for {columns[e.ColumnIndex]}?",
                        "Confirm Update",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            UpdateCellValueSafe(e.RowIndex, e.ColumnIndex);
                            LoadData(currentPage);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Update failed: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cell.Value = oldValue;
                        }
                    }
                    else
                    {
                        cell.Value = oldValue;
                    }
                }
            }
            catch { /* ignore unexpected errors */ }
        }

        private void UpdateCellValueSafe(int rowIndex, int colIndex)
        {
            string columnName = columns[colIndex];
            object value = dgv.Rows[rowIndex].Cells[columnName].Value;
            object id = dgv.Rows[rowIndex].Cells[primaryKeyColumn].Value;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                value = DBNull.Value;

            string sql = $"UPDATE [{tableName}] SET [{columnName}]=? WHERE [{primaryKeyColumn}]=?";

            using (var conn = new OleDbConnection(DbConfig.ConnectionString))
            using (var cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("?", value);
                cmd.Parameters.AddWithValue("?", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void Dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
            object id = e.Row.Cells[primaryKeyColumn].Value;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteRow(id);
                    LoadData(currentPage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed: " + ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteRow(object id)
        {
            string sql = $"DELETE FROM [{tableName}] WHERE [{primaryKeyColumn}]=?";
            using (var conn = new OleDbConnection(DbConfig.ConnectionString))
            using (var cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("?", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertRow(Dictionary<string, object> rowValues)
        {
            string columnsString = string.Join(",", rowValues.Keys.Select(k => $"[{k}]"));
            string parametersString = string.Join(",", Enumerable.Repeat("?", rowValues.Count));

            string sql = $"INSERT INTO [{tableName}] ({columnsString}) VALUES ({parametersString})";

            using (var conn = new OleDbConnection(DbConfig.ConnectionString))
            using (var cmd = new OleDbCommand(sql, conn))
            {
                foreach (var kv in rowValues)
                    cmd.Parameters.AddWithValue("?", kv.Value ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
