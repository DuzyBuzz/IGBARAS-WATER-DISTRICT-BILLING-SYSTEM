using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class BillingAndPaymentsControl : UserControl
    {
        // ---------------- PAGINATION VARIABLES ----------------
        private int billingPageSize = 100;
        private int billingPageIndex = 0;
        private DataTable billingTable;

        private int paymentsPageSize = 100;
        private int paymentsPageIndex = 0;
        private DataTable paymentsTable;
        public BillingAndPaymentsControl()
        {
            InitializeComponent();
        }

        private void searchAccountNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        // ------------------- PAGINATION HELPER -------------------
        private DataTable GetPagedTable(DataTable dt, int pageIndex, int pageSize)
        {
            DataTable pagedTable = dt.Clone();
            int start = pageIndex * pageSize;
            int end = Math.Min(start + pageSize, dt.Rows.Count);

            for (int i = start; i < end; i++)
                pagedTable.ImportRow(dt.Rows[i]);

            return pagedTable;
        }

        private void UpdateBillingPageLabel()
        {
            if (billingTable != null && billingTable.Rows.Count > 0)
                billingPageLabel.Text = $"Page {billingPageIndex + 1} of {Math.Ceiling((double)billingTable.Rows.Count / billingPageSize)}";
            else
                billingPageLabel.Text = "Page 0 of 0";
        }

        
        //private void UpdatePaymentsPageLabel()
        //{
        //    if (paymentsTable != null && paymentsTable.Rows.Count > 0)
        //        paymentsPageLabel.Text = $"Page {paymentsPageIndex + 1} of {Math.Ceiling((double)paymentsTable.Rows.Count / paymentsPageSize)}";
        //    else
        //        paymentsPageLabel.Text = "Page 0 of 0";
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            LoadSelectedColumns();
        }

        private void serviceApplyButton_Click(object sender, EventArgs e)
        {

        }
        private void searchAccountNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string keyword = searchAccountNumberTextBox.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadSelectedColumns(); // if empty, reload full table
                    return;
                }
                SearchBilling(keyword);
            }
        }

        private void BillingAndPaymentsControl_Load(object sender, EventArgs e)
        {
            LoadPaymentsSelectedColumns();
            PlaceholderHelper.AddPlaceholder(searchAccountNumberTextBox, "🔎Account Number or Bill No.");
            PlaceholderHelper.AddPlaceholder(paymentSearchTextBox, "🔎Account Number or Bill No. or OR Number");
            LoadSelectedColumns();
            AutoCompleteHelper.FillTextBoxWithColumns("Tb_Payments", new string[] { "AccountNo", "CurrentBillNo", "ORNumber" }, paymentSearchTextBox);
            AutoCompleteHelper.FillTextBoxWithColumns("Tb_Billing", new string[] { "AccountNo", "BillNo" }, searchAccountNumberTextBox);

            AddDeleteContextMenu(paymentsDataGridView, "Tb_Payments", "PaymentID");
            AddDeleteContextMenu(billingDataGridView, "Tb_Billing", "BillingID");
        }
        private void LoadSelectedColumns()
        {
            billingTable = CustomTableLoaderHelper.LoadSelectedColumnsToDataTable(
                "Tb_Billing",
                new string[] {"BillingID", "BillNo", "DateCreated", "AccountNo", "DateFrom", "DateTo", "PrevReading",
            "PresentReading", "DueDate", "Is_PartiallyPaid", "Is_FullyPaid", "Is_Arrears", "DiscountAmount",
            "TaxAmount", "FreeWater", "ArrearsAmount", "AmountBilled", "ArrearsPenaltyAmount", "TotalAmountBilled",
            "ServiceConnectionFee", "TotalSCF", "SCFArrears", "Is_SCFPartiallyPaid", "Is_SCFPaid"}
            );

            billingPageIndex = 0;
            ShowBillingPage();
        }

        private void ShowBillingPage()
        {
            if (billingTable == null || billingTable.Rows.Count == 0)
            {
                billingDataGridView.DataSource = null;
                billingPageLabel.Text = "Page 0 of 0";
                return;
            }

            int start = billingPageIndex * billingPageSize;
            int end = Math.Min(start + billingPageSize, billingTable.Rows.Count);

            DataTable pagedTable = billingTable.Clone();
            for (int i = start; i < end; i++)
                pagedTable.ImportRow(billingTable.Rows[i]);

            billingDataGridView.DataSource = pagedTable;

            int totalPages = (int)Math.Ceiling((double)billingTable.Rows.Count / billingPageSize);
            billingPageLabel.Text = $"Page {billingPageIndex + 1} of {totalPages}";
        }


        private void LoadPaymentsSelectedColumns()
        {
            paymentsTable = CustomTableLoaderHelper.LoadSelectedColumnsToDataTable(
                "Tb_Payments",
                new string[] {"PaymentID", "ORNumber", "CurrentBillNo", "PaymentDate", "AccountNo", "PaymentType", "ArrearsAmount",
            "ArrearsPenalty", "TotalArrears", "BillCharge", "TaxAmount", "DiscountAmount", "TotalCurrent",
            "AmountPaid", "Penalty", "[Net Bill Charge]", "TotalAmountPaid", "Balance", "Remarks", "FreeWater",
            "[OthersAmount]", "SCFBalance", "TotalPenalty", "ServiceConnectionFee"}
            );

            paymentsPageIndex = 0;
            ShowPaymentsPage();
        }
        private void ShowPaymentsPage()
        {
            if (paymentsTable == null || paymentsTable.Rows.Count == 0)
            {
                paymentsDataGridView.DataSource = null;
                paymentsPageLabel.Text = "Page 0 of 0";
                return;
            }

            int start = paymentsPageIndex * paymentsPageSize;
            int end = Math.Min(start + paymentsPageSize, paymentsTable.Rows.Count);

            DataTable pagedTable = paymentsTable.Clone();
            for (int i = start; i < end; i++)
                pagedTable.ImportRow(paymentsTable.Rows[i]);

            paymentsDataGridView.DataSource = pagedTable;

            int totalPages = (int)Math.Ceiling((double)paymentsTable.Rows.Count / paymentsPageSize);
            paymentsPageLabel.Text = $"Page {paymentsPageIndex + 1} of {totalPages}";
        }

        private void billingApplyButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to apply the changes to the Billing details?\n\n" +
                "This action will save the modifications to the database and may affect related records.",
                "Confirm Save",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            billingDataGridView.EndEdit();

            var dt = billingDataGridView.DataSource as DataTable;
            if (dt == null)
            {
                MessageBox.Show("No data source found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool anyError = false;

            using (var connection = new OleDbConnection(DbConfig.ConnectionString))
            {
                connection.Open();

                foreach (DataGridViewRow row in billingDataGridView.Rows)
                {
                    if (row.IsNewRow) continue;

                    var billingId = row.Cells["BillingID"].Value;
                    var billNo = row.Cells["BillNo"].Value;
                    var isFullyPaid = row.Cells["Is_FullyPaid"].Value;
                    var isSCFPaid = row.Cells["Is_SCFPaid"].Value;

                    DataRowView drv = row.DataBoundItem as DataRowView;
                    if (drv == null) continue;

                    var originalBillNo = drv.Row["BillNo", DataRowVersion.Original];
                    var originalIsFullyPaid = drv.Row["Is_FullyPaid", DataRowVersion.Original];
                    var originalIsSCFPaid = drv.Row["Is_SCFPaid", DataRowVersion.Original];

                    // ✅ FIX: check if any tracked columns have changed
                    bool hasChanges =
                        !object.Equals(billNo, originalBillNo) ||
                        !object.Equals(isFullyPaid, originalIsFullyPaid) ||
                        !object.Equals(isSCFPaid, originalIsSCFPaid);

                    if (hasChanges)
                    {
                        var columnValues = new Dictionary<string, object>
                {
                    { "BillNo", billNo },
                    { "Is_FullyPaid", isFullyPaid },
                    { "Is_SCFPaid", isSCFPaid }
                };

                        try
                        {
                            ColumnUpdaterHelper.UpdateColumns("Tb_Billing", "BillingID", billingId, columnValues, connection);
                        }
                        catch
                        {
                            anyError = true;
                            // Error message is already shown in ColumnUpdaterHelper
                        }
                    }
                }
            }

            if (anyError)
            {
                MessageBox.Show(
                    "Some records could not be updated due to duplicate BillNo or other database errors.\n" +
                    "Please review the error messages and correct the data.",
                    "Partial Update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("BillNo(s), Is_FullyPaid, and Is_SCFPaid updated successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadSelectedColumns();
        }


        private void billingUndoButton_Click(object sender, EventArgs e)
        {
            LoadSelectedColumns();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            LoadSelectedColumns();
            searchAccountNumberTextBox.Text = "";
        }

        private void paymentsApplyButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to apply the changes to the Payments details?\n\n" +
                "This action will save the modifications to the database and may affect related records.",
                "Confirm Save",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                paymentsDataGridView.EndEdit();

                var dt = paymentsDataGridView.DataSource as DataTable;
                if (dt == null)
                {
                    MessageBox.Show("No data source found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool anyError = false;

                using (var connection = new OleDbConnection(DbConfig.ConnectionString))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in paymentsDataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var paymentId = row.Cells["PaymentID"].Value;
                        var currentBillNo = row.Cells["CurrentBillNo"].Value;
                        var balance = row.Cells["Balance"].Value;
                        var amountPaid = row.Cells["AmountPaid"].Value;
                        var discountAmount = row.Cells["DiscountAmount"].Value;

                        DataRowView drv = row.DataBoundItem as DataRowView;
                        if (drv == null) continue;
                        var originalCurrentBillNo = drv.Row["CurrentBillNo", DataRowVersion.Original];
                        var originalBalance = drv.Row["Balance", DataRowVersion.Original];
                        var originalAmountPaid = drv.Row["AmountPaid", DataRowVersion.Original];
                        var originalDiscountAmount = drv.Row["DiscountAmount", DataRowVersion.Original];

                        // Check if any relevant column has changed
                        if (!object.Equals(currentBillNo, originalCurrentBillNo) ||
                            !object.Equals(balance, originalBalance) ||
                            !object.Equals(amountPaid, originalAmountPaid)||
                            !object.Equals(discountAmount, originalDiscountAmount))
                        {
                            var columnValues = new Dictionary<string, object>
                    {
                        { "CurrentBillNo", currentBillNo },
                        { "Balance", balance },
                        { "AmountPaid", amountPaid },
                        { "DiscountAmount", discountAmount }
                    };

                            try
                            {
                                ColumnUpdaterHelper.UpdateColumns("Tb_Payments", "PaymentID", paymentId, columnValues, connection);
                            }
                            catch
                            {
                                anyError = true;
                                // Error message is already shown in ColumnUpdaterHelper
                            }
                        }
                    }
                }

                if (anyError)
                {
                    MessageBox.Show(
                        "Some records could not be updated due to duplicate CurrentBillNo or other database errors.\n" +
                        "Please review the error messages and correct the data.",
                        "Partial Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("CurrentBillNo(s), Balance(s), and AmountPaid(s) updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadPaymentsSelectedColumns();
            }
        }

        private void paymentsUndoButton_Click(object sender, EventArgs e)
        {

            LoadPaymentsSelectedColumns();
        }

        private void paymentsRefreshButton_Click(object sender, EventArgs e)
        {

            LoadPaymentsSelectedColumns();
        }



        private void paymentSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string keyword = paymentSearchTextBox.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadPaymentsSelectedColumns(); // if empty, reload full table
                    return;
                }
                SearchPayments(keyword);
            }
        }

        private void paymentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AddDeleteContextMenu(DataGridView dgv, string tableName, string idColumn)
        {
            var menu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("Delete Row");
            deleteItem.ForeColor = Color.Red;
            deleteItem.Image = SystemIcons.Error.ToBitmap();
            deleteItem.Click += (s, e) =>
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
                            LoadSelectedColumns();
                            LoadPaymentsSelectedColumns();
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

        private void billingNextButton_Click(object sender, EventArgs e)
        {
            if ((billingPageIndex + 1) * billingPageSize < billingTable.Rows.Count)
            {
                billingPageIndex++;
                ShowBillingPage();
            }
        }

        private void paymentsNextButton_Click(object sender, EventArgs e)
        {
            if ((paymentsPageIndex + 1) * paymentsPageSize < paymentsTable.Rows.Count)
            {
                paymentsPageIndex++;
                ShowPaymentsPage();
            }
        }

        private void paymentsPrevButton_Click(object sender, EventArgs e)
        {
            if (paymentsPageIndex > 0)
            {
                paymentsPageIndex--;
                ShowPaymentsPage();
            }
        }
        private void SearchBilling(string keyword)
        {
            if (billingTable == null) return;

            // Reset filter
            DataTable filtered = billingTable.Clone();

            foreach (DataRow row in billingTable.Rows)
            {
                if (row["AccountNo"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    row["BillNo"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filtered.ImportRow(row);
                }
            }

            billingPageIndex = 0;
            billingTable = filtered; // now table contains only filtered rows
            ShowBillingPage();
        }

        private void SearchPayments(string keyword)
        {
            if (paymentsTable == null) return;

            // Reset filter
            DataTable filtered = paymentsTable.Clone();

            foreach (DataRow row in paymentsTable.Rows)
            {
                if (row["AccountNo"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    row["CurrentBillNo"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    row["ORNumber"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filtered.ImportRow(row);
                }
            }

            paymentsPageIndex = 0;
            paymentsTable = filtered; // now table contains only filtered rows
            ShowPaymentsPage();
        }

        private void paymentsClearButton_Click(object sender, EventArgs e)
        {
            LoadPaymentsSelectedColumns();
            paymentSearchTextBox.Text = "";
        }

        private void paymentsRefreshButton_Click_1(object sender, EventArgs e)
        {
            LoadPaymentsSelectedColumns();

        }
    }

}
