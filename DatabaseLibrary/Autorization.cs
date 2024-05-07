using Npgsql;
using System;
using System.Data;
namespace DatabaseLibrary
{
    public class Autorization
    {
        public static NpgsqlConnection npgSqlConnection;
        public static string username; 
        public static string password;
        public static string connectionString;
        static public void Autorize(string userID, string pswrd) 
        {
            username = userID;
            password = pswrd;
            connectionString = String.Format($"Server=localhost;Port=5432;User ID={username};Password={password};Database=db;");
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }
        static public void OpenConnection()
        {
            connectionString = String.Format($"Server=localhost;Port=5432;User ID={username};Password={password};Database=db;");
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
