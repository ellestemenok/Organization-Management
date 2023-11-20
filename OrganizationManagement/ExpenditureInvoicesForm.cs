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
    public partial class ExpenditureInvoicesForm : Form
    {
        public ExpenditureInvoicesForm()
        {
            InitializeComponent();
        }

        private void ExpenditureInvoicesForm_Load(object sender, EventArgs e)
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
                "FROM public.\"ExpenditureInvoice\" pid\r\n" +
                "JOIN public.\"Contractor\" c ON pid.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                "JOIN public.\"Storage\" s ON pid.\"StorageID\" = s.\"StorageID\" " +
                "ORDER BY pid.\"InvoiceNumber\" DESC;";
            DataDB.FillDataGridViewWithQueryResult(expinvoicesGrid, query);
            expinvoicesGrid.Columns["InvoiceID"].Visible = false;
            expinvoicesGrid.Columns["Дата"].Width = 100;
            expinvoicesGrid.Columns["Номер"].Width = 50;
        }

        private void ExpenditureInvoicesForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            //DataGridViewRow selectedRow = invoicesGrid.SelectedRows[0];
            //int invoiceID = Convert.ToInt32(selectedRow.Cells["InvoiceID"].Value);

            //AddExpenditureInvoiceForm addForm = new AddExpenditureInvoiceForm();
            //addForm.MdiParent = ActiveForm;
            //addForm.Show();
        }

        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = expinvoicesGrid.SelectedRows[0];
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
                "FROM public.\"ExpenditureInvoice\" pid\r\n" +
                "JOIN public.\"Contractor\" c ON pid.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                "JOIN public.\"Storage\" s ON pid.\"StorageID\" = s.\"StorageID\"\r\n" +
                $"WHERE pid.\"InvoiceID\" = {invoiceID};";

            DataTable invoicesData = invoicesRepository.FillFormWithQueryResult(query);

            EditExpenditureInvoiceForm editForm = new EditExpenditureInvoiceForm(invoicesData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = expinvoicesGrid.SelectedRows[0];
                int invoiceID = Convert.ToInt32(selectedRow.Cells["InvoiceID"].Value);
                ExpenditureInvoice.Delete(invoiceID);
                LoadDataIntoDataGridView();
            }
        }
    }
}
