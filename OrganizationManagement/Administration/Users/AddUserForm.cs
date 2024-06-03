using DatabaseLibrary;  // Подключение библиотеки для работы с базой данных
using System;
using System.Windows.Forms;

namespace OrganizationManagement
{
    // Класс, представляющий форму для добавления пользователя
    public partial class AddUserForm : Form
    {
        // Конструктор формы
        public AddUserForm()
        {
            InitializeComponent();  // Инициализация компонентов формы
        }
        // Обработчик события нажатия на кнопку "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Считывание значений полей ввода
            string fio = fioField.Text;  // ФИО пользователя
            string login = loginField.Text;  // Логин пользователя
            string password = passwordField.Text;  // Пароль пользователя
            string role = roleBox.Text;  // Роль пользователя
            bool isActive = isActiveBox.Checked;  // Активность пользователя
            // Проверка на заполнение обязательных полей
            if (fio == "" || login == "" || password == "" || role == "")
            {
                // Если одно из обязательных полей не заполнено, вывод сообщения об ошибке
                MessageBox.Show("Не заполнены обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Прерывание выполнения метода
            }
            // Вставка нового пользователя в базу данных
            User.Insert(fio, login, password, role, isActive);
            // Закрытие формы после успешного сохранения
            Close();
        }
    }
}
