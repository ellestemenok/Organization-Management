using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class PKO
    {
        public static void Insert(DateTime date, int contractorID, int invoiceID, double sum)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"PKO\"" +
                "(\r\n\t\"PkoDate\"," +
                " \"ContractorID\", \"ExpInvID\", \"Sum\")\r\n\t" +
                "VALUES (@PkoDate, @ContractorID, @ExpInvID, @Sum);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@PkoDate", date);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@ExpInvID", invoiceID);
                cmd.Parameters.AddWithValue("@Sum", sum);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(int pkoID, DateTime date, int number, int contractorID, int invoiceID, double sum, string name = "")
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"PKO\"\r\n\t" +
                "SET " +
                "\"PkoDate\"=@PkoDate, " +
                "\"ExpInvID\"=@ExpInvID, " +
                "\"ContractorID\"=@ContractorID, " +
                "\"Sum\"=@Sum, " +
                "\"PkoNum\"=@PkoNum," +
                "\"Name\"=@Name " +
                "WHERE \"PkoID\"=@PkoID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@PkoDate", date);
                cmd.Parameters.AddWithValue("@ExpInvID", invoiceID);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@Sum", sum);
                cmd.Parameters.AddWithValue("@PkoNum", number);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@PkoID", pkoID);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
