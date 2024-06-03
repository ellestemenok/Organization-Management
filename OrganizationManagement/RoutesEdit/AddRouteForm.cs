using DatabaseLibrary;
using System;
using System.Windows.Forms;
namespace OrganizationManagement.RoutesEdit
{
    public partial class AddRouteForm : Form // Объявление класса формы добавления маршрута, наследующего класс Form.
    {
        public AddRouteForm() // Определение конструктора класса формы.
        {
            InitializeComponent(); // Инициализация компонентов формы.
        }

        private void saveButton_Click(object sender, EventArgs e) // Обработчик события нажатия кнопки "Сохранить".
        {
            string routeName = nameField.Text; // Получение текста из поля ввода имени маршрута.

            Route.Insert(routeName); // Вставка нового маршрута в базу данных.
            Log.Insert(mainMDIForm.userID, "Создан маршрут " + routeName); // Вставка записи в журнал о создании нового маршрута.

            Close(); // Закрытие формы добавления маршрута после сохранения.
        }
    }
}