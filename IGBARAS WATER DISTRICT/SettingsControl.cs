using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void SettingsControl_Load(object sender, EventArgs e)
        {
            PlaceholderHelper.AddPlaceholder(currentPasswordTextBox, "Current Password.");
            PlaceholderHelper.AddPlaceholder(newPasswordTextBox, "New Password.");
            PlaceholderHelper.AddPlaceholder(confirmPasswordTextBox, "Confirm Password");
            fullnameTextBox.Text = $"{UserCredentials.Fullname}";
            userNameTextBox.Text = $"{UserCredentials.Username}";

        }
        private void accountApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Validation checks
                if (string.IsNullOrWhiteSpace(currentPasswordTextBox.Text) ||
                    string.IsNullOrWhiteSpace(newPasswordTextBox.Text) ||
                    string.IsNullOrWhiteSpace(confirmPasswordTextBox.Text))
                {
                    MessageBox.Show("Please fill in all password fields.");
                    return;
                }

                if (newPasswordTextBox.Text.Trim() != confirmPasswordTextBox.Text.Trim())
                {
                    MessageBox.Show("New password and confirmation do not match.");
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(DbConfig.ConnectionString))
                {
                    conn.Open();

                    // Step 2: Verify current password from DB
                    string checkPassQuery = "SELECT [password] FROM users WHERE userID = @userID";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkPassQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@userID", UserCredentials.UserId);

                        object dbPasswordObj = checkCmd.ExecuteScalar();
                        if (dbPasswordObj == null)
                        {
                            MessageBox.Show("User not found.");
                            return;
                        }

                        string dbPassword = dbPasswordObj.ToString();

                        if (dbPassword != currentPasswordTextBox.Text.Trim())
                        {
                            MessageBox.Show("Current password is incorrect.");
                            return;
                        }
                    }

                    // Step 3: Update user record
                    string updateQuery = @"UPDATE users 
                                   SET userName = @userName, 
                                       [password] = @password, 
                                       fullName = @fullName
                                   WHERE userID = @userID";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userName", userNameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", newPasswordTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@fullName", fullnameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@userID", UserCredentials.UserId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account updated successfully! Please log in again.");

                            // Sync helper values
                            UserCredentials.Username = userNameTextBox.Text.Trim();
                            UserCredentials.Fullname = fullnameTextBox.Text.Trim();

                            // Step 4: Hide current form and show login form
                            this.FindForm().Hide();
                            Login loginForm = new Login();
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("No record found to update.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Show passwords
                newPasswordTextBox.PasswordChar = '\0';
                confirmPasswordTextBox.PasswordChar = '\0';
            }
            else
            {
                // Hide passwords
                newPasswordTextBox.PasswordChar = '*';
                confirmPasswordTextBox.PasswordChar = '*';
            }
        }


    }
}
