using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.IO;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class ReportsControl : UserControl
    {
        // Keep loaded reports as class members to reuse
        private ReportDocument agingReport;
        private ReportDocument dailyBillingReport;

        // Path to your Access MDB database file
        private readonly string dbFullPath = Path.Combine(Application.StartupPath, @"..\Database\Datafile.mdb");

        public ReportsControl()
        {
            InitializeComponent();

        }

        private void ReportsControl_Load(object sender, EventArgs e)
        {
            // Load and show Aging report immediately on load
            agingReport = ReportHelper.LoadReport("AgingOfAccountsReport.rpt");

            if (agingReport != null)
            {
                SetDatabaseLocation(agingReport);

                // Assign to viewer on Aging tab (crystalReportViewer1)
                crystalReportViewer1.ReportSource = agingReport;
                crystalReportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Failed to load Aging of Accounts report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check which tab is selected by comparing references
            if (tabControl1.SelectedTab == dailyBillingTab) // Replace with your actual Daily Billing tab name
            {
                // Load Daily Billing report only once on first tab selection
                if (dailyBillingReport == null)
                {
                    dailyBillingReport = ReportHelper.LoadReport("DailyBillingReport.rpt");

                    if (dailyBillingReport != null)
                    {
                        SetDatabaseLocation(dailyBillingReport);
                    }
                    else
                    {
                        MessageBox.Show("Failed to load Daily Billing report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Show the Daily Billing report in crystalReportViewer2 on Daily Billing tab
                crystalReportViewer2.ReportSource = dailyBillingReport;
                crystalReportViewer2.RefreshReport();
            }
            else if (tabControl1.SelectedTab == agingOfAccountsTab) // Replace with your actual Aging tab name
            {
                // Show Aging report again if user switches back to Aging tab
                if (agingReport != null)
                {
                    crystalReportViewer1.ReportSource = agingReport;
                    crystalReportViewer1.RefreshReport();
                }
            }
        }

        /// <summary>
        /// Sets the database location and connection info for the given report document.
        /// </summary>
        /// <param name="report">The ReportDocument to set connection info for.</param>
        private void SetDatabaseLocation(ReportDocument report)
        {
            ConnectionInfo connInfo = new ConnectionInfo
            {
                ServerName = "", // For Access MDB, this is empty
                DatabaseName = dbFullPath,
                Type = ConnectionInfoType.CRQE,
                AllowCustomConnection = true
            };

            foreach (Table table in report.Database.Tables)
            {
                TableLogOnInfo logOnInfo = table.LogOnInfo;
                logOnInfo.ConnectionInfo = connInfo;
                table.ApplyLogOnInfo(logOnInfo);
                table.Location = dbFullPath; // Important for Access DB
            }
        }
    }
}
