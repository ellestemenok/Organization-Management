using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class EditUserForm : Form
    { 
        private int userID;
        public EditUserForm(DataTable usersData)
        {
            InitializeComponent();

            if (usersData.Rows.Count > 0)
            {
                userID = Convert.ToInt32(usersData.Rows[0]["UserID"]);
                fioField.Text = usersData.Rows[0]["FullName"].ToString();
                loginField.Text = usersData.Rows[0]["Login"].ToString();
                roleBox.Text = usersData.Rows[0]["Role"].ToString();
                isActiveBox.Checked = Convert.ToBoolean(usersData.Rows[0]["isActive"]);
            }
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

            

            User.Update(userID, fio, login, password, role, isActive);
            Close();

        }
    }
}
