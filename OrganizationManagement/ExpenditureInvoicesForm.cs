using DatabaseLibrary;
using System;
using System.Data;
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
            DataDB.FillDataGridViewWithQueryResult(invoicesGrid, query);
            invoicesGrid.Columns["InvoiceID"].Visible = false;
            invoicesGrid.Columns["Дата"].Width = 100;
            invoicesGrid.Columns["Номер"].Width = 50;
        }

        private void ExpenditureInvoicesForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddExpenditureInvoiceForm addForm = new AddExpenditureInvoiceForm();
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
                DataGridViewRow selectedRow = invoicesGrid.SelectedRows[0];
                int invoiceID = Convert.ToInt32(selectedRow.Cells["InvoiceID"].Value);
                ExpenditureInvoice.Delete(invoiceID);
                LoadDataIntoDataGridView();
            }
        }

        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = filterBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)invoicesGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("CONVERT(Номер, 'System.String') LIKE '%{0}%' OR Контрагент LIKE '%{0}%' OR Склад LIKE '%{0}%' " +
                            "OR Основание LIKE '%{0}%' OR CONVERT(Сумма, 'System.String') LIKE '%{0}%'", searchText);
            }
            else
            {
                ((DataTable)invoicesGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }

        private void invoicesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int invoiceID = Convert.ToInt32(invoicesGrid.Rows[e.RowIndex].Cells["InvoiceID"].Value);
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
        }
    }
}
