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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dailyBillingTab = new System.Windows.Forms.TabPage();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.monthlyBillingTab = new System.Windows.Forms.TabPage();
            this.crystalReportViewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dailyCollectionTab = new System.Windows.Forms.TabPage();
            this.crystalReportViewer4 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.monthlyCollectionTab = new System.Windows.Forms.TabPage();
            this.crystalReportViewer5 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
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
            // 
            // agingOfAccountsTab
            // 
            this.agingOfAccountsTab.Controls.Add(this.crystalReportViewer1);
            this.agingOfAccountsTab.Location = new System.Drawing.Point(4, 29);
            this.agingOfAccountsTab.Name = "agingOfAccountsTab";
            this.agingOfAccountsTab.Padding = new System.Windows.Forms.Padding(3);
            this.agingOfAccountsTab.Size = new System.Drawing.Size(1173, 774);
            this.agingOfAccountsTab.TabIndex = 0;
            this.agingOfAccountsTab.Text = "Aging of Accounts";
            this.agingOfAccountsTab.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1167, 768);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // dailyBillingTab
            // 
            this.dailyBillingTab.Controls.Add(this.crystalReportViewer2);
            this.dailyBillingTab.Location = new System.Drawing.Point(4, 29);
            this.dailyBillingTab.Name = "dailyBillingTab";
            this.dailyBillingTab.Size = new System.Drawing.Size(1173, 774);
            this.dailyBillingTab.TabIndex = 3;
            this.dailyBillingTab.Text = "Daily Billing";
            this.dailyBillingTab.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(1173, 774);
            this.crystalReportViewer2.TabIndex = 0;
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
            // 
            // dailyCollectionTab
            // 
            this.dailyCollectionTab.Controls.Add(this.crystalReportViewer4);
            this.dailyCollectionTab.Location = new System.Drawing.Point(4, 29);
            this.dailyCollectionTab.Name = "dailyCollectionTab";
            this.dailyCollectionTab.Padding = new System.Windows.Forms.Padding(3);
            this.dailyCollectionTab.Size = new System.Drawing.Size(1173, 774);
            this.dailyCollectionTab.TabIndex = 1;
            this.dailyCollectionTab.Text = "Daily Collection";
            this.dailyCollectionTab.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer4
            // 
            this.crystalReportViewer4.ActiveViewIndex = -1;
            this.crystalReportViewer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer4.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer4.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer4.Name = "crystalReportViewer4";
            this.crystalReportViewer4.Size = new System.Drawing.Size(1167, 768);
            this.crystalReportViewer4.TabIndex = 0;
            // 
            // monthlyCollectionTab
            // 
            this.monthlyCollectionTab.Controls.Add(this.crystalReportViewer5);
            this.monthlyCollectionTab.Location = new System.Drawing.Point(4, 29);
            this.monthlyCollectionTab.Name = "monthlyCollectionTab";
            this.monthlyCollectionTab.Size = new System.Drawing.Size(1173, 774);
            this.monthlyCollectionTab.TabIndex = 2;
            this.monthlyCollectionTab.Text = "Monthly Collection";
            this.monthlyCollectionTab.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer5
            // 
            this.crystalReportViewer5.ActiveViewIndex = -1;
            this.crystalReportViewer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer5.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer5.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer5.Name = "crystalReportViewer5";
            this.crystalReportViewer5.Size = new System.Drawing.Size(1173, 774);
            this.crystalReportViewer5.TabIndex = 0;
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
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private TabPage monthlyBillingTab;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer4;
        private TabPage monthlyCollectionTab;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer5;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}
