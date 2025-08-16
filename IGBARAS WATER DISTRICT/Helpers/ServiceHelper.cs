using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace IGBARAS_WATER_DISTRICT.Helpers
{
    /// <summary>
    /// Represents a single service item containing the ServiceID.
    /// </summary>
    public class ServiceItem
    {
        public int ServiceID { get; set; } // e.g., 1, 2, 10

        public override string ToString()
        {
            return ServiceID.ToString(); // Shown in ComboBox directly
        }
    }

    internal static class ServiceHelper
    {
        /// <summary>
        /// Retrieves all ServiceID values from Tb_Service in ascending order.
        /// </summary>
        public static List<ServiceItem> GetServiceIDHelper()
        {
            List<ServiceItem> serviceList = new List<ServiceItem>();

            // Open Access database connection
            using (OleDbConnection conn = new OleDbConnection(DbConfig.ConnectionString))
            {
                conn.Open();

                // Select ServiceID column from Tb_Service ordered ascending
                string query = @"
                    SELECT ServiceID 
                    FROM Tb_Service 
                    ORDER BY ServiceID ASC";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    // NOTE: No parameters needed since we are selecting all ServiceID

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Safely convert ServiceID to int
                            int serviceId = Convert.ToInt32(reader["ServiceID"]);

                            // Add to list as ServiceItem object
                            serviceList.Add(new ServiceItem
                            {
                                ServiceID = serviceId
                            });
                        }
                    }
                }
            }

            return serviceList;
        }
    }
}
