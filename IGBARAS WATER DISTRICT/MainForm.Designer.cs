// Project: IGBARAS Water District Billing System
// Type: WinForms (.NET Framework 4.8)
// File: MainForm.Designer.cs

using System.Drawing;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel sidebarPanel;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.billingAndPaymentsButton = new System.Windows.Forms.Button();
            this.billSettingsButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.reportsButton = new System.Windows.Forms.Button();
            this.accountsButton = new System.Windows.Forms.Button();
            this.billingButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.AutoScroll = true;
            this.sidebarPanel.BackColor = System.Drawing.Color.White;
            this.sidebarPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sidebarPanel.Controls.Add(this.billingAndPaymentsButton);
            this.sidebarPanel.Controls.Add(this.billSettingsButton);
            this.sidebarPanel.Controls.Add(this.settingsButton);
            this.sidebarPanel.Controls.Add(this.reportsButton);
            this.sidebarPanel.Controls.Add(this.accountsButton);
            this.sidebarPanel.Controls.Add(this.billingButton);
            this.sidebarPanel.Controls.Add(this.panel1);
            this.sidebarPanel.Controls.Add(this.logoutButton);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(206, 986);
            this.sidebarPanel.TabIndex = 1;
            // 
            // billingAndPaymentsButton
            // 
            this.billingAndPaymentsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.billingAndPaymentsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.billingAndPaymentsButton.FlatAppearance.BorderSize = 0;
            this.billingAndPaymentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.billingAndPaymentsButton.Font = new System.Drawing.Font("Arial", 12F);
            this.billingAndPaymentsButton.Location = new System.Drawing.Point(0, 344);
            this.billingAndPaymentsButton.Margin = new System.Windows.Forms.Padding(50);
            this.billingAndPaymentsButton.Name = "billingAndPaymentsButton";
            this.billingAndPaymentsButton.Size = new System.Drawing.Size(202, 45);
            this.billingAndPaymentsButton.TabIndex = 16;
            this.billingAndPaymentsButton.Text = "📝 Billing and Payments";
            this.billingAndPaymentsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.billingAndPaymentsButton.UseVisualStyleBackColor = false;
            this.billingAndPaymentsButton.Click += new System.EventHandler(this.billingAndPaymentsButton_Click);
            // 
            // billSettingsButton
            // 
            this.billSettingsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.billSettingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.billSettingsButton.FlatAppearance.BorderSize = 0;
            this.billSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.billSettingsButton.Font = new System.Drawing.Font("Arial", 12F);
            this.billSettingsButton.Location = new System.Drawing.Point(0, 299);
            this.billSettingsButton.Margin = new System.Windows.Forms.Padding(50);
            this.billSettingsButton.Name = "billSettingsButton";
            this.billSettingsButton.Size = new System.Drawing.Size(202, 45);
            this.billSettingsButton.TabIndex = 15;
            this.billSettingsButton.Text = "🧮Bill Settings";
            this.billSettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.billSettingsButton.UseVisualStyleBackColor = false;
            this.billSettingsButton.Click += new System.EventHandler(this.billSettingsButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.settingsButton.Font = new System.Drawing.Font("Arial", 12F);
            this.settingsButton.Location = new System.Drawing.Point(0, 892);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(50);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(202, 45);
            this.settingsButton.TabIndex = 14;
            this.settingsButton.Text = "⚙️ Settings";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // reportsButton
            // 
            this.reportsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.reportsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportsButton.FlatAppearance.BorderSize = 0;
            this.reportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reportsButton.Font = new System.Drawing.Font("Arial", 12F);
            this.reportsButton.Location = new System.Drawing.Point(0, 254);
            this.reportsButton.Margin = new System.Windows.Forms.Padding(50);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(202, 45);
            this.reportsButton.TabIndex = 13;
            this.reportsButton.Text = "📝 Reports";
            this.reportsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportsButton.UseVisualStyleBackColor = false;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // accountsButton
            // 
            this.accountsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.accountsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.accountsButton.FlatAppearance.BorderSize = 0;
            this.accountsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.accountsButton.Font = new System.Drawing.Font("Arial", 12F);
            this.accountsButton.Location = new System.Drawing.Point(0, 209);
            this.accountsButton.Margin = new System.Windows.Forms.Padding(50);
            this.accountsButton.Name = "accountsButton";
            this.accountsButton.Size = new System.Drawing.Size(202, 45);
            this.accountsButton.TabIndex = 9;
            this.accountsButton.Text = "👥 Concessionaire";
            this.accountsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.accountsButton.UseVisualStyleBackColor = false;
            this.accountsButton.Click += new System.EventHandler(this.accountsButton_Click);
            // 
            // billingButton
            // 
            this.billingButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.billingButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.billingButton.FlatAppearance.BorderSize = 0;
            this.billingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.billingButton.Font = new System.Drawing.Font("Arial", 12F);
            this.billingButton.Location = new System.Drawing.Point(0, 164);
            this.billingButton.Margin = new System.Windows.Forms.Padding(50);
            this.billingButton.Name = "billingButton";
            this.billingButton.Size = new System.Drawing.Size(202, 45);
            this.billingButton.TabIndex = 7;
            this.billingButton.Text = "💸 Billing Invoice";
            this.billingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.billingButton.UseVisualStyleBackColor = false;
            this.billingButton.Click += new System.EventHandler(this.billingButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 164);
            this.panel1.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.usernameLabel);
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(35, 15);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(130, 127);
            this.panel7.TabIndex = 8;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(16, 101);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(93, 19);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "IGD Official";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(35, 127);
            this.panel5.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(165, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(35, 127);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 20);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 15);
            this.panel2.TabIndex = 2;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.Firebrick;
            this.logoutButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Arial", 12F);
            this.logoutButton.ForeColor = System.Drawing.SystemColors.Control;
            this.logoutButton.Location = new System.Drawing.Point(0, 937);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(50);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(202, 45);
            this.logoutButton.TabIndex = 5;
            this.logoutButton.Text = "⍈ Logout";
            this.logoutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(206, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1378, 986);
            this.mainPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1584, 986);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IGBARAS Water District Billing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sidebarPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button logoutButton;
        private Button accountsButton;
        private Button billingButton;
        private Panel panel1;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel7;
        private PictureBox pictureBox1;
        public Panel mainPanel;
        private Button reloadButton;
        private Button reportsButton;
        private Button settingsButton;
        private Label usernameLabel;
        private Button billSettingsButton;
        private Button billingAndPaymentsButton;
    }
}
