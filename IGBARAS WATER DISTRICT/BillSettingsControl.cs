using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class BillSettingsControl : UserControl
    {
        public BillSettingsControl()
        {
            InitializeComponent();
        }

        private void BillSettingsControl_Load(object sender, EventArgs e)
        {
            TableLoaderHelper.LoadTableToGrid(serviceDataGridView, "Tb_Service");
            TableLoaderHelper.LoadTableToGrid(settingsDataGidView, "Tb_Settings");
            TableLoaderHelper.LoadTableToGrid(zoneDataGridView, "Tb_Zone");
            TableLoaderHelper.LoadTableToGrid(discountDataGridView, "Tb_Discount");

            //TableLoaderHelper.LoadTableToGrid(billingDataGridView, "Tb_Billing");
            //TableLoaderHelper.LoadTableToGrid(paymentsDataGridView, "Tb_Payments");


            settingsDataGidView.AllowUserToAddRows = false;
            settingsDataGidView.RowHeadersVisible = false;
        }

        // ✅ Service Section
        private void undoServiceButton_Click(object sender, EventArgs e)
        {
            TableLoaderHelper.LoadTableToGrid(serviceDataGridView, "Tb_Service");
        }

        private void applyServiceButton_Click(object sender, EventArgs e)
        {
            if (ConfirmUpdate("service settings"))
            {
                TableUpdaterHelper.UpdateTableFromGrid(serviceDataGridView, "Tb_Service", "ServiceID");
            }
        }

        // ✅ Settings Section
        private void settingsApplyButton_Click(object sender, EventArgs e)
        {
            if (ConfirmUpdate("system settings"))
            {
                TableUpdaterHelper.UpdateTableFromGrid(settingsDataGidView, "Tb_Settings", "SettingID");
            }
        }

        private void settingsUndoButton_Click(object sender, EventArgs e)
        {
            TableLoaderHelper.LoadTableToGrid(settingsDataGidView, "Tb_Settings");
        }

        // ✅ Discount Section
        private void discountApplyButton_Click(object sender, EventArgs e)
        {
            if (ConfirmUpdate("discount settings"))
            {
                TableUpdaterHelper.UpdateTableFromGrid(discountDataGridView, "Tb_Discount", "DiscountID");
            }
        }

        private void discountUndoButton_Click(object sender, EventArgs e)
        {
            TableLoaderHelper.LoadTableToGrid(discountDataGridView, "Tb_Discount");
        }

        // ✅ Zone Section
        private void zoneUndoButton_Click(object sender, EventArgs e)
        {
            TableLoaderHelper.LoadTableToGrid(zoneDataGridView, "Tb_Zone");
        }

        private void zoneApplyButton_Click(object sender, EventArgs e)
        {
            if (ConfirmUpdate("zone settings"))
            {
                TableUpdaterHelper.UpdateTableFromGrid(zoneDataGridView, "Tb_Zone", "ZoneID");
            }
        }

        // 📌 Reusable Confirmation Method
        private bool ConfirmUpdate(string sectionName)
        {
            DialogResult result = MessageBox.Show(
                $"You are about to apply changes to the {sectionName}.\n\n" +
                "Please confirm that all modifications are correct before proceeding.\n\n" +
                "Do you want to continue?",
                "Confirm Changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            return result == DialogResult.Yes;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }
        // Centralized Apply All Changes
        private void applyAllChangesButton_Click(object sender, EventArgs e)
        {
            if (!ConfirmAction("Are you sure you want to apply ALL pending changes? This will update Service, Settings, Discount, and Zone tables."))
                return;

            try
            {
                // Apply all updates
                TableUpdaterHelper.UpdateTableFromGrid(serviceDataGridView, "Tb_Service", "ServiceID");
                TableUpdaterHelper.UpdateTableFromGrid(settingsDataGidView, "Tb_Settings", "SettingID");
                TableUpdaterHelper.UpdateTableFromGrid(discountDataGridView, "Tb_Discount", "DiscountID");
                TableUpdaterHelper.UpdateTableFromGrid(zoneDataGridView, "Tb_Zone", "ZoneID");


                MessageBox.Show("All changes have been successfully applied.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while applying changes:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method for confirmation prompts
        private bool ConfirmAction(string message)
        {
            var result = MessageBox.Show(
                message,
                "Confirm Changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }
        //private void billingApplyButton_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show(
        //        "Are you sure you want to apply all changes to the Billing records?",
        //        "Confirm Update",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question
        //    );

        //    if (result == DialogResult.Yes)
        //    {
        //        TableUpdaterHelper.UpdateTableFromGrid(billingDataGridView, "Tb_Billing", "BillingID");
        //        MessageBox.Show("Billing records have been successfully updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void paymentsApplyButton_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show(
        //        "Are you sure you want to apply all changes to the Payments records?",
        //        "Confirm Update",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question
        //    );

        //    if (result == DialogResult.Yes)
        //    {
        //        TableUpdaterHelper.UpdateTableFromGrid(paymentsDataGridView, "Tb_Payments", "PaymentID");
        //        MessageBox.Show("Payments records have been successfully updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

    }
}
