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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class CreateConcessionaireForm : Form
    {
        public CreateConcessionaireForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadZoneComboBox()
        {
            int districtNo = 1; // Replace with actual district if needed

            var zoneList = ZoneHelper.GetZoneCodeHelper(districtNo);

            zoneCodeComboBox.DataSource = zoneList;
            zoneCodeComboBox.DisplayMember = "ZoneCode"; // Shown: "01", "02", "11"
            zoneCodeComboBox.ValueMember = "ZoneCode";   // Internal value: same as displayed

            if (zoneCodeComboBox.Items.Count > 0)
                zoneCodeComboBox.SelectedIndex = 0;
        }
        private void LoadServiceIDComboBox()
        {
            var serviceList = ServiceHelper.GetServiceIDHelper();

            // Bind to ComboBox (e.g., serviceComboBox)
            serviceIDComboBox.DataSource = serviceList;
            serviceIDComboBox.DisplayMember = "ServiceID";  // What is shown in dropdown
            serviceIDComboBox.ValueMember = "ServiceID";    // Actual value you can retrieve
        }


        private void CreateConcessionaireForm_Load(object sender, EventArgs e)
        {
            statusComboBox.SelectedIndex = 0;
            LoadZoneComboBox();
            LoadServiceIDComboBox();
            SetTabOrder();
            this.AcceptButton = submitButton;
        }

        private void serviceConnectionFeeTextBox_KeyDown(object sender, KeyEventArgs e)
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

        private void submitButton_Click(object sender, EventArgs e)
        {
            // Step 1: Validate required fields and notify which are missing
            var missingFields = new List<string>();

            if (string.IsNullOrWhiteSpace(accountNumberTextBox.Text))
                missingFields.Add("Account Number");
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
                missingFields.Add("First Name");
            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
                missingFields.Add("Last Name");
            if (string.IsNullOrWhiteSpace(addressTextBox.Text))
                missingFields.Add("Address");
            if (zoneCodeComboBox.SelectedIndex == -1)
                missingFields.Add("Zone Code");
            if (serviceIDComboBox.SelectedIndex == -1)
                missingFields.Add("Service ID");
            if (statusComboBox.SelectedIndex == -1)
                missingFields.Add("Status");
            if (string.IsNullOrWhiteSpace(serviceConnectionFeeTextBox.Text))
                missingFields.Add("Service Connection Fee");
            if (string.IsNullOrWhiteSpace(meterNoTextBox.Text))
                missingFields.Add("Meter No");

            if (missingFields.Count > 0)
            {
                MessageBox.Show(
                    "Please fill out the following required fields:\n\n" +
                    string.Join("\n", missingFields),
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Step 2: Format the Concessionaire Name -> LASTNAME, FIRSTNAME SUFFIX. MI.
            string suffix = string.IsNullOrWhiteSpace(sfxComboBox.Text) ? "" : $" {sfxComboBox.Text}";
            string middleInitial = string.IsNullOrWhiteSpace(miTextBox.Text) ? "" : $" {miTextBox.Text[0].ToString().ToUpper()}.";
            string concessionaireName = $"{lastNameTextBox.Text.ToUpper()}, {firstNameTextBox.Text.ToUpper()}{suffix.ToUpper()}{middleInitial}";

            try
            {
                using (var connection = new OleDbConnection(DbConfig.ConnectionString))
                {
                    connection.Open();

                    // Step 3: Check for duplicate AccountNo
                    string checkQuery = "SELECT COUNT(*) FROM Tb_Concessionaire WHERE AccountNo = @AccountNo";
                    using (var checkCmd = new OleDbCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@AccountNo", accountNumberTextBox.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("The Account Number already exists. Please use another one.",
                                "Duplicate Account No.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    // Step 3: Check for duplicate AccountNo
                    string checkMeterQuery = "SELECT COUNT(*) FROM Tb_Concessionaire WHERE MeterNo = @MeterNo";
                    using (var checkCmd = new OleDbCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@MeterNo", meterNoTextBox.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("The Meter Number already exists. Please use another one.",
                                "Duplicate Meter No.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Step 4: Ask for confirmation (show all details in custom dialog)
                    int valueColumn = 50;
                    string details =
                            $"ACCOUNT NO:{new string(' ', Math.Max(1, valueColumn - "ACCOUNT NO:".Length))}{accountNumberTextBox.Text.ToUpper()}\n" +
                            $"NAME:{new string(' ', Math.Max(1, valueColumn - "NAME:".Length))}{concessionaireName.ToUpper()}\n" +
                            $"ADDRESS:{new string(' ', Math.Max(1, valueColumn - "ADDRESS:".Length))}{addressTextBox.Text.ToUpper()}\n" +
                            $"ZONE CODE:{new string(' ', Math.Max(1, valueColumn - "ZONE CODE:".Length))}{zoneCodeComboBox.Text.ToUpper()}\n" +
                            $"SERVICE ID:{new string(' ', Math.Max(1, valueColumn - "SERVICE ID:".Length))}{serviceIDComboBox.SelectedValue.ToString().ToUpper()}\n" +
                            $"METER NO:{new string(' ', Math.Max(1, valueColumn - "METER NO:".Length))}{meterNoTextBox.Text.ToUpper()}\n" +
                            $"TAX EXEMPT:{new string(' ', Math.Max(1, valueColumn - "TAX EXEMPT:".Length))}{(taxExemptCheckBox.Checked ? "YES" : "NO")}\n" +
                            $"FIRST READING DATE:{new string(' ', Math.Max(1, valueColumn - "FIRST READING DATE:".Length))}{firstReadingDateDateTimePicker.Value:MM/dd/yyyy}\n" +
                            $"DUE EXEMPT:{new string(' ', Math.Max(1, valueColumn - "DUE EXEMPT:".Length))}{(dueExemptCheckBox.Checked ? "YES" : "NO")}\n" +
                            $"STATUS:{new string(' ', Math.Max(1, valueColumn - "STATUS:".Length))}{statusComboBox.Text.ToUpper()}\n" +
                            $"SERVICE CONNECTION FEE:{new string(' ', Math.Max(1, valueColumn - "SERVICE CONNECTION FEE:".Length))}{Convert.ToDecimal(serviceConnectionFeeTextBox.Text):N2}\n" +
                            $"SENIOR CITIZEN:{new string(' ', Math.Max(1, valueColumn - "SENIOR CITIZEN:".Length))}{(discountedCheckBox.Checked ? "YES" : "NO")}";

                    using (var confirmDialog = new ConfirmationDialog(details))
                    {
                        if (confirmDialog.ShowDialog() != DialogResult.Yes)
                        {
                            return; // user cancelled
                        }
                    }

                    // Step 5: Insert record
                    string insertQuery = @"
                        INSERT INTO Tb_Concessionaire
                        (AccountNo, ConcessionaireName, Address, ZoneCode, ServiceID, MeterNo, TaxExempt, 
                         FirstReadingDate, DueExempt, Status, SCF, SeniorCitizen)
                        VALUES
                        (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    using (var cmd = new OleDbCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("AccountNo", accountNumberTextBox.Text.Trim().ToUpper());
                        cmd.Parameters.AddWithValue("ConcessionaireName", concessionaireName);
                        cmd.Parameters.AddWithValue("Address", addressTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("ZoneCode", zoneCodeComboBox.Text);
                        cmd.Parameters.AddWithValue("ServiceID", int.Parse(serviceIDComboBox.SelectedValue.ToString())); // ensure numeric
                        cmd.Parameters.AddWithValue("MeterNo", meterNoTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("TaxExempt", taxExemptCheckBox.Checked);
                        cmd.Parameters.AddWithValue("FirstReadingDate", firstReadingDateDateTimePicker.Text);
                        cmd.Parameters.AddWithValue("DueExempt", dueExemptCheckBox.Checked); // bool works for Yes/No
                        cmd.Parameters.AddWithValue("Status", statusComboBox.Text);
                        cmd.Parameters.AddWithValue("SCF", Convert.ToDouble(serviceConnectionFeeTextBox.Text)); // double not decimal
                        cmd.Parameters.AddWithValue("SeniorCitizen", discountedCheckBox.Checked);


                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ask if user wants to add another
                    DialogResult addAnother = MessageBox.Show(
                        "Do you want to add another concessionaire?",
                        "Add Another",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (addAnother == DialogResult.Yes)
                    {
                        ClearAllFields();
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetTabOrder()
        {
            // Row 1 (Name fields, left to right)
            firstNameTextBox.TabIndex = 0;
            miTextBox.TabIndex = 1;
            lastNameTextBox.TabIndex = 2;
            sfxComboBox.TabIndex = 3;

            // Row 2 (Address)
            addressTextBox.TabIndex = 4;

            // Row 3 (Meter No)
            meterNoTextBox.TabIndex = 5;

            // Row 4 (Zone, Service, Status)
            zoneCodeComboBox.TabIndex = 6;
            serviceIDComboBox.TabIndex = 7;
            statusComboBox.TabIndex = 8;

            // Row 5 (Service Fee and Date)
            serviceConnectionFeeTextBox.TabIndex = 9;
            firstReadingDateDateTimePicker.TabIndex = 10;

            // Row 6 (Account No + Checkboxes)
            accountNumberTextBox.TabIndex = 11;
            taxExemptCheckBox.TabIndex = 12;
            dueExemptCheckBox.TabIndex = 13;
            discountedCheckBox.TabIndex = 14;

            // Optional: Submit button last
            submitButton.TabIndex = 15;
        }

        private void CreateConcessionaireForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ask user before closing
            DialogResult result = MessageBox.Show(
                "All the inputs will not be saved.\n\nDo you really want to exit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                // Cancel the closing
                e.Cancel = true;
            }
        }
        private void ClearAllFields()
        {
            accountNumberTextBox.Clear();
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            addressTextBox.Clear();
            meterNoTextBox.Clear();
            serviceConnectionFeeTextBox.Clear();
            sfxComboBox.SelectedIndex = -1;
            miTextBox.Clear();
            zoneCodeComboBox.SelectedIndex = 0;
            serviceIDComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndex = 0;
            taxExemptCheckBox.Checked = false;
            dueExemptCheckBox.Checked = false;
            discountedCheckBox.Checked = false;
            firstReadingDateDateTimePicker.Value = DateTime.Today;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void meterNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow numbers, numpad numbers, backspace, delete, arrows
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) &&
                !(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) &&
                e.KeyCode != Keys.Back &&
                e.KeyCode != Keys.Delete &&
                e.KeyCode != Keys.Left &&
                e.KeyCode != Keys.Right)
            {
                e.SuppressKeyPress = true; // block the key
            }
        }
    }
}
