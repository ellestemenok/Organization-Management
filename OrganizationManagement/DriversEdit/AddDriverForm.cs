using DatabaseLibrary; // Подключение библиотеки для работы с базой данных
using System; // Подключение базовой библиотеки .NET
using System.Windows.Forms; // Подключение библиотеки для создания Windows Forms приложений

namespace OrganizationManagement.DriversEdit
{
    // Класс формы для добавления водителя, унаследованный от Form
    public partial class AddDriverForm : Form
    {
        // Конструктор формы AddDriverForm
        public AddDriverForm()
        {
            InitializeComponent(); // Инициализация компонентов формы
        }
        // Обработчик события клика по кнопке сохранения
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение имени водителя из текстового поля
            string driverName = nameField.Text;

            // Вставка нового водителя в базу данных
            Driver.Insert(driverName);

            // Логирование действия создания нового водителя с указанием имени пользователя
            Log.Insert(mainMDIForm.userID, "Создан водитель " + driverName);

            // Закрытие формы после успешного добавления водителя
            Close();
        }
    }
}
