using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace DatabaseLibrary
{
    public class ExpenditureInvoice
    {
        // Метод для обновления накладной
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
                // Установка параметров команды
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                cmd.Parameters.AddWithValue("@InvoiceDate", date);
                cmd.Parameters.AddWithValue("@InvoiceNumber", number);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@StorageID", storageID);

                // Выполнение команды
                cmd.ExecuteNonQuery();
            }
        }

        // Метод для удаления накладной
        public static void Delete(int invoiceID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"ExpenditureInvoice\" " +
                "WHERE \"InvoiceID\" = @InvoiceID", Autorization.npgSqlConnection))
            {
                try
                {
                    // Установка параметра команды
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);

                    // Выполнение команды
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Обработка ошибки при удалении, если элемент используется в другой таблице
                    MessageBox.Show("Ошибка: элемент используется в другой таблице.", "Запрещено", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        // Метод для удаления детали накладной
        public static void DeleteDetail(int detailID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"ExpenditureInvoiceDetail\" " +
                "WHERE \"DetailID\" = @DetailID", Autorization.npgSqlConnection))
            {
                // Установка параметра команды
                cmd.Parameters.AddWithValue("@DetailID", detailID);

                // Выполнение команды
                cmd.ExecuteNonQuery();
            }
        }

        // Метод для вставки новой накладной
        public static void Insert(DateTime date, int contractorID, int storageID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"ExpenditureInvoice\"" +
                "(\r\n\t\"InvoiceDate\", " +
                "\"ContractorID\", " +
                "\"StorageID\") \r\n\t" +
                "VALUES (@InvoiceDate, @ContractorID, @StorageID);",
                Autorization.npgSqlConnection))
            {
                // Установка параметров команды
                cmd.Parameters.AddWithValue("@InvoiceDate", date);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@StorageID", storageID);

                // Выполнение команды
                cmd.ExecuteNonQuery();
            }
        }
        // Метод для добавления продукта к накладной
        public static void AddProductToInvoice(int invoiceID, int productID, double quantity)
        {
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"ExpenditureInvoiceDetail\" " +
                    "(\"InvoiceID\", \"ProductID\", \"Quantity\") " +
                    "VALUES (@InvoiceID, @ProductID, @Quantity);", Autorization.npgSqlConnection))
                {
                    // Установка параметров команды
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);

                    // Выполнение команды
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}