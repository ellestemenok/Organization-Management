using DatabaseLibrary;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace OrganizationManagement.PKOnRKOEdit
{
    public partial class AddPKOForm : Form
    {
        private int pkoID; // Поле для хранения ID ПКО
        // Конструктор класса, принимающий ID накладной расходов (по умолчанию 0)
        public AddPKOForm(int expInvID = 0)
        {
            InitializeComponent(); // Инициализация компонентов формы
            Autorization.OpenConnection(); // Открытие соединения с базой данных
            sumBox.KeyPress += KeyPressEvent.textBox_KeyPressMoney;
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(orgBox, "SELECT \"OrganizationID\", \"Name\" FROM public.\"Organization\" WHERE  \"OrganizationID\" = 1");
            DataDB.LoadDataIntoComboBox(invBox, "SELECT \"InvoiceID\", CAST(\"InvoiceNumber\" AS VARCHAR) AS \"InvoiceNumber\" FROM public.\"ExpenditureInvoice\" ORDER BY \"InvoiceID\" ASC");
            int invoiceID;
            // Определение ID накладной расходов
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
            // Вставка новой записи ПКО в базу данных
            PKO.Insert(DateTime.Today, 1, invoiceID, 0.00);
            // Заполнение полей формы данными
            invBox.Text = invoiceID.ToString();
            contractorBox.Text = ((KeyValuePair<int, string>)contractorBox.Items[0]).Value;
            orgBox.Text = ((KeyValuePair<int, string>)orgBox.Items[0]).Value;
            // Получение ID последнего созданного ПКО
            pkoID = Convert.ToInt32(DataDB.ExecuteScalarQuery("SELECT MAX(\"PkoID\") " +
                "FROM public.\"PKO\";"));
            // Заполнение поля номера ПКО
            numField.Text = DataDB.ExecuteScalarQuery("SELECT MAX(\"PkoNum\") " +
                "FROM public.\"PKO\";");
            // Установка текущей даты в поле выбора даты
            dateTimePicker.Value = DateTime.Today;
            // Формирование названия ПКО
            nameField.Text = "Приходный кассовый ордер №" + numField.Text;
        }
        // Обработчик события нажатия кнопки "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            DateTime date = dateTimePicker.Value;
            int contractorID = 0;
            int number = Convert.ToInt32(numField.Text);
            int invoiceID = 0;
            // Получение ID выбранной накладной расходов
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
            PKO.Update(pkoID, date, number, contractorID, invoiceID, sum, name);
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
                    string insertCashboxQuery = "INSERT INTO public.\"Cashbox\" (\"Name\", \"CashboxDate\") VALUES (@Name, @CashboxDate) RETURNING \"CashboxID\";";
                    int newCashboxID = 0;

                    using (var command = new NpgsqlCommand(insertCashboxQuery, Autorization.npgSqlConnection))
                    {
                        string cashName = "Кассовый отчет за " + date.ToShortDateString();
                        command.Parameters.AddWithValue("@Name", cashName);
                        command.Parameters.AddWithValue("@CashboxDate", date);
                        object result = command.ExecuteScalar(); // Выполнение запроса и возвращение CashboxID
                        if (result != null && int.TryParse(result.ToString(), out newCashboxID) && newCashboxID > 0)
                        {
                            // Создаем запись в Payment с новым CashboxID
                            CreatePaymentRecord(date, name, contractorID, sum, newCashboxID, number);
                        }
                        else
                        {
                            MessageBox.Show("Не удалось создать новую кассу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
                $"VALUES ('{name}', 'Продажа', {contractorID}, {formattedSum}, {cashboxID}, '{date.TimeOfDay}')";
            DataDB.ExecuteQuery(paymentQuery);// Выполнение запроса на вставку записи
        }
    }
}
