using DatabaseLibrary;
using OrganizationManagement.InvoicesEdit;
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class InvoicesForm : Form
    {
        public InvoicesForm()
        {
            InitializeComponent(); //инициализация компонента
        }
        private void InvoicesForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection(); //открытие соединения с БД
        }
        public void LoadDataIntoDataGridView()
        {
            //Выборка столбцов и записей для отображения в dataGridView
            string query = "SELECT\r\n" +
                "pid.\"InvoiceID\", " +
                "pid.\"InvoiceDate\" AS \"Дата\",\r\n" +
                "pid.\"InvoiceNumber\" AS \"Номер\",\r\n" +
                "c.\"Name\" AS \"Контрагент\",\r\n" +
                "pid.\"TotalAmount\" AS \"Сумма\"\r\n, " +
                "pid.\"Given\" AS \"Отдана\" \r\n" +
                "FROM public.\"Invoice\" pid\r\n" +
                "JOIN public.\"Contractor\" c ON pid.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                "ORDER BY pid.\"InvoiceNumber\" DESC;";
            DataDB.FillDataGridViewWithQueryResult(invoicesGrid, query);
            invoicesGrid.Columns["InvoiceID"].Visible = false;
            invoicesGrid.Columns["Дата"].Width = 100;
            invoicesGrid.Columns["Номер"].Width = 50;
        }
        private void InvoicesForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView(); //отображение содержимого окна
        }
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView(); //обновление содержимого страницы
        }
        //редактирование записи
        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = invoicesGrid.SelectedRows[0];
            int invoiceID = Convert.ToInt32(selectedRow.Cells["InvoiceID"].Value);
            DataDB invoicesRepository = new DataDB();
            string query = "SELECT\r\n" +
                "pid.\"ExpInvID\",\r\n    " +
                "pid.\"InvoiceID\",\r\n    " +
                "pid.\"InvoiceDate\",\r\n    " +
                "pid.\"InvoiceNumber\",\r\n    " +
                "pid.\"Given\",\r\n    " +
                "pid.\"ExpInvID\",\r\n    " +
                "c.\"Name\" as \"ContractorName\",\r\n    " +
                "c.\"Reason\" as \"Reason\",\r\n    " +
                "c.\"ConsigneeAddress\" as \"ConsigneeAddress\",\r\n    " +
                "pa.\"Name\" as \"Name\",\r\n    " +
                "org.\"Name\" as \"OrgName\",\r\n    " +
                "org.\"ConsigneeAddress\" as \"OrgConsigneeAddress\",\r\n    " +
                "pid.\"TotalAmount\"\r\n" +
                "FROM public.\"Invoice\" pid\r\n" +
                "JOIN public.\"Contractor\" c ON pid.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                "JOIN public.\"Organization\" org ON pid.\"OrgID\" = org.\"OrganizationID\"\r\n" +
                "JOIN public.\"PaymentAccount\" pa ON pid.\"PaymentID\" = pa.\"AccountID\"\r\n" +
                $"WHERE pid.\"InvoiceID\" = {invoiceID};";
            DataTable invoicesData = invoicesRepository.FillFormWithQueryResult(query);
            EditInvoiceForm editForm = new EditInvoiceForm(invoicesData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
        //удаление записи
        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = invoicesGrid.SelectedRows[0];
                int invoiceID = Convert.ToInt32(selectedRow.Cells["InvoiceID"].Value);
                Log.Insert(mainMDIForm.userID, "Удалена счет-фактура №" + selectedRow.Cells["Номер"].Value.ToString()); // создание лога об удалении счет-фактуры
                Invoice.Delete(invoiceID);
                LoadDataIntoDataGridView();
            }
        }
        //фильтр для поиска записей
        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = filterBox.Text.Trim();
            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)invoicesGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("CONVERT(Номер, 'System.String') LIKE '%{0}%' OR Контрагент LIKE '%{0}%' OR CONVERT(Сумма, 'System.String') LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)invoicesGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
        //редактирование записи даблкликом
        private void invoicesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = invoicesGrid.SelectedRows[0];
                int invoiceID = Convert.ToInt32(selectedRow.Cells["InvoiceID"].Value);
                DataDB invoicesRepository = new DataDB();
                string query = "SELECT\r\n" +
                    "pid.\"ExpInvID\",\r\n    " +
                    "pid.\"InvoiceID\",\r\n    " +
                    "pid.\"InvoiceDate\",\r\n    " +
                    "pid.\"InvoiceNumber\",\r\n    " +
                    "pid.\"Given\",\r\n    " +
                    "pid.\"ExpInvID\",\r\n    " +
                    "c.\"Name\" as \"ContractorName\",\r\n    " +
                    "c.\"Reason\" as \"Reason\",\r\n    " +
                    "c.\"ConsigneeAddress\" as \"ConsigneeAddress\",\r\n    " +
                    "pa.\"Name\" as \"Name\",\r\n    " +
                    "org.\"Name\" as \"OrgName\",\r\n    " +
                    "org.\"ConsigneeAddress\" as \"OrgConsigneeAddress\",\r\n    " +
                    "pid.\"TotalAmount\"\r\n" +
                    "FROM public.\"Invoice\" pid\r\n" +
                    "JOIN public.\"Contractor\" c ON pid.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                    "JOIN public.\"Organization\" org ON pid.\"OrgID\" = org.\"OrganizationID\"\r\n" +
                    "LEFT JOIN public.\"PaymentAccount\" pa ON pid.\"PaymentID\" = pa.\"AccountID\"\r\n" +
                    $"WHERE pid.\"InvoiceID\" = {invoiceID};";
                DataTable invoicesData = invoicesRepository.FillFormWithQueryResult(query);
                EditInvoiceForm editForm = new EditInvoiceForm(invoicesData);
                editForm.MdiParent = ActiveForm;
                editForm.Show();
            }
        }
    }
}