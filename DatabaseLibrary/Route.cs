using Npgsql;
using System;
using System.Windows.Forms;

namespace DatabaseLibrary
{
    public class Route
    {
        //метод для обновления названия маршрута
        public static void UpdateRouteName(int routeID, string newName)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Route\" " +
                "SET \"Name\" = @newName WHERE \"RouteID\" = @routeID", 
                Autorization.npgSqlConnection)) 
            {
                //заполнение параметров и выполнение запроса
                cmd.Parameters.AddWithValue("@newName", newName);
                cmd.Parameters.AddWithValue("@routeID", routeID);
                cmd.ExecuteNonQuery();
            }
        }
        //метод для создания нового маршрута
        public static void Insert(string newName)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Route\" (\"Name\") VALUES (@Name);", 
                Autorization.npgSqlConnection))
            {
                //заполнение параметров и выполнение запроса
                cmd.Parameters.AddWithValue("@Name", newName);
                cmd.ExecuteNonQuery();
            }
        }
        //метод для удаления маршрута
        public static void Delete(int routeID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM public.\"Route\" WHERE \"RouteID\" = @RouteID",
                Autorization.npgSqlConnection))
            {
                try
                {
                    //заполнение параметров и выполнение запроса
                    cmd.Parameters.AddWithValue("@RouteID", routeID);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //если удаление маршрута приведет к нарушению целостности данных, то действие запрещается
                    MessageBox.Show("Ошибка: элемент используется в другой таблице.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
