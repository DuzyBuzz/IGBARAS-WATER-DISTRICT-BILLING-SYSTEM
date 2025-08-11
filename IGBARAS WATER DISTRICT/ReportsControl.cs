using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class ReportsControl : UserControl
    {
        // Cache loaded reports to avoid reloading
        private readonly Dictionary<string, ReportDocument> loadedReports = new Dictionary<string, ReportDocument>();

        // Path to your Access MDB database file
        private readonly string dbFullPath = Path.Combine(Application.StartupPath, @"..\Database\Datafile.mdb");

        public ReportsControl()
        {
            InitializeComponent();
        }

        private void ReportsControl_Load(object sender, EventArgs e)
        {
            // Load Aging of Accounts report immediately on form load
            LoadReportToViewer("AgingOfAccountsReport.rpt", agingOfAccountsTab, agingCrystalReportViewer);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check which tab is selected and load corresponding report
            if (tabControl1.SelectedTab == dailyBillingTab)
            {
                LoadReportToViewer("DailyBillingReport.rpt", dailyBillingTab, dailyBillingCrystalReportViewer);
            }
            else if (tabControl1.SelectedTab == agingOfAccountsTab)
            {
                LoadReportToViewer("AgingOfAccountsReport.rpt", agingOfAccountsTab, agingCrystalReportViewer);
            }
            else if (tabControl1.SelectedTab == dailyCollectionTab) // ✅ Add your Daily Collection tab here
            {
                LoadReportToViewer("DailyCollectionReport.rpt", dailyCollectionTab, dailyBillingCrystalReportViewer);
            }
        }

        /// <summary>
        /// Loads the specified Crystal Report into the provided viewer and caches it.
        /// </summary>
        /// <param name="reportFileName">Report file name (must exist in the Reports folder).</param>
        /// <param name="tabPage">The TabPage this report belongs to.</param>
        /// <param name="viewer">The CrystalReportViewer control to display the report.</param>
        private void LoadReportToViewer(string reportFileName, TabPage tabPage, CrystalDecisions.Windows.Forms.CrystalReportViewer viewer)
        {
            try
            {
                // If already loaded, just set it to the viewer
                if (loadedReports.ContainsKey(reportFileName))
                {
                    viewer.ReportSource = loadedReports[reportFileName];
                    viewer.RefreshReport();
                    return;
                }

                // Load the report
                var report = ReportHelper.LoadReport(reportFileName);

                if (report == null)
                {
                    MessageBox.Show($"Failed to load report: {reportFileName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Set the database connection info
                SetDatabaseLocation(report);

                // Cache the report
                loadedReports[reportFileName] = report;

                // Display the report
                viewer.ReportSource = report;
                viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report {reportFileName}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ServerName = "",
                DatabaseName = dbFullPath,
                Type = ConnectionInfoType.CRQE,
                AllowCustomConnection = true
            };

            foreach (Table table in report.Database.Tables)
            {
                TableLogOnInfo logOnInfo = table.LogOnInfo;
                logOnInfo.ConnectionInfo = connInfo;
                table.ApplyLogOnInfo(logOnInfo);
                table.Location = dbFullPath;
            }
        }
    }
}
