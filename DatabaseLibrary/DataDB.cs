using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DatabaseLibrary
{
    public class DataDB
    {
        // Метод для заполнения DataGridView результатом SELECT запроса
        public static void FillDataGridViewWithQueryResult(DataGridView dataGridView, string query)
        {
            // Проверка, что соединение с базой данных открыто
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                // Использование NpgsqlDataAdapter для выполнения запроса и заполнения DataTable
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, Autorization.npgSqlConnection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable; // Установка DataTable в качестве источника данных для DataGridView
                }
            }
        }

        // Метод, который возвращает DataTable для получения данных
        public DataTable FillFormWithQueryResult(string query)
        {
            // Проверка, что соединение с базой данных открыто
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                // Использование NpgsqlCommand и NpgsqlDataAdapter для выполнения запроса и заполнения DataTable
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable; // Возвращение заполненного DataTable
                }
            }
            else
            {
                return null; // Возвращение null, если соединение не открыто
            }
        }

        // Метод для загрузки категорий в TreeView
        public static void LoadCategoriesIntoTreeView(string query, TreeView treeViewCategories)
        {
            // Проверка, что соединение с базой данных открыто
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                // Использование NpgsqlCommand и NpgsqlDataReader для выполнения запроса и чтения данных
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    treeViewCategories.Nodes.Clear(); // Очистка существующих узлов TreeView
                    while (reader.Read())
                    {
                        string categoryName = reader["Name"].ToString();
                        treeViewCategories.Nodes.Add(categoryName); // Добавление категории в TreeView
                    }
                }
            }
        }

        // Метод для загрузки данных в ComboBox
        public static void LoadDataIntoComboBox(ComboBox comboBox, string query)
        {
            // Проверка, что соединение с базой данных открыто
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                comboBox.Items.Clear(); // Очистка существующих элементов ComboBox
                // Использование NpgsqlCommand и NpgsqlDataReader для выполнения запроса и чтения данных
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        comboBox.Items.Add(new KeyValuePair<int, string>(ID, Name)); // Добавление элемента в ComboBox
                    }
                }
                // Установка отображаемого поля и значения по умолчанию
                comboBox.DisplayMember = "Value";
                comboBox.ValueMember = "Key";
            }
        }

        // Метод, возвращающий результат запроса с агрегатными функциями
        public static string ExecuteScalarQuery(string query)
        {
            string result = null;
            // Проверка, что соединение с базой данных открыто
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                // Использование NpgsqlCommand для выполнения запроса и получения результата
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                {
                    result = command.ExecuteScalar()?.ToString(); // Получение результата запроса
                }
            }
            return result; // Возвращение результата
        }

        // Метод для выполнения произвольного запроса
        public static void ExecuteQuery(string query)
        {
            // Проверка, что соединение с базой данных открыто
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                // Использование NpgsqlCommand для выполнения запроса
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                {
                    command.ExecuteNonQuery(); // Выполнение запроса
                }
            }
        }

        // Метод для выполнения запроса с параметрами
        public static void ExecuteQueryWithParams(string query, NpgsqlParameter[] parameters)
        {
            // Проверка, что соединение с базой данных открыто
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                // Использование NpgsqlCommand для выполнения запроса
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                {
                    // Добавление параметров к команде
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery(); // Выполнение запроса
                }
            }
        }
    }
}
