using Npgsql;
using System.Windows.Forms;
namespace DatabaseLibrary
{
    public class User
    {
        public static void Delete(int userID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) FROM public.\"User\" WHERE \"Role\" = 'Администратор' AND \"UserID\" != @UserID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);

                long count = (long)cmd.ExecuteScalar(); // Изменено приведение на long для предотвращения InvalidCastException

                if (count == 0) // Если это последний администратор
                {
                    MessageBox.Show("Это единственный администратор в системе, его удаление невозможно.", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Если это не последний администратор, можно безопасно удалить пользователя
                cmd.CommandText = "DELETE FROM public.\"User\" WHERE \"UserID\" = @UserID";
                cmd.ExecuteNonQuery();
            }
        }



        private static bool CheckUniqueLoginAndPassword(string login, string password)
        {
            // Первоначально проверяем только уникальность логина
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"Password\" FROM public.\"User\" " +
                    "WHERE \"Login\" = @Login;", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Login", login);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var storedPasswordHash = reader.GetString(0);
                        // Сверяем хэши паролей
                        if (BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                        {
                            return false; // Найдено совпадение логина и пароля
                        }
                    }
                }
            }
            return true; // Нет совпадений логина, или пароль отличается
        }

        public static void Insert(string fio, string login, string password, string role, bool isActive)
        {
            if (!CheckUniqueLoginAndPassword(login, password))
            {
                MessageBox.Show("Пользователь с таким логином и паролем уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"User\" (\"Login\", \"FullName\", \"Password\", \"Role\", \"isActive\") " +
                "VALUES (@Login, @FullName, @Password, @Role, @isActive);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@FullName", fio);
                cmd.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(password));
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(int userID, string fio, string login, string password, string role, bool isActive)
        {
            if (!CheckUniqueLoginAndPassword(login, password))
            {
                MessageBox.Show("Пользователь с таким логином и паролем уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"User\"\r\n\t" +
                "SET " +
                "\"FullName\"=@FullName, " +
                "\"Login\"=@Login, " +
                "\"Role\"=@Role, " +
                "\"isActive\"=@isActive, " +
                "\"Password\"=@Password " +
                "WHERE \"UserID\"=@UserID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@FullName", fio);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                cmd.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(password));
                cmd.ExecuteNonQuery();
            }
        }



    }
}
