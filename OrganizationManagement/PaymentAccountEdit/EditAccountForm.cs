using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement.AccountEdit
{
    public partial class EditAccountForm : Form
    {
        private int accountID;
        public EditAccountForm(DataTable accountData)
        {
            InitializeComponent();

            if (accountData.Rows.Count > 0)
            {
                accountID = Convert.ToInt32(accountData.Rows[0]["AccountID"]);
                nameField.Text = accountData.Rows[0]["Name"].ToString();
                numberField.Text = accountData.Rows[0]["AccountNumber"].ToString();
                bankField.Text = accountData.Rows[0]["BankName"].ToString();
                corrField.Text = accountData.Rows[0]["СorrAccount"].ToString();
                bikField.Text = accountData.Rows[0]["BIK"].ToString();
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            string accountNumber = numberField.Text;
            string bankname = bankField.Text;
            string corrAccount = corrField.Text;
            string bik = bikField.Text;

            Requisites.UpdatePaymentAccount(accountID, name, accountNumber, bankname, corrAccount, bik);
            Close();
        }
    }
}
