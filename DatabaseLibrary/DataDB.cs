using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace DatabaseLibrary
{
    public class DataDB
    {
        //метод для записи в определенную таблицу результат SELECT запроса
        public static void FillDataGridViewWithQueryResult(DataGridView dataGridView, string query) 
        {
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, Autorization.npgSqlConnection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
            }
        }
        //метод, который возвращает таблицу, чтобы "вытащить" оттуда данные
        public DataTable FillFormWithQueryResult(string query) 
        {
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            else { return null; }
        }
        public static void LoadCategoriesIntoTreeView(string query, TreeView treeViewCategories)
        {
            // Подключение к базе данных и запрос данных
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    treeViewCategories.Nodes.Clear();
                    while (reader.Read())
                    {
                        string categoryName = reader["Name"].ToString();
                        treeViewCategories.Nodes.Add(categoryName);
                    }
                }
            }
        }
        public static void LoadDataIntoComboBox(ComboBox comboBox, string query)
        {
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                comboBox.Items.Clear();
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        comboBox.Items.Add(new KeyValuePair<int, string>(ID, Name));
                    }
                }
            // установим отображаемое поле и значение по умолчанию
                comboBox.DisplayMember = "Value";
                comboBox.ValueMember = "Key";
            }
        }
        //метод, возвращающий результат запроса с агрегатными функциями
        public static string ExecuteScalarQuery(string query)
        {
            string result = null;
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                {
                    result = command.ExecuteScalar()?.ToString();
                }
            }
            return result;
        }

        public static void ExecuteQuery(string query)
        {
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ExecuteQueryWithParams(string query, NpgsqlParameter[] parameters)
        {
            if (Autorization.npgSqlConnection != null && Autorization.npgSqlConnection.State == ConnectionState.Open)
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, Autorization.npgSqlConnection))
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
