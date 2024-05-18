using DatabaseLibrary;
using System;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class AutorizationForm : Form
    {
        public string username; //логин пользователя
        public string password; //пароль пользователя
        public AutorizationForm()
        {
            InitializeComponent(); //инициализация окна
        }
        private void autorizationButton_Click(object sender, EventArgs e)
        {
            try
            {
                //заполняем переменные значениями из полей
                username = usernameField.Text;
                password = passwordField.Text;
                var (role, fullName, fetchedUserID) = Autorization.Autorize(username, password); //выполняем авторизацию

                if (role != null)
                {
                    mainMDIForm.SetUserRole(role); // Установка роли пользователя
                    mainMDIForm.SetUserID(fetchedUserID); // Установка ID пользователя
                    Form nextForm = new mainMDIForm(); //открытие главного окна приложения
                    nextForm.Show();
                    Hide();
                }
                else //если логин и пароль не валидны
                {
                    MessageBox.Show("Неверные учетные данные.", 
                        "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) //если пароль и логин верны, но вход не выполняется
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", 
                    "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
