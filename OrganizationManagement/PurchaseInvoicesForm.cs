using DatabaseLibrary;
using OrganizationManagement.NomenclatureEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class PurchaseInvoicesForm : Form
    {
        public PurchaseInvoicesForm()
        {
            InitializeComponent();
        }

        private void PurchaseInvoicesForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT\r\n" +
                "pid.\"InvoiceID\", " +
                "pid.\"InvoiceDate\" AS \"Дата\",\r\n" +
                "pid.\"InvoiceNumber\" AS \"Номер\",\r\n" +
                "c.\"Name\" AS \"Контрагент\",\r\n" +
                "s.\"Name\" AS \"Склад\",\r\n" +
                "c.\"Reason\" AS \"Основание\",\r\n" +
                "pid.\"TotalAmount\" AS \"Сумма\"\r\n" +
                "FROM public.\"PurchaseInvoice\" pid\r\n" +
                "JOIN public.\"Contractor\" c ON pid.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                "JOIN public.\"Storage\" s ON pid.\"StorageID\" = s.\"StorageID\";";
            DataDB.FillDataGridViewWithQueryResult(invoicesGrid, query);
            invoicesGrid.Columns["InvoiceID"].Visible = false;
            invoicesGrid.Columns["Дата"].Width = 100;
            invoicesGrid.Columns["Номер"].Width = 50;
        }

        private void PurchaseInvoicesForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddPurchaseInvoiceForm addForm = new AddPurchaseInvoiceForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }

        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = invoicesGrid.SelectedRows[0];
            int invoiceID = Convert.ToInt32(selectedRow.Cells["InvoiceID"].Value);
            DataDB invoicesRepository = new DataDB();

            string query = "SELECT\r\n" +
                "pid.\"InvoiceID\",\r\n    " +
                "pid.\"InvoiceDate\",\r\n    " +
                "pid.\"InvoiceNumber\",\r\n    " +
                "c.\"Name\" as \"ContractorName\",\r\n    " +
                "s.\"Name\" as \"StorageName\",\r\n    " +
                "c.\"Reason\" as \"Reason\",\r\n    " +
                "pid.\"TotalAmount\"\r\n" +
                "FROM public.\"PurchaseInvoice\" pid\r\n" +
                "JOIN public.\"Contractor\" c ON pid.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                "JOIN public.\"Storage\" s ON pid.\"StorageID\" = s.\"StorageID\"\r\n" +
                $"WHERE pid.\"InvoiceID\" = {invoiceID};";

            DataTable invoicesData = invoicesRepository.FillFormWithQueryResult(query);

            EditPurchaseInvoiceForm editForm = new EditPurchaseInvoiceForm(invoicesData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
    }
}
