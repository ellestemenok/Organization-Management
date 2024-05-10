using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class RKO
    {
        public static void Insert(DateTime date, int contractorID, int invoiceID, double sum)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"RKO\"" +
                "(\r\n\t\"RkoDate\"," +
                " \"ContractorID\", \"PurchInvID\", \"Sum\")\r\n\t" +
                "VALUES (@RkoDate, @ContractorID, @PurchInvID, @Sum);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@RkoDate", date);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@PurchInvID", invoiceID);
                cmd.Parameters.AddWithValue("@Sum", sum);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(int rkoID, DateTime date, int number, int contractorID, int invoiceID, double sum, string name = "")
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"RKO\"\r\n\t" +
                "SET " +
                "\"RkoDate\"=@RkoDate, " +
                "\"PurchInvID\"=@PurchInvID, " +
                "\"ContractorID\"=@ContractorID, " +
                "\"Sum\"=@Sum, " +
                "\"RkoNum\"=@RkoNum," +
                "\"Name\"=@Name " +
                "WHERE \"RkoID\"=@RkoID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@RkoDate", date);
                cmd.Parameters.AddWithValue("@PurchInvID", invoiceID);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@Sum", sum);
                cmd.Parameters.AddWithValue("@RkoNum", number);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@RkoID", rkoID);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
