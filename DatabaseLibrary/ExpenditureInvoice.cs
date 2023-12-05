using Npgsql;
using System;
using System.Data;

namespace DatabaseLibrary
{
    public class ExpenditureInvoice
    {
        public static void Update(int invoiceID, DateTime date, int number, int contractorID, int storageID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"ExpenditureInvoice\"\r\n\t" +
                "SET " +
                "\"InvoiceDate\"=@InvoiceDate, " +
                "\"InvoiceNumber\"=@InvoiceNumber, " +
                "\"ContractorID\"=@ContractorID, " +
                "\"StorageID\"=@StorageID\r\n\t" +
                "WHERE \"InvoiceID\" =@InvoiceID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                cmd.Parameters.AddWithValue("@InvoiceDate", date);
                cmd.Parameters.AddWithValue("@InvoiceNumber", number);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@StorageID", storageID);

                cmd.ExecuteNonQuery();
            }
        }
        public static void Delete(int invoiceID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"ExpenditureInvoice\" " +
                "WHERE \"InvoiceID\" = @InvoiceID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteDetail(int detailID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"ExpenditureInvoiceDetail\" " +
                "WHERE \"DetailID\" = @DetailID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@DetailID", detailID);
                cmd.ExecuteNonQuery();
            }
        }
        public static void Insert(DateTime date, int contractorID, int storageID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"ExpenditureInvoice\"" +
                "(\r\n\t\"InvoiceDate\", " +
                "\"ContractorID\", " +
                "\"StorageID\") \r\n\t" +
                "VALUES (@InvoiceDate, @ContractorID, @StorageID);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@InvoiceDate", date);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@StorageID", storageID);

                cmd.ExecuteNonQuery();
            }
        }
        public static void AddProductToInvoice(int invoiceID, int productID, int quantity)
        {
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"ExpenditureInvoiceDetail\" " +
                    "(\"InvoiceID\", \"ProductID\", \"Quantity\") " +
                    "VALUES (@InvoiceID, @ProductID, @Quantity);", Autorization.npgSqlConnection))
                {
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
