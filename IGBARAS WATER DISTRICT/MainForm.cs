using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using IGBARAS_WATER_DISTRICT.Helpers;
using IGBARAS_WATER_DISTRICT.Reports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class MainForm : Form
    {
        // Dictionary to store the loaded user controls (optional, for reference)
        private Dictionary<string, UserControl> loadedControls = new Dictionary<string, UserControl>();

        // Keep track of currently displayed control
        private string currentControlName = string.Empty;
        private Dictionary<string, Button> sidebarButtons;

        public MainForm()
        {
            InitializeComponent();

            // Initialize the sidebar button dictionary
            sidebarButtons = new Dictionary<string, Button>
            {
                { "RealeaseBilling", billingButton },
                { "Accounts", accountsButton },
                { "Reports", reportsButton },
                { "BillSettings", billSettingsButton },
                { "Settings", settingsButton },
                { "BillingAndPayments", billingAndPaymentsButton },
            };
        }

        private void LoadControl(string controlName)
        {
            // 🚫 Avoid unnecessary action if same control is being loaded
            if (currentControlName == controlName)
                return;

            // 🧹 Remove old control if exists
            if (!string.IsNullOrEmpty(currentControlName) && loadedControls.ContainsKey(currentControlName))
            {
                var oldControl = loadedControls[currentControlName];
                mainPanel.Controls.Remove(oldControl);
                oldControl.Dispose();
                loadedControls.Remove(currentControlName);
            }

            currentControlName = controlName;

            // 🖍 Highlight the corresponding sidebar button
            HighlightActiveButton(controlName);

            // 🛠 Dynamically create a new control instance each time
            var type = Type.GetType($"IGBARAS_WATER_DISTRICT.{controlName}Control");

            if (type != null && type.IsSubclassOf(typeof(UserControl)))
            {
                var controlInstance = (UserControl)Activator.CreateInstance(type);
                controlInstance.Dock = DockStyle.Fill;

                // Add to panel and dictionary
                loadedControls[controlName] = controlInstance;
                mainPanel.Controls.Add(controlInstance);
                controlInstance.BringToFront();
            }
            else
            {
                MessageBox.Show($"Control '{controlName}' not found.");
            }
        }

        private void HighlightActiveButton(string controlName)
        {
            // Reset all buttons to default
            foreach (var btn in sidebarButtons.Values)
            {
                btn.BackColor = SystemColors.Control;
                btn.ForeColor = Color.Black;
                btn.Font = new Font(btn.Font, FontStyle.Regular);
            }

            // Highlight current button
            if (sidebarButtons.TryGetValue(controlName, out var activeButton))
            {
                activeButton.BackColor = Color.MediumSeaGreen;
                activeButton.ForeColor = Color.White;
                activeButton.Font = new Font(activeButton.Font, FontStyle.Bold);
            }
        }

        // Button click handlers
        private void settingsButton_Click(object sender, EventArgs e) => LoadControl("Settings");
        private void systemInformationButton_Click(object sender, EventArgs e) => LoadControl("SystemInformation");
        private void accountsButton_Click(object sender, EventArgs e) => LoadControl("Accounts");
        private void billingButton_Click(object sender, EventArgs e) => LoadControl("RealeaseBilling");
        private void billSettingsButton_Click(object sender, EventArgs e) => LoadControl("BillSettings");
        private void billingAndPaymentsButton_Click(object sender, EventArgs e) => LoadControl("BillingAndPayments");
        private void reportsButton_Click(object sender, EventArgs e) => LoadControl("Reports");

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadControl("RealeaseBilling");
            usernameLabel.Text = $"{UserCredentials.Fullname}";
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentControlName))
            {
                MessageBox.Show("No control currently loaded.", "Reload Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🧹 Remove the old control from panel
            if (loadedControls.ContainsKey(currentControlName))
            {
                var oldControl = loadedControls[currentControlName];
                mainPanel.Controls.Remove(oldControl);
                oldControl.Dispose();
                loadedControls.Remove(currentControlName);
            }

            LoadControl(currentControlName); // reload the same page
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout and return to the login screen?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login loginForm = new Login();
                loginForm.Show();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Optional: clean up resources if needed
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "You are about to close the application.\n\nDo you want to exit now?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                Application.ExitThread();
                Environment.Exit(0);
            }
        }
    }
}
