﻿using DatabaseLibrary;
using OrganizationManagement._dataTables;
using OrganizationManagement.PurchaseInvoicesEdit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class EditPurchaseInvoiceForm : Form
    {
        private int invoiceID;
        public EditPurchaseInvoiceForm(DataTable invoicesData)
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
        private void addItem_Click(object sender, EventArgs e)
        {
            AddGoodinPurchaseInvoiceForm addForm = new AddGoodinPurchaseInvoiceForm(invoiceID);
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
            PurchaseInvoice.Update(invoiceID, invoiceDate, invoiceNumber, contractorID, storageID);
            Log.Insert(mainMDIForm.userID, "Отредактирована расходная накладная №" + invoiceNumber.ToString());
            // Закрываем форму после сохранения
            Close();
        }
        private void UpdateQuantnPrice()
        {
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
        private void EditPurchaseInvoiceForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            UpdateQuantnPrice();
            if (specGrid.Rows.Count > 0) storageBox.Enabled = false;
        }
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = specGrid.SelectedRows[0];
            int detailID = Convert.ToInt32(selectedRow.Cells["DetailID"].Value);
            PurchaseInvoice.DeleteDetail(detailID);
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

        private void paymentJournal_Click(object sender, EventArgs e)
        {
            PaymentsForPurchForm paymentJournal = new PaymentsForPurchForm(invoiceID);
            paymentJournal.MdiParent = ActiveForm;
            paymentJournal.Show();
        }

        private void printButton_Click(object sender, EventArgs e)
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
            PurchaseInvoice.Update(invoiceID, invoiceDate, invoiceNumber, contractorID, storageID);
            IReportDataProvider provider = new PurchInvoiceReportDataProvider(invoiceID);
            ReportViewForm viewForm = new ReportViewForm(provider);
            viewForm.MdiParent = ActiveForm;
            viewForm.Show();
        }
    }
}
