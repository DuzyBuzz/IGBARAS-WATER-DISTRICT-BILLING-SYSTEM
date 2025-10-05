using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT.Helpers
{
    public static class SearchHelper
    {
        public static DataTable SearchToTable(
            string tableName,
            string[] columnNames = null,
            Control filterControl = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            string[] columns = null,
            string dateColumn = null) // ✅ new parameter
        {
            try
            {
                string columnsString = (columns != null && columns.Length > 0)
                    ? string.Join(",", columns)
                    : "*";

                string sql = $"SELECT {columnsString} FROM {tableName}";
                string filterValue = "";

                if (filterControl != null)
                {
                    if (filterControl is TextBox tb)
                        filterValue = tb.Text.Trim();
                    else if (filterControl is ComboBox cb)
                        filterValue = cb.Text.Trim();
                    else
                        throw new ArgumentException("Unsupported control type.");
                }

                var conditions = new List<string>();

                // Account/other string filters
                if (!string.IsNullOrEmpty(filterValue) && columnNames != null && columnNames.Length > 0)
                {
                    var orConditions = new List<string>();
                    foreach (var col in columnNames)
                        orConditions.Add($"[{col}] LIKE ?");
                    conditions.Add("(" + string.Join(" OR ", orConditions) + ")");
                }

                // Date filters
                if (!string.IsNullOrEmpty(dateColumn))
                {
                    if (fromDate.HasValue)
                        conditions.Add($"[{dateColumn}] >= ?");
                    if (toDate.HasValue)
                        conditions.Add($"[{dateColumn}] <= ?");
                }

                if (conditions.Count > 0)
                    sql += " WHERE " + string.Join(" AND ", conditions);

                using (var conn = new OleDbConnection(DbConfig.ConnectionString))
                using (var cmd = new OleDbCommand(sql, conn))
                {
                    // Add parameters in correct order
                    if (!string.IsNullOrEmpty(filterValue) && columnNames != null && columnNames.Length > 0)
                    {
                        foreach (var col in columnNames)
                            cmd.Parameters.AddWithValue("?", $"%{filterValue}%");
                    }

                    if (!string.IsNullOrEmpty(dateColumn))
                    {
                        if (fromDate.HasValue)
                            cmd.Parameters.AddWithValue("?", fromDate.Value.Date);
                        if (toDate.HasValue)
                            cmd.Parameters.AddWithValue("?", toDate.Value.Date);
                    }

                    using (var adapter = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SearchToTable failed: " + ex.Message);
                return new DataTable();
            }
        }
    }
}
