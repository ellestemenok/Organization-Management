using DatabaseLibrary;
using OrganizationManagement.CashboxEdit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace OrganizationManagement.PKOnRKOEdit
{
    public partial class AddRKOForm : Form
    {
        private int rkoID; // Поле для хранения ID РКО
        // Конструктор класса, принимающий ID накладной закупки (по умолчанию 0)
        private void AddRKOForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();// Открытие соединения с базой данных
        }
        public AddRKOForm(int purInvID = 0)
        {
            InitializeComponent(); // Инициализация компонентов формы
            Autorization.OpenConnection(); // Открытие соединения с базой данных
            sumBox.KeyPress += KeyPressEvent.textBox_KeyPressMoney;
            // Загрузка данных в выпадающие списки контрагентов, организаций и накладных закупки
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(orgBox, "SELECT \"OrganizationID\", \"Name\" FROM public.\"Organization\" WHERE  \"OrganizationID\" = 1");
            DataDB.LoadDataIntoComboBox(invBox, "SELECT \"InvoiceID\",CAST(\"InvoiceNumber\" AS VARCHAR) AS \"InvoiceNumber\" FROM public.\"PurchaseInvoice\" ORDER BY \"InvoiceID\" ASC");
            int invoiceID;
            // Определение ID накладной закупки
            if (purInvID != 0)
            {
                invoiceID = purInvID;
            }
            else
            {
                invoiceID = Convert.ToInt32(DataDB.ExecuteScalarQuery("SELECT MAX(\"InvoiceID\") " +
                    "FROM public.\"PurchaseInvoice\";"));
            }
            // Вставка новой записи РКО в базу данных
            RKO.Insert(DateTime.Today, 1, invoiceID, 0.00);
            // Заполнение полей формы данными
            invBox.Text = invoiceID.ToString();
            contractorBox.Text = ((KeyValuePair<int, string>)contractorBox.Items[0]).Value;
            orgBox.Text = ((KeyValuePair<int, string>)orgBox.Items[0]).Value;
            // Получение ID последнего созданного РКО
            rkoID = Convert.ToInt32(DataDB.ExecuteScalarQuery("SELECT MAX(\"RkoID\") " +
                "FROM public.\"RKO\";"));
            numField.Text = DataDB.ExecuteScalarQuery("SELECT MAX(\"RkoNum\") " +
                "FROM public.\"RKO\";");
            dateTimePicker.Value = DateTime.Today;
            nameField.Text = "Расходный кассовый ордер №" + numField.Text;
        }
        // Обработчик события нажатия кнопки "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            DateTime date = dateTimePicker.Value;
            int contractorID = 0;
            int number = Convert.ToInt32(numField.Text);
            int invoiceID = 0;
            // Получение ID выбранной накладной закупки
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
            // Обновление данных РКО в базе данных
            RKO.Update(rkoID, date, number, contractorID, invoiceID, sum, name);
            Log.Insert(mainMDIForm.userID, "Создан " + name);
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
        // Метод для создания записи в таблице Payment
        private void CreatePaymentRecord(DateTime date, string name, int contractorID, double sum, int cashboxID, int number)
        {
            string formattedSum = sum.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string paymentQuery = $"INSERT INTO public.\"Payment\" " +
                $"(\"Name\", \"Type\", \"ContractorID\", \"Sum\", \"CashboxID\", \"Time\") " +
                $"VALUES ('{name}', 'Инкассация', {contractorID}, -{formattedSum}, {cashboxID}, '{date.TimeOfDay}')";
            DataDB.ExecuteQuery(paymentQuery); // Выполнение запроса на вставку записи
        }
    }
}