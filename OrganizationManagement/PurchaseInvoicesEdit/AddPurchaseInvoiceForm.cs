using DatabaseLibrary;
using OrganizationManagement._dataTables;
using OrganizationManagement.PurchaseInvoicesEdit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class AddPurchaseInvoiceForm : Form
    {
        private int invoiceID; // Переменная для хранения идентификатора счета на закупку.
        // Конструктор класса, инициализирующий компоненты формы и загружающий данные в ComboBox'ы.
        public AddPurchaseInvoiceForm()
        {
            InitializeComponent();
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(storageBox, "SELECT \"StorageID\", \"Name\" FROM public.\"Storage\" ORDER BY \"StorageID\" ASC");
            PurchaseInvoice.Insert(DateTime.Today, 1, 1);
            // Установка значений по умолчанию для ComboBox'ов.
            contractorBox.Text = ((KeyValuePair<int, string>)contractorBox.Items[0]).Value;
            storageBox.Text = ((KeyValuePair<int, string>)storageBox.Items[0]).Value;
            // Получение идентификатора последнего добавленного счета на закупку.
            invoiceID = Convert.ToInt32(DataDB.ExecuteScalarQuery("SELECT MAX(\"InvoiceID\") " +
                "FROM public.\"PurchaseInvoice\";"));
            numField.Text = DataDB.ExecuteScalarQuery("SELECT MAX(\"InvoiceNumber\") " +
                "FROM public.\"PurchaseInvoice\";");
            dateTimePicker.Value = DateTime.Today;

        }
        // Метод для загрузки данных о товарах в DataGridView.
        public void LoadDataIntoDataGridView()
        {
            // Формирование SQL-запроса для выборки спецификации счета на закупку.
            string query = "SELECT\r\n" +
                "pid.\"InvoiceID\"," +
                "pd.\"DetailID\", " +
                "g.\"ArticleNumber\" AS \"Артикул\",\r\n" +
                "g.\"Name\" AS \"Название\",\r\n" +
                "pd.\"Quantity\" AS \"Кол-во\",\r\n" +
                "mu.\"Name\" AS \"Ед. изм.\",\r\n" +
                "g.\"NetCost\" AS \"Цена\",\r\n" +
                "pd.\"Total\" AS \"Стоимость\"\r\n" +
                "FROM public.\"PurchaseInvoice\" pid\r\n" +
                "JOIN public.\"PurchaseInvoiceDetail\" pd ON pid.\"InvoiceID\" = pd.\"InvoiceID\"\r\n" +
                "JOIN public.\"Good\" g ON pd.\"ProductID\" = g.\"GoodID\"\r\n" +
                "JOIN public.\"MeasureUnit\" mu ON g.\"MeasureUnitID\" = mu.\"UnitID\"\r\n" +
                $"WHERE pid.\"InvoiceID\" = {invoiceID}; ";
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
        // Обработчик события нажатия кнопки "Добавить товар".
        private void addItem_Click(object sender, EventArgs e)
        {
            DateTime invoiceDate = dateTimePicker.Value; // Получение выбранной пользователем даты счета на закупку.
            int contractorID = 0;
            int storageID = 0;
            int number = Convert.ToInt32(numField.Text); // Получение номера счета на закупку.

            // Получение идентификатора выбранного контрагента.
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }

            // Получение идентификатора выбранного склада.
            if (storageBox.SelectedItem != null)
            {
                var storageItem = (KeyValuePair<int, string>)storageBox.SelectedItem;
                storageID = storageItem.Key;
            }

            PurchaseInvoice.Update(invoiceID, invoiceDate, number, contractorID, storageID); // Обновление данных о счете на закупку.

            AddGoodinPurchaseInvoiceForm addForm = new AddGoodinPurchaseInvoiceForm(invoiceID); // Создание формы для добавления товара в счет на закупку.
            addForm.MdiParent = ActiveForm;
            addForm.Show(); // Отображение формы добавления товара.
        }
        // Обработчик события нажатия кнопки "Сохранить".
        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime invoiceDate = dateTimePicker.Value; // Получение выбранной пользователем даты счета на закупку.
            int contractorID = 0;
            int storageID = 0;
            int number = Convert.ToInt32(numField.Text); // Получение номера счета на закупку.

            // Получение идентификатора выбранного контрагента.
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }

            // Получение идентификатора выбранного склада.
            if (storageBox.SelectedItem != null)
            {
                var storageItem = (KeyValuePair<int, string>)storageBox.SelectedItem;
                storageID = storageItem.Key;
            }

            PurchaseInvoice.Update(invoiceID, invoiceDate, number, contractorID, storageID); // Обновление данных о счете на закупку.
            Log.Insert(mainMDIForm.userID, "Добавлена приходная накладная №" + number.ToString()); // Запись действия в журнал.
            Close(); // Закрытие формы после сохранения.
        }
        // Метод для обновления количества и цены.
        private void UpdateQuantnPrice()
        {
            // Обновление данных о количестве, сумме и долге.
            quant1.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(COUNT(\"DetailID\"), 0.00) FROM public.\"PurchaseInvoiceDetail\"\r\nWHERE \"InvoiceID\"={invoiceID};");
            quant2.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(SUM(\"Quantity\"), 0.00) FROM public.\"PurchaseInvoiceDetail\"\r\nWHERE \"InvoiceID\"={invoiceID};");
            sum.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(SUM(\"Total\"), 0.00) FROM public.\"PurchaseInvoiceDetail\"\r\nWHERE \"InvoiceID\"={invoiceID};");
            opl.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(SUM(\"Sum\"), 0.00) from public.\"RKO\" WHERE \"PurchInvID\" ={invoiceID}");
            duty.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(\"TotalAmount\" - (SELECT COALESCE(SUM(\"Sum\"),0.00) from public.\"RKO\" " +
                $"WHERE \"PurchInvID\" = {invoiceID}), 0.00) " +
                $"AS \"Долг\" \r\nFROM public.\"PurchaseInvoice\" WHERE \"InvoiceID\" = {invoiceID}");
            if (Convert.ToDouble(duty.Text) == Convert.ToDouble(sum.Text)) duty.ForeColor = System.Drawing.Color.Red;
            if (Convert.ToDouble(duty.Text) > 0 && Convert.ToDouble(duty.Text) != Convert.ToDouble(sum.Text)) duty.ForeColor = System.Drawing.Color.Blue;
            if (Convert.ToDouble(duty.Text) < 0) duty.ForeColor = System.Drawing.Color.Green;
        }
        // Обработчик события входа на форму.
        private void AddPurchaseInvoiceForm_Enter(object sender, EventArgs e)
        {
            UpdateQuantnPrice(); // Обновление данных о количестве и цене.
            LoadDataIntoDataGridView(); // Загрузка данных о товарах в DataGridView.
            if (specGrid.Rows.Count > 0) storageBox.Enabled = false; // Отключение возможности изменения склада, если спецификация счета на закупку не пуста.
        }
        // Обработчик события нажатия кнопки "Удалить товар".
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = specGrid.SelectedRows[0];
            int detailID = Convert.ToInt32(selectedRow.Cells["DetailID"].Value);
            PurchaseInvoice.DeleteDetail(detailID); // Удаление выбранной детали счета на закупку.
            UpdateQuantnPrice(); // Обновление данных о количестве и цене.
            LoadDataIntoDataGridView(); // Обновление данных о товарах в DataGridView.
        }
        // Обработчик события изменения выбранного контрагента.
        private void contractorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedgoodID = ((KeyValuePair<int, string>)contractorBox.SelectedItem).Key;
            DataDB contractorRepository = new DataDB();
            DataTable contrData = contractorRepository.FillFormWithQueryResult(
                "SELECT \"ContractorID\", " +
                "\"Reason\" \r\n" +
                "FROM public.\"Contractor\" \r\n" +
                $"WHERE \"ContractorID\" = {selectedgoodID};");
            // Заполнение поля "Основание" данными из базы данных.
            if (contrData != null && contrData.Rows.Count > 0)
            {
                // Заполнение полей значениями из базы данных
                reasonField.Text = contrData.Rows[0]["Reason"].ToString();
            }
        }
        // Обработчик события нажатия кнопки "Журнал платежей".
        private void paymentJournal_Click(object sender, EventArgs e)
        {
            PaymentsForPurchForm paymentJournal = new PaymentsForPurchForm(invoiceID);
            paymentJournal.MdiParent = ActiveForm;
            paymentJournal.Show();
        }
        // Обработчик события нажатия кнопки "Печать".
        private void printButton_Click(object sender, EventArgs e)
        {
            // Получение данных для сохранения.
            DateTime invoiceDate = dateTimePicker.Value;
            int contractorID = 0;
            int storageID = 0;
            int number = Convert.ToInt32(numField.Text);
            // Получение идентификатора контрагента.
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            // Получение идентификатора склада.
            if (storageBox.SelectedItem != null)
            {
                var storageItem = (KeyValuePair<int, string>)storageBox.SelectedItem;
                storageID = storageItem.Key;
            }
            PurchaseInvoice.Update(invoiceID, invoiceDate, number, contractorID, storageID);
            IReportDataProvider provider = new PurchInvoiceReportDataProvider(invoiceID);
            ReportViewForm viewForm = new ReportViewForm(provider);
            viewForm.MdiParent = ActiveForm;
            viewForm.Show();// Отображение формы просмотра отчета
        }
    }
}
