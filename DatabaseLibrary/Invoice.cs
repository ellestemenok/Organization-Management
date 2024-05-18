using Npgsql;
using System;
using System.Windows.Forms;

namespace DatabaseLibrary
{
    public class Invoice
    {
        //метод для обновления записи о счет-фактуре
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
                //выполнение запроса и ввод параметров
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
        //метод для удаления счет-фактуры
        public static void Delete(int invoiceID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"Invoice\" " +
                "WHERE \"InvoiceID\" = @InvoiceID", Autorization.npgSqlConnection))
            {
                try
                {
                    //выполнение запроса и ввод параметров
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //если удаление этой счет-фактуры приведет к нарушению целостности БД, то выполнение действия запрещается
                    MessageBox.Show("Ошибка: элемент используется в другой таблице.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
