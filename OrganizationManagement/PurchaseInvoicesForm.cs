using DatabaseLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class PurchaseInvoicesForm : Form
    {
        public PurchaseInvoicesForm()
        {
            InitializeComponent(); //инициализация компонента
        }
        private void PurchaseInvoicesForm_Load(object sender, EventArgs e)
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
                "s.\"Name\" AS \"Склад\",\r\n" +
                "c.\"Reason\" AS \"Основание\",\r\n" +
                "pid.\"TotalAmount\" AS \"Сумма\"\r\n" +
                "FROM public.\"PurchaseInvoice\" pid\r\n" +
                "JOIN public.\"Contractor\" c ON pid.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                "JOIN public.\"Storage\" s ON pid.\"StorageID\" = s.\"StorageID\" " +
                "ORDER BY pid.\"InvoiceNumber\" DESC;";
            DataDB.FillDataGridViewWithQueryResult(invoicesGrid, query);
            invoicesGrid.Columns["InvoiceID"].Visible = false;
            invoicesGrid.Columns["Дата"].Width = 100;
            invoicesGrid.Columns["Номер"].Width = 50;
            UpdateRowColors();
        }
        //метод для обновления цвета записей в таблице
        private void UpdateRowColors()
        {
            foreach (DataGridViewRow row in invoicesGrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    double totalAmount = Convert.ToDouble(row.Cells["Сумма"].Value);
                    int invoiceID = Convert.ToInt32(row.Cells["InvoiceID"].Value);
                    // Выполняем запрос для получения долга
                    string debtQuery = "SELECT COALESCE(\"TotalAmount\" - (SELECT COALESCE(SUM(\"Sum\"),0.00) from public.\"RKO\" " +
                                        $"WHERE \"PurchInvID\" = {invoiceID}), 0.00) AS \"Долг\" " +
                                        $"FROM public.\"PurchaseInvoice\" WHERE \"InvoiceID\" = {invoiceID}";
                    double debt = Convert.ToDouble(DataDB.ExecuteScalarQuery(debtQuery));
                    // Установка цвета в зависимости от условий
                    if (debt == totalAmount) // если долг = сумма накладной
                        row.DefaultCellStyle.ForeColor = Color.Red; // цвет строки = красный
                    else if (debt > 0 && debt != totalAmount) // если долг != сумма накладной и долг > 0
                        row.DefaultCellStyle.ForeColor = Color.Blue; // цвет строки = синий
                    else if (debt < 0) // если долг < 0
                        row.DefaultCellStyle.ForeColor = Color.Green; // цвет строки = Зеленый
                }
            }
        }
        //отображение содержимого окна
        private void PurchaseInvoicesForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        //добавление приходной накладной
        private void addItem_Click(object sender, EventArgs e)
        {
            AddPurchaseInvoiceForm addForm = new AddPurchaseInvoiceForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        //обновление содержимого окна
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        //редактирование приходной накладной
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
        //удаление записи
        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = invoicesGrid.SelectedRows[0];
                int invoiceID = Convert.ToInt32(selectedRow.Cells["InvoiceID"].Value);
                Log.Insert(mainMDIForm.userID, "Удалена приходная накладная №" + selectedRow.Cells["Номер"].Value.ToString());
                PurchaseInvoice.Delete(invoiceID);
                LoadDataIntoDataGridView();
            }
        }
        //редактирование записи на даблклик
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
        //фильтр для поиска записей
        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = filterBox.Text.Trim();
            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)invoicesGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("CONVERT(Номер, 'System.String') LIKE '%{0}%' OR Контрагент LIKE '%{0}%' OR Склад LIKE '%{0}%' " +
                            "OR Основание LIKE '%{0}%' OR CONVERT(Сумма, 'System.String') LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)invoicesGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
