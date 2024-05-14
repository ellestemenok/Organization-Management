using DocumentFormat.OpenXml.Spreadsheet;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Cashbox
    {

        public static void Insert(string name, DateTime date)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Cashbox\"" +
                "(\r\n\t\"Name\"," +
                " \"CashboxDate\")\r\n\t" +
                "VALUES (@Name, @CashboxDate);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@CashboxDate", date);
                cmd.ExecuteNonQuery();
            }
        }

        public static bool Exists(DateTime date)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"Cashbox\"" +
                " WHERE \"CashboxDate\" = @date;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@date", date);
                var count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
               
        }

        public static void AddPayment(DateTime time, string type, double sum, int? contractorID, string name, int cashboxID, int userID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Payment\" " +
                "(\"Time\", \"Type\", \"Sum\", \"ContractorID\", \"Name\", \"CashboxID\", \"CreatedBy\") " +
                "VALUES (@time, @type, @sum, @contractorID, @name, @cashboxID, @userID)",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@time", time.TimeOfDay);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@sum", sum);
                if (contractorID.HasValue)
                    cmd.Parameters.AddWithValue("@contractorID", contractorID.Value);
                else
                    cmd.Parameters.AddWithValue("@contractorID", DBNull.Value);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@cashboxID", cashboxID);
                cmd.Parameters.AddWithValue("@userID", userID);

                cmd.ExecuteNonQuery();
            }

        }

    }
}
