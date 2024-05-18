using Npgsql;
using System;
using System.Windows.Forms;

namespace DatabaseLibrary
{
    public class Driver
    {
        //метод для обновления записи о водителе
        public static void Update(int driverID, string name, object routeID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Driver\"\r\n\t" +
                "SET " +
                "\"Name\"=@Name, " +
                "\"RouteID\"=@RouteID " +
                "WHERE \"DriverID\"=@DriverID;",
                Autorization.npgSqlConnection))
            {
                //выполнение запроса и ввод параметров
                cmd.Parameters.AddWithValue("@DriverID", driverID);
                cmd.Parameters.AddWithValue("@Name", name);

                //водитель может быть без установленного ему маршрута
                if (routeID != null && routeID != DBNull.Value)
                {
                    cmd.Parameters.AddWithValue("@RouteID", (int)routeID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RouteID", DBNull.Value);
                }

                cmd.ExecuteNonQuery();
            }
        }

        //метод для удаления водителя
        public static void Delete(int driverID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"Driver\" " +
                "WHERE \"DriverID\" = @DriverID", Autorization.npgSqlConnection))
            {
                try
                {
                    //выполнение запроса и ввод параметров
                    cmd.Parameters.AddWithValue("@DriverID", driverID);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //если удаление этого водителя приведет к нарушению целостности БД, то выполнение действия запрещается
                    MessageBox.Show("Ошибка: элемент используется в другой таблице.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        //метод для создания нового водителя
        public static void Insert(string name)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Driver\"" +
                "(\r\n\t\"Name\") " +
                "VALUES (@Name);",
                Autorization.npgSqlConnection))
            {
                //выполнение запроса и ввод параметров
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
