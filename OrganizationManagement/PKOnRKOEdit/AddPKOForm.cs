using DatabaseLibrary;
using OrganizationManagement.CashboxEdit;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Windows.Forms;
namespace OrganizationManagement.PKOnRKOEdit
{
    public partial class AddPKOForm : Form
    {
        private int pkoID;
        public AddPKOForm(int expInvID = 0)
        {
            InitializeComponent();
            Autorization.OpenConnection();
            sumBox.KeyPress += KeyPressEvent.textBox_KeyPressMoney;
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(orgBox, "SELECT \"OrganizationID\", \"Name\" FROM public.\"Organization\" WHERE  \"OrganizationID\" = 1");
            DataDB.LoadDataIntoComboBox(invBox, "SELECT \"InvoiceID\", CAST(\"InvoiceNumber\" AS VARCHAR) AS \"InvoiceNumber\" FROM public.\"ExpenditureInvoice\" ORDER BY \"InvoiceID\" ASC");
            int invoiceID;
            if (expInvID != 0)
            {
                invoiceID = expInvID;
            }
            else
            {
                invoiceID = Convert.ToInt32(DataDB.ExecuteScalarQuery("SELECT MAX(\"InvoiceID\") " +
                    "FROM public.\"ExpenditureInvoice\";"));
            }
            Console.WriteLine(expInvID.ToString());

            PKO.Insert(DateTime.Today, 1, invoiceID, 0.00);

            invBox.Text = invoiceID.ToString();
            contractorBox.Text = ((KeyValuePair<int, string>)contractorBox.Items[0]).Value;
            orgBox.Text = ((KeyValuePair<int, string>)orgBox.Items[0]).Value;

            pkoID = Convert.ToInt32(DataDB.ExecuteScalarQuery("SELECT MAX(\"PkoID\") " +
                "FROM public.\"PKO\";"));
            numField.Text = DataDB.ExecuteScalarQuery("SELECT MAX(\"PkoNum\") " +
                "FROM public.\"PKO\";");
            dateTimePicker.Value = DateTime.Today;
            nameField.Text = "Приходный кассовый ордер №" + numField.Text;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker.Value;
            int contractorID = 0;
            int number = Convert.ToInt32(numField.Text);
            int invoiceID = 0;
            if (invBox.SelectedItem != null)
            {
                var invItem = (KeyValuePair<int, string>)invBox.SelectedItem;
                invoiceID = invItem.Key;
            }

            double sum = Convert.ToDouble(sumBox.Text);
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            string name = nameField.Text;
            PKO.Update(pkoID, date, number, contractorID, invoiceID, sum, name);

            // Проверка наличия Cashbox на указанную дату
            string cashboxQuery = $"SELECT \"CashboxID\" FROM public.\"Cashbox\" WHERE \"CashboxDate\" = '{date:yyyy-MM-dd}'";
            object cashboxResult = DataDB.ExecuteScalarQuery(cashboxQuery);
            int cashboxID;

            if (cashboxResult != null && int.TryParse(cashboxResult.ToString(), out cashboxID))
            {
                // Cashbox уже существует, добавляем запись в Payment
                CreatePaymentRecord(date, name, contractorID, sum, cashboxID, number);
            }
            else
            {
                // Предложить пользователю создать новую кассу
                var userChoice = MessageBox.Show("Кассы на указанную дату не существует. Создать?", 
                    "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (userChoice == DialogResult.Yes)
                {
                    AddCashboxForm newMDIChild = new AddCashboxForm();
                    newMDIChild.MdiParent = this.MdiParent;
                    newMDIChild.Show();
                }
            }
            Close();
        }

        private void CreatePaymentRecord(DateTime date, string name, int contractorID, double sum, int cashboxID, int number)
        {
            string formattedSum = sum.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string paymentQuery = $"INSERT INTO public.\"Payment\" " +
                $"(\"Name\", \"Type\", \"ContractorID\", \"Sum\", \"CashboxID\", \"Time\") " +
                $"VALUES ('{name}', 'Продажа', {contractorID}, {formattedSum}, {cashboxID}, '{date.TimeOfDay}')";
            DataDB.ExecuteQuery(paymentQuery);
        }

    }
}
