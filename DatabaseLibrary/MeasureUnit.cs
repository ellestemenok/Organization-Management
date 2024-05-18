using Npgsql;
using System.Windows.Forms;
using System;
namespace DatabaseLibrary
{
    public class MeasureUnit
    {
        //метод для обновления записи в таблице единиц измерения
        public static void Update(int unitID, int okeiID, string name, string fullname, bool fractional)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"MeasureUnit\" " +
                "SET \"okeiID\" = @okeiID, " +
                "\"Name\" = @Name, " +
                "\"FullName\"= @FullName, " +
                "\"Fractional\"= @Fractional " +
                "WHERE \"UnitID\" = @UnitID;",
                Autorization.npgSqlConnection))
            {
                // Задаем параметры SQL-команды
                cmd.Parameters.AddWithValue("@UnitID", unitID);
                cmd.Parameters.AddWithValue("@okeiID", okeiID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@Fractional", fractional);
                // выполняем команду
                cmd.ExecuteNonQuery();
            }
        }
        //метод для создания единицы измерения
        public static void Insert(int okeiID, string name, string fullname, bool fractional)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"MeasureUnit\" " +
                "(\"okeiID\", \"Name\", \"FullName\", \"Fractional\")" +
                "VALUES (@okeiID, @Name, @FullName, @Fractional);",
                Autorization.npgSqlConnection))
            {
                // Задаем параметры SQL-команды
                cmd.Parameters.AddWithValue("@okeiID", okeiID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@Fractional", fractional);
                // выполняем команду
                cmd.ExecuteNonQuery();
            }
        }
        //метод для удаления единицы измерения
        public static void Delete(int unitID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"MeasureUnit\" " +
                "WHERE \"UnitID\" = @UnitID", Autorization.npgSqlConnection))
            {
                try
                {
                    // Задаем параметры SQL-команды и выполняем запрос
                    cmd.Parameters.AddWithValue("@UnitID", unitID);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //если удаление этой ед. измерения приведет к нарушению целостности БД, то выполнение действия запрещается
                    MessageBox.Show("Ошибка: элемент используется в другой таблице.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
