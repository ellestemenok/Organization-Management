using Npgsql; // Подключение библиотеки Npgsql для работы с PostgreSQL
using System.Configuration; // Подключение библиотеки System.Configuration для работы с конфигурацией приложения
using System.Data; // Подключение библиотеки System.Data для работы с данными
using System.Windows.Forms; // Подключение библиотеки System.Windows.Forms для работы с формами

namespace DatabaseLibrary
{
    public class Autorization
    {
        // Объявление статической переменной для хранения подключения к базе данных PostgreSQL
        public static NpgsqlConnection npgSqlConnection;

        // Получение строки подключения из конфигурационного файла приложения
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Объявление статической переменной для хранения полного имени пользователя
        public static string fullName;

        // Метод для авторизации пользователя по логину и паролю
        public static (string Role, string FullName, int UserID) Autorize(string login, string pswrd)
        {
            // Создание подключения к базе данных с использованием строки подключения
            using (var npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                npgSqlConnection.Open(); // Открытие подключения к базе данных

                // Создание команды SQL для получения информации о пользователе по логину
                var cmd = new NpgsqlCommand("SELECT \"Password\", \"Role\", \"FullName\", \"UserID\", \"isActive\" " +
                    "FROM public.\"User\" WHERE \"Login\" = @Login", npgSqlConnection);
                cmd.Parameters.AddWithValue("@Login", login); // Добавление параметра логина в команду

                // Выполнение команды и чтение результатов
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Проверка, удалось ли найти пользователя
                    {
                        bool isActive = reader.GetBoolean(4); // Получение значения, активен ли пользователь
                        string role = reader.GetString(1); // Получение роли пользователя

                        if (isActive) // Если пользователь активен
                        {
                            string storedPassword = reader.GetString(0); // Получение хранимого пароля
                            fullName = reader.GetString(2); // Получение полного имени пользователя
                            int userID = reader.GetInt32(3); // Получение идентификатора пользователя

                            // Проверка пароля пользователя с использованием BCrypt
                            if (BCrypt.Net.BCrypt.Verify(pswrd, storedPassword))
                            {
                                return (role, fullName, userID); 
                                // Возврат роли, полного имени и идентификатора пользователя при успешной авторизации
                            }
                        }
                        else if (role != "Администратор") // Если роль пользователя не "Администратор"
                        {
                            // Вывод сообщения об ошибке, если аккаунт не активен
                            MessageBox.Show("Ваш аккаунт не активен.", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return (null, null, 0); // Возврат null значений и 0 идентификатора пользователя
                        }
                    }
                }
            }
            return (null, null, 0); // Возврат null значений и 0 идентификатора пользователя при неуспешной авторизации
        }

        // Метод для открытия подключения к базе данных
        static public void OpenConnection()
        {
            npgSqlConnection = new NpgsqlConnection(connectionString); // Создание нового подключения к базе данных
            npgSqlConnection.Open(); // Открытие подключения
        }

        // Метод для закрытия подключения к базе данных
        static public void CloseConnection()
        {
            if (npgSqlConnection != null && npgSqlConnection.State == ConnectionState.Open) // Проверка, что подключение открыто
            {
                npgSqlConnection.Close(); // Закрытие подключения
            }
        }
    }
}