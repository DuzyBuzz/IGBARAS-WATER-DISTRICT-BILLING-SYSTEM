using CrystalDecisions.CrystalReports.Engine;
using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using TextBox = System.Windows.Forms.TextBox;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class RealeaseBillingControl : UserControl
    {
        private string[] billData;
        private string[] selectedBillingData;
        private int _previousMeterConsumed = -1; // Default to -1 for first time check
        private bool _isUpdatingMeterConsumed = false;

        public RealeaseBillingControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// this is the event handler for the print save button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printSaveButton_Click(object sender, EventArgs e)
        {
            if (accountNumberTextBox.Text == null)
            {
                MessageBox.Show("No selected Account. Please select an account first.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CheckBillingDate())
            {
                MessageBox.Show("This customer is already billed for this month.", "Duplicate Billing", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // First confirmation message
            string verifyDataMessage = "Please verify the input data carefully to ensure accuracy.\n\nDo you want to proceed with saving the billing record?";
            DialogResult verifyResult = MessageBox.Show(verifyDataMessage, "Verify Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (verifyResult == DialogResult.No)
            {
                return;
            }

            // Second confirmation message
            string preparePrinterMessage = "Please prepare the preprint paper and ensure the printer is properly set up and ready to print.\n\nAre you ready to proceed?";
            DialogResult prepareResult = MessageBox.Show(preparePrinterMessage, "Prepare Printer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (prepareResult == DialogResult.No)
            {
                return;
            }

            try
            {
                int serviceId = int.Parse(serviceIDLabel.Text.Trim());
                // Save billing data to database
                InsertToBillingTable(serviceId);

                // Third confirmation message
                string printConfirmationMessage = "The billing record has been saved successfully.\n\nDo you want to print the billing invoice now?";
                DialogResult printResult = MessageBox.Show(printConfirmationMessage, "Print Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (printResult == DialogResult.Yes)
                {
                    // Create a new PrintDocument
                    PrintDocument pd = new PrintDocument();

                    // Optional: set the paper size to custom 8.25" x 11.75"
                    pd.DefaultPageSettings.PaperSize = new PaperSize("CustomA4", 825, 1175); // 100 DPI units (1 inch = 100)


                    // Assign the PrintPage handler
                    pd.PrintPage += new PrintPageEventHandler(BillingMapPrintPage);

                    // Show a print dialog for user confirmation
                    PrintDialog dialog = new PrintDialog();
                    dialog.Document = pd;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        pd.Print(); // Start the print job
                    }
                    SetNextBillNo();
                }
                else
                {
                    MessageBox.Show("The printing process was cancelled due to an interruption. Please try again if needed.",
                                    "Printing Cancelled",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ An error occurred while saving or printing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void billPaidButton_Click(object sender, EventArgs e)
        {
            string accountNo = collectionNameLabel.Text;
            string billNo = collectionBillingInvoiceTextBox.Text;




            // ✅ Check if required fields are empty
            if (string.IsNullOrWhiteSpace(accountNo) || string.IsNullOrWhiteSpace(billNo))
            {
                MessageBox.Show(
                    "No account or billing number has been selected.\n\nPlease ensure both Account Number and Bill Number are specified before proceeding.",
                    "Missing Required Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // First confirmation message
            string verifyDataMessage = "Please verify the input data carefully to ensure accuracy.\n\nDo you want to proceed with saving the billing record?";
            DialogResult verifyResult = MessageBox.Show(verifyDataMessage, "Verify Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (verifyResult == DialogResult.No)
            {
                return;
            }

            // Second confirmation message
            string preparePrinterMessage = "Please prepare the preprint paper and ensure the printer is properly set up and ready to print.\n\nAre you ready to proceed?";
            DialogResult prepareResult = MessageBox.Show(preparePrinterMessage, "Prepare Printer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (prepareResult == DialogResult.No)
            {
                return;
            }

            try
            {
                // Save billing record to database
                //UpdateBillingRecord();
                InsertIntoPayments();

                //LoadPayments();

                // Third confirmation message
                string printConfirmationMessage = "The billing record has been saved successfully.\n\nDo you want to print the billing invoice now?";
                DialogResult printResult = MessageBox.Show(printConfirmationMessage, "Print Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (printResult == DialogResult.Yes)
                {
                    // Create a new PrintDocument
                    PrintDocument pd = new PrintDocument();

                    // Optional: set the paper size to custom 8.25" x 11.75"
                    pd.DefaultPageSettings.PaperSize = new PaperSize("CustomA4", 825, 1175); // 100 DPI units (1 inch = 100)


                    // Assign the PrintPage handler
                    pd.PrintPage += new PrintPageEventHandler(CollectionMapPrintPage);

                    // Show a print dialog for user confirmation
                    PrintDialog dialog = new PrintDialog();
                    dialog.Document = pd;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        pd.Print(); // Start the print job
                    }
                    MessageBox.Show(
                        $"Concessionaire Change: ₱{changeLabel.Text}.",
                        "Transaction Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );



                }
                else
                {
                    MessageBox.Show("The printing process was cancelled due to an interruption. Please try again if needed.",
                                    "Printing Cancelled",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ An error occurred while saving or printing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // user get bill settings helper to get the due date days ine tb_billsettings table




        /// <summary>

        /// <summary>
        /// end of the print save button click event.
        /// </summary>

        private bool CheckBillingDate()
        {
            string readingDateText = fromReadingDateLabel.Text.Trim();

            if (string.IsNullOrWhiteSpace(readingDateText))
            {
                // No reading date = not yet billed
                return false;
            }

            if (DateTime.TryParseExact(readingDateText, "MMM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fromDate))
            {
                DateTime now = DateTime.Now;

                if (fromDate.Month == now.Month && fromDate.Year == now.Year)
                {
                    return true;
                }

                return false;
            }

            // If the format is invalid, assume not billed — OR handle differently if needed
            return false;
        }






        private void DisableButton()
        {
            if (string.IsNullOrEmpty(subTotalAmountDueLabel.Text))
            {
                printSaveButton.Enabled = false;
            }
            else
            {
                printSaveButton.Enabled = true;
            }
            if (totalPaidAmountTextBox.Text == "0")
            {
                billPaidButton.Enabled = false;
            }
        }
        private void ClearButtonDisable()
        {
            if (!string.IsNullOrEmpty(searchAccountNumberTextBox.Text))
            {
                clearButton.ForeColor = Color.Crimson;
                clearButton.Enabled = true;
            }
            else
            {
                clearButton.ForeColor = Color.Gray;
                clearButton.Enabled = false;
            }
        }


        private void SetDateNow()
        {
            dueDateLabel.Text = DateTime.Now.AddDays(14).ToString("MMMM dd, yyyy");
            dateBilledLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            toReadingDateLabel.Text = DateTime.Now.ToString("MMM-dd-yyyy");
            paymentDateLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void InsertToBillingTable(int serviceId)
        {
            try
            {
                using (var connection = new OleDbConnection(DbConfig.ConnectionString))
                {
                    connection.Open();

                    // Step 1: Get service rate info
                    string serviceQuery = "SELECT * FROM Tb_Service WHERE ServiceId = @serviceId";
                    using (var serviceCmd = new OleDbCommand(serviceQuery, connection))
                    {
                        serviceCmd.Parameters.AddWithValue("@serviceId", serviceId);

                        using (var reader = serviceCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string serviceType = reader["ServiceType"].ToString();
                                decimal minRate = Convert.ToDecimal(reader["MinRate"]);
                                decimal rate11_20 = Convert.ToDecimal(reader["Rate11-20"]);
                                decimal rate21_30 = Convert.ToDecimal(reader["Rate21-30"]);
                                decimal rate31_40 = Convert.ToDecimal(reader["Rate31-40"]);
                                decimal rate41_Above = Convert.ToDecimal(reader["Rate41-Above"]);

                                string insertQuery = @"
                        INSERT INTO Tb_Billing (
                            BillNo, DateCreated, AccountNo, ServiceDescription, DateFrom, DateTo, PrevReading, PresentReading, 
                            DueDate, MinRate, [Rate11-20], [Rate21-30], [Rate31-40], [Rate41-Above], PenaltyRate, 
                            Penalty, Tax, TaxAmount, ServiceConnectionFee, Is_Arrears, DiscountName, Discount, DiscountAmount, ArrearsAmount, AmountBilled, ArrearsPenaltyAmount, TotalAmountBilled, ConcessionaireID, UserID, FreeWater, SCFArrears, TotalSCF
                        ) VALUES (
                            @BillNo, @DateCreated, @AccountNo, @ServiceDescription, @DateFrom, @DateTo, @PrevReading, @PresentReading, 
                            @DueDate, @MinRate, @Rate11_20, @Rate21_30, @Rate31_40, @Rate41_Above, 
                            @PenaltyRate, @Penalty, @Tax, @TaxAmount, @ServiceConnectionFee, @Is_Arrears, @DiscountName, @Discount, @DiscountAmount, @ArrearsAmount, @AmountBilled, @ArrearsPenaltyAmount, @TotalAmountBilled, @ConcessionaireID, @UserID, @FreeWater, @SCFArrears, @TotalSCF
                        )";

                                using (var insertCmd = new OleDbCommand(insertQuery, connection))
                                {
                                    insertCmd.Parameters.AddWithValue("@BillNo", int.Parse(invoiceTextBox.Text.Trim()));
                                    insertCmd.Parameters.AddWithValue("@DateCreated", DateTime.Now.ToString("MMMM dd, yyyy"));
                                    insertCmd.Parameters.AddWithValue("@AccountNo", accountNumberTextBox.Text.Trim());
                                    insertCmd.Parameters.AddWithValue("@ServiceDescription", serviceType);
                                    string fromDateText = fromReadingDateLabel.Text.Trim();

                                    if (string.IsNullOrWhiteSpace(fromDateText))
                                    {
                                        insertCmd.Parameters.AddWithValue("@DateFrom", DateTime.ParseExact(firstReadingDateLabel.Text.Trim(), "MMM-d-yyyy", CultureInfo.InvariantCulture));
                                    }
                                    else
                                    {
                                        insertCmd.Parameters.AddWithValue("@DateFrom",
                                            DateTime.ParseExact(fromDateText, "MMM-d-yyyy", CultureInfo.InvariantCulture));
                                    }

                                    insertCmd.Parameters.AddWithValue("@DateTo", DateTime.ParseExact(toReadingDateLabel.Text.Trim(), "MMM-d-yyyy", CultureInfo.InvariantCulture));
                                    insertCmd.Parameters.AddWithValue("@PrevReading", int.Parse(previousReadingTextBox.Text.Trim()));
                                    insertCmd.Parameters.AddWithValue("@PresentReading", int.Parse(presentReadingTextBox.Text.Trim()));

                                    insertCmd.Parameters.AddWithValue("@DueDate", DateTime.ParseExact(dueDateLabel.Text.Trim(), "MMMM dd, yyyy", CultureInfo.InvariantCulture));
                                    insertCmd.Parameters.AddWithValue("@MinRate", minRate);
                                    insertCmd.Parameters.AddWithValue("@Rate11_20", rate11_20);
                                    insertCmd.Parameters.AddWithValue("@Rate21_30", rate21_30);
                                    insertCmd.Parameters.AddWithValue("@Rate31_40", rate31_40);
                                    insertCmd.Parameters.AddWithValue("@Rate41_Above", rate41_Above);

                                    insertCmd.Parameters.AddWithValue("@PenaltyRate", int.Parse(penaltyPercentLabel.Text.Trim().Replace("%", "")));
                                    insertCmd.Parameters.AddWithValue("@ArrearsPenaltyAmount", decimal.Parse(penaltyAmountLabel.Text.Trim().Replace(",", "")));
                                    insertCmd.Parameters.AddWithValue("@Tax", int.Parse(taxExemptedPercentLabel.Text.Trim().Replace("%", "")));
                                    insertCmd.Parameters.AddWithValue("@TaxAmount", decimal.Parse(taxAmountLabel.Text.Trim().Replace(",", "")));
                                    insertCmd.Parameters.AddWithValue("@ServiceConnectionFee", decimal.Parse(currentSCFLabel.Text.Trim().Replace(",", "")));
                                    insertCmd.Parameters.AddWithValue("@Is_Arrears", int.Parse(isArrearsLabel.Text.Trim()));
                                    insertCmd.Parameters.AddWithValue("@DiscountName", discountNameLabel.Text.Trim());
                                    insertCmd.Parameters.AddWithValue("@Discount", int.Parse(discountedPercentLabel.Text.Trim().Replace("%", "")));
                                    insertCmd.Parameters.AddWithValue("@DiscountAmount", decimal.Parse(discountedAmountLabel.Text.Trim().Replace(",", "")));
                                    insertCmd.Parameters.AddWithValue("@ArrearsAmount", decimal.Parse(arrearsAmountLabel.Text.Trim().Replace(",", "")));
                                    insertCmd.Parameters.AddWithValue("@AmountBilled", decimal.Parse(subTotalAmountDueLabel.Text.Trim().Replace(",", "")));
                                    insertCmd.Parameters.AddWithValue("@ArrearsPenaltyAmount", decimal.Parse(penaltyAmountLabel.Text.Trim().Replace(",", "")));
                                    insertCmd.Parameters.AddWithValue("@TotalAmountBilled", decimal.Parse(totalAmountDueLabel.Text.Trim().Replace(",", "")));
                                    insertCmd.Parameters.AddWithValue("@ConcessionaireID", int.Parse(concessionaireIDLabel.Text.Trim()));
                                    insertCmd.Parameters.AddWithValue("@UserID", UserCredentials.UserId);


                                    // Safely parse FreeWater, default to 0 if empty or invalid
                                    int freeWater = 0;
                                    if (!int.TryParse(freeWaterTextBox.Text.Trim(), out freeWater))
                                    {
                                        freeWater = 0;
                                    }

                                    insertCmd.Parameters.AddWithValue("@FreeWater", freeWater);


                                    insertCmd.Parameters.AddWithValue("@SCFArrears", decimal.Parse(scfArrearsLabel.Text.Trim().Replace(",", "")));
                                    insertCmd.Parameters.AddWithValue("@TotalSCF", decimal.Parse(totalSCFAmountLabel.Text.Trim().Replace(",", "")));

                                    insertCmd.ExecuteNonQuery();
                                    MessageBox.Show("Billing record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    printSaveButton.Enabled = false;

                                    SetNextBillNo();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Service not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Insert failed:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBillinInfo()
        {
            fullnameTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
            accountNumberTextBox.Text = string.Empty;

            fromReadingDateLabel.Text = string.Empty;

            previousReadingTextBox.Text = string.Empty;
            presentReadingTextBox.Text = string.Empty;
            collectionTotalMeteredAmountLabel.Text = string.Empty;


        }

        private void SetNextBillNo()
        {
            string query = "SELECT MAX(Val(BillNo)) FROM Tb_Billing";
            using (OleDbConnection conn = new OleDbConnection(DbConfig.ConnectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                int latestBillNo = 0;

                if (result != DBNull.Value && int.TryParse(result.ToString(), out int parsedNo))
                {
                    latestBillNo = parsedNo;
                }

                invoiceTextBox.Text = (latestBillNo + 1).ToString();
            }
        }

        private void SetNextORNo()
        {
            string query = "SELECT MAX(Val(ORNumber)) FROM Tb_Payments";
            using (OleDbConnection conn = new OleDbConnection(DbConfig.ConnectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                int latestORNo = 0;

                if (result != DBNull.Value && int.TryParse(result.ToString(), out int parsedNo))
                {
                    latestORNo = parsedNo;
                }

                orNumberTextBox.Text = (latestORNo + 1).ToString();
            }
        }

        private async void BillingControl_Load(object sender, EventArgs e)
        {

            collectingOfficerNameLabel.Text = UserCredentials.Fullname;
            billPaidButton.Enabled = false;
            SetDateNow();
            SetNextBillNo();
            SetNextORNo();
            ClearWaterChargeLabels();
            ClearWaterChargeLabels2();

            PlaceholderHelper.AddPlaceholder(searchAccountNumberTextBox, "🔎 Fullname or Account Number.");
            PlaceholderHelper.AddPlaceholder(remarksTextBox, "📝 Remarks");

            ClearButtonDisable();
            // 🟡 Load data from DB to billingDataGridView
            using (var loadingForm = new LoadingForm())
            {
                var task1 = DGVHelper.LoadDataToGridAsync(accountDataGridView, "Tb_Concessionaire", loadingForm);

                await Task.WhenAll(task1);
            }
            // 🟢 Optional: Setup autocomplete after data loaded
            AutoCompleteHelper.FillTextBoxWithColumns("Tb_Concessionaire", new string[] { "AccountNo", "ConcessionaireName" }, searchAccountNumberTextBox);
            AutoCompleteHelper.FillTextBoxWithColumns("Tb_Payments", new string[] { "BankName" }, bankNameTextBox);
            cashCheckBox.Checked = true; // Default to cash payment
            //LoadPayments();

            FormatDataGridView(accountDataGridView);
            FormatDataGridView(billDataGridView);
            FormatDataGridView(paymentsOnThisDayDataGridView);
            LoadZoneComboBox();
            LoadPaymentsToday();
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




        private void accountDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearWaterChargeLabels();
            ClearWaterChargeLabels2();
            arrearsAmountLabel.Text = "0.00";
            totalPaidAmountTextBox.Text = "0";
            fromReadingDateLabel.Text = "";
            previousReadingTextBox.Text = "0";
            meterConsumedReadingTextBox.Text = "0";
            presentReadingTextBox.Text = "";
            totalQuantityLabel.Text = "0";
            totalWaterConsumptionAmountLabel.Text = "0.00";
            totalAmountDueLabel.Text = "0.00";
            totalSCFAmountLabel.Text = "0.00";
            minimumChargeLabel.Text = "0.00";
            penaltyAmountLabel.Text = "0.00";
            penaltyPercentLabel.Text = "10%";
            freeWaterCheckBox.Checked = false;

            isWithHoldingTaxLabel.Text = "0";
            isArrearsLabel.Text = "0";
            dueExemptLabel.Text = "0";
            collectionTotalMeteredAmountLabel.Text = "0.00";
            totalWaterConsumptionAmountLabel2.Text = "0.00";
            collectionTaxAmountLabel.Text = "0.00";
            collectionPenaltyLabel.Text = "0.00";
            collectionArrearsAmountLabel.Text = "0.00";
            totalPaidAmountTextBox.Text = "0.00";
            taxExemptedPercentLabel2.Text = "0%";
            arrearsAmountLabel2.Text = "0.00";
            totalAmountDueLabel2.Text = "0.00";
            penaltyPercentLabel2.Text = "10%";
            totalQuantityLabel2.Text = "0";
            bankNameTextBox.Text = "";
            checkNumberTextBox.Text = "";
            bankAccountNumberText.Text = "";
            cashCheckBox.Checked = true;
            DisableButton();
            if (e.RowIndex < 0) return; // Ignore header or invalid rows

            // 🟦 Get selected row
            DataGridViewRow selectedRow = accountDataGridView.Rows[e.RowIndex];

            // 🟦 Extract individual values using the column names
            string concessionaireID = selectedRow.Cells["concessionaireID"].Value?.ToString();
            string accountNo = selectedRow.Cells["accountno"].Value?.ToString();
            string fullname = selectedRow.Cells["fullname"].Value?.ToString();
            string address = selectedRow.Cells["businessAddress"].Value?.ToString();
            string zoneCode = selectedRow.Cells["zoneCode"].Value?.ToString();
            string serviceID = selectedRow.Cells["serviceId"].Value?.ToString();
            string meterNo = selectedRow.Cells["meterNo"].Value?.ToString();
            string frdObj = selectedRow.Cells["firstReadingDate"].Value?.ToString();
            int taxExempt = Convert.ToInt32(selectedRow.Cells["taxExempt"].Value);
            int IsSeniorCitizen = Convert.ToInt32(selectedRow.Cells["seniorCitizen"].Value);
            string dueExempted = selectedRow.Cells["dueExempt"].Value?.ToString();
            string status = selectedRow.Cells["status"].Value?.ToString();
            string scf = selectedRow.Cells["SCF"].Value?.ToString();

            collectionAccountNoLabel.Text = accountNo;
            if (DateTime.TryParse(frdObj?.ToString(), out DateTime frd))
            {
                fromReadingDateLabel.Text = frd.ToString("MMM-dd-yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                fromReadingDateLabel.Text = ""; // or show a default/fallback message
            }
            discountedPercentLabel.Text = $"{DiscountHelper.GetSeniorCitizenDiscountPercent(IsSeniorCitizen)}%";
            if (IsSeniorCitizen == 1)
            {
                discountNameLabel.Text = "SENIOR CITIZEN";
            }
            else
            {
                discountNameLabel.Text = "";
            }
            if (decimal.TryParse(scf, out decimal scfValue))
            {
                scfBalanceLabel.Text = $"SCF Balance: ₱{scfValue:N2}";
            }
            else
            {
                scfBalanceLabel.Text = "SCF Balance: ₱0.00";
            }
            decimal SCFBalance = 0;
            if (!string.IsNullOrWhiteSpace(scf))
            {
                SCFBalance = decimal.Parse(scf);
            }
            decimal displayAmount = 0;
            if (SCFBalance > 0)
            {
                // Determine amount to display in the textbox
                displayAmount = Math.Min(SCFBalance, 500m); // max 500

                // Format and set the textbox
                totalSCFAmountLabel.Text = displayAmount.ToString("N2");
            }
            else
            {
                // If scf is 0, clear or reset the textbox
                totalSCFAmountLabel.Text = "0.00";
            }
            Debug.WriteLine("scf //////"+ scfValue);
            defaultDiscount = discountedPercentLabel.Text;
            defaultDiscountName = discountNameLabel.Text;
            firstReadingDateLabel.Text = frdObj;
            serviceIDLabel.Text = serviceID;
            dueExemptLabel.Text = dueExempted;
            double taxPercent = SettingsHelper.GetTaxPercent(taxExempt);
            taxExemptedPercentLabel.Text = $"{taxPercent:0.##}%";
            defaultTax = taxExemptedPercentLabel.Text;
            concessionaireIDLabel.Text = concessionaireID;

            if (!string.IsNullOrWhiteSpace(accountNo))
            {
                // Load billing history
                LoadAccountBillHistory(accountNo);

                // 🟦 Get latest bill number
                string latestBillNo = GetLatestBillNoHelper.GetLatestBillNo(accountNo);
                Debug.WriteLine(!string.IsNullOrEmpty(latestBillNo)
                    ? $"✅ Latest bill_id: {latestBillNo}"
                    : $"⚠️ No bill found for account number: {accountNo}");
                // Convert latestBillNo to string if it's not already
                string billNo = latestBillNoLabel.Text;

                // Create an instance of RecentBillDetailsHelper
                var recentBillDetailsHelper = new RecentBillDetailsHelper();
                var bill = recentBillDetailsHelper.GetBillByBillNo(latestBillNo);



                if (bill != null)
                {
                    if (bill.IsFullyPaid)
                    {
                        // Bill is fully paid, always show 0.00
                        arrearsAmountLabel.Text = "0.00";
                    }
                    else if (bill.IsPatrtiallyPaid)
                    {
                        // Bill is partially paid, show the remaining balance
                        arrearsAmountLabel.Text = bill.Balance.ToString("N2");
                    }
                    else
                    {
                        // Bill is unpaid (neither fully nor partially paid), show full billed amount
                        arrearsAmountLabel.Text = bill.TotalAmountBilled.ToString("N2");
                    }


                    ////////////////////////////////////////////////////////////////////////
                    // Calculate monthly SCF charge (max ₱500 or remaining balance)
                    decimal monthlySCF = Math.Min(displayAmount, 500m);

                    // Default values
                    decimal SCFArrears = 0m;
                    decimal currentSCF = 0m;

                    // Determine SCF arrears and current charge based on bill status
                    if (bill.IsSCFPaid)
                    {
                        // Fully paid: no arrears, no current charge
                        SCFArrears = 0m;
                        currentSCF = 0m;
                    }
                    else if (bill.IsSCFPartiallyPaid)
                    {
                        // Partially paid: use arrears from bill, plus current month charge
                        SCFArrears = bill.SCFArrearsAmount > 0 ? bill.SCFArrearsAmount : 0m;
                        currentSCF = monthlySCF;
                    }
                    else
                    {
                        // Unpaid: use total SCF from bill as arrears, plus current month charge
                        SCFArrears = bill.TotalSCFAmount > 0 ? bill.TotalSCFAmount : 0m;
                        currentSCF = monthlySCF;
                    }

                    // Compute total SCF
                    decimal totalSCF = SCFArrears + currentSCF;

                    // Update labels
                    scfArrearsLabel.Text = SCFArrears.ToString("N2");
                    currentSCFLabel.Text = currentSCF.ToString("N2");
                    totalSCFAmountLabel.Text = totalSCF.ToString("N2");



                    // You can also update arrearsAmountLabel2 if needed:
                    // arrearsAmountLabel2.Text = arrearsAmountLabel.Text;

                    string message =
                        $"Account No: {bill.AccountNo}\n" +
                        $"Billing Period: {bill.DateFrom:MMMM dd, yyyy} to {bill.DateTo:MMMM dd, yyyy}\n" +
                        $"Previous Reading: {bill.PrevReading:N0} cu.m\n" +
                        $"Present Reading: {bill.PresentReading:N0} cu.m\n" +
                        $"Penalty: {bill.Penalty:C}\n" +
                        $"Tax: {bill.Tax:C}\n" +
                        $"Total Paid: {bill.AmountPaid:C}\n" +
                        $"Due Date: {bill.DueDate:MMMM dd, yyyy}";
                    fromReadingDateLabel.Text = $"{bill.DateTo:MMM-dd-yyyy}";
                    previousReadingTextBox.Text = $"{bill.PresentReading}";
                    arrearsAmountLabel2.Text = $"{bill.ArrearsAmount.ToString("N2")}";
                    dateBilledLabel2.Text = $"{bill.DateCreated:MMMM dd, yyyy}";
                    int isArrears = 0;

                    if (bill.Balance > 0)
                    {
                        isArrears = 0;
                    }
                    else
                    {
                        isArrears = 1;
                    }

                    double penaltyPercent = SettingsHelper.GetPenaltyPercent(isArrears);

                    decimal arrearsAmount = decimal.Parse(arrearsAmountLabel.Text.Replace(",", ""));

                    decimal arrearsPenalty = SettingsHelper.CalculatePenaltyOnArrears(arrearsAmount);

                    penaltyAmountLabel.Text = arrearsPenalty.ToString("N2");

                    Debug.WriteLine($"{bill.Balance}");
                    if (arrearsAmountLabel.Text != "0.00")
                    {
                        isArrearsLabel.Text = "-1";
                    }
                    else
                    {
                        isArrearsLabel.Text = "0";
                    }
                    if (currentTabLabel.Text == "Collection Reciept")
                    {
                        int meterConsumed = Math.Max(0, (int)((bill.PresentReading - bill.PrevReading) - bill.FreeWater));
                        Debug.WriteLine(
                            $"Meter consumed: {meterConsumed} cu.m | Tax: {bill.Tax}% | Discount: {bill.Discount}% | SCF: {bill.CurrentSCFAmount:N2} | DueDate: {bill.DueDate:MMMM dd, yyyy}"
                        );
                        freeWaterLabel.Text = bill.FreeWater.ToString();
                        meterConsumedReadingTextBox.Text = meterConsumed.ToString();
                        taxExemptedPercentLabel2.Text = $"{bill.Tax}%";
                        discountedPercentLabel2.Text = $"{bill.Discount}%";
                        totalSCFAmountLabel2.Text = $"{bill.TotalSCFAmount:N2}";
                        dueDateLabel2.Text = bill.DueDate.ToString("MMMM dd, yyyy");

                        if (int.TryParse(serviceIDLabel.Text.Trim(), out int serviceId))
                        {
                            PopulateServiceRateLabels2(serviceId, meterConsumed);
                        }
                        collectionNameLabel.Text = fullname;
                        collectionAddressLabel.Text = address;
                        collectionBillingInvoiceTextBox.Text = bill.BillNo;
                    }
                }
            }

            // Tax Exempt

            // 🟦 Update UI fields
            accountNumberTextBox.Text = accountNo;
            fullnameTextBox.Text = fullname;
            addressTextBox.Text = address;
            accountnoBillHistory.Text = $"Account ID: {accountNo}";
        }

        private void InsertIntoPayments()
        {
            try
            {
                using (var connection = new OleDbConnection(DbConfig.ConnectionString))
                {
                    connection.Open();

                    // Pre-calculate values used in both insert and update
                    decimal totalCurrent = decimal.TryParse(subTotalAmountDueLabel2.Text.Replace(",", ""), out decimal tbc) ? tbc : 0m;
                    decimal amountPaid = decimal.TryParse(paymentForBillingTextBox.Text.Replace(",", ""), out decimal ap) ? ap : 0m;
                    decimal penaltyAmount = decimal.TryParse(penaltyAmountLabel2.Text.Replace(",", ""), out decimal pa) ? pa : 0m;
                    decimal scfAmountPaid = decimal.TryParse(collectionSCFTextBox.Text.Replace(",", ""), out decimal scfpaid) ? scfpaid : 0m;
                    decimal totalCurrentSCF = decimal.TryParse(totalSCFAmountLabel2.Text.Replace(",", ""), out decimal scfcurrent) ? scfcurrent : 0m;

                    decimal SCFbalance = totalCurrentSCF - scfAmountPaid;
                    if (SCFbalance < 0) SCFbalance = 0;

                    decimal arrearsAmount = decimal.TryParse(arrearsAmountLabel2.Text.Trim().Replace(",", ""), out decimal aa) ? aa : 0m;
                    decimal arrearsPenalty = SettingsHelper.CalculatePenaltyOnArrears(arrearsAmount);
                    decimal totalArrears = arrearsAmount + arrearsPenalty;

                    decimal totalPenalty = decimal.TryParse(collectionPenaltyLabel.Text.Trim().Replace(",", ""), out decimal tp) ? tp : 0m;

                    totalCurrent = totalCurrent + arrearsAmount + totalPenalty;
                    decimal balance = totalCurrent - amountPaid;
                    if (balance < 0) balance = 0;

                    string insertQuery = @"
                INSERT INTO Tb_Payments (
                    ORNumber, CurrentBillNo, AccountNo, PaymentDate, PaymentType, ArrearsAmount, ArrearsPenalty, TotalArrears, 
                    BillCharge, TaxAmount, TotalCurrent, CheckNumber, BankName, BankAccountNumber, DateIssued, 
                    CheckAmount, CashAmount, AmountPaid, [Net Bill Charge], Balance, DiscountName, DiscountAmount, 
                    Penalty, ServiceConnectionFee, Remarks, OthersAmount1, UserID, FreeWater, SCFBalance, TotalPenalty, TotalAmountPaid
                ) VALUES (
                    @ORNumber, @CurrentBillNo, @AccountNo, @PaymentDate, @PaymentType, @ArrearsAmount, @ArrearsPenalty, @TotalArrears, 
                    @BillCharge, @TaxAmount, @TotalCurrent, @CheckNumber, @BankName, @BankAccountNumber, @DateIssued, 
                    @CheckAmount, @CashAmount, @AmountPaid, @NetBillCharge, @Balance, @DiscountName, @DiscountAmount, 
                    @Penalty, @ServiceConnectionFee, @Remarks, @OthersAmount1, @UserID, @FreeWater, @SCFBalance, @TotalPenalty, @TotalAmountPaid
                )";

                    using (var insertCmd = new OleDbCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@ORNumber", int.Parse(orNumberTextBox.Text.Trim()));
                        insertCmd.Parameters.AddWithValue("@CurrentBillNo", int.Parse(collectionBillingInvoiceTextBox.Text.Trim()));
                        insertCmd.Parameters.AddWithValue("@AccountNo", accountNumberTextBox.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@PaymentDate", DateTime.Now.ToString("M/d/yyyy"));
                        insertCmd.Parameters.AddWithValue("@PaymentType", cashCheckBox.Checked ? "Cash" : "Check");
                        insertCmd.Parameters.AddWithValue("@ArrearsAmount", arrearsAmount);
                        insertCmd.Parameters.AddWithValue("@ArrearsPenalty", arrearsPenalty);
                        insertCmd.Parameters.AddWithValue("@TotalArrears", totalArrears);
                        insertCmd.Parameters.AddWithValue("@BillCharge", decimal.Parse(totalWaterConsumptionAmountLabel2.Text.Replace(",", "")));
                        insertCmd.Parameters.AddWithValue("@TaxAmount", decimal.Parse(collectionTaxAmountLabel.Text.Replace(",", "")));
                        insertCmd.Parameters.AddWithValue("@TotalCurrent", decimal.Parse(collectionTotalMeteredAmountLabel.Text.Replace(",", "")));

                        if (checkCheckBox.Checked)
                        {
                            insertCmd.Parameters.AddWithValue("@CheckNumber", checkNumberTextBox.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@BankName", bankNameTextBox.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@BankAccountNumber", bankAccountNumberText.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@DateIssued", checkDateIssuedDateTimePicker.Value.ToString("M/d/yyyy"));
                        }
                        else
                        {
                            insertCmd.Parameters.AddWithValue("@CheckNumber", DBNull.Value);
                            insertCmd.Parameters.AddWithValue("@BankName", DBNull.Value);
                            insertCmd.Parameters.AddWithValue("@BankAccountNumber", DBNull.Value);
                            insertCmd.Parameters.AddWithValue("@DateIssued", DBNull.Value);
                        }

                        insertCmd.Parameters.AddWithValue("@CheckAmount", cashCheckBox.Checked ? 0m : decimal.Parse(totalPaidAmountTextBox.Text.Trim()));
                        insertCmd.Parameters.AddWithValue("@CashAmount", cashCheckBox.Checked ? decimal.Parse(totalPaidAmountTextBox.Text.Trim()) : 0m);
                        insertCmd.Parameters.AddWithValue("@AmountPaid", amountPaid);
                        insertCmd.Parameters.AddWithValue("@NetBillCharge", decimal.Parse(totalPlusSFCOthersLabel.Text.Replace(",", "")));
                        insertCmd.Parameters.AddWithValue("@Balance", balance);
                        insertCmd.Parameters.AddWithValue("@DiscountName", discountNameLabel.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@DiscountAmount", decimal.Parse(discountedAmountLabel2.Text.Replace(",", "")));
                        insertCmd.Parameters.AddWithValue("@Penalty", penaltyAmount);
                        insertCmd.Parameters.AddWithValue("@ServiceConnectionFee", decimal.Parse(collectionSCFTextBox.Text.Replace(",", "")));
                        insertCmd.Parameters.AddWithValue("@Remarks", remarksTextBox.Text.Trim() == "📝 Remarks" ? "" : remarksTextBox.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@OthersAmount1", decimal.Parse(paymentFroOthersLabel.Text.Replace(",", "")));
                        insertCmd.Parameters.AddWithValue("@UserID", UserCredentials.UserId);
                        insertCmd.Parameters.AddWithValue("@FreeWater", int.Parse(freeWaterLabel.Text.Trim()));
                        insertCmd.Parameters.AddWithValue("@SCFBalance", SCFbalance);
                        insertCmd.Parameters.AddWithValue("@TotalPenalty", decimal.Parse(collectionPenaltyLabel.Text.Replace(",", "")));
                        insertCmd.Parameters.AddWithValue("@UserID", UserCredentials.UserId);
                        insertCmd.Parameters.AddWithValue("@TotalAmountPaid", decimal.Parse(totalPaidAmountTextBox.Text.Replace(",", "")));
                        insertCmd.ExecuteNonQuery();
                    }

                    // UPDATE billing status
                    string updateBillingQuery = @"
                UPDATE Tb_Billing
                SET 
                    Is_FullyPaid = @IsFullyPaid, 
                    Is_PartiallyPaid = @IsPartiallyPaid,
                    Is_SCFPaid = @IsSCFFullyPaid,
                    Is_SCFPartiallyPaid = @IsSCFPartiallyPaid
                WHERE BillNo = @BillNo";

                    using (var updateCmd = new OleDbCommand(updateBillingQuery, connection))
                    {
                        bool isFullyPaid = amountPaid >= totalCurrent;
                        bool isPartiallyPaid = amountPaid > 0 && amountPaid < totalCurrent;
                        bool isSCFFullyPaid = scfAmountPaid >= totalCurrentSCF;
                        bool isSCFPartiallyPaid = scfAmountPaid > 0 && scfAmountPaid < totalCurrentSCF;

                        updateCmd.Parameters.AddWithValue("@IsFullyPaid", isFullyPaid);
                        updateCmd.Parameters.AddWithValue("@IsPartiallyPaid", isPartiallyPaid);
                        updateCmd.Parameters.AddWithValue("@IsSCFFullyPaid", isSCFFullyPaid);
                        updateCmd.Parameters.AddWithValue("@IsSCFPartiallyPaid", isSCFPartiallyPaid);
                        updateCmd.Parameters.AddWithValue("@BillNo", int.Parse(collectionBillingInvoiceTextBox.Text.Trim()));

                        updateCmd.ExecuteNonQuery();
                    }

                    // Deduct SCF payment from concessionaire's SCF balance
                    string updateScfQuery = "UPDATE Tb_Concessionaire SET SCF = SCF - ? WHERE AccountNo = ?";
                    using (var updateScfCmd = new OleDbCommand(updateScfQuery, connection))
                    {
                        updateScfCmd.Parameters.AddWithValue("?", scfAmountPaid);
                        updateScfCmd.Parameters.AddWithValue("?", collectionAccountNoLabel.Text.Trim());
                        updateScfCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Payment record inserted and billing status updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPaymentsToday();
                    SetNextORNo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Insert failed:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCollection()
        {
            collectionNameLabel.Text = "";
            collectionAddressLabel.Text = "";
            collectionTotalMeteredAmountLabel.Text = "0.00";
            collectionArrearsAmountLabel.Text = "0.00";
            collectionPenaltyLabel.Text = "0.00";
            collectionTaxAmountLabel.Text = "0.00";
            collectionSCFTextBox.Text = "0.00";
            collectionOtherPaymentTextBox.Text = "0.00";
            totalPaidAmountTextBox.Text = "0.00";
            collectionBillingInvoiceTextBox.Text = "";
            remarksTextBox.Text = "";
            billPaidButton.Enabled = false;
        }








        private void LoadAccountBillHistory(string accountNo)
        {
            string query = @"
SELECT
    b.BillNo AS [Bill No],
    b.DateFrom AS [From],
    b.DateTo AS [To],
    b.PrevReading AS [Prev Reading],
    b.PresentReading AS [Present Reading],
    (b.PresentReading - b.PrevReading) AS [Meter Consumed(m³)],
    b.DueDate AS [Due Date],
    b.FreeWater AS [Free Water],
    b.TotalSCF AS [SCF],
    b.AmountBilled AS [Amount Billed],
    IIF(b.Is_FullyPaid = True, 'Fully Paid',
        IIF(b.Is_PartiallyPaid = True, 'Partially Paid', 'Unpaid')) AS [Status],
    p.Balance,
    p.SCFBalance
FROM Tb_Billing AS b
LEFT JOIN Tb_Payments AS p
    ON b.BillNo = p.CurrentBillNo
WHERE b.AccountNo = ?
ORDER BY b.BillNo DESC;


        ";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(DbConfig.ConnectionString))
                {
                    conn.Open();

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", accountNo);

                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            billDataGridView.DataSource = dt;

                            billDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                            // Highlight the text color of Status column only
                            foreach (DataGridViewRow row in billDataGridView.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var statusCell = row.Cells["Status"];
                                string status = statusCell.Value?.ToString()?.Trim();

                                if (status == "Fully Paid")
                                {
                                    statusCell.Style.ForeColor = Color.Green;
                                    statusCell.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                }
                                else if (status == "Partially Paid")
                                {
                                    statusCell.Style.ForeColor = Color.OrangeRed;
                                    statusCell.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                }
                                else if (status == "Unpaid")
                                {
                                    statusCell.Style.ForeColor = Color.DarkRed;
                                    statusCell.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                }
                                else
                                {
                                    statusCell.Style.ForeColor = billDataGridView.DefaultCellStyle.ForeColor;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load bill history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void searchButton_Click(object sender, EventArgs e)
        {
            string keyword = searchAccountNumberTextBox.Text.Trim().Replace("'", "''"); // prevent errors with single quotes

            if (accountDataGridView.DataSource is DataTable dt)
            {
                // Filter on both 'accountno' and 'fullname' columns
                dt.DefaultView.RowFilter = $"accountno LIKE '%{keyword}%' OR name LIKE '%{keyword}%'";
            }
        }





        private async void clearButton_Click(object sender, EventArgs e)
        {
            if (accountDataGridView.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = ""; // reset filter
            }

            searchAccountNumberTextBox.Clear();
            using (var loadingForm = new LoadingForm())
            {
                var task1 = DGVHelper.LoadDataToGridAsync(accountDataGridView, "Tb_Concessionaire", loadingForm);

                await Task.WhenAll(task1);
            }
        }
        private void accountNumberTextBox_TextChanged(object sender, EventArgs e)
        {


        }



        public void PopulateServiceRateLabels2(int serviceId, int totalConsumption)
        {
            {
                using (var conn = new OleDbConnection(DbConfig.ConnectionString))
                {
                    string query = @"
                    SELECT MinRate, [Rate11-20], [Rate21-30], [Rate31-40], [Rate41-Above]
                    FROM Tb_Service
                    WHERE ServiceID = ?";
                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", serviceId);
                        conn.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Get service rates
                                decimal minRate = Convert.ToDecimal(reader["MinRate"]);
                                decimal rate11_20 = Convert.ToDecimal(reader["Rate11-20"]);
                                decimal rate21_30 = Convert.ToDecimal(reader["Rate21-30"]);
                                decimal rate31_40 = Convert.ToDecimal(reader["Rate31-40"]);
                                decimal rate41_above = Convert.ToDecimal(reader["Rate41-Above"]);

                                int q10 = Math.Min(totalConsumption, 10);
                                int q20 = Math.Min(Math.Max(totalConsumption - 10, 0), 10);
                                int q30 = Math.Min(Math.Max(totalConsumption - 20, 0), 10);
                                int q40 = Math.Min(Math.Max(totalConsumption - 30, 0), 10);
                                int q41 = Math.Max(totalConsumption - 40, 0);

                                decimal a10 = q10 > 0 ? minRate : 0; // Minimum charge
                                decimal a20 = q20 * rate11_20;
                                decimal a30 = q30 * rate21_30;
                                decimal a40 = q40 * rate31_40;
                                decimal a41 = q41 * rate41_above;

                                decimal total = a10 + a20 + a30 + a40 + a41;

                                // Populate labels
                                tenQuantityLabel2.Text = q10.ToString();
                                tenUnitPriceLabel2.Text = (minRate / 10).ToString("N2");
                                tenAmountLabel2.Text = a10.ToString("N2");

                                twentyQuantityLabel2.Text = q20.ToString();
                                twentyUnitPriceLabel2.Text = rate11_20.ToString("N2");
                                twentyAmountLabel2.Text = a20.ToString("N2");

                                thirtyQuantityLabel2.Text = q30.ToString();
                                thirtyUnitPriceLabel2.Text = rate21_30.ToString("N2");
                                thirtyAmountLabel2.Text = a30.ToString("N2");

                                fortyQuantityLabel2.Text = q40.ToString();
                                fortyUnitPriceLabel2.Text = rate31_40.ToString("N2");
                                fortyAmountLabel2.Text = a40.ToString("N2");

                                fortyUpQuantityLabel2.Text = q41.ToString();
                                fortyUpUnitPriceLabel2.Text = rate41_above.ToString("N2");
                                fortyUpAmountLabel2.Text = a41.ToString("N2");

                                minimumChargeLabel2.Text = minRate.ToString("N2");
                                totalWaterConsumptionAmountLabel2.Text = total.ToString("N2");
                                totalQuantityLabel2.Text = totalConsumption.ToString();


                            }


                            decimal discounted = 0;
                            decimal taxAdded = 0;

                            // Clean up input texts
                            string discountText = discountedPercentLabel2.Text.Replace("%", "").Trim();
                            string taxAddedText = taxExemptedPercentLabel2.Text.Replace("%", "").Trim();

                            if (!decimal.TryParse(totalWaterConsumptionAmountLabel2.Text.Trim(), out decimal totalConsumptionAmount))
                            {
                                totalConsumptionAmount = 0;
                            }

                            decimal addedTaxWaterConsumption = 0;



                            // Parse Tax
                            if (decimal.TryParse(taxAddedText, out decimal percent2))
                            {
                                taxAdded = totalConsumptionAmount * (percent2 / 100);
                                taxAmountLabel2.Text = taxAdded.ToString("N2");
                            }
                            else
                            {
                                taxAmountLabel2.Text = "0.00";
                            }
                            // Parse Discount
                            if (decimal.TryParse(discountText, out decimal percent1))
                            {

                                addedTaxWaterConsumption = totalConsumptionAmount + taxAdded;
                                discounted = addedTaxWaterConsumption * (percent1 / 100);
                                discountedAmountLabel2.Text = discounted.ToString("N2");

                            }
                            else
                            {
                                discountedAmountLabel2.Text = "0.00";
                            }
                            decimal discountedTaxAmount = 0;

                            decimal totalTaxAmount = 0;
                            // Parse Discount tax
                            if (decimal.TryParse(discountText, out decimal percent3))
                            {
                                decimal taxAmount = decimal.Parse(taxAmountLabel2.Text.Trim());

                                discountedTaxAmount = taxAmount * (percent3 / 100);
                                totalTaxAmount = taxAmount - discountedTaxAmount;


                                collectionTaxAmountLabel.Text = totalTaxAmount.ToString("N2");




                            }
                            else
                            {
                                collectionTaxAmountLabel.Text = "0.00";
                            }


                            collectionTotalMeteredAmountLabel.Text = (totalConsumptionAmount - discounted + discountedTaxAmount).ToString("N2");
                            Debug.WriteLine($"Discounted Amount: {discounted}");


                            // Step 3: Get Due Date (required for late penalty)
                            DateTime dueDate;
                            if (!DateTime.TryParseExact(dateBilledLabel2.Text, "MMMM dd, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDate))
                            {
                                dueDate = DateTime.Now; // fallback, or handle differently if needed
                            }
                            decimal arrearsAmount = decimal.Parse(arrearsAmountLabel2.Text.Replace(",", "").Trim());
                            // Calculate penalties
                            decimal arrearsPenalty = SettingsHelper.CalculatePenaltyOnArrears(arrearsAmount);
                            decimal latePenalty = SettingsHelper.CalculateLatePaymentPenalty(totalConsumptionAmount, dueDate);

                            penaltyAmountLabel2.Text = latePenalty.ToString("N2");
                            // Create a list to hold the penalties to display
                            List<string> parts = new List<string>();

                            decimal totalPenalty = arrearsPenalty + latePenalty;
                            collectionPenaltyLabel.Text = totalPenalty.ToString("N2");
                            // Add arrears penalty if greater than 0
                            if (arrearsPenalty > 0)
                                parts.Add(arrearsPenalty.ToString("N2"));

                            // Add late penalty if greater than 0
                            if (latePenalty > 0)
                                parts.Add(latePenalty.ToString("N2"));

                            // Display logic
                            if (parts.Count > 0)
                            {
                                // Show the penalties joined by " + " (e.g., "120.32 + 235.60")
                                allPenaltyLabel.Text = string.Join(" + ", parts);

                                // Show the total sum of penalties
                                penaltySumLabel.Text = (arrearsPenalty + latePenalty).ToString("N2");
                            }
                            else
                            {
                                // If both penalties are zero
                                collectionPenaltyLabel.Text = "0.00";
                                penaltySumLabel.Text = "0.00";
                            }


                            arrearsPenaltyAmountLabel.Text = arrearsPenalty.ToString("N2");

                            // Step 2: Final Charge Calculation
                            decimal chargeSubTotal = totalConsumptionAmount - discounted + taxAdded;

                            // Display Final Total
                            subTotalAmountDueLabel2.Text = chargeSubTotal.ToString("N2");
                            decimal scf = totalSCFAmountLabel2.Text.Trim().Replace(",", "").Trim() == "" ? 0 : decimal.Parse(totalSCFAmountLabel2.Text.Trim().Replace(",", ""));
                            decimal othersAmount = collectionOtherPaymentTextBox.Text.Trim().Replace(",", "").Trim() == "" ? 0 : decimal.Parse(collectionOtherPaymentTextBox.Text.Trim().Replace(",", ""));
                            decimal totalAmountCharge = chargeSubTotal + arrearsPenalty + latePenalty + arrearsAmount;



                            decimal totalAmountDuePlusSCF = totalAmountCharge + scf + othersAmount;
                            totalPlusSFCOthersLabel.Text = totalAmountDuePlusSCF.ToString("N2");
                            totalAmountDueLabel2.Text = totalAmountCharge.ToString("N2");

                            collectionArrearsAmountLabel.Text = arrearsAmountLabel2.Text;

                        }
                    }


                }
            }
        }


        public void PopulateServiceRateLabels(int serviceId, int totalConsumption)
        {
            using (var conn = new OleDbConnection(DbConfig.ConnectionString))
            {
                string query = @"
            SELECT MinRate, [Rate11-20], [Rate21-30], [Rate31-40], [Rate41-Above]
            FROM Tb_Service
            WHERE ServiceID = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", serviceId);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Get service rates
                            decimal minRate = Convert.ToDecimal(reader["MinRate"]);
                            decimal rate11_20 = Convert.ToDecimal(reader["Rate11-20"]);
                            decimal rate21_30 = Convert.ToDecimal(reader["Rate21-30"]);
                            decimal rate31_40 = Convert.ToDecimal(reader["Rate31-40"]);
                            decimal rate41_above = Convert.ToDecimal(reader["Rate41-Above"]);

                            int q10 = Math.Min(totalConsumption, 10);
                            int q20 = Math.Min(Math.Max(totalConsumption - 10, 0), 10);
                            int q30 = Math.Min(Math.Max(totalConsumption - 20, 0), 10);
                            int q40 = Math.Min(Math.Max(totalConsumption - 30, 0), 10);
                            int q41 = Math.Max(totalConsumption - 40, 0);

                            decimal a10 = q10 > 0 ? minRate : 0; // Minimum charge
                            decimal a20 = q20 * rate11_20;
                            decimal a30 = q30 * rate21_30;
                            decimal a40 = q40 * rate31_40;
                            decimal a41 = q41 * rate41_above;

                            decimal total = a10 + a20 + a30 + a40 + a41;

                            // Populate labels
                            tenQuantityLabel.Text = q10.ToString();
                            tenUnitPriceLabel.Text = (minRate / 10).ToString("N2");
                            tenAmountLabel.Text = a10.ToString("N2");

                            twentyQuantityLabel.Text = q20.ToString();
                            twentyUnitPriceLabel.Text = rate11_20.ToString("N2");
                            twentyAmountLabel.Text = a20.ToString("N2");

                            thirtyQuantityLabel.Text = q30.ToString();
                            thirtyUnitPriceLabel.Text = rate21_30.ToString("N2");
                            thirtyAmountLabel.Text = a30.ToString("N2");

                            fortyQuantityLabel.Text = q40.ToString();
                            fortyUnitPriceLabel.Text = rate31_40.ToString("N2");
                            fortyAmountLabel.Text = a40.ToString("N2");

                            fortyUpQuantityLabel.Text = q41.ToString();
                            fortyUpUnitPriceLabel.Text = rate41_above.ToString("N2");
                            fortyUpAmountLabel.Text = a41.ToString("N2");

                            minimumChargeLabel.Text = minRate.ToString("N2");
                            totalWaterConsumptionAmountLabel.Text = total.ToString("N2");
                            totalQuantityLabel.Text = totalConsumption.ToString();

                            // Hide rows with zero quantity
                            tenQuantityLabel.Visible = tenUnitPriceLabel.Visible = tenAmountLabel.Visible = q10 > 0;
                            twentyQuantityLabel.Visible = twentyUnitPriceLabel.Visible = twentyAmountLabel.Visible = q20 > 0;
                            thirtyQuantityLabel.Visible = thirtyUnitPriceLabel.Visible = thirtyAmountLabel.Visible = q30 > 0;
                            fortyQuantityLabel.Visible = fortyUnitPriceLabel.Visible = fortyAmountLabel.Visible = q40 > 0;
                            fortyUpQuantityLabel.Visible = fortyUpUnitPriceLabel.Visible = fortyUpAmountLabel.Visible = q41 > 0;
                        }

                        // ----------------------
                        // Calculation section
                        // ----------------------

                        decimal discounted = 0;
                        decimal taxAdded = 0;
                        decimal arrears = 0;

                        string discountText = discountedPercentLabel.Text.Replace("%", "").Trim();
                        string taxAddedText = taxExemptedPercentLabel.Text.Replace("%", "").Trim();

                        // Parse Total Consumption Amount
                        if (!decimal.TryParse(totalWaterConsumptionAmountLabel.Text.Trim(), out decimal totalConsumptionAmount))
                            totalConsumptionAmount = 0;

                        // Parse Tax
                        if (decimal.TryParse(taxAddedText, out decimal percent2))
                        {
                            taxAdded = totalConsumptionAmount * (percent2 / 100);
                            taxAmountLabel.Text = taxAdded.ToString("N2");
                        }
                        else
                        {
                            taxAmountLabel.Text = "0.00";
                        }

                        decimal addedTaxWaterConsumption = totalConsumptionAmount + taxAdded;

                        // Parse Discount
                        if (decimal.TryParse(discountText, out decimal percent1))
                        {
                            discounted = addedTaxWaterConsumption * (percent1 / 100);
                            discountedAmountLabel.Text = discounted.ToString("N2");
                        }
                        else
                        {
                            discountedAmountLabel.Text = "0.00";
                        }

                        // Step 2: Final Charge Calculation
                        decimal chargeSubTotal = addedTaxWaterConsumption - discounted;
                        subTotalAmountDueLabel.Text = chargeSubTotal.ToString("N2");

                        arrears = decimal.Parse(arrearsAmountLabel.Text.Replace(",", "").Trim());
                        decimal penaltyAmount = decimal.Parse(penaltyAmountLabel.Text.Replace(",", "").Trim());
                        decimal scf = decimal.Parse(totalSCFAmountLabel.Text.Replace(",", "").Trim());

                        // Total amount due calculations
                        decimal totalAmountDue = chargeSubTotal + penaltyAmount + arrears;
                        decimal totalAmountDuePlusSCF = totalAmountDue + scf;

                        totalAmountDueLabel.Text = totalAmountDue.ToString("N2");
                        totalAmountDueSCFLabel.Text = totalAmountDuePlusSCF.ToString("N2");
                    }
                }
            }
        }


        private void meterConsumedReadingTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateMeterConsumedAfterFreeWater()
        {
            int freeWaterValue = 0;

            string freeWaterText = freeWaterTextBox.Text.Trim();

            // Only subtract free water if textbox is not empty AND valid positive number
            if (!string.IsNullOrEmpty(freeWaterText) && int.TryParse(freeWaterText, out int parsedFreeWater) && parsedFreeWater >= 0)
            {
                freeWaterValue = parsedFreeWater;
            }

            // Subtract free water, but don't let result go below zero
            int adjustedMeterConsumed = Math.Max(originalMeterConsumed - freeWaterValue, 0);

            totalQuantityLabel.Text = adjustedMeterConsumed.ToString();
        }

        private void presentReadingTextBox_TextChanged(object sender, EventArgs e)
        {
            string input = presentReadingTextBox.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d*$"))
            {
                presentReadingTextBox.Text = "";
                meterConsumedReadingTextBox.Clear();
                ClearWaterChargeLabels();
                printSaveButton.Enabled = false;
                return;
            }

            if (meterConsumedReadingTextBox.Text != "")
            {
                ClearWaterChargeLabels();
                totalAmountDueLabel.Text = "0.00";
                totalQuantityLabel.Text = "0";
                totalWaterConsumptionAmountLabel.Text = "0.00";
                subTotalAmountDueLabel.Text = "0.00";
            }

            printSaveButton.Enabled = !(string.IsNullOrEmpty(input) || input == "0");

            if (int.TryParse(input, out int presentReading) &&
                int.TryParse(previousReadingTextBox.Text.Trim(), out int previousReading))
            {
                if (presentReading >= previousReading)
                {
                    // Actual meter consumed
                    originalMeterConsumed = presentReading - previousReading;
                    meterConsumedReadingTextBox.Text = originalMeterConsumed.ToString();

                    // Adjusted for free water
                    int freeWaterValue = 0;
                    string freeWaterText = freeWaterTextBox.Text.Trim();
                    if (!string.IsNullOrEmpty(freeWaterText) && int.TryParse(freeWaterText, out int parsedFreeWater) && parsedFreeWater >= 0)
                        freeWaterValue = parsedFreeWater;

                    int adjustedMeterConsumed = Math.Max(originalMeterConsumed - freeWaterValue, 0);
                    totalQuantityLabel.Text = adjustedMeterConsumed.ToString();

                    // Populate service rates using adjusted value
                    if (int.TryParse(serviceIDLabel.Text.Trim(), out int serviceId))
                        PopulateServiceRateLabels(serviceId, adjustedMeterConsumed);
                }
                else
                {
                    meterConsumedReadingTextBox.Clear();
                    originalMeterConsumed = 0;
                }
            }
            else
            {
                meterConsumedReadingTextBox.Clear();
                ClearWaterChargeLabels();
                originalMeterConsumed = 0;
            }
        }

        private void freeWaterTextBox_TextChanged(object sender, EventArgs e)
        {
            string input = freeWaterTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(input) && (!int.TryParse(input, out int freeWaterValue) || freeWaterValue < 0))
            {
                freeWaterTextBox.Text = "";
                return;
            }

            // Recalculate adjusted meter consumed and update population
            int adjustedMeterConsumed = Math.Max(originalMeterConsumed - (string.IsNullOrEmpty(input) ? 0 : int.Parse(input)), 0);
            totalQuantityLabel.Text = adjustedMeterConsumed.ToString();

            if (int.TryParse(serviceIDLabel.Text.Trim(), out int serviceId))
                PopulateServiceRateLabels(serviceId, adjustedMeterConsumed);
        }





        private void ClearWaterChargeLabels2()
        {
            // Clear all tier 1 (0–10) labels
            tenQuantityLabel2.Text = tenUnitPriceLabel2.Text = tenAmountLabel2.Text = "";
            twentyQuantityLabel2.Text = twentyUnitPriceLabel2.Text = twentyAmountLabel2.Text = "";
            thirtyQuantityLabel2.Text = thirtyUnitPriceLabel2.Text = thirtyAmountLabel2.Text = "";
            fortyQuantityLabel2.Text = fortyUnitPriceLabel2.Text = fortyAmountLabel2.Text = "";
            fortyUpQuantityLabel2.Text = fortyUpUnitPriceLabel2.Text = fortyUpAmountLabel2.Text = "";

            // Clear subtotal and tax/discounts
            discountedAmountLabel2.Text = "0";
            taxAmountLabel2.Text = "0.00";
            subTotalAmountDueLabel2.Text = "";
            penaltyAmountLabel2.Text = "0.00";
        }

        private void ClearAmounts()
        {

            // Clear discount and tax labels
            discountedPercentLabel.Text = "0";
            discountedAmountLabel.Text = "0";
            taxExemptedPercentLabel.Text = "0";
            taxAmountLabel.Text = "0.00";
            subTotalAmountDueLabel.Text = "0.00";
            arrearsAmountLabel.Text = "0.00";
            totalAmountDueLabel.Text = "0.00";
            // Also clear totals
            totalQuantityLabel.Text = "0";
            totalWaterConsumptionAmountLabel.Text = "0.00";
        }
        private void ClearAmounts2()
        {
            // Clear discount and tax labels
            discountedPercentLabel2.Text = "0%";
            discountedAmountLabel2.Text = "0.00";
            taxExemptedPercentLabel2.Text = "0%";
            taxAmountLabel2.Text = "0.00";
            arrearsAmountLabel2.Text = "0.00";
            subTotalAmountDueLabel2.Text = "0.00";
            totalAmountDueLabel2.Text = "0.00";

            totalWaterConsumptionAmountLabel2.Text = "0.00";
            // Also clear totals
            totalQuantityLabel.Text = "0";
            totalWaterConsumptionAmountLabel.Text = "0.00";


            collectionArrearsAmountLabel.Text = "0.00";
            collectionBillingInvoiceTextBox.Text = "000-0000000";
            totalPaidAmountTextBox.Text = "0.00";
        }
        private void ClearWaterChargeLabels()
        {
            // Clear all tier labels if input is invalid
            tenQuantityLabel.Text = tenUnitPriceLabel.Text = tenAmountLabel.Text = "";
            twentyQuantityLabel.Text = twentyUnitPriceLabel.Text = twentyAmountLabel.Text = "";
            thirtyQuantityLabel.Text = thirtyUnitPriceLabel.Text = thirtyAmountLabel.Text = "";
            fortyQuantityLabel.Text = fortyUnitPriceLabel.Text = fortyAmountLabel.Text = "";
            fortyUpQuantityLabel.Text = fortyUpUnitPriceLabel.Text = fortyUpAmountLabel.Text = "";
            discountedAmountLabel.Text = "0";
            taxAmountLabel.Text = "0";
            subTotalAmountDueLabel.Text = "";
        }
        private async void syncButton_Click(object sender, EventArgs e)
        {
            // 🟡 Load data from DB to billingDataGridView
            using (var loadingForm = new LoadingForm()) // make sure you created LoadingForm
            {
                await DGVHelper.LoadDataToGridAsync(accountDataGridView, "v_concessionaire_detail", loadingForm);
            }
        }


        private void arrearsLabel_Click(object sender, EventArgs e)
        {

        }

        private void discountedAmountLabel_Click(object sender, EventArgs e)
        {

        }

        private void exemptedAmountLabel_Click(object sender, EventArgs e)
        {

        }

        private void chargeLabel_Click(object sender, EventArgs e)
        {

        }
        private int originalMeterConsumed = 0;






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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void isWithHoldingTaxLabel_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void amountPaidTextBox_Click(object sender, EventArgs e)
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


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabControl = sender as TabControl;
            var selectedTab = tabControl.SelectedTab; // TabPage object
            int selectedIndex = tabControl.SelectedIndex; // Index
            ClearWaterChargeLabels();
            ClearWaterChargeLabels2();
            ClearAmounts();
            ClearAmounts2();
            // Example: Show tab name in a label
            currentTabLabel.Text = $"{selectedTab.Text}";

            // Or use selectedIndex for logic
            // if (selectedIndex == 0) { ... }
        }

        private void totalAmountPaidTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private bool CheckIfBillIsPaidToday(string currentBillNo)
        {
            using (var conn = new OleDbConnection(DbConfig.ConnectionString))
            {
                try
                {
                    conn.Open();

                    // Parse the currentBillNo to int
                    if (!int.TryParse(currentBillNo, out int billNo))
                    {
                        MessageBox.Show("Invalid Bill Number format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);

                    string query = @"
                SELECT COUNT(*) 
                FROM Tb_Billing AS B
                INNER JOIN Tb_Payments AS P
                    ON B.BillNo = P.CurrentBillNo
                WHERE 
                    B.BillNo = ?
                    AND (B.Is_PartiallyPaid = 'Yes' OR B.Is_FullyPaid = 'Yes')
                    AND P.PaymentDate >= ? 
                    AND P.PaymentDate < ?";

                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        // Add parameters in order
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = billNo;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = today;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = tomorrow;

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking bill payment status:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }










        //Y↓\X→|000|025|050|075|100|125|150|175|200|225|250|275|300|325|350|375|400|425|
        //-----+-----------------------------------------------------------------------+
        //000  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //025  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //050  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //075  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //100  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //125  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //150  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //175  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //200  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //225  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //250  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //275  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //300  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //325  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //350  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //375  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //400  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //425  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //450  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //475  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //500  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //525  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //550  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //575  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //600  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //625  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |
        //650  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |




        private void printlangmuna_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();

            // Optional: set the paper size to custom 8.25" x 11.75"
            pd.DefaultPageSettings.PaperSize = new PaperSize("CustomA4", 825, 1175); // 100 DPI units (1 inch = 100)


            // Assign the PrintPage handler
            pd.PrintPage += new PrintPageEventHandler(BillingMapPrintPage);

            // Show a print dialog for user confirmation
            PrintDialog dialog = new PrintDialog();
            dialog.Document = pd;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print(); // Start the print job
            }
        }
        private void LoadPaymentsToday()
        {
            try
            {
                using (var connection = new OleDbConnection(DbConfig.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            p.ORNumber AS [OR No],
                            b.BillNo AS [Bill No],
                            p.AccountNo AS [Account No],
                            p.PaymentDate AS [Payment Date],
                            p.AmountPaid AS [Amount Paid],
                            p.Balance AS [Balance],
                            b.DueDate AS [Due Date],
                            IIF(b.Is_FullyPaid = True, 'Fully Paid',
                                IIF(b.Is_PartiallyPaid = True, 'Partially Paid', 'Unpaid')) AS [Status]
                        FROM 
                            Tb_Payments AS p
                        INNER JOIN 
                            Tb_Billing AS b ON p.CurrentBillNo = b.BillNo
                        WHERE 
                            FORMAT(p.PaymentDate, 'yyyy-mm-dd') = FORMAT(Date(), 'yyyy-mm-dd')
                            AND (b.Is_FullyPaid = True OR b.Is_PartiallyPaid = True)
                        ORDER BY 
                            p.ORNumber DESC;
                        ";

                    using (var adapter = new OleDbDataAdapter(query, connection))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        paymentsOnThisDayDataGridView.DataSource = dataTable;

                        FormatDataGridView(paymentsOnThisDayDataGridView);
                        HighlightPaymentStatus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading today's payments.\n" + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        private void HighlightPaymentStatus()
        {
            foreach (DataGridViewRow row in paymentsOnThisDayDataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                var statusCell = row.Cells["Status"];
                string status = statusCell.Value?.ToString()?.Trim();

                if (status == "Partially Paid")
                {
                    statusCell.Style.ForeColor = Color.Red;
                }
                else if (status == "Fully Paid")
                {
                    statusCell.Style.ForeColor = Color.Green;
                }
                else
                {
                    // Optional: Reset to default if needed
                    statusCell.Style.BackColor = paymentsOnThisDayDataGridView.DefaultCellStyle.BackColor;
                    statusCell.Style.ForeColor = paymentsOnThisDayDataGridView.DefaultCellStyle.ForeColor;
                }
            }
        }






        public void CollectionMapPrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Calibre", 9);
            Pen gridPen = Pens.Orange;
            Brush brush = Brushes.Red;

            void PrintIfNotZero(string value, int x, int y)
            {
                if (!string.IsNullOrWhiteSpace(value) && value != "0.00")
                {
                    g.DrawString(value, font, Brushes.Black, x, y);
                }
            }

            // header information
            string paymentDate = paymentDateLabel.Text;

            // personal information
            string name = collectionNameLabel.Text;
            string address = collectionAddressLabel.Text;
            string metered = collectionTotalMeteredAmountLabel.Text;
            string arrears = collectionArrearsAmountLabel.Text;
            string penalty = collectionPenaltyLabel.Text;
            string tax = collectionTaxAmountLabel.Text;
            string scf = collectionSCFTextBox.Text;
            string others = collectionOtherPaymentTextBox.Text;
            string totalamount = totalPaidAmountTextBox.Text;
            string collectingOfficer = collectingOfficerNameLabel.Text;

            PrintIfNotZero(paymentDate, 340, 170);
            PrintIfNotZero(name, 110, 200);
            PrintIfNotZero(address, 110, 248);

            PrintIfNotZero(metered, 300, 310);
            PrintIfNotZero(arrears, 300, 335);
            PrintIfNotZero(penalty, 300, 360);
            PrintIfNotZero(tax, 300, 385);
            PrintIfNotZero(scf, 300, 410);
            PrintIfNotZero(others, 300, 435);
            PrintIfNotZero(totalamount, 300, 455);

            e.HasMorePages = false;
        }


        private void DrawBillingForm(Graphics g, int offsetY, Font font, Brush brush)
        {
            // Helper method to print only if value is not 0, 0.00, or empty
            void PrintIfNotZero(string value, int x, int y, bool allowZero = false)
            {
                if (!string.IsNullOrWhiteSpace(value) && (allowZero || (value != "0" && value != "0.00")))
                {
                    g.DrawString(value, font, brush, x, y + offsetY);
                }
            }

            // Always print previous reading even if 0
            PrintIfNotZero(previousReadingTextBox.Text, 210, 265, true);
            PrintIfNotZero(dateBilledLabel.Text, 300, 105);
            PrintIfNotZero(fullnameTextBox.Text, 190, 153);
            PrintIfNotZero(addressTextBox.Text, 190, 168);
            PrintIfNotZero(accountNumberTextBox.Text, 190, 200);

            PrintIfNotZero(fromReadingDateLabel.Text, 288, 213);
            PrintIfNotZero(toReadingDateLabel.Text, 368, 213);

            PrintIfNotZero(presentReadingTextBox.Text, 290, 265);
            PrintIfNotZero(meterConsumedReadingTextBox.Text, 370, 265);

            PrintIfNotZero(dueDateLabel.Text, 670, 35);

            PrintIfNotZero(totalQuantityLabel.Text, 605, 90);
            PrintIfNotZero(minimumChargeLabel.Text, 648, 105);
            PrintIfNotZero(totalWaterConsumptionAmountLabel.Text, 700, 90);

            // Only print tier rows if their quantity > 0 (just like in PopulateServiceRateLabels)
            if (int.TryParse(tenQuantityLabel.Text, out int q10) && q10 > 0)
            {
                PrintIfNotZero(tenQuantityLabel.Text, 605, 125);
                PrintIfNotZero(tenUnitPriceLabel.Text, 648, 125);
                PrintIfNotZero(tenAmountLabel.Text, 700, 125);
            }
            if (int.TryParse(twentyQuantityLabel.Text, out int q20) && q20 > 0)
            {
                PrintIfNotZero(twentyQuantityLabel.Text, 605, 140);
                PrintIfNotZero(twentyUnitPriceLabel.Text, 648, 140);
                PrintIfNotZero(twentyAmountLabel.Text, 700, 140);
            }
            if (int.TryParse(thirtyQuantityLabel.Text, out int q30) && q30 > 0)
            {
                PrintIfNotZero(thirtyQuantityLabel.Text, 605, 155);
                PrintIfNotZero(thirtyUnitPriceLabel.Text, 648, 155);
                PrintIfNotZero(thirtyAmountLabel.Text, 700, 155);
            }
            if (int.TryParse(fortyQuantityLabel.Text, out int q40) && q40 > 0)
            {
                PrintIfNotZero(fortyQuantityLabel.Text, 605, 170);
                PrintIfNotZero(fortyUnitPriceLabel.Text, 648, 170);
                PrintIfNotZero(fortyAmountLabel.Text, 700, 170);
            }
            if (int.TryParse(fortyUpQuantityLabel.Text, out int q41) && q41 > 0)
            {
                PrintIfNotZero(fortyUpQuantityLabel.Text, 605, 185);
                PrintIfNotZero(fortyUpUnitPriceLabel.Text, 648, 185);
                PrintIfNotZero(fortyUpAmountLabel.Text, 700, 185);
            }

            PrintIfNotZero(discountedAmountLabel.Text, 700, 203);
            PrintIfNotZero(taxAmountLabel.Text, 700, 218);
            PrintIfNotZero(arrearsAmountLabel.Text, 700, 248);
            PrintIfNotZero(totalSCFAmountLabel.Text, 700, 263);
            PrintIfNotZero(subTotalAmountDueLabel.Text, 700, 283);
            PrintIfNotZero(penaltyAmountLabel.Text, 700, 298);
            PrintIfNotZero(subTotalAmountDueLabel.Text, 700, 313);
        }



        public void BillingMapPrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Calibre", 9);
            Brush brush = Brushes.Red;

            for (int i = 0; i < 3; i++)
            {
                int offsetY = i * 363;
                DrawBillingForm(g, offsetY, font, brush);
            }

            e.HasMorePages = false;
        }



        void PrintPages(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;

            int receiptHeight = 390;

            for (int i = 0; i < 3; i++)
            {
                int yOffset = i * receiptHeight;

                // Example: Draw some key labels (map more as needed)
                g.DrawString("0.00", font, brush, 295, 1 + yOffset);   // totalWaterConsumptionAmountLabel
                g.DrawString("0", font, brush, 149, 1 + yOffset);       // totalQuantityLabel
                g.DrawString("0.00", font, brush, 222, 150 + yOffset);  // fortyUpUnitPriceLabel
                g.DrawString("0", font, brush, 149, 150 + yOffset);     // fortyUpQuantityLabel
                g.DrawString("0.00", font, brush, 295, 150 + yOffset);  // fortyUpAmountLabel
                g.DrawString("0.00", font, brush, 295, 125 + yOffset);  // fortyAmountLabel

                // ... add the rest of your label mappings here
            }

            e.HasMorePages = false;
        }

        private void sfcInstallmentTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalAmountDue();
        }

        // Helper method to update total amount due label consistently
        private void UpdateTotalAmountDue()
        {
            decimal amountDue = 0.00m;
            decimal penalty = 0.00m;
            decimal scf = 0.00m;

            // Parse subtotal amount due label
            decimal.TryParse(subTotalAmountDueLabel.Text.Trim(), out amountDue);

            // Parse penalty label
            decimal.TryParse(penaltyAmountLabel.Text.Trim(), out penalty);

            // Parse SFC installment textbox (remove commas before parsing)
            string scfRaw = totalSCFAmountLabel.Text.Replace(",", "");
            decimal.TryParse(scfRaw, out scf);

            // Calculate total amount due
            decimal totalAmountDue = amountDue + penalty + scf;

            // Format and set total amount due label
            totalAmountDueLabel.Text = totalAmountDue.ToString("N2");
        }


        private void tableLayoutPanel51_Paint(object sender, PaintEventArgs e)
        {

        }

        private void orNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void collectionTotalPaidAmointLabel_Click(object sender, EventArgs e)
        {

        }

        private void cashCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cashCheckBox.Checked)
            {
                // If cash is selected, disable check-related fields
                bankNameTextBox.Enabled = false;
                checkNumberTextBox.Enabled = false;
                bankAccountNumberText.Enabled = false;
                checkCheckBox.Checked = false;
                bankNameTextBox.Text = "";
                checkNumberTextBox.Text = "";
                bankAccountNumberText.Text = "";
            }
            else
            {
                // Enable check-related fields if cash is not selected
                bankNameTextBox.Enabled = true;
                checkNumberTextBox.Enabled = true;
                bankAccountNumberText.Enabled = true;
                checkCheckBox.Checked = true;
                checkCheckBox.Enabled = true;
            }
        }

        private void checkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCheckBox.Checked)
            {
                cashCheckBox.Checked = false;
                PlaceholderHelper.AddPlaceholder(checkNumberTextBox, "Check No.");
                PlaceholderHelper.AddPlaceholder(bankNameTextBox, "Bank Name");
                PlaceholderHelper.AddPlaceholder(bankAccountNumberText, "Bank Account No.");
                chequePanel.Enabled = true;
                checkDateIssuedDateTimePicker.Enabled = true;
                checkDateIssuedDateTimePicker.Format = DateTimePickerFormat.Short;
                checkDateIssuedDateTimePicker.Value = DateTime.Now;
            }
            else
            {
                checkDateIssuedDateTimePicker.Enabled = false;

                checkDateIssuedDateTimePicker.Format = DateTimePickerFormat.Custom;
                checkDateIssuedDateTimePicker.CustomFormat = " ";


                chequePanel.Enabled = false;
                cashCheckBox.Checked = true;
            }
        }

        private void FormatDataGridView(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Arial", 10);
            dgv.EnableHeadersVisualStyles = false;
        }

        private void searchAccountNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void thirtyQuantityLabel_Click(object sender, EventArgs e)
        {

        }

        private void collectingOfficerNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void accountDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Only format once per row (check if you're on the first column, or skip if you like)
            if (e.RowIndex >= 0 && accountDataGridView.Rows[e.RowIndex].Cells["status"].Value != null)
            {
                string status = accountDataGridView.Rows[e.RowIndex].Cells["status"].Value.ToString().Trim().ToLower();

                if (status == "disconnected")
                {
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204, 204);
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; // Optional
                }
                else if (status == "active")
                {
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 255, 204);
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; // Optional
                }
                else
                {
                    // Reset for other statuses
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    accountDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void accountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void accountDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void discountCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void sfcInstallmentTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private string defaultDiscount;
        private string defaultDiscountName;
        private string defaultTax;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Parse meterConsumed safely
            int meterConsumed = 0;
            int.TryParse(meterConsumedReadingTextBox.Text?.Trim(), out meterConsumed);

            // Parse serviceId safely
            if (int.TryParse(serviceIDLabel.Text?.Trim(), out int serviceId))
            {
                if (freeWaterCheckBox.Checked)
                {
                    discountedPercentLabel.Text = "100%";
                    discountNameLabel.Text = "FREE WATER";
                    taxExemptedPercentLabel.Text = "0%";
                }
                else
                {
                    discountedPercentLabel.Text = defaultDiscount;
                    discountNameLabel.Text = defaultDiscountName;
                    taxExemptedPercentLabel.Text = defaultTax;
                }

                // Always call Populate after setting discount
                PopulateServiceRateLabels(serviceId, meterConsumed);
            }
        }

        private void bankNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void penaltyAmountLabel2_Click(object sender, EventArgs e)
        {

        }

        private void refreshPaymentsTodayButton_Click(object sender, EventArgs e)
        {
            LoadPaymentsToday();
        }

        private void freeWaterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            freeWaterTextBox.Enabled = freeWaterCheckBox.Checked;

            if (!freeWaterCheckBox.Checked)
            {
                freeWaterTextBox.Text = ""; // This clears the free water input and triggers update
            }
        }



        private void collectionTotalAmountPaidTextBox_MouseLeave(object sender, EventArgs e)
        {

        }

        private void collectionOtherPaymentTextBox_TextChanged(object sender, EventArgs e)
        {


            if (decimal.TryParse(collectionOtherPaymentTextBox.Text, out decimal otherPayment))
                paymentFroOthersLabel.Text = otherPayment.ToString("N2");
            else
                paymentFroOthersLabel.Text = "0.00";

            if (!int.TryParse(serviceIDLabel.Text.Trim(), out int serviceID))
                return;

            if (!int.TryParse(meterConsumedReadingTextBox.Text.Trim(), out int totalWaterConsumed))
                return;

            PopulateServiceRateLabels2(serviceID, totalWaterConsumed);
            CalculateTotal();
        }


        private void collectionSCFTextBox_TextChanged(object sender, EventArgs e) 
        {
            CalculateTotal();
        }

        private void collectionSCFTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void collectionOtherPaymentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void presentReadingTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void presentReadingTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void freeWaterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void sfcInstallmentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void totalPaidAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(collectionOtherPaymentTextBox.Text, out decimal otherPayment))
                paymentFroOthersLabel.Text = otherPayment.ToString("N2");
            else
                paymentFroOthersLabel.Text = "0.00";

            if (!int.TryParse(serviceIDLabel.Text.Trim(), out int serviceID))
                return;

            if (!int.TryParse(meterConsumedReadingTextBox.Text.Trim(), out int totalWaterConsumed))
                return;

            // Enable the button if totalPaidAmountTextBox is NOT empty or zero
            if (decimal.TryParse(totalPaidAmountTextBox.Text.Trim(), out decimal totalPaid) && totalPaid > 0)
            {
                billPaidButton.Enabled = true;
            }
            else
            {
                billPaidButton.Enabled = false;
            }
        }

        private void paymentForSCFTextBox_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(paymentForSCFTextBox.Text, out decimal value))
            {
                collectionSCFTextBox.Text = value.ToString("N2"); 
            }
            else
            {
                collectionSCFTextBox.Text = "0.00";
            }
        }

        private void paymentForSCFTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow: number keys, decimal point, comma, backspace, delete, arrow keys, tab
            bool isNumberKey = (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                               (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);
            bool isAllowedSymbol = e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Oemcomma;
            bool isControlKey = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Tab;

            if (!isNumberKey && !isAllowedSymbol && !isControlKey)
            {
                e.SuppressKeyPress = true; // Block the key
            }
        }

        private void paymentForBillingTextBox_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(totalAmountDueLabel2.Text, out decimal totalAmountDue) &&
                decimal.TryParse(paymentForBillingTextBox.Text, out decimal paymentAmount))
            {
                if (paymentAmount > totalAmountDue)
                {
                    MessageBox.Show(
                        "Payment amount cannot exceed the total amount due.",
                        "Invalid Amount",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    // Reset the textbox to the max allowed value
                    paymentForBillingTextBox.Text = totalAmountDue.ToString();
                    paymentForBillingTextBox.SelectionStart = paymentForBillingTextBox.Text.Length;
                }
                // Calculate remaining balance
                decimal balance = totalAmountDue - paymentAmount;
                totalAmountBilledBalanceLabel.Text = balance.ToString("N2");
            }
            CalculateTotal();
        }



        private void paymentForBillingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow: number keys, decimal point, comma, backspace, delete, arrow keys, tab
            bool isNumberKey = (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                               (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);
            bool isAllowedSymbol = e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Oemcomma;
            bool isControlKey = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Tab;

            if (!isNumberKey && !isAllowedSymbol && !isControlKey)
            {
                e.SuppressKeyPress = true; // Block the key
            }
        }

        private void collectionOtherPaymentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow: number keys, decimal point, comma, backspace, delete, arrow keys, tab
            bool isNumberKey = (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                               (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);
            bool isAllowedSymbol = e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Oemcomma;
            bool isControlKey = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Tab;

            if (!isNumberKey && !isAllowedSymbol && !isControlKey)
            {
                e.SuppressKeyPress = true; // Block the key
            }
        }

        private void paymentForBillingTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, delete, decimal point, and comma
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Block invalid input
            }
        }

        private decimal ParseDecimal(string value)
        {
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            // Try with local culture (handles commas for thousands separator)
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
                return result;

            return 0;
        }

        private void CalculateTotal()
        {
            decimal collectionSCF = ParseDecimal(collectionSCFTextBox.Text);
            decimal paymentForBilling = ParseDecimal(paymentForBillingTextBox.Text);
            decimal paymentForOthers = ParseDecimal(paymentFroOthersLabel.Text);

            decimal total = collectionSCF + paymentForBilling + paymentForOthers;

            // Example: Show in a label
            totalPaidAmountTextBox.Text = total.ToString("N2");
        }
    }
}