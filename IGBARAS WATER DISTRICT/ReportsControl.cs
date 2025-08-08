using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class ReportsControl : UserControl
    {
        public ReportsControl() => InitializeComponent();

        private void ReportsControl_Load(object sender, EventArgs e)
        {
            // 1️⃣ Load your report from the Reports folder
            ReportDocument report = ReportHelper.LoadReport("AgingOfAccountsReport.rpt");

            if (report != null)
            {
                // 2️⃣ Build the relative path to your MDB file
                string dbFullPath = Path.Combine(Application.StartupPath, @"..\Database\Datafile.mdb");

                // 3️⃣ Overwrite the database location at runtime
                ConnectionInfo connInfo = new ConnectionInfo
                {
                    ServerName = "", // Empty for Access MDB
                    DatabaseName = dbFullPath,
                    Type = ConnectionInfoType.CRQE,
                    AllowCustomConnection = true
                };

                foreach (Table table in report.Database.Tables)
                {
                    TableLogOnInfo logOnInfo = table.LogOnInfo;
                    logOnInfo.ConnectionInfo = connInfo;
                    table.ApplyLogOnInfo(logOnInfo);

                    // Force the table to point to the new MDB location
                    table.Location = dbFullPath;
                }

                // 4️⃣ Display the report
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.RefreshReport();

            }

        }

    }

}
