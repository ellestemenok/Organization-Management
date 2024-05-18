using Npgsql;
using System;
using System.Windows.Forms;
namespace DatabaseLibrary
{
    public class PurchaseInvoice
    {
        //метод для обновления записи приходной накладной
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
                //задаем параметры
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                cmd.Parameters.AddWithValue("@InvoiceDate", date);
                cmd.Parameters.AddWithValue("@InvoiceNumber", number);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@StorageID", storageID);
                //выполняем запрос
                cmd.ExecuteNonQuery();
            }
        }
        //метод для удаления приходной накладной
        public static void Delete(int invoiceID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"PurchaseInvoice\" " +
                "WHERE \"InvoiceID\" = @InvoiceID", Autorization.npgSqlConnection))
            {
                try
                { 
                    // задаем параметры и выполняем запрос
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //если удаление этой накладной приведет к нарушению целостности БД, то выполнение действия запрещается
                    MessageBox.Show("Ошибка: элемент используется в другой таблице.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        //метод для удаления элемента спецификации накладной 
        public static void DeleteDetail(int detailID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"PurchaseInvoiceDetail\" " +
                "WHERE \"DetailID\" = @DetailID", Autorization.npgSqlConnection))
            {
                // задаем параметры и выполняем запрос
                cmd.Parameters.AddWithValue("@DetailID", detailID);
                cmd.ExecuteNonQuery();
            }
        }
        //метод для создания новой приходной накладной
        public static void Insert(DateTime date, int contractorID, int storageID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"PurchaseInvoice\"" +
                "(\r\n\t\"InvoiceDate\", " +
                "\"ContractorID\", " +
                "\"StorageID\") \r\n\t" +
                "VALUES (@InvoiceDate, @ContractorID, @StorageID);",
                Autorization.npgSqlConnection))
            {
                //задаем параметры
                cmd.Parameters.AddWithValue("@InvoiceDate", date);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@StorageID", storageID);
                //выполняем запрос
                cmd.ExecuteNonQuery();
            }
        }
        //метод для добавления элемента спецификации приходной накладной
        public static void AddProductToInvoice(int invoiceID, int productID, double quantity)
        {
            if (Autorization.npgSqlConnection != null)
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO " +
                    "public.\"PurchaseInvoiceDetail\" (\"InvoiceID\", \"ProductID\", \"Quantity\") " +
                    "VALUES (@InvoiceID, @ProductID, @Quantity);", Autorization.npgSqlConnection))
                {
                    // задаем параметры
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    //выполняем запрос
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
