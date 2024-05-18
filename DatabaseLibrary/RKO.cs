using Npgsql;
using System;

namespace DatabaseLibrary
{
    public class RKO
    {
        //метод для создания нового РКО
        public static void Insert(DateTime date, int contractorID, int invoiceID, double sum)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"RKO\"" +
                "(\r\n\t\"RkoDate\"," +
                " \"ContractorID\", \"PurchInvID\", \"Sum\")\r\n\t" +
                "VALUES (@RkoDate, @ContractorID, @PurchInvID, @Sum);",
                Autorization.npgSqlConnection))
            {
                //Заполнение параметров
                cmd.Parameters.AddWithValue("@RkoDate", date);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@PurchInvID", invoiceID);
                cmd.Parameters.AddWithValue("@Sum", sum);
                //Выполнение запроса
                cmd.ExecuteNonQuery();
            }
        }

        //метод для обновления РКО
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
                //Заполнение параметров
                cmd.Parameters.AddWithValue("@RkoDate", date);
                cmd.Parameters.AddWithValue("@PurchInvID", invoiceID);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@Sum", sum);
                cmd.Parameters.AddWithValue("@RkoNum", number);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@RkoID", rkoID);
                //выполнение запроса
                cmd.ExecuteNonQuery();
            }
        }

    }
}
