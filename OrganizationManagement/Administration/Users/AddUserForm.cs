using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class AddUserForm : Form
    { 
        public AddUserForm()
        {
            InitializeComponent();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            string fio = fioField.Text;
            string login = loginField.Text;
            string password = passwordField.Text;
            string role = roleBox.Text;

            bool isActive = isActiveBox.Checked;

            if (fio == "" || login == "" || password == "" || role == "")
            {
                MessageBox.Show("Не заполнены обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            User.Insert(fio, login, password, role, isActive);
            Close();

        }
    }
}
