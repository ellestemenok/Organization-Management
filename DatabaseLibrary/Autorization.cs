using DocumentFormat.OpenXml.Spreadsheet;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace DatabaseLibrary
{
    public class Autorization
    {
        public static NpgsqlConnection npgSqlConnection;

        static public void Autorize(string userID, string password) 
        {
            string connectionString = String.Format($"Server=localhost;Port=5432;User ID={userID};Password={password};Database=db;");
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }

        static public void OpenConnection()
        {
            string connectionString = String.Format($"Server=localhost;Port=5432;User ID=postgres;Password=5215e;Database=db;");
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

        static public void Reconnect()
        {
            CloseConnection();
            OpenConnection();
        }

    }
}
