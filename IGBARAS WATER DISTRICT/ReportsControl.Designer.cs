using System.Drawing;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    partial class ReportsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.agingOfAccountsTab = new System.Windows.Forms.TabPage();
            this.agingCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dailyBillingTab = new System.Windows.Forms.TabPage();
            this.dailyBillingCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.monthlyBillingTab = new System.Windows.Forms.TabPage();
            this.crystalReportViewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dailyCollectionTab = new System.Windows.Forms.TabPage();
            this.dailyCollectionCrystalReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.monthlyCollectionTab = new System.Windows.Forms.TabPage();
            this.monthlyCollectionCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabControl1.SuspendLayout();
            this.agingOfAccountsTab.SuspendLayout();
            this.dailyBillingTab.SuspendLayout();
            this.monthlyBillingTab.SuspendLayout();
            this.dailyCollectionTab.SuspendLayout();
            this.monthlyCollectionTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.agingOfAccountsTab);
            this.tabControl1.Controls.Add(this.dailyBillingTab);
            this.tabControl1.Controls.Add(this.monthlyBillingTab);
            this.tabControl1.Controls.Add(this.dailyCollectionTab);
            this.tabControl1.Controls.Add(this.monthlyCollectionTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1181, 807);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // agingOfAccountsTab
            // 
            this.agingOfAccountsTab.Controls.Add(this.agingCrystalReportViewer);
            this.agingOfAccountsTab.Location = new System.Drawing.Point(4, 29);
            this.agingOfAccountsTab.Name = "agingOfAccountsTab";
            this.agingOfAccountsTab.Padding = new System.Windows.Forms.Padding(3);
            this.agingOfAccountsTab.Size = new System.Drawing.Size(1173, 774);
            this.agingOfAccountsTab.TabIndex = 0;
            this.agingOfAccountsTab.Text = "Aging of Accounts";
            this.agingOfAccountsTab.UseVisualStyleBackColor = true;
            // 
            // agingCrystalReportViewer
            // 
            this.agingCrystalReportViewer.ActiveViewIndex = -1;
            this.agingCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.agingCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.agingCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agingCrystalReportViewer.Location = new System.Drawing.Point(3, 3);
            this.agingCrystalReportViewer.Name = "agingCrystalReportViewer";
            this.agingCrystalReportViewer.Size = new System.Drawing.Size(1167, 768);
            this.agingCrystalReportViewer.TabIndex = 0;
            // 
            // dailyBillingTab
            // 
            this.dailyBillingTab.Controls.Add(this.dailyBillingCrystalReportViewer);
            this.dailyBillingTab.Location = new System.Drawing.Point(4, 29);
            this.dailyBillingTab.Name = "dailyBillingTab";
            this.dailyBillingTab.Size = new System.Drawing.Size(1173, 774);
            this.dailyBillingTab.TabIndex = 3;
            this.dailyBillingTab.Text = "Daily Billing";
            this.dailyBillingTab.UseVisualStyleBackColor = true;
            // 
            // dailyBillingCrystalReportViewer
            // 
            this.dailyBillingCrystalReportViewer.ActiveViewIndex = -1;
            this.dailyBillingCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dailyBillingCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.dailyBillingCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailyBillingCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.dailyBillingCrystalReportViewer.Name = "dailyBillingCrystalReportViewer";
            this.dailyBillingCrystalReportViewer.Size = new System.Drawing.Size(1173, 774);
            this.dailyBillingCrystalReportViewer.TabIndex = 0;
            this.dailyBillingCrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.ParameterPanel;
            // 
            // monthlyBillingTab
            // 
            this.monthlyBillingTab.Controls.Add(this.crystalReportViewer3);
            this.monthlyBillingTab.Location = new System.Drawing.Point(4, 29);
            this.monthlyBillingTab.Name = "monthlyBillingTab";
            this.monthlyBillingTab.Size = new System.Drawing.Size(1173, 774);
            this.monthlyBillingTab.TabIndex = 4;
            this.monthlyBillingTab.Text = "Monthly Billing";
            this.monthlyBillingTab.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer3
            // 
            this.crystalReportViewer3.ActiveViewIndex = -1;
            this.crystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer3.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer3.Name = "crystalReportViewer3";
            this.crystalReportViewer3.Size = new System.Drawing.Size(1173, 774);
            this.crystalReportViewer3.TabIndex = 0;
            this.crystalReportViewer3.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.ParameterPanel;
            this.crystalReportViewer3.Load += new System.EventHandler(this.crystalReportViewer3_Load);
            // 
            // dailyCollectionTab
            // 
            this.dailyCollectionTab.Controls.Add(this.dailyCollectionCrystalReport);
            this.dailyCollectionTab.Location = new System.Drawing.Point(4, 29);
            this.dailyCollectionTab.Name = "dailyCollectionTab";
            this.dailyCollectionTab.Padding = new System.Windows.Forms.Padding(3);
            this.dailyCollectionTab.Size = new System.Drawing.Size(1173, 774);
            this.dailyCollectionTab.TabIndex = 1;
            this.dailyCollectionTab.Text = "Daily Collection";
            this.dailyCollectionTab.UseVisualStyleBackColor = true;
            // 
            // dailyCollectionCrystalReport
            // 
            this.dailyCollectionCrystalReport.ActiveViewIndex = -1;
            this.dailyCollectionCrystalReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dailyCollectionCrystalReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.dailyCollectionCrystalReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailyCollectionCrystalReport.Location = new System.Drawing.Point(3, 3);
            this.dailyCollectionCrystalReport.Name = "dailyCollectionCrystalReport";
            this.dailyCollectionCrystalReport.Size = new System.Drawing.Size(1167, 768);
            this.dailyCollectionCrystalReport.TabIndex = 0;
            this.dailyCollectionCrystalReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.ParameterPanel;
            // 
            // monthlyCollectionTab
            // 
            this.monthlyCollectionTab.Controls.Add(this.monthlyCollectionCrystalReportViewer);
            this.monthlyCollectionTab.Location = new System.Drawing.Point(4, 29);
            this.monthlyCollectionTab.Name = "monthlyCollectionTab";
            this.monthlyCollectionTab.Size = new System.Drawing.Size(1173, 774);
            this.monthlyCollectionTab.TabIndex = 2;
            this.monthlyCollectionTab.Text = "Monthly Collection";
            this.monthlyCollectionTab.UseVisualStyleBackColor = true;
            // 
            // monthlyCollectionCrystalReportViewer
            // 
            this.monthlyCollectionCrystalReportViewer.ActiveViewIndex = -1;
            this.monthlyCollectionCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.monthlyCollectionCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.monthlyCollectionCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthlyCollectionCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.monthlyCollectionCrystalReportViewer.Name = "monthlyCollectionCrystalReportViewer";
            this.monthlyCollectionCrystalReportViewer.Size = new System.Drawing.Size(1173, 774);
            this.monthlyCollectionCrystalReportViewer.TabIndex = 0;
            this.monthlyCollectionCrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.ParameterPanel;
            // 
            // ReportsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Name = "ReportsControl";
            this.Size = new System.Drawing.Size(1181, 807);
            this.Load += new System.EventHandler(this.ReportsControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.agingOfAccountsTab.ResumeLayout(false);
            this.dailyBillingTab.ResumeLayout(false);
            this.monthlyBillingTab.ResumeLayout(false);
            this.dailyCollectionTab.ResumeLayout(false);
            this.monthlyCollectionTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage agingOfAccountsTab;
        private TabPage dailyCollectionTab;
        private TabPage dailyBillingTab;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer dailyBillingCrystalReportViewer;
        private TabPage monthlyBillingTab;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer dailyCollectionCrystalReport;
        private TabPage monthlyCollectionTab;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer monthlyCollectionCrystalReportViewer;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer agingCrystalReportViewer;
    }
}
