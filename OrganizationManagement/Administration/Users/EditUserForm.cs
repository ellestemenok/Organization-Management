using DatabaseLibrary;  // Подключение библиотеки для работы с базой данных
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    // Класс, представляющий форму для редактирования пользователя
    public partial class EditUserForm : Form
    {
        private int userID;  // Поле для хранения идентификатора пользователя
        // Конструктор формы, принимающий DataTable с данными пользователя
        public EditUserForm(DataTable usersData)
        {
            InitializeComponent();  // Инициализация компонентов формы

            // Проверка, что таблица содержит хотя бы одну строку
            if (usersData.Rows.Count > 0)
            {
                // Инициализация полей формы значениями из таблицы
                userID = Convert.ToInt32(usersData.Rows[0]["UserID"]);  // Присвоение идентификатора пользователя
                fioField.Text = usersData.Rows[0]["FullName"].ToString();  // Присвоение ФИО
                loginField.Text = usersData.Rows[0]["Login"].ToString();  // Присвоение логина
                roleBox.Text = usersData.Rows[0]["Role"].ToString();  // Присвоение роли
                isActiveBox.Checked = Convert.ToBoolean(usersData.Rows[0]["isActive"]);  // Присвоение состояния активности
            }
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
            // Обновление данных пользователя в базе данных
            User.Update(userID, fio, login, password, role, isActive);
            // Закрытие формы после успешного сохранения
            Close();
        }
        // Обработчик события при входе в форму
        private void EditUserForm_Enter(object sender, EventArgs e)
        {
            // Если роль пользователя "Администратор"
            if (roleBox.Text == "Администратор")
            {
                isActiveBox.Checked = true;  // Активировать чекбокс
                isActiveBox.Enabled = false;  // Отключить возможность изменения чекбокса
            }
        }
    }
}
