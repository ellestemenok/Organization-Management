using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Npgsql;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseLibrary
{
    public class DataDB
    {
        public static void FillDataGridViewWithQueryResult(DataGridView dataGridView, string query) //метод для записи в определенную таблицу результат SELECT запроса
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

        public DataTable FillFormWithQueryResult(string query) //метод, который возвращает таблицу, чтобы "вытащить" оттуда данные
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
            // Установим отображаемое поле и значение по умолчанию (если нужно)
                comboBox.DisplayMember = "Value";
                comboBox.ValueMember = "Key";
            }
        }


    }
}
