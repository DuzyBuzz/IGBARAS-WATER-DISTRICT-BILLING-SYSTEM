using System.Drawing;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    partial class BillSettingsControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.zoneDataGridView = new System.Windows.Forms.DataGridView();
            this.ZoneID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.serviceDataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.discountDataGridView = new System.Windows.Forms.DataGridView();
            this.DiscountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.settingsDataGidView = new System.Windows.Forms.DataGridView();
            this.SettingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.applyAllChangesButton = new System.Windows.Forms.Button();
            this.undoAllButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ServiceiD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoneDataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataGridView)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountDataGridView)).BeginInit();
            this.panel16.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsDataGidView)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 807);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1177, 803);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1171, 401);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.96499F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.03501F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1171, 359);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.40105F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.59895F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(825, 353);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel14);
            this.panel6.Controls.Add(this.zoneDataGridView);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(517, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(305, 347);
            this.panel6.TabIndex = 1;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label4);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(305, 23);
            this.panel14.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Zone";
            // 
            // zoneDataGridView
            // 
            this.zoneDataGridView.AllowUserToOrderColumns = true;
            this.zoneDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoneDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.zoneDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zoneDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zoneDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ZoneID});
            this.zoneDataGridView.Location = new System.Drawing.Point(3, 29);
            this.zoneDataGridView.Name = "zoneDataGridView";
            this.zoneDataGridView.Size = new System.Drawing.Size(299, 315);
            this.zoneDataGridView.TabIndex = 1;
            // 
            // ZoneID
            // 
            this.ZoneID.DataPropertyName = "ZoneID";
            this.ZoneID.HeaderText = "ZoneID";
            this.ZoneID.Name = "ZoneID";
            this.ZoneID.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel13);
            this.panel5.Controls.Add(this.serviceDataGridView);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(508, 347);
            this.panel5.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label3);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(508, 23);
            this.panel13.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Service";
            // 
            // serviceDataGridView
            // 
            this.serviceDataGridView.AllowUserToOrderColumns = true;
            this.serviceDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.serviceDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.serviceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceiD});
            this.serviceDataGridView.Location = new System.Drawing.Point(0, 29);
            this.serviceDataGridView.Name = "serviceDataGridView";
            this.serviceDataGridView.Size = new System.Drawing.Size(505, 315);
            this.serviceDataGridView.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.panel8, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(834, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.7537F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.2463F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(334, 353);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.discountDataGridView);
            this.panel8.Controls.Add(this.panel16);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 178);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(328, 172);
            this.panel8.TabIndex = 1;
            // 
            // discountDataGridView
            // 
            this.discountDataGridView.AllowUserToAddRows = false;
            this.discountDataGridView.AllowUserToDeleteRows = false;
            this.discountDataGridView.AllowUserToOrderColumns = true;
            this.discountDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.discountDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.discountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.discountDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DiscountID,
            this.DiscountName,
            this.Discount});
            this.discountDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.discountDataGridView.Location = new System.Drawing.Point(0, 23);
            this.discountDataGridView.Name = "discountDataGridView";
            this.discountDataGridView.Size = new System.Drawing.Size(328, 149);
            this.discountDataGridView.TabIndex = 1;
            // 
            // DiscountID
            // 
            this.DiscountID.DataPropertyName = "DiscountID";
            this.DiscountID.HeaderText = "DiscountID";
            this.DiscountID.Name = "DiscountID";
            this.DiscountID.Visible = false;
            // 
            // DiscountName
            // 
            this.DiscountName.DataPropertyName = "DiscountName";
            this.DiscountName.HeaderText = "Discount Name";
            this.DiscountName.Name = "DiscountName";
            this.DiscountName.ReadOnly = true;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.label6);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(328, 23);
            this.panel16.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 23);
            this.label6.TabIndex = 21;
            this.label6.Text = "Discounts";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel15);
            this.panel7.Controls.Add(this.settingsDataGidView);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(328, 169);
            this.panel7.TabIndex = 0;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label5);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(328, 23);
            this.panel15.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Penalty and Tax";
            // 
            // settingsDataGidView
            // 
            this.settingsDataGidView.AllowUserToAddRows = false;
            this.settingsDataGidView.AllowUserToDeleteRows = false;
            this.settingsDataGidView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsDataGidView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.settingsDataGidView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.settingsDataGidView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.settingsDataGidView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SettingID});
            this.settingsDataGidView.Location = new System.Drawing.Point(3, 29);
            this.settingsDataGidView.Name = "settingsDataGidView";
            this.settingsDataGidView.Size = new System.Drawing.Size(322, 137);
            this.settingsDataGidView.TabIndex = 2;
            // 
            // SettingID
            // 
            this.SettingID.DataPropertyName = "SettingID";
            this.SettingID.HeaderText = "SettingID";
            this.SettingID.Name = "SettingID";
            this.SettingID.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.applyAllChangesButton);
            this.panel3.Controls.Add(this.undoAllButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1171, 42);
            this.panel3.TabIndex = 18;
            // 
            // applyAllChangesButton
            // 
            this.applyAllChangesButton.BackColor = System.Drawing.Color.SteelBlue;
            this.applyAllChangesButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.applyAllChangesButton.ForeColor = System.Drawing.Color.White;
            this.applyAllChangesButton.Location = new System.Drawing.Point(873, 0);
            this.applyAllChangesButton.Name = "applyAllChangesButton";
            this.applyAllChangesButton.Size = new System.Drawing.Size(142, 42);
            this.applyAllChangesButton.TabIndex = 17;
            this.applyAllChangesButton.Text = "✏️ Apply Changes";
            this.applyAllChangesButton.UseVisualStyleBackColor = false;
            this.applyAllChangesButton.Click += new System.EventHandler(this.applyAllChangesButton_Click);
            // 
            // undoAllButton
            // 
            this.undoAllButton.BackColor = System.Drawing.Color.Brown;
            this.undoAllButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.undoAllButton.ForeColor = System.Drawing.Color.White;
            this.undoAllButton.Location = new System.Drawing.Point(1015, 0);
            this.undoAllButton.Name = "undoAllButton";
            this.undoAllButton.Size = new System.Drawing.Size(156, 42);
            this.undoAllButton.TabIndex = 16;
            this.undoAllButton.Text = "↩ Undo Changes";
            this.undoAllButton.UseVisualStyleBackColor = false;
            this.undoAllButton.Click += new System.EventHandler(this.undoAllButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 410);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1171, 390);
            this.panel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoScroll = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1171, 390);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // ServiceiD
            // 
            this.ServiceiD.DataPropertyName = "ServiceiD";
            this.ServiceiD.HeaderText = "ServiceID";
            this.ServiceiD.Name = "ServiceiD";
            this.ServiceiD.ReadOnly = true;
            // 
            // BillSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "BillSettingsControl";
            this.Size = new System.Drawing.Size(1181, 807);
            this.Load += new System.EventHandler(this.BillSettingsControl_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoneDataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataGridView)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.discountDataGridView)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsDataGidView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Button applyAllChangesButton;
        private Button undoAllButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel6;
        private Panel panel14;
        private Label label4;
        private DataGridView zoneDataGridView;
        private DataGridViewTextBoxColumn ZoneID;
        private Panel panel5;
        private Panel panel13;
        private Label label3;
        private DataGridView serviceDataGridView;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel8;
        private Panel panel16;
        private Label label6;
        private DataGridView discountDataGridView;
        private Panel panel7;
        private Panel panel15;
        private Label label5;
        private DataGridView settingsDataGidView;
        private DataGridViewTextBoxColumn SettingID;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel5;
        private DataGridViewTextBoxColumn DiscountID;
        private DataGridViewTextBoxColumn DiscountName;
        private DataGridViewTextBoxColumn Discount;
        private DataGridViewTextBoxColumn ServiceiD;
    }
}
