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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.searchAccountNumberTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateToBilling = new System.Windows.Forms.DateTimePicker();
            this.dateFromBilling = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paymentsTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentSearchTextBox = new System.Windows.Forms.TextBox();
            this.paymentsClearButton = new System.Windows.Forms.Button();
            this.paymentsRefreshButton = new System.Windows.Forms.Button();
            this.dateFromPayments = new System.Windows.Forms.DateTimePicker();
            this.dateToPayments = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.paymentsDataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.billingTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.billingDataGridView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.paymentsTab.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsDataGridView)).BeginInit();
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
            this.billingDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billingDataGridView.Location = new System.Drawing.Point(3, 39);
            this.billingDataGridView.Name = "billingDataGridView";
            this.billingDataGridView.Size = new System.Drawing.Size(1161, 730);
            this.billingDataGridView.TabIndex = 26;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.53316F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.411714F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.186908F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.Controls.Add(this.searchAccountNumberTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.clearButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateToBilling, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateFromBilling, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1161, 30);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // searchAccountNumberTextBox
            // 
            this.searchAccountNumberTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchAccountNumberTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchAccountNumberTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchAccountNumberTextBox.Location = new System.Drawing.Point(3, 4);
            this.searchAccountNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.searchAccountNumberTextBox.Name = "searchAccountNumberTextBox";
            this.searchAccountNumberTextBox.Size = new System.Drawing.Size(244, 25);
            this.searchAccountNumberTextBox.TabIndex = 30;
            this.searchAccountNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchAccountNumberTextBox_KeyDown);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.BackColor = System.Drawing.Color.White;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.Crimson;
            this.clearButton.Location = new System.Drawing.Point(253, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(21, 24);
            this.clearButton.TabIndex = 31;
            this.clearButton.Text = "❌";
            this.clearButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(281, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 24);
            this.button1.TabIndex = 36;
            this.button1.Text = "↺";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dateToBilling
            // 
            this.dateToBilling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateToBilling.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateToBilling.Location = new System.Drawing.Point(1053, 3);
            this.dateToBilling.Name = "dateToBilling";
            this.dateToBilling.Size = new System.Drawing.Size(105, 20);
            this.dateToBilling.TabIndex = 38;
            this.dateToBilling.ValueChanged += new System.EventHandler(this.DateToBilling_ValueChanged);
            // 
            // dateFromBilling
            // 
            this.dateFromBilling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFromBilling.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFromBilling.Location = new System.Drawing.Point(843, 3);
            this.dateFromBilling.Name = "dateFromBilling";
            this.dateFromBilling.Size = new System.Drawing.Size(99, 20);
            this.dateFromBilling.TabIndex = 37;
            this.dateFromBilling.ValueChanged += new System.EventHandler(this.DateFromBilling_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(948, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 30);
            this.label1.TabIndex = 39;
            this.label1.Text = "Date To:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(738, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 30);
            this.label2.TabIndex = 40;
            this.label2.Text = "Date From:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.paymentsDataGridView, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.708798F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.2912F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1167, 772);
            this.tableLayoutPanel3.TabIndex = 26;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 11;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.70543F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.325581F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.100775F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel4.Controls.Add(this.paymentSearchTextBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.paymentsClearButton, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.paymentsRefreshButton, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.dateFromPayments, 8, 0);
            this.tableLayoutPanel4.Controls.Add(this.dateToPayments, 10, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 7, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 9, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1161, 30);
            this.tableLayoutPanel4.TabIndex = 27;
            // 
            // paymentSearchTextBox
            // 
            this.paymentSearchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.paymentSearchTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paymentSearchTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentSearchTextBox.Location = new System.Drawing.Point(3, 4);
            this.paymentSearchTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.paymentSearchTextBox.Name = "paymentSearchTextBox";
            this.paymentSearchTextBox.Size = new System.Drawing.Size(246, 25);
            this.paymentSearchTextBox.TabIndex = 30;
            this.paymentSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.paymentSearchTextBox_KeyDown);
            // 
            // paymentsClearButton
            // 
            this.paymentsClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.paymentsClearButton.BackColor = System.Drawing.Color.White;
            this.paymentsClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.paymentsClearButton.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentsClearButton.ForeColor = System.Drawing.Color.Crimson;
            this.paymentsClearButton.Location = new System.Drawing.Point(255, 3);
            this.paymentsClearButton.Name = "paymentsClearButton";
            this.paymentsClearButton.Size = new System.Drawing.Size(21, 24);
            this.paymentsClearButton.TabIndex = 31;
            this.paymentsClearButton.Text = "❌";
            this.paymentsClearButton.UseVisualStyleBackColor = false;
            // 
            // paymentsRefreshButton
            // 
            this.paymentsRefreshButton.BackColor = System.Drawing.Color.SteelBlue;
            this.paymentsRefreshButton.ForeColor = System.Drawing.Color.White;
            this.paymentsRefreshButton.Location = new System.Drawing.Point(282, 3);
            this.paymentsRefreshButton.Name = "paymentsRefreshButton";
            this.paymentsRefreshButton.Size = new System.Drawing.Size(30, 24);
            this.paymentsRefreshButton.TabIndex = 36;
            this.paymentsRefreshButton.Text = "↺";
            this.paymentsRefreshButton.UseVisualStyleBackColor = false;
            // 
            // dateFromPayments
            // 
            this.dateFromPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFromPayments.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFromPayments.Location = new System.Drawing.Point(843, 3);
            this.dateFromPayments.Name = "dateFromPayments";
            this.dateFromPayments.Size = new System.Drawing.Size(99, 20);
            this.dateFromPayments.TabIndex = 37;
            this.dateFromPayments.ValueChanged += new System.EventHandler(this.DateFromPayments_ValueChanged);
            // 
            // dateToPayments
            // 
            this.dateToPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateToPayments.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateToPayments.Location = new System.Drawing.Point(1053, 3);
            this.dateToPayments.Name = "dateToPayments";
            this.dateToPayments.Size = new System.Drawing.Size(105, 20);
            this.dateToPayments.TabIndex = 38;
            this.dateToPayments.ValueChanged += new System.EventHandler(this.DateToPayments_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(738, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 30);
            this.label4.TabIndex = 42;
            this.label4.Text = "Date From:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(948, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 30);
            this.label3.TabIndex = 41;
            this.label3.Text = "Date To:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // paymentsDataGridView
            // 
            this.paymentsDataGridView.AllowUserToAddRows = false;
            this.paymentsDataGridView.AllowUserToDeleteRows = false;
            this.paymentsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.paymentsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.paymentsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.paymentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentsDataGridView.Location = new System.Drawing.Point(3, 39);
            this.paymentsDataGridView.Name = "paymentsDataGridView";
            this.paymentsDataGridView.Size = new System.Drawing.Size(1161, 730);
            this.paymentsDataGridView.TabIndex = 26;
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
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsDataGridView)).EndInit();
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
        private System.Windows.Forms.TextBox searchAccountNumberTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView paymentsDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox paymentSearchTextBox;
        private System.Windows.Forms.Button paymentsClearButton;
        private System.Windows.Forms.Button paymentsRefreshButton;
        private System.Windows.Forms.DateTimePicker dateToBilling;
        private System.Windows.Forms.DateTimePicker dateFromBilling;
        private System.Windows.Forms.DateTimePicker dateFromPayments;
        private System.Windows.Forms.DateTimePicker dateToPayments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
