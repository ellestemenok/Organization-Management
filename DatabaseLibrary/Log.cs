using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Log
    {
        public static void Insert(int userID, string logText)
        {
            // Получаем текущее время
            DateTime logDate = DateTime.Now;
            // Создаем SQL-команду для вставки данных в таблицу логов
            string query = "INSERT INTO public.\"Log\" (\"LogDate\", \"UserID\", \"LogText\") VALUES (@LogDate, @UserID, @LogText);";

            using (var npgSqlConnection = new NpgsqlConnection(Autorization.connectionString))
            {
                // Открываем соединение
                npgSqlConnection.Open();

                using (var cmd = new NpgsqlCommand(query, npgSqlConnection))
                {
                    // Задаем параметры SQL-команды
                    cmd.Parameters.AddWithValue("@LogDate", logDate);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@LogText", logText);

                    // Выполняем команду
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
