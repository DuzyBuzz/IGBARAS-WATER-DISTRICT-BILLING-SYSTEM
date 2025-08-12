using IGBARAS_WATER_DISTRICT.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

public static class TableUpdaterHelper
{
    // CREATE/UPDATE: Already handled by this method
    public static void UpdateTableFromGrid(DataGridView dgv, string tableName, string idColumn)
    {
        if (dgv.DataSource == null || dgv.Rows.Count == 0)
            return;

        using (var connection = new OleDbConnection(DbConfig.ConnectionString))
        {
            connection.Open();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var isInsert = row.Cells[idColumn].Value == null || string.IsNullOrWhiteSpace(row.Cells[idColumn].Value.ToString());

                var cmd = new OleDbCommand();
                cmd.Connection = connection;

                if (isInsert)
                {
                    // INSERT
                    var columnNames = new List<string>();
                    var paramPlaceholders = new List<string>();

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        var colName = dgv.Columns[i].Name;
                        if (string.Equals(colName, idColumn, StringComparison.OrdinalIgnoreCase))
                            continue;

                        columnNames.Add($"[{colName}]");
                        paramPlaceholders.Add("?");
                        cmd.Parameters.AddWithValue($"@p{i}", row.Cells[i].Value ?? DBNull.Value);
                    }

                    cmd.CommandText = $"INSERT INTO [{tableName}] ({string.Join(",", columnNames)}) VALUES ({string.Join(",", paramPlaceholders)})";
                }
                else
                {
                    // UPDATE
                    var idValue = row.Cells[idColumn].Value;
                    var updateQuery = new StringBuilder($"UPDATE [{tableName}] SET ");

                    int paramCount = 0;
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        var columnName = dgv.Columns[i].Name;
                        if (string.Equals(columnName, idColumn, StringComparison.OrdinalIgnoreCase))
                            continue;

                        updateQuery.Append($"[{columnName}] = ?, ");
                        cmd.Parameters.AddWithValue($"@p{paramCount++}", row.Cells[i].Value ?? DBNull.Value);
                    }

                    updateQuery.Length -= 2; // remove last comma
                    updateQuery.Append($" WHERE [{idColumn}] = ?");
                    cmd.Parameters.AddWithValue("@id", idValue);

                    cmd.CommandText = updateQuery.ToString();
                }

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error on row: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // READ: Load all rows from a table into a DataTable
    public static DataTable ReadTable(string tableName)
    {
        var dt = new DataTable();
        using (var connection = new OleDbConnection(DbConfig.ConnectionString))
        {
            string query = $"SELECT * FROM [{tableName}]";
            using (var adapter = new OleDbDataAdapter(query, connection))
            {
                adapter.Fill(dt);
            }
        }
        return dt;
    }

    // DELETE: Delete a row by ID
    public static bool DeleteRow(string tableName, string idColumn, object idValue)
    {
        using (var connection = new OleDbConnection(DbConfig.ConnectionString))
        {
            string query = $"DELETE FROM [{tableName}] WHERE [{idColumn}] = ?";
            using (var cmd = new OleDbCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", idValue);
                connection.Open();
                int affected = cmd.ExecuteNonQuery();
                return affected > 0;
            }
        }
    }
}
