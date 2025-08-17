using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class AccountsControl : UserControl
    {
        public AccountsControl()
        {
            InitializeComponent();
        }

        private async void AccountsControl_Load(object sender, EventArgs e)
        {
            PlaceholderHelper.AddPlaceholder(searchAccountNumberTextBox, "🔎 Fullname or Account Number.");
            using (var loadingForm = new LoadingForm())
            {
                var task1 = DGVHelper.LoadDataToGridAsync(accountDataGridView, "Tb_Concessionaire", loadingForm);

                await Task.WhenAll(task1);
            }
            AutoCompleteHelper.FillTextBoxWithColumns("Tb_Concessionaire", new string[] { "AccountNo", "ConcessionaireName" }, searchAccountNumberTextBox);
            LoadZoneComboBox();
            AddDeleteContextMenu(accountDataGridView, "Tb_Concessionaire", "ConcessionaireID");
            LoadComboBoxValues();

        }
        private void LoadComboBoxValues()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(DbConfig.ConnectionString))
                {
                    conn.Open();

                    // ZoneCode values
                    DataTable dtZone = new DataTable();
                    using (OleDbDataAdapter daZone = new OleDbDataAdapter(
                        "SELECT DISTINCT ZoneCode FROM Tb_Concessionaire WHERE ZoneCode IS NOT NULL", conn))
                    {
                        daZone.Fill(dtZone);
                    }

                    // ServiceID values
                    DataTable dtService = new DataTable();
                    using (OleDbDataAdapter daService = new OleDbDataAdapter(
                        "SELECT DISTINCT ServiceID FROM Tb_Concessionaire WHERE ServiceID IS NOT NULL", conn))
                    {
                        daService.Fill(dtService);
                    }

                    // Bind ZoneCode ComboBox column
                    if (accountDataGridView.Columns["ZoneCode"] is DataGridViewComboBoxColumn zoneCol)
                    {
                        zoneCol.DataSource = dtZone;
                        zoneCol.DisplayMember = "ZoneCode";
                        zoneCol.ValueMember = "ZoneCode";
                    }

                    // Bind ServiceID ComboBox column
                    if (accountDataGridView.Columns["ServiceID"] is DataGridViewComboBoxColumn serviceCol)
                    {
                        serviceCol.DataSource = dtService;
                        serviceCol.DisplayMember = "ServiceID";
                        serviceCol.ValueMember = "ServiceID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading combo values: {ex.Message}",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadZoneComboBox()
        {
            int districtNo = 1; // Replace with actual district if needed

            var zoneList = ZoneHelper.GetZoneCodeHelper(districtNo);

            zoneComboBox.DataSource = zoneList;
            zoneComboBox.DisplayMember = "ZoneCode"; // Shown: "01", "02", "11"
            zoneComboBox.ValueMember = "ZoneCode";   // Internal value: same as displayed

            if (zoneComboBox.Items.Count > 0)
                zoneComboBox.SelectedIndex = 0;
        }
        private void accountApplyButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to apply the changes to the concessionaire details?\n\n" +
                "This action will save the modifications to the database and may affect related records.",
                "Confirm Save",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                accountDataGridView.EndEdit();

                // Apply changes to the database
                TableUpdaterHelper.UpdateTableFromGrid(accountDataGridView, "Tb_Concessionaire", "ConcessionaireID");

                // Show success message
                MessageBox.Show("Concessionaire details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private async void accountUndoButton_Click(object sender, EventArgs e)
        {
            using (var loadingForm = new LoadingForm())
            {
                var task1 = DGVHelper.LoadDataToGridAsync(accountDataGridView, "Tb_Concessionaire", loadingForm);

                await Task.WhenAll(task1);
            }
        }

        private void searchAccountNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string keyword = searchAccountNumberTextBox.Text.Trim();

                if (string.IsNullOrEmpty(keyword)) return;

                // Prevent special character issues
                keyword = keyword.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");

                if (accountDataGridView.DataSource is DataTable dt)
                {
                    // Ensure exact column names are used from your MDB table
                    if (dt.Columns.Contains("AccountNo") && dt.Columns.Contains("ConcessionaireName"))
                    {
                        dt.DefaultView.RowFilter =
                            $"Convert(AccountNo, 'System.String') LIKE '%{keyword}%' OR Convert(ConcessionaireName, 'System.String') LIKE '%{keyword}%'";
                    }
                    else
                    {
                        MessageBox.Show("Ensure your MDB columns are named exactly 'AccountNo' and 'ConcessionaireName'.", "Column Name Error");
                    }
                }
            }
        }

        private void accountsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Make sure the column being formatted is the "Status" column
            if (accountDataGridView.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString().Trim().ToLower();

                if (status == "disconnected")
                {
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204, 204);
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (status == "active")
                {
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 255, 204);
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    // Reset for other statuses
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private async void clearButton_Click(object sender, EventArgs e)
        {
            searchAccountNumberTextBox.Clear();
            using (var loadingForm = new LoadingForm())
            {
                var task1 = DGVHelper.LoadDataToGridAsync(accountDataGridView, "Tb_Concessionaire", loadingForm);

                await Task.WhenAll(task1);
            }
        }

        private void zoneComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected zone code from ComboBox
            string zoneCode = zoneComboBox.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(zoneCode))
                return;

            if (accountDataGridView.DataSource is DataTable dt)
            {
                // Filter rows where accountno starts with the selected zoneCode (e.g., "04-")
                dt.DefaultView.RowFilter = $"accountno LIKE '{zoneCode}-%'";

                // Sort rows in ascending order by accountno
                dt.DefaultView.Sort = "accountno ASC";
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var loadingForm = new LoadingForm())
            {
                var task1 = DGVHelper.LoadDataToGridAsync(accountDataGridView, "Tb_Concessionaire", loadingForm);

                await Task.WhenAll(task1);
            }
        }
        private async void AddDeleteContextMenu(DataGridView dgv, string tableName, string idColumn)
        {
            var menu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("Delete Row");
            deleteItem.ForeColor = Color.Red;
            deleteItem.Image = SystemIcons.Error.ToBitmap();
            deleteItem.Click += async (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    var row = dgv.SelectedRows[0];

                    // Handle uncommitted new row deletion gracefully
                    if (row.IsNewRow)
                    {
                        MessageBox.Show("Cannot delete an uncommitted new row. Please enter data or cancel the row first.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var idValue = row.Cells[idColumn].Value;
                    if (idValue == null || idValue == DBNull.Value)
                    {
                        try
                        {
                            dgv.Rows.Remove(row); // Remove unsaved row
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("Cannot delete an uncommitted new row. Please enter data or cancel the row first.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        return;
                    }
                    if (MessageBox.Show("Are you sure you want to delete this row from the database?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (TableUpdaterHelper.DeleteRow(tableName, idColumn, idValue))
                        {
                            MessageBox.Show("Row deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            using (var loadingForm = new LoadingForm())
                            {
                                var task1 = DGVHelper.LoadDataToGridAsync(accountDataGridView, "Tb_Concessionaire", loadingForm);

                                await Task.WhenAll(task1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Delete failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };
            menu.Items.Add(deleteItem);
            dgv.ContextMenuStrip = menu;

            // Ensure right-click selects the row
            dgv.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hit = dgv.HitTest(e.X, e.Y);
                    if (hit.RowIndex >= 0)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[hit.RowIndex].Selected = true;
                    }
                }
            };
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Check if CreateConcessionaireForm is already open
            foreach (Form form in Application.OpenForms)
            {
                if (form is CreateConcessionaireForm)
                {
                    form.BringToFront();   // bring it to front
                    form.Focus();          // set focus
                    return;                // stop, don’t open another
                }
            }

            // If not open, create and show new instance
            var addConcessionaireForm = new CreateConcessionaireForm();
            addConcessionaireForm.Show();
        }

    }
}
