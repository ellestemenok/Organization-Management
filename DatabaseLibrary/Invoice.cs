using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DatabaseLibrary
{
    public class Invoice
    {

   
        public static void Update(int invoiceID, DateTime date, int number, int contractorID, int paymentID, bool isGiven, int? expNum)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Invoice\"\r\n\t" +
                "SET " +
                "\"InvoiceDate\"=@InvoiceDate, " +
                "\"InvoiceNumber\"=@InvoiceNumber, " +
                "\"ContractorID\"=@ContractorID, " +
                "\"Given\"=@Given, " +
                "\"ExpInvID\"=@ExpInvID, " +
                "\"PaymentID\"=@PaymentID\r\n\t" +
                "WHERE \"InvoiceID\"=@InvoiceID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                cmd.Parameters.AddWithValue("@InvoiceDate", date);
                cmd.Parameters.AddWithValue("@InvoiceNumber", number);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@Given", isGiven);
                cmd.Parameters.AddWithValue("@ExpInvID", expNum);
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);

                cmd.ExecuteNonQuery();
            }
        }

        public static void AddProductToInvoice(int invoiceID, int productID, int quantity)
        {
            if (Autorization.npgSqlConnection != null)
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO " +
                    "public.\"InvoiceDetail\" (\"InvoiceID\", \"ProductID\", \"Quantity\") " +
                    "VALUES (@InvoiceID, @ProductID, @Quantity);", Autorization.npgSqlConnection))
                {
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int invoiceID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"Invoice\" " +
                "WHERE \"InvoiceID\" = @InvoiceID", Autorization.npgSqlConnection))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: элемент используется в другой таблице.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
