using System.Drawing;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    partial class SettingsControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.currentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.fullnameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accountApplyButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.accountApplyButton, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.06015F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.37164F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.56821F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1181, 807);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.confirmPasswordTextBox, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.newPasswordTextBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.currentPasswordTextBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.userNameTextBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.fullnameTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBox1, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(396, 197);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76471F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(387, 271);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confirmPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(3, 208);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.PasswordChar = '*';
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(381, 26);
            this.confirmPasswordTextBox.TabIndex = 5;
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.newPasswordTextBox.Location = new System.Drawing.Point(3, 164);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.PasswordChar = '*';
            this.newPasswordTextBox.Size = new System.Drawing.Size(381, 26);
            this.newPasswordTextBox.TabIndex = 4;
            // 
            // currentPasswordTextBox
            // 
            this.currentPasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.currentPasswordTextBox.Location = new System.Drawing.Point(3, 120);
            this.currentPasswordTextBox.Name = "currentPasswordTextBox";
            this.currentPasswordTextBox.Size = new System.Drawing.Size(381, 26);
            this.currentPasswordTextBox.TabIndex = 3;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userNameTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.userNameTextBox.Location = new System.Drawing.Point(3, 76);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(381, 26);
            this.userNameTextBox.TabIndex = 2;
            // 
            // fullnameTextBox
            // 
            this.fullnameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fullnameTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.fullnameTextBox.Location = new System.Drawing.Point(3, 32);
            this.fullnameTextBox.Name = "fullnameTextBox";
            this.fullnameTextBox.Size = new System.Drawing.Size(381, 26);
            this.fullnameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(396, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // accountApplyButton
            // 
            this.accountApplyButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.accountApplyButton.BackColor = System.Drawing.Color.SteelBlue;
            this.accountApplyButton.ForeColor = System.Drawing.Color.White;
            this.accountApplyButton.Location = new System.Drawing.Point(518, 474);
            this.accountApplyButton.Name = "accountApplyButton";
            this.accountApplyButton.Size = new System.Drawing.Size(143, 31);
            this.accountApplyButton.TabIndex = 18;
            this.accountApplyButton.Text = "✏️ Apply Changes";
            this.accountApplyButton.UseVisualStyleBackColor = false;
            this.accountApplyButton.Click += new System.EventHandler(this.accountApplyButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 252);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "show password";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(1181, 807);
            this.Load += new System.EventHandler(this.SettingsControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox confirmPasswordTextBox;
        private TextBox newPasswordTextBox;
        private TextBox currentPasswordTextBox;
        private TextBox userNameTextBox;
        private TextBox fullnameTextBox;
        private Label label1;
        private Button accountApplyButton;
        private CheckBox checkBox1;
    }
}
