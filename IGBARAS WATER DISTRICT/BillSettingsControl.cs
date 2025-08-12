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
            AddDeleteContextMenu(serviceDataGridView, "Tb_Service", "ServiceID");
            AddDeleteContextMenu(settingsDataGidView, "Tb_Settings", "SettingID");
            AddDeleteContextMenu(zoneDataGridView, "Tb_Zone", "ZoneID");
            AddDeleteContextMenu(discountDataGridView, "Tb_Discount", "DiscountID");
        }

        private void BillSettingsControl_Load(object sender, EventArgs e)
        {
            ReloadAllTables();
            settingsDataGidView.AllowUserToAddRows = false;
            settingsDataGidView.RowHeadersVisible = false;
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

                // Always reload to mirror the database
                ReloadAllTables();
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

        private void undoAllButton_Click(object sender, EventArgs e)
        {
            ReloadAllTables();
        }

        // Helper to reload all tables
        private void ReloadAllTables()
        {
            TableLoaderHelper.LoadTableToGrid(serviceDataGridView, "Tb_Service");
            TableLoaderHelper.LoadTableToGrid(settingsDataGidView, "Tb_Settings");
            TableLoaderHelper.LoadTableToGrid(zoneDataGridView, "Tb_Zone");
            TableLoaderHelper.LoadTableToGrid(discountDataGridView, "Tb_Discount");
        }

        // Add right-click delete support to a DataGridView
        private void AddDeleteContextMenu(DataGridView dgv, string tableName, string idColumn)
        {
            var menu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("Delete Row");
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
                            ReloadAllTables();
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
    }
}
