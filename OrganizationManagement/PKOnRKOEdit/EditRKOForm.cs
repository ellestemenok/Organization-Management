using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.PKOnRKOEdit
{
    public partial class EditRKOForm : Form // Объявление класса формы редактирования РКО
    {
        private int rkoID; // Поле для хранения ID РКО
        // Конструктор класса, принимающий данные о РКО в виде таблицы данных
        public EditRKOForm(DataTable rkoData)
        {
            InitializeComponent(); // Инициализация компонентов формы
            Autorization.OpenConnection(); // Открытие соединения с базой данных
            sumBox.KeyPress += KeyPressEvent.textBox_KeyPressMoney; // Привязка обработчика события нажатия клавиш для поля суммы
            // Загрузка данных в выпадающие списки контрагентов, организаций и инвойсов
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(orgBox, "SELECT \"OrganizationID\", \"Name\" FROM public.\"Organization\" WHERE \"OrganizationID\" = 1");
            DataDB.LoadDataIntoComboBox(invBox, "SELECT \"InvoiceID\", CAST(\"InvoiceNumber\" AS VARCHAR) AS \"InvoiceNumber\" FROM public.\"PurchaseInvoice\" ORDER BY \"InvoiceID\" ASC");

            if (rkoData.Rows.Count > 0)
            {
                DataRow row = rkoData.Rows[0];
                rkoID = Convert.ToInt32(row["RkoID"]);
                dateTimePicker.Value = Convert.ToDateTime(row["Дата"]);
                numField.Text = row["Номер"].ToString();
                invBox.Text = row["Инвойс"].ToString();
                orgBox.Text = row["Организация"].ToString();
                contractorBox.Text = row["Контрагент"].ToString();
                sumBox.Text = row["Сумма"].ToString();
                nameField.Text = row["Основание"].ToString();
            }
        }
        // Обработчик события нажатия кнопки "Сохранить"
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
            // Получение ID выбранного контрагента
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            string name = nameField.Text;
            RKO.Update(rkoID, date, number, contractorID, invoiceID, sum, name);
            UpdatePaymentRecord(rkoID, date, "Расходный кассовый ордер №" + number, contractorID, sum);
            // Журналирование действия
            Log.Insert(mainMDIForm.userID, "Отредактирован Расходный кассовый ордер №" + number.ToString());
            Close(); // Закрытие формы после сохранения
        }
        // Метод для обновления записи в таблице Payment
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
                MessageBox.Show("Связанная запись платежа не найдена. Обновление не выполнено.", "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Обработчик события загрузки формы
        private void EditRKOForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }
    }
}
