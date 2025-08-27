using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace IGBARAS_WATER_DISTRICT.Helpers
{
    public static class CustomTableLoaderHelper
    {
        public static DataTable LoadSelectedColumnsToDataTable(string tableName, string[] columns)
        {
            if (columns == null || columns.Length == 0)
                throw new ArgumentException("No columns specified.");

            string columnList = string.Join(", ", columns);
            string query = $"SELECT {columnList} FROM [{tableName}]";

            using (var connection = new OleDbConnection(DbConfig.ConnectionString))
            using (var adapter = new OleDbDataAdapter(query, connection))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt; // return the full table
            }
        }

    }
}