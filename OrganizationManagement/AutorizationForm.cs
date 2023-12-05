using DatabaseLibrary;
using System;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class AutorizationForm : Form
    {

        public string userID;
        public string password;

        public AutorizationForm()
        {
            InitializeComponent();
        }
        private void autorizationButton_Click(object sender, EventArgs e)
        {
            try
            {
                userID = usernameField.Text;
                password = passwordField.Text;
                Autorization.Autorize(userID, password);
                MainMDI mainMDI = new MainMDI();
                mainMDI.Show();
                Hide();
                Autorization.CloseConnection();
            }
            catch
            {
                MessageBox.Show($"Ошибка подключения к базе данных: вы ввели неверные учетные данные.");
            }
        }
    }
}
