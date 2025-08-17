using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT.Helpers
{
    public static class ColumnUpdaterHelper
    {
        /// <summary>
        /// Updates only the specified columns for a single row in the table.
        /// </summary>
        /// <param name="tableName">Table name (e.g., "Tb_Billing")</param>
        /// <param name="idColumn">Primary key column name (e.g., "BillingID")</param>
        /// <param name="idValue">Primary key value for the row to update</param>
        /// <param name="columnValues">Dictionary of column names and their new values</param>
        public static void UpdateColumns(string tableName, string idColumn, object idValue, Dictionary<string, object> columnValues, OleDbConnection connection)
        {
            if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(idColumn) || columnValues == null || columnValues.Count == 0)
                throw new ArgumentException("Invalid arguments for column update.");

            var setClauses = new List<string>();
            var cmd = new OleDbCommand();
            cmd.Connection = connection;

            foreach (var kvp in columnValues)
            {
                setClauses.Add($"[{kvp.Key}] = ?");
                cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value ?? DBNull.Value);
            }

            cmd.CommandText = $"UPDATE [{tableName}] SET {string.Join(", ", setClauses)} WHERE [{idColumn}] = ?";
            cmd.Parameters.AddWithValue("@id", idValue);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                // Check for duplicate key error (error code 3022 for Access)
                if (ex.Message.Contains("duplicate") || ex.ErrorCode == -2147467259)
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
                    // Show the original error for other cases
                    MessageBox.Show(
                        "An error occurred while updating the record:\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}