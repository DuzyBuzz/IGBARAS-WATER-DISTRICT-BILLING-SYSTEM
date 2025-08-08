using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT.Helpers
{
    internal class ReportHelper
    {
        /// <summary>
        /// Loads a Crystal Report from the Reports folder using only the filename.
        /// </summary>
        /// <param name="reportFileName">Example: "AgingReport.rpt"</param>
        /// <returns>ReportDocument object ready to use</returns>
        public static ReportDocument LoadReport(string reportFileName)
        {
            try
            {
                // Get full path to the report inside the Reports folder
                string reportPath = Path.Combine(Application.StartupPath, "Reports", reportFileName);

                // Optional: check if file exists
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Report file not found:\n" + reportPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Create and load the report
                ReportDocument report = new ReportDocument();
                report.Load(reportPath);
                return report;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report:\n" + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
