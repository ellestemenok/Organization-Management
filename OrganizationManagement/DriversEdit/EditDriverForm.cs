using DatabaseLibrary;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.DriversEdit
{
    // Класс формы для редактирования водителя, унаследованный от Form
    public partial class EditDriverForm : Form
    {
        private int driverID; // Поле для хранения идентификатора водителя
        private DataTable driversData; // Поле для хранения данных водителей

        // Конструктор формы EditDriverForm
        public EditDriverForm(DataTable driversData)
        {
            InitializeComponent(); // Инициализация компонентов формы
            this.driversData = driversData; // Инициализация поля driversData

            // Проверка наличия строк в таблице данных водителей
            if (driversData.Rows.Count > 0)
            {
                // Загрузка данных маршрутов в комбобокс
                DataDB.LoadDataIntoComboBox(routesBox, "SELECT \"RouteID\", \"Name\" FROM public.\"Route\" WHERE \"RouteID\" <> 1 ORDER BY \"RouteID\" ASC");

                // Инициализация driverID из первой строки данных водителей
                driverID = Convert.ToInt32(driversData.Rows[0]["DriverID"]);

                // Установка текста в поле имени на основе данных водителей
                nameField.Text = driversData.Rows[0]["Name"].ToString();
            }
        }

        // Обработчик события клика по кнопке сохранения
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение имени водителя из текстового поля
            string name = nameField.Text;

            // Инициализация routeID как nullable для возможности присвоения null
            int? routeID = null;

            // Проверка наличия выбранного элемента в комбобоксе маршрутов
            if (routesBox.SelectedItem != null)
            {
                // Присвоение routeID значения ключа выбранного элемента
                routeID = ((KeyValuePair<int, string>)routesBox.SelectedItem).Key;

                // Подготовка запроса и параметров для сброса маршрута у других водителей
                string resetRouteQuery = "UPDATE public.\"Driver\" SET \"RouteID\" = NULL WHERE \"RouteID\" = @RouteID AND \"DriverID\" != @DriverID";
                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@RouteID", routeID),
                    new NpgsqlParameter("@DriverID", driverID)
                };

                // Сброс маршрута у других водителей
                DataDB.ExecuteQueryWithParams(resetRouteQuery, parameters);
            }

            // Обновление информации о текущем водителе
            Driver.Update(driverID, name, routeID.HasValue ? routeID.Value : (object)DBNull.Value); // Передаём DBNull.Value, если routeID == null

            // Логирование действия редактирования водителя с указанием имени пользователя
            Log.Insert(mainMDIForm.userID, "Отредактирован водитель " + name);

            // Закрытие формы после успешного редактирования водителя
            Close();
        }
    }
}