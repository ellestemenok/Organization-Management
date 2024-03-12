using DatabaseLibrary;
using System;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class AddAccountForm : Form
    {
        public AddAccountForm()
        {
            InitializeComponent();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            string accountNumber = numberField.Text;
            string bankName = bankField.Text;
            string corrAccount = corrField.Text;
            string bik = bikField.Text;
            Requisites.InsertPaymentAccount(name, accountNumber, 
                bankName, corrAccount, bik);
            Close();
        }
    }
}
