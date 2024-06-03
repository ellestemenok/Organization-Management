using Npgsql;
using System.Windows.Forms;
namespace DatabaseLibrary
{
    public class Storage
    {
        //метод для обновления склада
        public static void Update(int storageID, string name, bool ismain, bool isfree)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Storage\"\r\n\t" +
                "SET " +
                "\"Name\"=@Name, " +
                "\"isMain\"=@isMain, " +
                "\"isFree\"=@isFree " +
                "WHERE \"StorageID\"=@StorageID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@StorageID", storageID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@isMain", ismain);
                cmd.Parameters.AddWithValue("@isFree", isfree);
                cmd.ExecuteNonQuery();
            }
        }
        //метод для удаления склада
        public static void Delete(int storageID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"Storage\" " +
                "WHERE \"StorageID\" = @StorageID", Autorization.npgSqlConnection))
            {
                try
                {
                    //заполнение параметров и выполнение запроса
                    cmd.Parameters.AddWithValue("@StorageID", storageID);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //если удаления склада приведет к нарушению целостности БД, то действие запрещается
                    MessageBox.Show("Ошибка: элемент используется в другой таблице.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        //метод для создания нового склада
        public static void Insert(string name, bool ismain, bool isfree)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Storage\"" +
                "(\r\n\t\"Name\"," +
                " \"isMain\"," +
                " \"isFree\"," +
                " \"OrganizationID\")\r\n\t" +
                "VALUES (@Name, @isMain, @isFree, 1);",
                Autorization.npgSqlConnection))
            {
                //заполнение параметров и выполнение запроса
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@isMain", ismain);
                cmd.Parameters.AddWithValue("@isFree", isfree);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
