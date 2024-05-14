using Npgsql;
using System;
using System.Configuration;
using System.Data;
namespace DatabaseLibrary
{
    public class Autorization
    {
        public static NpgsqlConnection npgSqlConnection;
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static string fullName; // Поле для хранения полного имени
        public static (string Role, string FullName, int UserID) Autorize(string login, string pswrd)
        {
            using (var npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                npgSqlConnection.Open();
                var cmd = new NpgsqlCommand("SELECT \"Password\", \"Role\", \"FullName\", \"UserID\" FROM public.\"User\" WHERE \"Login\" = @Login", npgSqlConnection);
                cmd.Parameters.AddWithValue("@Login", login);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader.GetString(0);
                        string role = reader.GetString(1);
                        fullName = reader.GetString(2); // Считываем полное имя
                        int userID = reader.GetInt32(3); // Считываем UserID

                        if (BCrypt.Net.BCrypt.Verify(pswrd, storedPassword))
                        {
                            return (role, fullName, userID); // Возвращаем роль и полное имя
                        }
                    }
                }
            }
            return (null, null, 0); // Возвращает null, если авторизация не удалась
        }


        static public void OpenConnection()
        {
            //
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }



        static public void CloseConnection()
        {
            if (npgSqlConnection != null && npgSqlConnection.State == ConnectionState.Open)
            {
                npgSqlConnection.Close();
            }
        }
    }
}
