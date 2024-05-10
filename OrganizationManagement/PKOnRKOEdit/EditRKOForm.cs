using DatabaseLibrary;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.PKOnRKOEdit
{
    public partial class EditRKOForm : Form
    {
        private int rkoID;
        public EditRKOForm(DataTable rkoData)
        {
            InitializeComponent();
            Autorization.OpenConnection();
            sumBox.KeyPress += KeyPressEvent.textBox_KeyPressMoney;
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(orgBox, "SELECT \"OrganizationID\", \"Name\" FROM public.\"Organization\" WHERE \"OrganizationID\" = 1");

            if (rkoData.Rows.Count > 0)
            {
                DataRow row = rkoData.Rows[0];
                rkoID = Convert.ToInt32(row["RkoID"]);
                dateTimePicker.Value = Convert.ToDateTime(row["Дата"]);
                numField.Text = row["Номер"].ToString();
                invField.Text = row["Инвойс"].ToString();
                orgBox.Text = row["Организация"].ToString();
                contractorBox.Text = row["Контрагент"].ToString();
                sumBox.Text = row["Сумма"].ToString();
                nameField.Text = row["Основание"].ToString();
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker.Value;
            int contractorID = 0;
            int number = Convert.ToInt32(numField.Text);
            int invoiceID = Convert.ToInt32(invField.Text);
            double sum = Convert.ToDouble(sumBox.Text);
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            string name = nameField.Text;
            RKO.Update(rkoID, date, number, contractorID, invoiceID, sum, name);
            UpdatePaymentRecord(rkoID, date, "Приходный кассовый ордер №" + number, contractorID, sum);

            Close();
        }


        private void UpdatePaymentRecord(int rkoID, DateTime date, string name, int contractorID, double sum)
        {
            // Находим ID записи Payment, связанной с данным ПКО
            string findPaymentQuery = $"SELECT \"PaymentID\" FROM public.\"Payment\" WHERE \"Name\" IN (SELECT \"Name\" FROM public.\"RKO\" WHERE \"RkoID\"={rkoID});";
            object paymentID = DataDB.ExecuteScalarQuery(findPaymentQuery);
            if (paymentID != null)
            {
                // Обновляем запись в таблице Payment
                string updatePaymentQuery = $"UPDATE public.\"Payment\" SET " +
                    $"\"Name\" = '{name}', " +
                    $"\"ContractorID\" = {contractorID}, " +
                    $"\"Sum\" = {sum.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                    $"\"Time\" = '{date.TimeOfDay}' " +
                    $"WHERE \"PaymentID\" = {paymentID}";
                DataDB.ExecuteQuery(updatePaymentQuery);
            }
            else
            {
                // Здесь можете добавить логику на случай, если связанная запись в Payment отсутствует
                MessageBox.Show("Связанная запись платежа не найдена. Обновление не выполнено.", "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditRKOForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }
    }
}
