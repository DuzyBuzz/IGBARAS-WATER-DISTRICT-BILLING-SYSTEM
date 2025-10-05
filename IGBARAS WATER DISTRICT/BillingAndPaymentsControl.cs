using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class BillingAndPaymentsControl : UserControl
    {
        private DataTable billingTable;
        private DataTable paymentsTable;

        private DateTime billingFromDate;
        private DateTime billingToDate;

        private DateTime paymentsFromDate;
        private DateTime paymentsToDate;

        private Dictionary<Tuple<int, int>, object> billingOldValues = new Dictionary<Tuple<int, int>, object>();
        private Dictionary<Tuple<int, int>, object> paymentsOldValues = new Dictionary<Tuple<int, int>, object>();

        public BillingAndPaymentsControl()
        {
            InitializeComponent();

            // DataGridView cell edit events
            billingDataGridView.CellBeginEdit += BillingDataGridView_CellBeginEdit;
            billingDataGridView.CellEndEdit += BillingDataGridView_CellEndEdit;

            paymentsDataGridView.CellBeginEdit += PaymentsDataGridView_CellBeginEdit;
            paymentsDataGridView.CellEndEdit += PaymentsDataGridView_CellEndEdit;

            // DatePicker ValueChanged events
            dateFromBilling.ValueChanged += DateFromBilling_ValueChanged;
            dateToBilling.ValueChanged += DateToBilling_ValueChanged;
            dateFromPayments.ValueChanged += DateFromPayments_ValueChanged;
            dateToPayments.ValueChanged += DateToPayments_ValueChanged;
        }

        private void BillingAndPaymentsControl_Load(object sender, EventArgs e)
        {
            // Initialize date ranges
            billingFromDate = DateTime.Today.AddMonths(-1);
            billingToDate = DateTime.Today;
            paymentsFromDate = DateTime.Today.AddMonths(-1);
            paymentsToDate = DateTime.Today;

            // Set DatePickers
            dateFromBilling.Value = billingFromDate;
            dateToBilling.Value = billingToDate;
            dateFromPayments.Value = paymentsFromDate;
            dateToPayments.Value = paymentsToDate;

            // Add placeholders
            PlaceholderHelper.AddPlaceholder(searchAccountNumberTextBox, "🔎Account Number or Bill No.");
            PlaceholderHelper.AddPlaceholder(paymentSearchTextBox, "🔎Account Number or Bill No. or OR Number");

            // Load initial data filtered by date
            LoadBillingData();
            LoadPaymentsData();

            // Add delete context menus
            AddDeleteContextMenu(billingDataGridView, "Tb_Billing", "BillingID");
            AddDeleteContextMenu(paymentsDataGridView, "Tb_Payments", "PaymentID");

            // AutoComplete
            AutoCompleteHelper.FillTextBoxWithColumns("Tb_Billing", new string[] { "AccountNo", "BillNo" }, searchAccountNumberTextBox);
            AutoCompleteHelper.FillTextBoxWithColumns("Tb_Payments", new string[] { "AccountNo", "CurrentBillNo", "ORNumber" }, paymentSearchTextBox);
        }

        #region --- Billing ---

        private void LoadBillingData()
        {
            string[] columns = { "BillingID", "BillNo", "DateCreated", "AccountNo", "DateFrom", "DateTo",
                                 "PrevReading", "PresentReading", "DueDate", "Is_PartiallyPaid", "Is_FullyPaid",
                                 "Is_Arrears", "DiscountAmount", "TaxAmount", "FreeWater", "ArrearsAmount",
                                 "AmountBilled", "ArrearsPenaltyAmount", "TotalAmountBilled", "ServiceConnectionFee",
                                 "TotalSCF", "SCFArrears", "Is_SCFPartiallyPaid", "Is_SCFPaid" };

            billingTable = SearchHelper.SearchToTable(
                "Tb_Billing",
                null,
                null,
                billingFromDate,
                billingToDate,
                columns,
                "DateCreated"
            );

            billingTable.DefaultView.Sort = "DateCreated DESC";
            billingDataGridView.DataSource = null;
            billingDataGridView.DataSource = billingTable.DefaultView;

            if (billingDataGridView.Columns.Contains("BillingID"))
                billingDataGridView.Columns["BillingID"].Visible = false;
        }

        private void LoadBillingDataByKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadBillingData(); // fallback to date filter
                return;
            }

            string[] columns = { "BillingID", "BillNo", "DateCreated", "AccountNo", "DateFrom", "DateTo",
                         "PrevReading", "PresentReading", "DueDate", "Is_PartiallyPaid", "Is_FullyPaid",
                         "Is_Arrears", "DiscountAmount", "TaxAmount", "FreeWater", "ArrearsAmount",
                         "AmountBilled", "ArrearsPenaltyAmount", "TotalAmountBilled", "ServiceConnectionFee",
                         "TotalSCF", "SCFArrears", "Is_SCFPartiallyPaid", "Is_SCFPaid" };

            // Search the whole table ignoring date
            var table = SearchHelper.SearchToTable(
                "Tb_Billing",
                new string[] { "AccountNo", "BillNo" }, // columns to search
                null,
                null, // ignore fromDate
                null, // ignore toDate
                columns,
                "DateCreated"
            );

            // Filter the result by the keyword locally
            var filtered = table.AsEnumerable()
                .Where(r =>
                    r["AccountNo"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r["BillNo"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                );

            billingTable = filtered.Any() ? filtered.CopyToDataTable() : table.Clone();
            billingTable.DefaultView.Sort = "DateCreated DESC";
            billingDataGridView.DataSource = null;
            billingDataGridView.DataSource = billingTable.DefaultView;

            if (billingDataGridView.Columns.Contains("BillingID"))
                billingDataGridView.Columns["BillingID"].Visible = false;
        }


        private void searchAccountNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadBillingDataByKeyword(searchAccountNumberTextBox.Text.Trim());
            }
        }

        #endregion

        #region --- Payments ---

        private void LoadPaymentsData()
        {
            string[] columns = { "PaymentID","ORNumber","CurrentBillNo","PaymentDate","AccountNo","PaymentType",
                                 "ArrearsAmount","ArrearsPenalty","TotalArrears","BillCharge","TaxAmount",
                                 "DiscountAmount","TotalCurrent","AmountPaid","Penalty","[Net Bill Charge]",
                                 "TotalAmountPaid","Balance","Remarks","FreeWater","[OthersAmount]",
                                 "SCFBalance","TotalPenalty","ServiceConnectionFee" };

            paymentsTable = SearchHelper.SearchToTable(
                "Tb_Payments",
                null,
                null,
                paymentsFromDate,
                paymentsToDate,
                columns,
                "PaymentDate"
            );

            paymentsTable.DefaultView.Sort = "PaymentDate DESC";
            paymentsDataGridView.DataSource = null;
            paymentsDataGridView.DataSource = paymentsTable.DefaultView;

            if (paymentsDataGridView.Columns.Contains("PaymentID"))
                paymentsDataGridView.Columns["PaymentID"].Visible = false;
        }

        private void LoadPaymentsDataByKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadPaymentsData(); // fallback to date filter
                return;
            }

            string[] columns = { "PaymentID","ORNumber","CurrentBillNo","PaymentDate","AccountNo","PaymentType",
                         "ArrearsAmount","ArrearsPenalty","TotalArrears","BillCharge","TaxAmount",
                         "DiscountAmount","TotalCurrent","AmountPaid","Penalty","[Net Bill Charge]",
                         "TotalAmountPaid","Balance","Remarks","FreeWater","[OthersAmount]",
                         "SCFBalance","TotalPenalty","ServiceConnectionFee" };

            // Search the whole table ignoring date
            var table = SearchHelper.SearchToTable(
                "Tb_Payments",
                new string[] { "AccountNo", "CurrentBillNo", "ORNumber" },
                null,
                null, // ignore fromDate
                null, // ignore toDate
                columns,
                "PaymentDate"
            );

            // Filter locally by keyword
            var filtered = table.AsEnumerable()
                .Where(r =>
                    r["AccountNo"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r["CurrentBillNo"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r["ORNumber"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                );

            paymentsTable = filtered.Any() ? filtered.CopyToDataTable() : table.Clone();
            paymentsTable.DefaultView.Sort = "PaymentDate DESC";
            paymentsDataGridView.DataSource = null;
            paymentsDataGridView.DataSource = paymentsTable.DefaultView;

            if (paymentsDataGridView.Columns.Contains("PaymentID"))
                paymentsDataGridView.Columns["PaymentID"].Visible = false;
        }


        private void paymentSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadPaymentsDataByKeyword(paymentSearchTextBox.Text.Trim());
            }
        }

        #endregion

        #region --- DatePicker Handlers ---

        private void DateFromBilling_ValueChanged(object sender, EventArgs e)
        {
            billingFromDate = dateFromBilling.Value;
            LoadBillingData();
        }

        private void DateToBilling_ValueChanged(object sender, EventArgs e)
        {
            billingToDate = dateToBilling.Value;
            LoadBillingData();
        }

        private void DateFromPayments_ValueChanged(object sender, EventArgs e)
        {
            paymentsFromDate = dateFromPayments.Value;
            LoadPaymentsData();
        }

        private void DateToPayments_ValueChanged(object sender, EventArgs e)
        {
            paymentsToDate = dateToPayments.Value;
            LoadPaymentsData();
        }

        #endregion

        #region --- Cell Edit Handlers ---

        private void BillingDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            billingOldValues[Tuple.Create(e.RowIndex, e.ColumnIndex)] = billingDataGridView[e.ColumnIndex, e.RowIndex].Value;
        }

        private void BillingDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            HandleCellEdit(billingDataGridView, "Tb_Billing", "BillingID", e.RowIndex, e.ColumnIndex, billingOldValues);
        }

        private void PaymentsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            paymentsOldValues[Tuple.Create(e.RowIndex, e.ColumnIndex)] = paymentsDataGridView[e.ColumnIndex, e.RowIndex].Value;
        }

        private void PaymentsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            HandleCellEdit(paymentsDataGridView, "Tb_Payments", "PaymentID", e.RowIndex, e.ColumnIndex, paymentsOldValues);
        }

        private void HandleCellEdit(DataGridView dgv, string tableName, string idColumn, int rowIndex, int colIndex, Dictionary<Tuple<int, int>, object> oldValues)
        {
            var key = Tuple.Create(rowIndex, colIndex);
            object oldValue = oldValues.ContainsKey(key) ? oldValues[key] : null;
            object newValue = dgv[colIndex, rowIndex].Value;

            if (Equals(oldValue, newValue)) return;

            try
            {
                DialogResult result = MessageBox.Show(
                    $"Do you want to save the changes to '{dgv.Columns[colIndex].HeaderText}'?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    dgv[colIndex, rowIndex].Value = oldValue;
                    return;
                }

                if (dgv.Columns[colIndex].ValueType == typeof(double) ||
                    dgv.Columns[colIndex].ValueType == typeof(decimal) ||
                    dgv.Columns[colIndex].ValueType == typeof(int) ||
                    dgv.Columns[colIndex].ValueType == typeof(float))
                {
                    if (newValue == null || !double.TryParse(newValue.ToString(), out _))
                    {
                        MessageBox.Show($"Invalid number in '{dgv.Columns[colIndex].HeaderText}'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgv[colIndex, rowIndex].Value = oldValue;
                        return;
                    }
                }

                if (dgv.Columns[colIndex].ValueType == typeof(DateTime))
                {
                    if (newValue == null || !DateTime.TryParse(newValue.ToString(), out _))
                    {
                        MessageBox.Show($"Invalid date in '{dgv.Columns[colIndex].HeaderText}'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgv[colIndex, rowIndex].Value = oldValue;
                        return;
                    }
                }

                object idValue = dgv[idColumn, rowIndex].Value;
                var columnValues = new Dictionary<string, object>
                {
                    { dgv.Columns[colIndex].Name, dgv[colIndex, rowIndex].Value ?? DBNull.Value }
                };

                using (var conn = new OleDbConnection(DbConfig.ConnectionString))
                {
                    conn.Open();
                    ColumnUpdaterHelper.UpdateColumns(tableName, idColumn, idValue, columnValues, conn);
                }

                oldValues[key] = dgv[colIndex, rowIndex].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving changes:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv[colIndex, rowIndex].Value = oldValue;
            }
        }

        #endregion

        #region --- Common Helpers ---

        private void AddDeleteContextMenu(DataGridView dgv, string tableName, string idColumn)
        {
            var menu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("Delete Row") { ForeColor = Color.Red };
            deleteItem.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    var row = dgv.SelectedRows[0];
                    if (row.IsNewRow) return;

                    var id = row.Cells[idColumn].Value;
                    if (TableUpdaterHelper.DeleteRow(tableName, idColumn, id))
                    {
                        LoadBillingData();
                        LoadPaymentsData();
                    }
                }
            };
            menu.Items.Add(deleteItem);
            dgv.ContextMenuStrip = menu;
        }

        #endregion
    }
}
