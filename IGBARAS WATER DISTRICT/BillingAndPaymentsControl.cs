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
        public BillingAndPaymentsControl()
        {
            InitializeComponent();
        }

        private void searchAccountNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void zoneComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected zone code from ComboBox
            string zoneCode = zoneComboBox.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(zoneCode))
                return;

            if (billingDataGridView.DataSource is DataTable dt)
            {
                // Filter rows where accountno starts with the selected zoneCode (e.g., "04-")
                dt.DefaultView.RowFilter = $"accountno LIKE '{zoneCode}-%'";

                // Sort rows in ascending order by accountno
                dt.DefaultView.Sort = "accountno ASC";
            }
        }

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

                if (string.IsNullOrEmpty(keyword)) return;

                // Prevent special character issues
                keyword = keyword.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");

                if (billingDataGridView.DataSource is DataTable dt)
                {
                    // Ensure the column names are correct
                    if (dt.Columns.Contains("AccountNo") && dt.Columns.Contains("BillNo"))
                    {
                        dt.DefaultView.RowFilter =
                            $"Convert(AccountNo, 'System.String') LIKE '%{keyword}%' OR Convert(BillNo, 'System.String') LIKE '%{keyword}%'";
                    }
                    else
                    {
                        MessageBox.Show("Ensure your MDB columns are named exactly 'AccountNo' and 'BillNo'.", "Column Name Error");
                    }
                }
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
        private void LoadPaymentZoneComboBox()
        {
            int districtNo = 1; // Replace with actual district if needed

            var zoneList = ZoneHelper.GetZoneCodeHelper(districtNo);

            paymentsZoneComboBox.DataSource = zoneList;
            paymentsZoneComboBox.DisplayMember = "ZoneCode"; // Shown: "01", "02", "11"
            paymentsZoneComboBox.ValueMember = "ZoneCode";   // Internal value: same as displayed

            if (paymentsZoneComboBox.Items.Count > 0)
                paymentsZoneComboBox.SelectedIndex = 0;
        }
        private void BillingAndPaymentsControl_Load(object sender, EventArgs e)
        {
            LoadPaymentsSelectedColumns();
            PlaceholderHelper.AddPlaceholder(searchAccountNumberTextBox, "🔎Account Number or Bill No.");
            PlaceholderHelper.AddPlaceholder(paymentSearchTextBox, "🔎Account Number or Bill No. or OR Number");
            LoadSelectedColumns();
            AutoCompleteHelper.FillTextBoxWithColumns("Tb_Payments", new string[] { "AccountNo", "CurrentBillNo", "ORNumber" }, paymentSearchTextBox);
            AutoCompleteHelper.FillTextBoxWithColumns("Tb_Billing", new string[] { "AccountNo", "BillNo" }, searchAccountNumberTextBox);
            LoadZoneComboBox();
            LoadPaymentZoneComboBox();
        }
        private void LoadSelectedColumns()
        {
            LoadZoneComboBox();
            CustomTableLoaderHelper.LoadSelectedColumnsToGrid(
                billingDataGridView,
                "Tb_Billing",
                new string[] {"BillingID", "BillNo", "DateCreated", "AccountNo", "DateFrom", "DateTo", "PrevReading",
                    "PresentReading", "DueDate",  "Is_PartiallyPaid", "Is_FullyPaid", "Is_Arrears", "DiscountAmount", "TaxAmount", "FreeWater",
                    "ArrearsAmount", "AmountBilled", "ArrearsPenaltyAmount", "TotalAmountBilled"}
            );
        }
        private void LoadPaymentsSelectedColumns()
        {
            LoadZoneComboBox();
            CustomTableLoaderHelper.LoadSelectedColumnsToGrid(
                paymentsDataGridView,
                "Tb_Payments",
                new string[] {"PaymentID", "ORNumber", "CurrentBillNo", "PaymentDate", "AccountNo", "PaymentType", "ArrearsAmount", "ArrearsPenalty",
                    "TotalArrears", "BillCharge",  "TaxAmount", "DiscountAmount", "TotalCurrent", "AmountPaid", "Penalty", "[Net Bill Charge]", 
                    "Balance", "ServiceConnectionFee", "Remarks", "FreeWater"}
            );
        }

        private void billingApplyButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to apply the changes to the Billing details?\n\n" +
                "This action will save the modifications to the database and may affect related records.",
                "Confirm Save",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
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

                        DataRowView drv = row.DataBoundItem as DataRowView;
                        if (drv == null) continue;
                        var originalBillNo = drv.Row["BillNo", DataRowVersion.Original];
                        var originalIsFullyPaid = drv.Row["Is_FullyPaid", DataRowVersion.Original];

                        if (!object.Equals(billNo, originalBillNo) || !object.Equals(isFullyPaid, originalIsFullyPaid))
                        {
                            var columnValues = new Dictionary<string, object>
                    {
                        { "BillNo", billNo },
                        { "Is_FullyPaid", isFullyPaid }
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
                    MessageBox.Show("BillNo(s) and Is_FullyPaid updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadSelectedColumns();
            }
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

                        DataRowView drv = row.DataBoundItem as DataRowView;
                        if (drv == null) continue;
                        var originalCurrentBillNo = drv.Row["CurrentBillNo", DataRowVersion.Original];
                        var originalBalance = drv.Row["Balance", DataRowVersion.Original];

                        // Only check if CurrentBillNo has changed
                        if (!object.Equals(currentBillNo, originalCurrentBillNo))
                        {
                            var columnValues = new Dictionary<string, object>
                            {
                                { "CurrentBillNo", currentBillNo }
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
                    MessageBox.Show("CurrentBillNo(s) updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void paymentsZoneComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected zone code from ComboBox
            string zoneCode = paymentsZoneComboBox.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(zoneCode))
                return;

            if (paymentsDataGridView.DataSource is DataTable dt)
            {
                // Filter rows where accountno starts with the selected zoneCode (e.g., "04-")
                dt.DefaultView.RowFilter = $"accountno LIKE '{zoneCode}-%'";

                // Sort rows in ascending order by accountno
                dt.DefaultView.Sort = "accountno ASC";
            }
        }

        private void paymentsClearButton_Click(object sender, EventArgs e)
        {
            LoadPaymentsSelectedColumns();
        }

        private void paymentSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string keyword = paymentSearchTextBox.Text.Trim();

                if (string.IsNullOrEmpty(keyword)) return;

                // Prevent special character issues
                keyword = keyword.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");

                if (paymentsDataGridView.DataSource is DataTable dt)
                {
                    // Ensure the column names are correct
                    if (dt.Columns.Contains("AccountNo") && dt.Columns.Contains("CurrentBillNo") && dt.Columns.Contains("ORNumber"))
                    {
                        dt.DefaultView.RowFilter =
                            $"Convert(AccountNo, 'System.String') LIKE '%{keyword}%' " +
                            $"OR Convert(CurrentBillNo, 'System.String') LIKE '%{keyword}%' " +
                            $"OR Convert(ORNumber, 'System.String') LIKE '%{keyword}%'";
                    }
                    else
                    {
                        MessageBox.Show("Ensure your MDB columns are named exactly 'AccountNo', 'CurrentBillNo', and 'ORNumber'.", "Column Name Error");
                    }
                }
            }
        }
    }
}
