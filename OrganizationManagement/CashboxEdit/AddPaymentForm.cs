using DatabaseLibrary;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Windows.Forms;
namespace OrganizationManagement.CashboxEdit
{
    public partial class AddPaymentForm : Form
    {
        private int cashboxID;
        public AddPaymentForm(int cashID)
        {
            InitializeComponent();
            Autorization.OpenConnection();
            cashboxID = cashID;
            sumBox.KeyPress += KeyPressEvent.textBox_KeyPressMoney;
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            contractorBox.Text = ((KeyValuePair<int, string>)contractorBox.Items[0]).Value;
            typeBox.Text = typeBox.Items[0].ToString();

        }
        private void saveButton_Click(object sender, EventArgs e)
        {

            DateTime time = dateTimePicker.Value;
            string type = typeBox.Text;
            double sum = Convert.ToDouble(sumBox.Text);
            int? contractorID = null;
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            string name = nameField.Text;

            Cashbox.AddPayment(time, type, sum, contractorID, name, cashboxID) ;
            Close();

        }

    }
}
