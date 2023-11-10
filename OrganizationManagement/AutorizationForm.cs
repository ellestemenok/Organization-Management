using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class AutorizationForm : Form
    {
        public AutorizationForm()
        {
            InitializeComponent();
        }

        private void autorizationButton_Click(object sender, EventArgs e)
        {
            try
            {
                Autorization.Autorize(usernameField.Text, passwordField.Text);
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
