using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
namespace DatabaseLibrary
{
    public class Autorization
    {
        public static NpgsqlConnection npgSqlConnection;
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static string fullName; 

        public static (string Role, string FullName, int UserID) Autorize(string login, string pswrd)
        {
            using (var npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                npgSqlConnection.Open();
                var cmd = new NpgsqlCommand("SELECT \"Password\", \"Role\", \"FullName\", \"UserID\", \"isActive\" FROM public.\"User\" WHERE \"Login\" = @Login", npgSqlConnection);
                cmd.Parameters.AddWithValue("@Login", login);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Ensure there's a row to read
                    {
                        bool isActive = reader.GetBoolean(4);
                        string role = reader.GetString(1); // Define 'role' here to use it below

                        if (isActive)
                        {
                            string storedPassword = reader.GetString(0);
                            fullName = reader.GetString(2);
                            int userID = reader.GetInt32(3);

                            if (BCrypt.Net.BCrypt.Verify(pswrd, storedPassword))
                            {
                                return (role, fullName, userID);
                            }
                        }
                        else if (role != "Администратор") //
                        {
                            MessageBox.Show("Ваш аккаунт не активен.", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return (null, null, 0);
                        }
                    }
                }
            }
            return (null, null, 0); // Returns null if authorization failed
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
