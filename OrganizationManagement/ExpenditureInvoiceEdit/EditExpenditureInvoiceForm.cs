using DatabaseLibrary;
using Npgsql;
using OrganizationManagement.PurchaseInvoicesEdit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class EditExpenditureInvoiceForm : Form
    {
        private int invoiceID;
        public EditExpenditureInvoiceForm(DataTable invoicesData)
        {
            InitializeComponent();
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(storageBox, "SELECT \"StorageID\", \"Name\" FROM public.\"Storage\" ORDER BY \"StorageID\" ASC");

            if (invoicesData.Rows.Count > 0)
            {
                invoiceID = Convert.ToInt32(invoicesData.Rows[0]["InvoiceID"]);
                dateTimePicker.Value = (DateTime)invoicesData.Rows[0]["InvoiceDate"];
                numField.Text = invoicesData.Rows[0]["InvoiceNumber"].ToString();
                contractorBox.Text = invoicesData.Rows[0]["ContractorName"].ToString();
                storageBox.Text = invoicesData.Rows[0]["StorageName"].ToString();
                reasonField.Text = invoicesData.Rows[0]["Reason"].ToString();
                sum.Text = invoicesData.Rows[0]["TotalAmount"].ToString();
            }
        }
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
        private void addItem_Click(object sender, EventArgs e)
        {
            AddGoodinExpenditureInvoiceForm addForm = new AddGoodinExpenditureInvoiceForm(invoiceID);
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime invoiceDate = dateTimePicker.Value;
            int invoiceNumber = Convert.ToInt32(numField.Text);
            int contractorID = 0;
            int storageID = 0;

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

            // Вызываем метод Update из класса DataDB
            ExpenditureInvoice.Update(invoiceID, invoiceDate, invoiceNumber, contractorID, storageID);

            // Закрываем форму после сохранения
            Close();
        }
        private void UpdateQuantnPrice()
        {
            quant1.Text = DataDB.ExecuteScalarQuery($"SELECT COUNT(\"DetailID\") FROM public.\"ExpenditureInvoiceDetail\"\r\nWHERE \"InvoiceID\"={invoiceID};");
            quant2.Text = DataDB.ExecuteScalarQuery($"SELECT SUM(\"Quantity\") FROM public.\"ExpenditureInvoiceDetail\"\r\nWHERE \"InvoiceID\"={invoiceID};");
            sum.Text = DataDB.ExecuteScalarQuery($"SELECT SUM(\"Total\") FROM public.\"ExpenditureInvoiceDetail\"\r\nWHERE \"InvoiceID\"={invoiceID};");
        }
        private void EditExpenditureInvoiceForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            UpdateQuantnPrice();
            if (specGrid.Rows.Count > 0) storageBox.Enabled = false;
        }
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = specGrid.SelectedRows[0];
            int detailID = Convert.ToInt32(selectedRow.Cells["DetailID"].Value);
            ExpenditureInvoice.DeleteDetail(detailID);
            LoadDataIntoDataGridView();
            UpdateQuantnPrice();
        }
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
    }
}
