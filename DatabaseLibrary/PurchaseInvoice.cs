using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class PurchaseInvoice
    {
        public static void Update(int invoiceID, DateTime date, int number, int contractorID, int storageID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"PurchaseInvoice\"\r\n\t" +
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
                "public.\"PurchaseInvoice\" " +
                "WHERE \"InvoiceID\" = @InvoiceID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteDetail(int detailID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"PurchaseInvoiceDetail\" " +
                "WHERE \"DetailID\" = @DetailID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@DetailID", detailID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void AddProductToInvoice(int invoiceID, int productID, int quantity)
        {
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"PurchaseInvoiceDetail\" (\"InvoiceID\", \"ProductID\", \"Quantity\") VALUES (@InvoiceID, @ProductID, @Quantity);", Autorization.npgSqlConnection))
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
