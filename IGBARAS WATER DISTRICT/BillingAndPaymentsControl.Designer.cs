namespace IGBARAS_WATER_DISTRICT
{
    partial class BillingAndPaymentsControl
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
            this.billingTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.billingDataGridView = new System.Windows.Forms.DataGridView();
            this.BillingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevReading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PresentReadings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is_PartiallyPaid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Is_FullyPaid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Is_Arrears = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DiscountAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreeWater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrearsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountBilled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrearsPenaltyAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmountBilled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.zoneComboBox = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.searchAccountNumberTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.billingApplyButton = new System.Windows.Forms.Button();
            this.billingUndoButton = new System.Windows.Forms.Button();
            this.paymentsTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentsDataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentsRefreshButton = new System.Windows.Forms.Button();
            this.paymentsZoneComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.paymentSearchTextBox = new System.Windows.Forms.TextBox();
            this.paymentsClearButton = new System.Windows.Forms.Button();
            this.paymentsUndoButton = new System.Windows.Forms.Button();
            this.paymentsApplyButton = new System.Windows.Forms.Button();
            this.ORNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrearsAmounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrearsPenalty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalArrears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxAmounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountAmounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penalty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetBillChage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreeWaters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.billingTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.billingDataGridView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.paymentsTab.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsDataGridView)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.billingTab);
            this.tabControl1.Controls.Add(this.paymentsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1181, 807);
            this.tabControl1.TabIndex = 1;
            // 
            // billingTab
            // 
            this.billingTab.Controls.Add(this.tableLayoutPanel1);
            this.billingTab.Location = new System.Drawing.Point(4, 25);
            this.billingTab.Name = "billingTab";
            this.billingTab.Padding = new System.Windows.Forms.Padding(3);
            this.billingTab.Size = new System.Drawing.Size(1173, 778);
            this.billingTab.TabIndex = 0;
            this.billingTab.Text = "Billings";
            this.billingTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.billingDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.708798F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.2912F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1167, 772);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // billingDataGridView
            // 
            this.billingDataGridView.AllowUserToAddRows = false;
            this.billingDataGridView.AllowUserToDeleteRows = false;
            this.billingDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.billingDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.billingDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.billingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.billingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillingID,
            this.BillNo,
            this.DateCreated,
            this.AccountNo,
            this.DateFrom,
            this.DateTo,
            this.PrevReading,
            this.PresentReadings,
            this.DueDate,
            this.Is_PartiallyPaid,
            this.Is_FullyPaid,
            this.Is_Arrears,
            this.DiscountAmount,
            this.TaxAmount,
            this.FreeWater,
            this.ArrearsAmount,
            this.AmountBilled,
            this.ArrearsPenaltyAmount,
            this.TotalAmountBilled});
            this.billingDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billingDataGridView.Location = new System.Drawing.Point(3, 39);
            this.billingDataGridView.Name = "billingDataGridView";
            this.billingDataGridView.RowHeadersVisible = false;
            this.billingDataGridView.Size = new System.Drawing.Size(1161, 730);
            this.billingDataGridView.TabIndex = 26;
            // 
            // BillingID
            // 
            this.BillingID.DataPropertyName = "BillingID";
            this.BillingID.HeaderText = "BillingID";
            this.BillingID.Name = "BillingID";
            this.BillingID.Visible = false;
            this.BillingID.Width = 51;
            // 
            // BillNo
            // 
            this.BillNo.DataPropertyName = "BillNo";
            this.BillNo.HeaderText = "BillNo";
            this.BillNo.Name = "BillNo";
            this.BillNo.Width = 59;
            // 
            // DateCreated
            // 
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.HeaderText = "Date Billed";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.Width = 77;
            // 
            // AccountNo
            // 
            this.AccountNo.DataPropertyName = "AccountNo";
            this.AccountNo.HeaderText = "AccountNo";
            this.AccountNo.Name = "AccountNo";
            this.AccountNo.Width = 86;
            // 
            // DateFrom
            // 
            this.DateFrom.DataPropertyName = "DateFrom";
            this.DateFrom.HeaderText = "Date From";
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Width = 75;
            // 
            // DateTo
            // 
            this.DateTo.DataPropertyName = "DateTo";
            this.DateTo.HeaderText = "Date To";
            this.DateTo.Name = "DateTo";
            this.DateTo.Width = 66;
            // 
            // PrevReading
            // 
            this.PrevReading.DataPropertyName = "PrevReading";
            this.PrevReading.HeaderText = "Prev Reading";
            this.PrevReading.Name = "PrevReading";
            this.PrevReading.Width = 89;
            // 
            // PresentReadings
            // 
            this.PresentReadings.DataPropertyName = "PresentReading";
            this.PresentReadings.HeaderText = "Present Reading";
            this.PresentReadings.Name = "PresentReadings";
            this.PresentReadings.Width = 102;
            // 
            // DueDate
            // 
            this.DueDate.DataPropertyName = "DueDate";
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.Width = 72;
            // 
            // Is_PartiallyPaid
            // 
            this.Is_PartiallyPaid.DataPropertyName = "Is_PartiallyPaid";
            this.Is_PartiallyPaid.HeaderText = "Is Partially Paid";
            this.Is_PartiallyPaid.Name = "Is_PartiallyPaid";
            this.Is_PartiallyPaid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Is_PartiallyPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Is_PartiallyPaid.Width = 95;
            // 
            // Is_FullyPaid
            // 
            this.Is_FullyPaid.DataPropertyName = "Is_FullyPaid";
            this.Is_FullyPaid.HeaderText = "Is Fully Paid";
            this.Is_FullyPaid.Name = "Is_FullyPaid";
            this.Is_FullyPaid.Width = 62;
            // 
            // Is_Arrears
            // 
            this.Is_Arrears.DataPropertyName = "Is_Arrears";
            this.Is_Arrears.HeaderText = "Is Arrears";
            this.Is_Arrears.Name = "Is_Arrears";
            this.Is_Arrears.Width = 51;
            // 
            // DiscountAmount
            // 
            this.DiscountAmount.DataPropertyName = "DiscountAmount";
            this.DiscountAmount.HeaderText = "Discount Amount";
            this.DiscountAmount.Name = "DiscountAmount";
            this.DiscountAmount.Width = 104;
            // 
            // TaxAmount
            // 
            this.TaxAmount.DataPropertyName = "TaxAmount";
            this.TaxAmount.HeaderText = "Tax";
            this.TaxAmount.Name = "TaxAmount";
            this.TaxAmount.Width = 50;
            // 
            // FreeWater
            // 
            this.FreeWater.DataPropertyName = "FreeWater";
            this.FreeWater.HeaderText = "Free Water";
            this.FreeWater.Name = "FreeWater";
            this.FreeWater.Width = 79;
            // 
            // ArrearsAmount
            // 
            this.ArrearsAmount.DataPropertyName = "ArrearsAmount";
            this.ArrearsAmount.HeaderText = "Arrears Amount";
            this.ArrearsAmount.Name = "ArrearsAmount";
            this.ArrearsAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ArrearsAmount.Width = 96;
            // 
            // AmountBilled
            // 
            this.AmountBilled.DataPropertyName = "AmountBilled";
            this.AmountBilled.HeaderText = "Amount Billed";
            this.AmountBilled.Name = "AmountBilled";
            this.AmountBilled.ReadOnly = true;
            this.AmountBilled.Width = 88;
            // 
            // ArrearsPenaltyAmount
            // 
            this.ArrearsPenaltyAmount.DataPropertyName = "ArrearsPenaltyAmount";
            this.ArrearsPenaltyAmount.HeaderText = "Arrears Penalty";
            this.ArrearsPenaltyAmount.Name = "ArrearsPenaltyAmount";
            this.ArrearsPenaltyAmount.Width = 95;
            // 
            // TotalAmountBilled
            // 
            this.TotalAmountBilled.DataPropertyName = "TotalAmountBilled";
            this.TotalAmountBilled.HeaderText = "Total Amount Billed";
            this.TotalAmountBilled.Name = "TotalAmountBilled";
            this.TotalAmountBilled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TotalAmountBilled.Width = 113;
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.zoneComboBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label32, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.searchAccountNumberTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.clearButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.billingApplyButton, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.billingUndoButton, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1161, 30);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(667, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 24);
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
            this.zoneComboBox.Location = new System.Drawing.Point(617, 4);
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
            this.label32.Location = new System.Drawing.Point(528, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(83, 30);
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
            this.searchAccountNumberTextBox.Size = new System.Drawing.Size(489, 25);
            this.searchAccountNumberTextBox.TabIndex = 30;
            this.searchAccountNumberTextBox.TextChanged += new System.EventHandler(this.searchAccountNumberTextBox_TextChanged);
            this.searchAccountNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchAccountNumberTextBox_KeyDown);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.BackColor = System.Drawing.Color.White;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.Crimson;
            this.clearButton.Location = new System.Drawing.Point(498, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(24, 24);
            this.clearButton.TabIndex = 31;
            this.clearButton.Text = "❌";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // billingApplyButton
            // 
            this.billingApplyButton.BackColor = System.Drawing.Color.SteelBlue;
            this.billingApplyButton.ForeColor = System.Drawing.Color.White;
            this.billingApplyButton.Location = new System.Drawing.Point(1022, 3);
            this.billingApplyButton.Name = "billingApplyButton";
            this.billingApplyButton.Size = new System.Drawing.Size(119, 24);
            this.billingApplyButton.TabIndex = 35;
            this.billingApplyButton.Text = "✏️ Apply Changes";
            this.billingApplyButton.UseVisualStyleBackColor = false;
            this.billingApplyButton.Click += new System.EventHandler(this.billingApplyButton_Click);
            // 
            // billingUndoButton
            // 
            this.billingUndoButton.BackColor = System.Drawing.Color.Brown;
            this.billingUndoButton.ForeColor = System.Drawing.Color.White;
            this.billingUndoButton.Location = new System.Drawing.Point(887, 3);
            this.billingUndoButton.Name = "billingUndoButton";
            this.billingUndoButton.Size = new System.Drawing.Size(127, 24);
            this.billingUndoButton.TabIndex = 34;
            this.billingUndoButton.Text = "↩ Undo Changes";
            this.billingUndoButton.UseVisualStyleBackColor = false;
            this.billingUndoButton.Visible = false;
            this.billingUndoButton.Click += new System.EventHandler(this.billingUndoButton_Click);
            // 
            // paymentsTab
            // 
            this.paymentsTab.Controls.Add(this.tableLayoutPanel3);
            this.paymentsTab.Location = new System.Drawing.Point(4, 25);
            this.paymentsTab.Name = "paymentsTab";
            this.paymentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.paymentsTab.Size = new System.Drawing.Size(1173, 778);
            this.paymentsTab.TabIndex = 1;
            this.paymentsTab.Text = "Payments";
            this.paymentsTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.paymentsDataGridView, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.708798F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.2912F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1167, 772);
            this.tableLayoutPanel3.TabIndex = 26;
            // 
            // paymentsDataGridView
            // 
            this.paymentsDataGridView.AllowUserToAddRows = false;
            this.paymentsDataGridView.AllowUserToDeleteRows = false;
            this.paymentsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.paymentsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.paymentsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.paymentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ORNumber,
            this.CurrentBillNo,
            this.AccountNum,
            this.PaymentDate,
            this.PaymentType,
            this.ArrearsAmounts,
            this.ArrearsPenalty,
            this.TotalArrears,
            this.BillCharge,
            this.TaxAmounts,
            this.DiscountAmounts,
            this.TotalCurrent,
            this.AmountPaid,
            this.Penalty,
            this.NetBillChage,
            this.Balance,
            this.Remarks,
            this.FreeWaters,
            this.PaymentID});
            this.paymentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentsDataGridView.Location = new System.Drawing.Point(3, 39);
            this.paymentsDataGridView.Name = "paymentsDataGridView";
            this.paymentsDataGridView.RowHeadersVisible = false;
            this.paymentsDataGridView.Size = new System.Drawing.Size(1161, 730);
            this.paymentsDataGridView.TabIndex = 26;
            this.paymentsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.paymentsDataGridView_CellContentClick);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 9;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.18239F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.81761F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel4.Controls.Add(this.paymentsRefreshButton, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.paymentsZoneComboBox, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.paymentSearchTextBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.paymentsClearButton, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.paymentsUndoButton, 7, 0);
            this.tableLayoutPanel4.Controls.Add(this.paymentsApplyButton, 8, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1161, 30);
            this.tableLayoutPanel4.TabIndex = 25;
            // 
            // paymentsRefreshButton
            // 
            this.paymentsRefreshButton.BackColor = System.Drawing.Color.SteelBlue;
            this.paymentsRefreshButton.ForeColor = System.Drawing.Color.White;
            this.paymentsRefreshButton.Location = new System.Drawing.Point(667, 3);
            this.paymentsRefreshButton.Name = "paymentsRefreshButton";
            this.paymentsRefreshButton.Size = new System.Drawing.Size(49, 24);
            this.paymentsRefreshButton.TabIndex = 36;
            this.paymentsRefreshButton.Text = "↺";
            this.paymentsRefreshButton.UseVisualStyleBackColor = false;
            this.paymentsRefreshButton.Click += new System.EventHandler(this.paymentsRefreshButton_Click);
            // 
            // paymentsZoneComboBox
            // 
            this.paymentsZoneComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentsZoneComboBox.FormattingEnabled = true;
            this.paymentsZoneComboBox.Location = new System.Drawing.Point(617, 4);
            this.paymentsZoneComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.paymentsZoneComboBox.Name = "paymentsZoneComboBox";
            this.paymentsZoneComboBox.Size = new System.Drawing.Size(44, 21);
            this.paymentsZoneComboBox.TabIndex = 33;
            this.paymentsZoneComboBox.Text = "01";
            this.paymentsZoneComboBox.SelectedIndexChanged += new System.EventHandler(this.paymentsZoneComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 30);
            this.label1.TabIndex = 32;
            this.label1.Text = "Filter Zone";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentSearchTextBox
            // 
            this.paymentSearchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.paymentSearchTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paymentSearchTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentSearchTextBox.Location = new System.Drawing.Point(3, 4);
            this.paymentSearchTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.paymentSearchTextBox.Name = "paymentSearchTextBox";
            this.paymentSearchTextBox.Size = new System.Drawing.Size(489, 25);
            this.paymentSearchTextBox.TabIndex = 30;
            this.paymentSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.paymentSearchTextBox_KeyDown);
            // 
            // paymentsClearButton
            // 
            this.paymentsClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentsClearButton.BackColor = System.Drawing.Color.White;
            this.paymentsClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.paymentsClearButton.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentsClearButton.ForeColor = System.Drawing.Color.Crimson;
            this.paymentsClearButton.Location = new System.Drawing.Point(498, 3);
            this.paymentsClearButton.Name = "paymentsClearButton";
            this.paymentsClearButton.Size = new System.Drawing.Size(24, 24);
            this.paymentsClearButton.TabIndex = 31;
            this.paymentsClearButton.Text = "❌";
            this.paymentsClearButton.UseVisualStyleBackColor = false;
            this.paymentsClearButton.Click += new System.EventHandler(this.paymentsClearButton_Click);
            // 
            // paymentsUndoButton
            // 
            this.paymentsUndoButton.BackColor = System.Drawing.Color.Brown;
            this.paymentsUndoButton.ForeColor = System.Drawing.Color.White;
            this.paymentsUndoButton.Location = new System.Drawing.Point(887, 3);
            this.paymentsUndoButton.Name = "paymentsUndoButton";
            this.paymentsUndoButton.Size = new System.Drawing.Size(127, 24);
            this.paymentsUndoButton.TabIndex = 34;
            this.paymentsUndoButton.Text = "↩ Undo Changes";
            this.paymentsUndoButton.UseVisualStyleBackColor = false;
            this.paymentsUndoButton.Visible = false;
            this.paymentsUndoButton.Click += new System.EventHandler(this.paymentsUndoButton_Click);
            // 
            // paymentsApplyButton
            // 
            this.paymentsApplyButton.BackColor = System.Drawing.Color.SteelBlue;
            this.paymentsApplyButton.ForeColor = System.Drawing.Color.White;
            this.paymentsApplyButton.Location = new System.Drawing.Point(1022, 3);
            this.paymentsApplyButton.Name = "paymentsApplyButton";
            this.paymentsApplyButton.Size = new System.Drawing.Size(119, 24);
            this.paymentsApplyButton.TabIndex = 35;
            this.paymentsApplyButton.Text = "✏️ Apply Changes";
            this.paymentsApplyButton.UseVisualStyleBackColor = false;
            this.paymentsApplyButton.Click += new System.EventHandler(this.paymentsApplyButton_Click);
            // 
            // ORNumber
            // 
            this.ORNumber.DataPropertyName = "ORNumber";
            this.ORNumber.HeaderText = "OR Number";
            this.ORNumber.Name = "ORNumber";
            this.ORNumber.ReadOnly = true;
            this.ORNumber.Width = 88;
            // 
            // CurrentBillNo
            // 
            this.CurrentBillNo.DataPropertyName = "CurrentBillNo";
            this.CurrentBillNo.HeaderText = "Bill No.";
            this.CurrentBillNo.Name = "CurrentBillNo";
            this.CurrentBillNo.Width = 65;
            // 
            // AccountNum
            // 
            this.AccountNum.DataPropertyName = "AccountNo";
            this.AccountNum.HeaderText = "Account No.";
            this.AccountNum.Name = "AccountNum";
            this.AccountNum.ReadOnly = true;
            this.AccountNum.Width = 92;
            // 
            // PaymentDate
            // 
            this.PaymentDate.DataPropertyName = "PaymentDate";
            this.PaymentDate.HeaderText = "PaymentDate";
            this.PaymentDate.Name = "PaymentDate";
            this.PaymentDate.ReadOnly = true;
            this.PaymentDate.Width = 96;
            // 
            // PaymentType
            // 
            this.PaymentType.DataPropertyName = "PaymentType";
            this.PaymentType.HeaderText = "Payment Type";
            this.PaymentType.Name = "PaymentType";
            this.PaymentType.ReadOnly = true;
            // 
            // ArrearsAmounts
            // 
            this.ArrearsAmounts.DataPropertyName = "ArrearsAmount";
            this.ArrearsAmounts.HeaderText = "Arrears Amount";
            this.ArrearsAmounts.Name = "ArrearsAmounts";
            this.ArrearsAmounts.ReadOnly = true;
            this.ArrearsAmounts.Width = 96;
            // 
            // ArrearsPenalty
            // 
            this.ArrearsPenalty.DataPropertyName = "ArrearsPenalty";
            this.ArrearsPenalty.HeaderText = "Arrears Penalty";
            this.ArrearsPenalty.Name = "ArrearsPenalty";
            this.ArrearsPenalty.ReadOnly = true;
            this.ArrearsPenalty.Width = 95;
            // 
            // TotalArrears
            // 
            this.TotalArrears.DataPropertyName = "TotalArrears";
            this.TotalArrears.HeaderText = "Total Arrears";
            this.TotalArrears.Name = "TotalArrears";
            this.TotalArrears.ReadOnly = true;
            this.TotalArrears.Width = 85;
            // 
            // BillCharge
            // 
            this.BillCharge.DataPropertyName = "BillCharge";
            this.BillCharge.HeaderText = "Bill Charge";
            this.BillCharge.Name = "BillCharge";
            this.BillCharge.ReadOnly = true;
            this.BillCharge.Width = 76;
            // 
            // TaxAmounts
            // 
            this.TaxAmounts.DataPropertyName = "TaxAmount";
            this.TaxAmounts.HeaderText = "Tax";
            this.TaxAmounts.Name = "TaxAmounts";
            this.TaxAmounts.ReadOnly = true;
            this.TaxAmounts.Width = 50;
            // 
            // DiscountAmounts
            // 
            this.DiscountAmounts.DataPropertyName = "DiscountAmount";
            this.DiscountAmounts.HeaderText = "Discount";
            this.DiscountAmounts.Name = "DiscountAmounts";
            this.DiscountAmounts.Width = 74;
            // 
            // TotalCurrent
            // 
            this.TotalCurrent.DataPropertyName = "TotalCurrent";
            this.TotalCurrent.HeaderText = "Total Bill Charge";
            this.TotalCurrent.Name = "TotalCurrent";
            this.TotalCurrent.ReadOnly = true;
            // 
            // AmountPaid
            // 
            this.AmountPaid.DataPropertyName = "AmountPaid";
            this.AmountPaid.HeaderText = "Amount Paid";
            this.AmountPaid.Name = "AmountPaid";
            this.AmountPaid.Width = 85;
            // 
            // Penalty
            // 
            this.Penalty.DataPropertyName = "Penalty";
            this.Penalty.HeaderText = "Penalty";
            this.Penalty.Name = "Penalty";
            this.Penalty.ReadOnly = true;
            this.Penalty.Width = 67;
            // 
            // NetBillChage
            // 
            this.NetBillChage.DataPropertyName = "Net Bill Charge";
            this.NetBillChage.HeaderText = "Net Bill Charge";
            this.NetBillChage.Name = "NetBillChage";
            this.NetBillChage.ReadOnly = true;
            this.NetBillChage.Width = 94;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.Width = 71;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 74;
            // 
            // FreeWaters
            // 
            this.FreeWaters.DataPropertyName = "FreeWater";
            this.FreeWaters.HeaderText = "Free Water";
            this.FreeWaters.Name = "FreeWaters";
            this.FreeWaters.ReadOnly = true;
            this.FreeWaters.Width = 79;
            // 
            // PaymentID
            // 
            this.PaymentID.DataPropertyName = "PaymentID";
            this.PaymentID.HeaderText = "PaymentID";
            this.PaymentID.Name = "PaymentID";
            this.PaymentID.ReadOnly = true;
            this.PaymentID.Visible = false;
            this.PaymentID.Width = 84;
            // 
            // BillingAndPaymentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "BillingAndPaymentsControl";
            this.Size = new System.Drawing.Size(1181, 807);
            this.Load += new System.EventHandler(this.BillingAndPaymentsControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.billingTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.billingDataGridView)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.paymentsTab.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paymentsDataGridView)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage billingTab;
        private System.Windows.Forms.TabPage paymentsTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView billingDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox zoneComboBox;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox searchAccountNumberTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button billingApplyButton;
        private System.Windows.Forms.Button billingUndoButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView paymentsDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button paymentsRefreshButton;
        private System.Windows.Forms.ComboBox paymentsZoneComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox paymentSearchTextBox;
        private System.Windows.Forms.Button paymentsClearButton;
        private System.Windows.Forms.Button paymentsApplyButton;
        private System.Windows.Forms.Button paymentsUndoButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevReading;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresentReadings;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Is_PartiallyPaid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Is_FullyPaid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Is_Arrears;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreeWater;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrearsAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountBilled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrearsPenaltyAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmountBilled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrearsAmounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrearsPenalty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalArrears;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxAmounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountAmounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penalty;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetBillChage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreeWaters;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentID;
    }
}
