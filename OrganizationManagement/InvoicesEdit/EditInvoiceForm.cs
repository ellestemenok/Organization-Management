using DatabaseLibrary;
using OrganizationManagement._dataTables;
using OrganizationManagement.PurchaseInvoicesEdit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement.InvoicesEdit
{
    // Объявление класса формы редактирования накладных
    public partial class EditInvoiceForm : Form
    {
        private int invoiceID; // Поле для хранения ID накладной
        // Конструктор класса, принимающий таблицу данных о накладной
        public EditInvoiceForm(DataTable invoicesData)
        {
            InitializeComponent();
            // Загрузка данных в комбо-боксы для выбора контрагента и платежного счета
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(paymentBox, "SELECT \"AccountID\", \"Name\" FROM public.\"PaymentAccount\" ORDER BY \"AccountID\" ASC");
            // Заполнение полей формы данными из таблицы, если таковые есть
            if (invoicesData != null && invoicesData.Rows.Count > 0)
            {
                DataRow row = invoicesData.Rows[0]; // Предполагаем, что данные одной накладной передаются в DataTable
                // Заполнение полей формы данными из строки таблицы
                invoiceID = Convert.ToInt32(row["InvoiceID"]);
                orgBox.Text = row["OrgName"].ToString();
                gruzOtprBox.Text = row["OrgConsigneeAddress"].ToString();
                dateTimePicker.Value = Convert.ToDateTime(row["InvoiceDate"]);
                numField.Text = row["InvoiceNumber"].ToString();
                givenBox.Checked = Convert.ToBoolean(row["Given"]);
                contractorBox.Text = row["ContractorName"].ToString();
                gruzPolBox.Text = row["ConsigneeAddress"].ToString();
                paymentBox.Text = row["Name"].ToString();
                sumField.Text = row["TotalAmount"].ToString();
                expNumField.Text = row["ExpInvID"].ToString();
                reasonBox.Text = row["Reason"].ToString();
            }
            UpdateQuantnPrice(); // Обновление поля суммы накладной
        }
        // Метод для загрузки данных в DataGridView при входе на форму
        public void LoadDataIntoDataGridView()
        { 
            int expID;
            // Попытка преобразовать номер расходной накладной в целое число
            if (int.TryParse(expNumField.Text, out expID))
            {
                // Формирование запроса для получения спецификации по расходной накладной
                string query = "SELECT\r\n" +
                            "pid.\"InvoiceID\"," +
                            "pd.\"DetailID\", " +
                            "g.\"ArticleNumber\" AS \"Артикул\",\r\n" +
                            "g.\"Name\" AS \"Название\",\r\n" +
                            "pd.\"Quantity\" AS \"Кол-во\",\r\n" +
                            "mu.\"Name\" AS \"Ед. изм.\",\r\n" +
                            "g.\"TradePrice\" AS \"Цена\",\r\n" +
                            "pd.\"Total\" AS \"Стоимость\"\r\n" +
                            "FROM public.\"ExpenditureInvoice\" pid\r\n" +
                            "JOIN public.\"ExpenditureInvoiceDetail\" pd ON pid.\"InvoiceID\" = pd.\"InvoiceID\"\r\n" +
                            "JOIN public.\"Good\" g ON pd.\"ProductID\" = g.\"GoodID\"\r\n" +
                            "JOIN public.\"MeasureUnit\" mu ON g.\"MeasureUnitID\" = mu.\"UnitID\"\r\n" +
                            $"WHERE pid.\"InvoiceID\" = {expID}; ";
                // Заполнение DataGridView результатами запроса
                DataDB.FillDataGridViewWithQueryResult(specGrid, query);
            specGrid.Columns["InvoiceID"].Visible = false;
            specGrid.Columns["DetailID"].Visible = false;
            specGrid.Columns["Артикул"].Width = 70;
            specGrid.Columns["Название"].Width = 200;
            specGrid.Columns["Кол-во"].Width = 55;
            specGrid.Columns["Ед. изм."].Width = 45;
            specGrid.Columns["Цена"].Width = 60;
            specGrid.Columns["Стоимость"].Width = 90;
            }
        }
        private void AddInvoiceForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            UpdateQuantnPrice();
        }
        // Метод для обновления поля суммы накладной
        private void UpdateQuantnPrice()
        {
            // Запрос к базе данных для получения суммы накладной по ее ID
            sumField.Text = DataDB.ExecuteScalarQuery($"SELECT \"TotalAmount\" FROM public.\"Invoice\"\r\nWHERE \"InvoiceID\"={invoiceID};");
        }
        // Обработчик события нажатия кнопки сохранения изменений в накладной
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            DateTime invoiceDate = dateTimePicker.Value;
            int contractorID = 0;
            int paymentID = 0;
            int number = Convert.ToInt32(numField.Text);
            // Получение ID контрагента, если он выбран
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            // Получение ID платежного счета, если он выбран
            if (paymentBox.SelectedItem != null)
            {
                var paymentItem = (KeyValuePair<int, string>)paymentBox.SelectedItem;
                paymentID = paymentItem.Key;
            }
            int? expNum; // Объявляем переменную как nullable int
            if (int.TryParse(expNumField.Text, out int parsedValue))
            {
                expNum = parsedValue; // Присваиваем expNum значение parsedValue, если преобразование успешно
            }
            else
            {
                expNum = null; // Устанавливаем expNum в null, если ввод не может быть преобразован в число
            }

            bool isGiven = givenBox.Checked;
            // Обновление данных о накладной в базе данных
            Invoice.Update(invoiceID, invoiceDate, number, contractorID, paymentID, isGiven, expNum);
            // Закрываем форму после сохранения
            Close();
        }
        // Обработчик события нажатия кнопки "Добавить позицию" в накладной
        private void addItem_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            DateTime invoiceDate = dateTimePicker.Value;
            int contractorID = 0;
            int paymentID = 0;
            int number = Convert.ToInt32(numField.Text);
            // Получение ID контрагента, если он выбран
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            // Получение ID платежного счета, если он выбран
            if (paymentBox.SelectedItem != null)
            {
                var paymentItem = (KeyValuePair<int, string>)paymentBox.SelectedItem;
                paymentID = paymentItem.Key;
            }
            int? expNum; // Объявляем переменную как nullable int
            if (int.TryParse(expNumField.Text, out int parsedValue))
            {
                expNum = parsedValue; // Присваиваем expNum значение parsedValue, если преобразование успешно
                AddGoodinExpenditureInvoiceForm addForm = new AddGoodinExpenditureInvoiceForm(parsedValue);
                addForm.MdiParent = ActiveForm;
                addForm.Show();
            }
            else
            {
                expNum = null; // Устанавливаем expNum в null, если ввод не может быть преобразован в число
            }
            bool isGiven = givenBox.Checked;
            // Обновление данных о накладной в базе данных
            Invoice.Update(invoiceID, invoiceDate, number, contractorID, paymentID, isGiven, expNum);
            Log.Insert(mainMDIForm.userID, "Отредактирована счет-фактура №" + number.ToString());
            UpdateQuantnPrice();
        }
        // Обработчик события нажатия кнопки "Удалить позицию" в накладной
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = specGrid.SelectedRows[0];
            int detailID = Convert.ToInt32(selectedRow.Cells["DetailID"].Value);
            ExpenditureInvoice.DeleteDetail(detailID);
            UpdateQuantnPrice(); // Обновление поля суммы накладной
            LoadDataIntoDataGridView(); // Повторная загрузка данных в DataGridView
        }
        // Обработчик события нажатия кнопки "Печать накладной"
        private void printButton_Click(object sender, EventArgs e)
        {
            DateTime invoiceDate = dateTimePicker.Value;  // Получение данных из полей формы
            int contractorID = 0;
            int paymentID = 0;
            int number = Convert.ToInt32(numField.Text);
            // Получение ID контрагента, если он выбран
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            // Получение ID платежного счета, если он выбран
            if (paymentBox.SelectedItem != null)
            {
                var paymentItem = (KeyValuePair<int, string>)paymentBox.SelectedItem;
                paymentID = paymentItem.Key;
            }
            int? expNum; // Объявляем переменную как nullable int
            if (int.TryParse(expNumField.Text, out int parsedValue))
            {
                expNum = parsedValue; // Присваиваем expNum значение parsedValue, если преобразование успешно
            }
            else
            {
                expNum = null; // Устанавливаем expNum в null, если ввод не может быть преобразован в число
            }
            bool isGiven = givenBox.Checked;
            Invoice.Update(invoiceID, invoiceDate, number, contractorID, paymentID, isGiven, expNum);
            // Отображение формы предварительного просмотра отчета
            IReportDataProvider provider = new InvoiceReportDataProvider(invoiceID);
            ReportViewForm viewForm = new ReportViewForm(provider);
            viewForm.MdiParent = ActiveForm;
            viewForm.Show();
        }
    }
}
