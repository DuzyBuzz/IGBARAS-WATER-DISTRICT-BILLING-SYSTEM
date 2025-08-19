using System;
using System.Data;
using System.Data.OleDb;

namespace IGBARAS_WATER_DISTRICT.Helpers
{
    internal class RecentBillDetailsHelper
    {
        public class BillingInfo
        {
            public string BillNo { get; set; }
            public string AccountNo { get; set; }
            public DateTime DateFrom { get; set; }
            public DateTime DateTo { get; set; }
            public decimal PrevReading { get; set; }
            public decimal PresentReading { get; set; }
            public DateTime DueDate { get; set; }
            public DateTime DateCreated { get; set; }
            public decimal Penalty { get; set; }
            public decimal Tax { get; set; }
            public string DiscountName { get; set; }
            public int Discount { get; set; }
            public decimal OtherDiscount { get; set; }
            public decimal DiscountAmount { get; set; }
            public decimal Balance { get; set; }
            public decimal ArrearsAmount { get; set; }
            public decimal TotalAmountBilled { get; set; }
            public string Others1 { get; set; }
            public decimal OthersAmount1 { get; set; }
            public string Others2 { get; set; }
            public decimal OthersAmount2 { get; set; }
            public decimal AmountPaid { get; set; }
            public decimal AmountBilled { get; set; }
            public decimal TaxAmount { get; set; }

            public bool IsArrears { get; set; }
            public bool IsFullyPaid { get; set; }
            public bool IsPatrtiallyPaid { get; set; }
            public decimal SCFArrearsAmount { get; set; }
            public decimal CurrentSCFAmount { get; set; }
            public bool IsSCFPaid { get; set; }
            public bool IsSCFPartiallyPaid { get; set; }
            public decimal TotalSCFAmount { get; set; }
            public decimal SCFBalance { get; set; }
            public int FreeWater { get; set; }
            public bool IsInitialBilling { get; set; }

        }

        public BillingInfo GetBillByBillNo(string billNo)
        {
            if (string.IsNullOrWhiteSpace(billNo))
                return null;

            using (var connection = new OleDbConnection(DbConfig.ConnectionString))
            {
                const string query = @"
                    SELECT 
                        b.*, 
                        p.Balance,
                        p.SCFBalance
                    FROM 
                        Tb_Billing AS b
                    LEFT JOIN 
                        Tb_Payments AS p 
                        ON b.BillNo = p.CurrentBillNo
                    WHERE 
                        b.BillNo = ?
                ";

                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", billNo);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new BillingInfo
                            {
                                BillNo = reader["BillNo"]?.ToString(),
                                AccountNo = reader["AccountNo"]?.ToString(),
                                DateFrom = reader["DateFrom"] != DBNull.Value ? Convert.ToDateTime(reader["DateFrom"]) : DateTime.MinValue,
                                DateTo = reader["DateTo"] != DBNull.Value ? Convert.ToDateTime(reader["DateTo"]) : DateTime.MinValue,
                                PrevReading = reader["PrevReading"] != DBNull.Value ? Convert.ToDecimal(reader["PrevReading"]) : 0m,
                                PresentReading = reader["PresentReading"] != DBNull.Value ? Convert.ToDecimal(reader["PresentReading"]) : 0m,
                                DueDate = reader["DueDate"] != DBNull.Value ? Convert.ToDateTime(reader["DueDate"]) : DateTime.MinValue,
                                DateCreated = reader["DateCreated"] != DBNull.Value ? Convert.ToDateTime(reader["DateCreated"]) : DateTime.MinValue,
                                Penalty = reader["Penalty"] != DBNull.Value ? Convert.ToDecimal(reader["Penalty"]) : 0m,
                                Tax = reader["Tax"] != DBNull.Value ? Convert.ToDecimal(reader["Tax"]) : 0m,
                                DiscountName = reader["DiscountName"]?.ToString(),
                                Discount = reader["Discount"] != DBNull.Value ? Convert.ToInt32(reader["Discount"]) : 0,
                                OtherDiscount = reader["OtherDiscount"] != DBNull.Value ? Convert.ToDecimal(reader["OtherDiscount"]) : 0m,
                                DiscountAmount = reader["DiscountAmount"] != DBNull.Value ? Convert.ToDecimal(reader["DiscountAmount"]) : 0m,
                                Balance = reader["Balance"] != DBNull.Value ? Convert.ToDecimal(reader["Balance"]) : 0m,
                                ArrearsAmount = reader["ArrearsAmount"] != DBNull.Value ? Convert.ToDecimal(reader["ArrearsAmount"]) : 0m,
                                TotalAmountBilled = reader["TotalAmountBilled"] != DBNull.Value ? Convert.ToDecimal(reader["TotalAmountBilled"]) : 0m,
                                Others1 = reader["Others1"]?.ToString(),
                                OthersAmount1 = reader["OthersAmount1"] != DBNull.Value ? Convert.ToDecimal(reader["OthersAmount1"]) : 0m,
                                Others2 = reader["Others2"]?.ToString(),
                                OthersAmount2 = reader["OthersAmount2"] != DBNull.Value ? Convert.ToDecimal(reader["OthersAmount2"]) : 0m,
                                AmountPaid = reader["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(reader["AmountPaid"]) : 0m,
                                AmountBilled = reader["AmountBilled"] != DBNull.Value ? Convert.ToDecimal(reader["AmountBilled"]) : 0m,
                                TaxAmount = reader["TaxAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TaxAmount"]) : 0m,

                                IsArrears = reader["Is_Arrears"] != DBNull.Value && Convert.ToBoolean(reader["Is_Arrears"]),
                                IsFullyPaid = reader["Is_FullyPaid"] != DBNull.Value && Convert.ToBoolean(reader["Is_FullyPaid"]),
                                IsPatrtiallyPaid = reader["Is_PartiallyPaid"] != DBNull.Value && Convert.ToBoolean(reader["Is_PartiallyPaid"]),
                                CurrentSCFAmount = reader["ServiceConnectionFee"] != DBNull.Value ? Convert.ToDecimal(reader["ServiceConnectionFee"]) : 0m,
                                SCFArrearsAmount = reader["SCFArrears"] != DBNull.Value ? Convert.ToDecimal(reader["SCFArrears"]) : 0m,
                                TotalSCFAmount = reader["TotalSCF"] != DBNull.Value ? Convert.ToDecimal(reader["TotalSCF"]) : 0m,
                                IsSCFPaid = reader["Is_SCFPaid"] != DBNull.Value && Convert.ToBoolean(reader["Is_SCFPaid"]),
                                IsSCFPartiallyPaid = reader["Is_SCFPartiallyPaid"] != DBNull.Value && Convert.ToBoolean(reader["Is_SCFPartiallyPaid"]),
                                SCFBalance = reader["SCFBalance"] != DBNull.Value ? Convert.ToDecimal(reader["SCFBalance"]) : 0m,
                                FreeWater = reader["FreeWater"] != DBNull.Value ? Convert.ToInt32(reader["FreeWater"]) : 0,
                                IsInitialBilling = reader["Is_InitialBilling"] != DBNull.Value && Convert.ToBoolean(reader["Is_InitialBilling"]),

                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
