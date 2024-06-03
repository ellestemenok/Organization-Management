using DatabaseLibrary;
using Npgsql;
using OrganizationManagement._dataTables;
using OrganizationManagement.PurchaseInvoicesEdit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class AddExpenditureInvoiceForm : Form
    {
        private int invoiceID; // Идентификатор расходной накладной
        // Конструктор формы добавления расходной накладной
        public AddExpenditureInvoiceForm()
        {
            InitializeComponent();
            // Загрузка данных в комбо-боксы
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(storageBox, "SELECT \"StorageID\", \"Name\" FROM public.\"Storage\" ORDER BY \"StorageID\" ASC");
            ExpenditureInvoice.Insert(DateTime.Today, 1, 1);
            // Вставка новой записи о расходной накладной и заполнение формы данными
            contractorBox.Text = ((KeyValuePair<int, string>)contractorBox.Items[0]).Value;
            storageBox.Text = ((KeyValuePair<int, string>)storageBox.Items[0]).Value;
            // Получение идентификатора созданной накладной и ее номера
            invoiceID = Convert.ToInt32(DataDB.ExecuteScalarQuery("SELECT MAX(\"InvoiceID\") " +
                "FROM public.\"ExpenditureInvoice\";"));
            numField.Text = DataDB.ExecuteScalarQuery("SELECT MAX(\"InvoiceNumber\") " +
                "FROM public.\"ExpenditureInvoice\";");
            dateTimePicker.Value = DateTime.Today;
        }
        // Загрузка данных в таблицу деталей расходной накладной
        public void LoadDataIntoDataGridView()
        {
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
        // Обработчик клика по кнопке добавления товара
        private void addItem_Click(object sender, EventArgs e)
        {
            DateTime invoiceDate = dateTimePicker.Value;
            int contractorID = 0;
            int storageID = 0;
            int number = Convert.ToInt32(numField.Text);
            // Получение выбранного контрагента и склада
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            if (storageBox.SelectedItem != null)
            {
                var storageItem = (KeyValuePair<int, string>)storageBox.SelectedItem;
                storageID = storageItem.Key;
            }
            ExpenditureInvoice.Update(invoiceID, invoiceDate, number, contractorID, storageID);
            // Обновление информации о расходной накладной и открытие формы добавления товара
            AddGoodinExpenditureInvoiceForm addForm = new AddGoodinExpenditureInvoiceForm(invoiceID);
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        // Обработчик клика по кнопке сохранения
        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime invoiceDate = dateTimePicker.Value;
            int contractorID = 0;
            int storageID = 0;
            int number = Convert.ToInt32(numField.Text);
            // Получение выбранного контрагента и склада
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            if (storageBox.SelectedItem != null)
            {
                var storageItem = (KeyValuePair<int, string>)storageBox.SelectedItem;
                storageID = storageItem.Key;
            }
            // Обновление информации о расходной накладной, запись в лог и закрытие формы
            ExpenditureInvoice.Update(invoiceID, invoiceDate, number, contractorID, storageID);
            Log.Insert(mainMDIForm.userID, "Добавлена расходная накладная №" + number.ToString());
            // Закрываем форму после сохранения
            Close();
        }
        // Обновление данных о количестве, сумме и долге
        private void UpdateQuantnPrice()
        {
            quant1.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(COUNT(\"DetailID\"), 0.00) FROM public.\"ExpenditureInvoiceDetail\"\r\nWHERE \"InvoiceID\"={invoiceID};");
            quant2.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(SUM(\"Quantity\"), 0.00) FROM public.\"ExpenditureInvoiceDetail\"\r\nWHERE \"InvoiceID\"={invoiceID};");
            sum.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(SUM(\"Total\"), 0.00) FROM public.\"ExpenditureInvoiceDetail\"\r\nWHERE \"InvoiceID\"={invoiceID};");
            opl.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(SUM(\"Sum\"), 0.00) from public.\"PKO\" WHERE \"ExpInvID\" ={invoiceID}");
            duty.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(\"TotalAmount\" - (SELECT COALESCE(SUM(\"Sum\"),0.00) from public.\"PKO\" " +
                $"WHERE \"ExpInvID\" = {invoiceID}), 0.00) " +
                $"AS \"Долг\" \r\nFROM public.\"ExpenditureInvoice\" WHERE \"InvoiceID\" = {invoiceID}");
            if (Convert.ToDouble(duty.Text) == Convert.ToDouble(sum.Text)) duty.ForeColor = System.Drawing.Color.Red;
            if (Convert.ToDouble(duty.Text) > 0 && Convert.ToDouble(duty.Text) != Convert.ToDouble(sum.Text)) duty.ForeColor = System.Drawing.Color.Blue;
            if (Convert.ToDouble(duty.Text) < 0) duty.ForeColor = System.Drawing.Color.Green;
        }
        // Обработчик события входа на форму
        private void AddExpenditureInvoiceForm_Enter(object sender, EventArgs e)
        {
            UpdateQuantnPrice();
            LoadDataIntoDataGridView();
            if (specGrid.Rows.Count > 0) storageBox.Enabled = false;
        }
        // Обработчик клика по кнопке удаления товара
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = specGrid.SelectedRows[0];
            int detailID = Convert.ToInt32(selectedRow.Cells["DetailID"].Value);
            ExpenditureInvoice.DeleteDetail(detailID);
            UpdateQuantnPrice();
        }
        // Обработчик изменения выбранного контрагента
        private void contractorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedgoodID = ((KeyValuePair<int, string>)contractorBox.SelectedItem).Key;
            DataDB contractorRepository = new DataDB();
            DataTable contrData = contractorRepository.FillFormWithQueryResult(
                "SELECT \"ContractorID\", " +
                "\"Reason\" \r\n" +
                "FROM public.\"Contractor\" \r\n" +
                $"WHERE \"ContractorID\" = {selectedgoodID};");
            if (contrData != null && contrData.Rows.Count > 0)
            {
                // Заполнение полей значениями из базы данных
                reasonField.Text = contrData.Rows[0]["Reason"].ToString();
            }
        }
        // Обработчик создания счета-фактуры
        private void создатьСчетфактуруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(Autorization.connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Получаем данные из ExpenditureInvoice
                        NpgsqlCommand cmd = new NpgsqlCommand($"SELECT \"InvoiceDate\", \"ContractorID\" FROM public.\"ExpenditureInvoice\" WHERE \"InvoiceID\" = {invoiceID};", conn);
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        if (!reader.Read())
                        {
                            reader.Close();
                            throw new Exception("Расходная накладная не найдена.");
                        }
                        DateTime invoiceDate = reader.GetDateTime(0);
                        int contractorID = reader.GetInt32(1);
                        reader.Close(); // Обязательно закрываем ридер

                        // Получаем суммарную стоимость по расходной накладной
                        cmd = new NpgsqlCommand($"SELECT COALESCE(SUM(\"Total\"), 0) FROM public.\"ExpenditureInvoiceDetail\" WHERE \"InvoiceID\"={invoiceID};", conn);
                        double totalAmount = Convert.ToDouble(cmd.ExecuteScalar());

                        // Создаем новый Invoice
                        cmd = new NpgsqlCommand("INSERT INTO public.\"Invoice\" (\"InvoiceDate\", \"ContractorID\", \"OrgID\", \"ExpInvID\", \"TotalAmount\") VALUES (@InvoiceDate, @ContractorID, 1, @ExpInvID, @TotalAmount) RETURNING \"InvoiceID\";", conn);
                        cmd.Parameters.AddWithValue("@InvoiceDate", invoiceDate);
                        cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                        cmd.Parameters.AddWithValue("@ExpInvID", invoiceID);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        int newInvoiceID = (int)cmd.ExecuteScalar();

                        // Копирование деталей из ExpenditureInvoiceDetail в InvoiceDetail
                        cmd = new NpgsqlCommand($"SELECT \"ProductID\", \"Quantity\", \"Total\" FROM public.\"ExpenditureInvoiceDetail\" WHERE \"InvoiceID\" = {invoiceID};", conn);
                        reader = cmd.ExecuteReader();
                        List<Tuple<int, int, decimal>> details = new List<Tuple<int, int, decimal>>();
                        while (reader.Read())
                        {
                            details.Add(new Tuple<int, int, decimal>(reader.GetInt32(0), reader.GetInt32(1), reader.GetDecimal(2)));
                        }
                        reader.Close(); // Обязательно закрываем ридер

                        transaction.Commit();
                        MessageBox.Show("Счет-фактура успешно создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ошибка при создании счета-фактуры: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // Обработчик клика по кнопке журнала платежей
        private void paymentJournal_Click(object sender, EventArgs e)
        {
            PaymentsForExpForm paymentJournal = new PaymentsForExpForm(invoiceID);
            paymentJournal.MdiParent = ActiveForm;
            paymentJournal.Show();

        }
        // Обработчик клика по кнопке печати
        private void printButton_Click(object sender, EventArgs e)
        {
            DateTime invoiceDate = dateTimePicker.Value;
            int contractorID = 0;
            int storageID = 0;
            int number = Convert.ToInt32(numField.Text);
            // Получение выбранного контрагента и склада
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            if (storageBox.SelectedItem != null)
            {
                var storageItem = (KeyValuePair<int, string>)storageBox.SelectedItem;
                storageID = storageItem.Key;
            }
            // Обновление информации о расходной накладной и открытие формы отчета
            ExpenditureInvoice.Update(invoiceID, invoiceDate, number, contractorID, storageID);
            IReportDataProvider provider = new ExpenditureInvoiceReportDataProvider(invoiceID);
            ReportViewForm viewForm = new ReportViewForm(provider);
            viewForm.MdiParent = ActiveForm;
            viewForm.Show();
        }
    }
}
