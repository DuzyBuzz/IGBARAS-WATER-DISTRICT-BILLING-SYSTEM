using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT.Helpers
{
    public static class ColumnUpdaterHelper
    {
        /// <summary>
        /// Updates only the specified columns for a single row in the table using an existing OleDbConnection.
        /// </summary>
        public static void UpdateColumns(string tableName, string idColumn, object idValue, Dictionary<string, object> columnValues, OleDbConnection connection)
        {
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(idColumn) || columnValues == null || columnValues.Count == 0)
                throw new ArgumentException("Invalid arguments for column update.");

            try
            {
                var setClauses = new List<string>();
                using (var cmd = new OleDbCommand())
                {
                    cmd.Connection = connection;

                    // Add SET clauses and parameters
                    foreach (var kvp in columnValues)
                    {
                        setClauses.Add($"[{kvp.Key}] = ?");
                        cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value ?? DBNull.Value);
                    }

                    // Add WHERE clause parameter at the end
                    cmd.CommandText = $"UPDATE [{tableName}] SET {string.Join(", ", setClauses)} WHERE [{idColumn}] = ?";
                    cmd.Parameters.AddWithValue("@id", idValue ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (OleDbException ex)
            {
                if (ex.Message.ToLower().Contains("duplicate"))
                {
                    MessageBox.Show(
                        "The changes you requested were not successful because they would create duplicate values in the index, primary key, or relationship.\n\n" +
                        "Please ensure the data you entered is unique and does not conflict with existing records.",
                        "Duplicate Value Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    MessageBox.Show(
                        "An error occurred while updating the record:\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
