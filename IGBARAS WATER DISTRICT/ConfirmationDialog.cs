using System;
using System.Drawing;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class ConfirmationDialog : Form
    {
        public ConfirmationDialog(string details)
        {
            InitializeComponent();

            detailsRichTextBox.Clear();
            detailsRichTextBox.ReadOnly = true;
            detailsRichTextBox.WordWrap = false;
            detailsRichTextBox.ScrollBars = RichTextBoxScrollBars.Both;

            int lineWidth = 55;
            string[] lines = details.Split('\n');

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    detailsRichTextBox.AppendText("\n");
                    continue;
                }

                int separatorIndex = line.IndexOf(':');
                if (separatorIndex > -1)
                {
                    string label = line.Substring(0, separatorIndex + 1).Trim();
                    string value = line.Substring(separatorIndex + 1).Trim();
                    int valuePad = lineWidth - label.Length - value.Length;
                    if (valuePad < 1) valuePad = 1;

                    detailsRichTextBox.SelectionFont = new Font("Consolas", 10, FontStyle.Bold);
                    detailsRichTextBox.SelectionColor = Color.Black;
                    detailsRichTextBox.AppendText(label);

                    detailsRichTextBox.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);
                    detailsRichTextBox.SelectionColor = Color.Black;
                    detailsRichTextBox.AppendText(new string(' ', valuePad));
                    detailsRichTextBox.AppendText(value + "\n");
                }
                else
                {
                    detailsRichTextBox.SelectionFont = new Font("Arial", 10, FontStyle.Regular);
                    detailsRichTextBox.SelectionColor = Color.Black;
                    detailsRichTextBox.AppendText(line + "\n");
                }
            }

            detailsRichTextBox.SelectionStart = 0;
            detailsRichTextBox.ScrollToCaret();
            detailsRichTextBox.SelectionLength = 0;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes; // User confirmed
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No; // User canceled
            this.Close();
        }


        private void ConfirmationDialog_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnConfirm;
            this.CancelButton = btnCancel;
        }
    }
}
