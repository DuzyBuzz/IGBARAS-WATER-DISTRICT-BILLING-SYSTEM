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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accountDataGridView = new System.Windows.Forms.DataGridView();
            this.accountno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concessionaireID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstReadingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxExempt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dueExempt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.seniorCitizen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.zoneComboBox = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.searchAccountNumberTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.serviceApplyButton = new System.Windows.Forms.Button();
            this.settingsUndoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accountDataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountDataGridView
            // 
            this.accountDataGridView.AllowUserToDeleteRows = false;
            this.accountDataGridView.AllowUserToOrderColumns = true;
            this.accountDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.accountDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.accountDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.accountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountno,
            this.concessionaireID,
            this.fullname,
            this.businessAddress,
            this.zoneCode,
            this.serviceId,
            this.meterNo,
            this.firstReadingDate,
            this.taxExempt,
            this.dueExempt,
            this.seniorCitizen,
            this.status});
            this.accountDataGridView.EnableHeadersVisualStyles = false;
            this.accountDataGridView.Location = new System.Drawing.Point(3, 41);
            this.accountDataGridView.Name = "accountDataGridView";
            this.accountDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.accountDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.accountDataGridView.Size = new System.Drawing.Size(1175, 763);
            this.accountDataGridView.TabIndex = 24;
            this.accountDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.accountsDataGridView_CellFormatting);
            // 
            // accountno
            // 
            this.accountno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.accountno.DataPropertyName = "AccountNo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.accountno.DefaultCellStyle = dataGridViewCellStyle1;
            this.accountno.FillWeight = 400F;
            this.accountno.HeaderText = "Account #";
            this.accountno.Name = "accountno";
            // 
            // concessionaireID
            // 
            this.concessionaireID.DataPropertyName = "ConcessionaireID";
            this.concessionaireID.HeaderText = "ConcessionaireID";
            this.concessionaireID.Name = "concessionaireID";
            this.concessionaireID.Visible = false;
            this.concessionaireID.Width = 114;
            // 
            // fullname
            // 
            this.fullname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fullname.DataPropertyName = "ConcessionaireName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fullname.DefaultCellStyle = dataGridViewCellStyle2;
            this.fullname.FillWeight = 200F;
            this.fullname.HeaderText = "Concessionaire Name";
            this.fullname.Name = "fullname";
            this.fullname.Width = 350;
            // 
            // businessAddress
            // 
            this.businessAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.businessAddress.DataPropertyName = "Address";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.businessAddress.DefaultCellStyle = dataGridViewCellStyle3;
            this.businessAddress.FillWeight = 300F;
            this.businessAddress.HeaderText = "Business Address";
            this.businessAddress.Name = "businessAddress";
            this.businessAddress.Width = 300;
            // 
            // zoneCode
            // 
            this.zoneCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.zoneCode.DataPropertyName = "ZoneCode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.zoneCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.zoneCode.FillWeight = 50F;
            this.zoneCode.HeaderText = "Zone Code";
            this.zoneCode.Name = "zoneCode";
            this.zoneCode.Width = 50;
            // 
            // serviceId
            // 
            this.serviceId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.serviceId.DataPropertyName = "ServiceID";
            this.serviceId.HeaderText = "Service ID";
            this.serviceId.Name = "serviceId";
            this.serviceId.Width = 75;
            // 
            // meterNo
            // 
            this.meterNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.meterNo.DataPropertyName = "MeterNo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.meterNo.DefaultCellStyle = dataGridViewCellStyle5;
            this.meterNo.FillWeight = 200F;
            this.meterNo.HeaderText = "Meter #";
            this.meterNo.Name = "meterNo";
            this.meterNo.Width = 150;
            // 
            // firstReadingDate
            // 
            this.firstReadingDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.firstReadingDate.DataPropertyName = "FirstReadingDate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.firstReadingDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.firstReadingDate.HeaderText = "First Reading Date(FRD)";
            this.firstReadingDate.Name = "firstReadingDate";
            // 
            // taxExempt
            // 
            this.taxExempt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.taxExempt.DataPropertyName = "TaxExempt";
            this.taxExempt.FillWeight = 50F;
            this.taxExempt.HeaderText = "Tax Exempt";
            this.taxExempt.Name = "taxExempt";
            this.taxExempt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.taxExempt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.taxExempt.Width = 50;
            // 
            // dueExempt
            // 
            this.dueExempt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dueExempt.DataPropertyName = "DueExempt";
            this.dueExempt.FillWeight = 50F;
            this.dueExempt.HeaderText = "Due Exempt";
            this.dueExempt.Name = "dueExempt";
            this.dueExempt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dueExempt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dueExempt.Width = 50;
            // 
            // seniorCitizen
            // 
            this.seniorCitizen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.seniorCitizen.DataPropertyName = "SeniorCitizen";
            this.seniorCitizen.FillWeight = 50F;
            this.seniorCitizen.HeaderText = "Senior Citizen";
            this.seniorCitizen.Name = "seniorCitizen";
            this.seniorCitizen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seniorCitizen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.seniorCitizen.Width = 50;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.status.DataPropertyName = "Status";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle7;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.accountDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.708798F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.2912F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1181, 807);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.18239F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.81761F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.zoneComboBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label32, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.searchAccountNumberTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.clearButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.serviceApplyButton, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.settingsUndoButton, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1175, 32);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(697, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 26);
            this.button1.TabIndex = 36;
            this.button1.Text = "↺";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zoneComboBox
            // 
            this.zoneComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoneComboBox.FormattingEnabled = true;
            this.zoneComboBox.Location = new System.Drawing.Point(647, 4);
            this.zoneComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.zoneComboBox.Name = "zoneComboBox";
            this.zoneComboBox.Size = new System.Drawing.Size(44, 21);
            this.zoneComboBox.TabIndex = 33;
            this.zoneComboBox.Text = "01";
            this.zoneComboBox.SelectedIndexChanged += new System.EventHandler(this.zoneComboBox_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(558, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(83, 32);
            this.label32.TabIndex = 32;
            this.label32.Text = "Filter Zone";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchAccountNumberTextBox
            // 
            this.searchAccountNumberTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchAccountNumberTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchAccountNumberTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchAccountNumberTextBox.Location = new System.Drawing.Point(3, 4);
            this.searchAccountNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.searchAccountNumberTextBox.Name = "searchAccountNumberTextBox";
            this.searchAccountNumberTextBox.Size = new System.Drawing.Size(517, 25);
            this.searchAccountNumberTextBox.TabIndex = 30;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.BackColor = System.Drawing.Color.White;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.Crimson;
            this.clearButton.Location = new System.Drawing.Point(526, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(26, 26);
            this.clearButton.TabIndex = 31;
            this.clearButton.Text = "❌";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // serviceApplyButton
            // 
            this.serviceApplyButton.BackColor = System.Drawing.Color.SteelBlue;
            this.serviceApplyButton.ForeColor = System.Drawing.Color.White;
            this.serviceApplyButton.Location = new System.Drawing.Point(1052, 3);
            this.serviceApplyButton.Name = "serviceApplyButton";
            this.serviceApplyButton.Size = new System.Drawing.Size(119, 26);
            this.serviceApplyButton.TabIndex = 35;
            this.serviceApplyButton.Text = "✏️ Apply Changes";
            this.serviceApplyButton.UseVisualStyleBackColor = false;
            this.serviceApplyButton.Click += new System.EventHandler(this.accountApplyButton_Click);
            // 
            // settingsUndoButton
            // 
            this.settingsUndoButton.BackColor = System.Drawing.Color.Brown;
            this.settingsUndoButton.ForeColor = System.Drawing.Color.White;
            this.settingsUndoButton.Location = new System.Drawing.Point(917, 3);
            this.settingsUndoButton.Name = "settingsUndoButton";
            this.settingsUndoButton.Size = new System.Drawing.Size(127, 26);
            this.settingsUndoButton.TabIndex = 34;
            this.settingsUndoButton.Text = "↩ Undo Changes";
            this.settingsUndoButton.UseVisualStyleBackColor = false;
            this.settingsUndoButton.Click += new System.EventHandler(this.accountUndoButton_Click);
            // 
            // AccountsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AccountsControl";
            this.Size = new System.Drawing.Size(1181, 807);
            this.Load += new System.EventHandler(this.AccountsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountDataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView accountDataGridView;
        private DataGridViewTextBoxColumn accountno;
        private DataGridViewTextBoxColumn concessionaireID;
        private DataGridViewTextBoxColumn fullname;
        private DataGridViewTextBoxColumn businessAddress;
        private DataGridViewTextBoxColumn zoneCode;
        private DataGridViewTextBoxColumn serviceId;
        private DataGridViewTextBoxColumn meterNo;
        private DataGridViewTextBoxColumn firstReadingDate;
        private DataGridViewCheckBoxColumn taxExempt;
        private DataGridViewCheckBoxColumn dueExempt;
        private DataGridViewCheckBoxColumn seniorCitizen;
        private DataGridViewTextBoxColumn status;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button clearButton;
        private TextBox searchAccountNumberTextBox;
        private Label label32;
        private ComboBox zoneComboBox;
        private Button settingsUndoButton;
        private Button serviceApplyButton;
        private Button button1;
    }
}
