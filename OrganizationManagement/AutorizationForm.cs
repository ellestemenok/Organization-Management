using DatabaseLibrary;
using System;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class AutorizationForm : Form
    {
        public string username; // Переименовано с userID на username
        public string password;

        public AutorizationForm()
        {
            InitializeComponent();
        }

        private void autorizationButton_Click(object sender, EventArgs e)
        {
            try
            {
                username = usernameField.Text; // Используйте новое имя переменной
                password = passwordField.Text;
                var (role, fullName, fetchedUserID) = Autorization.Autorize(username, password);

                if (role != null)
                {
                    mainMDIAdminForm.SetUserRole(role); // Установка роли пользователя
                    mainMDIAdminForm.SetUserID(fetchedUserID); // Установка ID пользователя
                    Form nextForm = new mainMDIAdminForm();
                    //Form nextForm;
                    //if (role == "Администратор")
                    //{
                    //    nextForm = new mainMDIAdminForm();
                    //}
                    //else
                    //{
                    //    nextForm = new MainMDI(); // Если есть другая форма для других ролей
                    //                              // Если требуется, добавьте код для установки UserID и в этой форме
                    //}

                    nextForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверные учетные данные.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
