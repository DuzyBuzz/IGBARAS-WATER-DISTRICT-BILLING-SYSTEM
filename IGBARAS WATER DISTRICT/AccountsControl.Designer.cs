using System.Drawing;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    partial class AccountsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.accountApplyButton = new System.Windows.Forms.Button();
            this.accountUndoButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchAccountNumberTextBox = new System.Windows.Forms.TextBox();
            this.zoneComboBox = new System.Windows.Forms.ComboBox();
            this.accountsDataGridView = new System.Windows.Forms.DataGridView();
            this.ConcessionaireID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConcessionaireName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZoneCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstReadingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeniorCitizen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TaxExempt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DueExempt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(518, 20);
            this.miniToolStrip.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 758F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1181, 807);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1175, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "IGBARAS WATER DISTRICT CONCESSIONAIRE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 52);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.329114F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1175, 752);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.accountsDataGridView, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.561993F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.438F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1169, 746);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel8.Controls.Add(this.accountApplyButton, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.accountUndoButton, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1163, 35);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // accountApplyButton
            // 
            this.accountApplyButton.BackColor = System.Drawing.Color.SteelBlue;
            this.accountApplyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountApplyButton.ForeColor = System.Drawing.Color.White;
            this.accountApplyButton.Location = new System.Drawing.Point(1018, 3);
            this.accountApplyButton.Name = "accountApplyButton";
            this.accountApplyButton.Size = new System.Drawing.Size(142, 29);
            this.accountApplyButton.TabIndex = 17;
            this.accountApplyButton.Text = "✏️ Apply Changes";
            this.accountApplyButton.UseVisualStyleBackColor = false;
            // 
            // accountUndoButton
            // 
            this.accountUndoButton.BackColor = System.Drawing.Color.Brown;
            this.accountUndoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountUndoButton.ForeColor = System.Drawing.Color.White;
            this.accountUndoButton.Location = new System.Drawing.Point(885, 3);
            this.accountUndoButton.Name = "accountUndoButton";
            this.accountUndoButton.Size = new System.Drawing.Size(127, 29);
            this.accountUndoButton.TabIndex = 16;
            this.accountUndoButton.Text = "↩ Undo Changes";
            this.accountUndoButton.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0862F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.913794F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 323F));
            this.tableLayoutPanel3.Controls.Add(this.clearButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.searchAccountNumberTextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.zoneComboBox, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(876, 29);
            this.tableLayoutPanel3.TabIndex = 18;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.White;
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearButton.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.Crimson;
            this.clearButton.Location = new System.Drawing.Point(343, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(31, 23);
            this.clearButton.TabIndex = 25;
            this.clearButton.Text = "❌";
            this.clearButton.UseVisualStyleBackColor = false;
            // 
            // searchAccountNumberTextBox
            // 
            this.searchAccountNumberTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchAccountNumberTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchAccountNumberTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchAccountNumberTextBox.Location = new System.Drawing.Point(3, 4);
            this.searchAccountNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.searchAccountNumberTextBox.Name = "searchAccountNumberTextBox";
            this.searchAccountNumberTextBox.Size = new System.Drawing.Size(334, 26);
            this.searchAccountNumberTextBox.TabIndex = 7;
            // 
            // zoneComboBox
            // 
            this.zoneComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoneComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoneComboBox.FormattingEnabled = true;
            this.zoneComboBox.Location = new System.Drawing.Point(380, 3);
            this.zoneComboBox.Name = "zoneComboBox";
            this.zoneComboBox.Size = new System.Drawing.Size(100, 26);
            this.zoneComboBox.TabIndex = 8;
            // 
            // accountsDataGridView
            // 
            this.accountsDataGridView.AllowUserToOrderColumns = true;
            this.accountsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.accountsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.accountsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConcessionaireID,
            this.AccountNo,
            this.ConcessionaireName,
            this.Address,
            this.ZoneCode,
            this.ServiceID,
            this.MeterNo,
            this.FirstReadingDate,
            this.SeniorCitizen,
            this.TaxExempt,
            this.DueExempt,
            this.Status});
            this.accountsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountsDataGridView.Location = new System.Drawing.Point(3, 44);
            this.accountsDataGridView.Name = "accountsDataGridView";
            this.accountsDataGridView.RowHeadersVisible = false;
            this.accountsDataGridView.Size = new System.Drawing.Size(1163, 699);
            this.accountsDataGridView.TabIndex = 1;
            // 
            // ConcessionaireID
            // 
            this.ConcessionaireID.DataPropertyName = "ConcessionaireID";
            this.ConcessionaireID.HeaderText = "ConcessionaireID";
            this.ConcessionaireID.Name = "ConcessionaireID";
            this.ConcessionaireID.Visible = false;
            // 
            // AccountNo
            // 
            this.AccountNo.DataPropertyName = "AccountNo";
            this.AccountNo.HeaderText = "AccountNo";
            this.AccountNo.Name = "AccountNo";
            this.AccountNo.Width = 123;
            // 
            // ConcessionaireName
            // 
            this.ConcessionaireName.DataPropertyName = "ConcessionaireName";
            this.ConcessionaireName.HeaderText = "ConcessionaireName";
            this.ConcessionaireName.Name = "ConcessionaireName";
            this.ConcessionaireName.Width = 124;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Width = 123;
            // 
            // ZoneCode
            // 
            this.ZoneCode.DataPropertyName = "ZoneCode";
            this.ZoneCode.HeaderText = "ZoneCode";
            this.ZoneCode.Name = "ZoneCode";
            this.ZoneCode.Width = 123;
            // 
            // ServiceID
            // 
            this.ServiceID.DataPropertyName = "ServiceID";
            this.ServiceID.HeaderText = "ServiceID";
            this.ServiceID.Name = "ServiceID";
            this.ServiceID.Width = 124;
            // 
            // MeterNo
            // 
            this.MeterNo.DataPropertyName = "MeterNo";
            this.MeterNo.HeaderText = "MeterNo";
            this.MeterNo.Name = "MeterNo";
            this.MeterNo.Width = 123;
            // 
            // FirstReadingDate
            // 
            this.FirstReadingDate.DataPropertyName = "FirstReadingDate";
            this.FirstReadingDate.HeaderText = "FirstReadingDate";
            this.FirstReadingDate.Name = "FirstReadingDate";
            this.FirstReadingDate.Width = 124;
            // 
            // SeniorCitizen
            // 
            this.SeniorCitizen.DataPropertyName = "SeniorCitizen";
            this.SeniorCitizen.HeaderText = "SeniorCitizen";
            this.SeniorCitizen.Name = "SeniorCitizen";
            this.SeniorCitizen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeniorCitizen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SeniorCitizen.Width = 123;
            // 
            // TaxExempt
            // 
            this.TaxExempt.DataPropertyName = "TaxExempt";
            this.TaxExempt.HeaderText = "TaxExempt";
            this.TaxExempt.Name = "TaxExempt";
            this.TaxExempt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TaxExempt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TaxExempt.Width = 123;
            // 
            // DueExempt
            // 
            this.DueExempt.DataPropertyName = "DueExempt";
            this.DueExempt.HeaderText = "DueExempt";
            this.DueExempt.Name = "DueExempt";
            this.DueExempt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DueExempt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DueExempt.Width = 124;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            this.Status.DefaultCellStyle = dataGridViewCellStyle1;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.Width = 123;
            // 
            // AccountsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AccountsControl";
            this.Size = new System.Drawing.Size(1181, 807);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ToolStrip miniToolStrip;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel8;
        private Button accountApplyButton;
        private Button accountUndoButton;
        private DataGridView accountsDataGridView;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox searchAccountNumberTextBox;
        private ComboBox zoneComboBox;
        private Button clearButton;
        private DataGridViewTextBoxColumn ConcessionaireID;
        private DataGridViewTextBoxColumn AccountNo;
        private DataGridViewTextBoxColumn ConcessionaireName;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn ZoneCode;
        private DataGridViewTextBoxColumn ServiceID;
        private DataGridViewTextBoxColumn MeterNo;
        private DataGridViewTextBoxColumn FirstReadingDate;
        private DataGridViewCheckBoxColumn SeniorCitizen;
        private DataGridViewCheckBoxColumn TaxExempt;
        private DataGridViewCheckBoxColumn DueExempt;
        private DataGridViewTextBoxColumn Status;
    }
}
