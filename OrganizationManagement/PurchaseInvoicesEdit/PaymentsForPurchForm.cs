using DatabaseLibrary;
using System;
using OrganizationManagement.PKOnRKOEdit;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class PaymentsForPurchForm : Form
    {
        int invoiceID;
        public PaymentsForPurchForm(int purchInvID)
        {
            InitializeComponent();
            invoiceID = purchInvID;
            Text += invoiceID.ToString();
        }
        private void PaymentsForPurchForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }
        private void PaymentsForPurchForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT \"RkoID\", " +
                "\"RkoDate\" AS \"Дата\", " +
                "\"Sum\" AS \"Сумма\", " +
                $"\"Name\" AS \"Примечание\" FROM public.\"RKO\" WHERE \"PurchInvID\" = {invoiceID}";
            DataDB.FillDataGridViewWithQueryResult(paymentsGrid, query);
            paymentsGrid.Columns["RkoID"].Visible = false;
        }
        private void addItem_Click(object sender, EventArgs e)
        {
            AddRKOForm addForm = new AddRKOForm(invoiceID);
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = paymentsGrid.SelectedRows[0];
            int rkoID = Convert.ToInt32(selectedRow.Cells["RkoID"].Value);

            // Подтверждение удаления от пользователя
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранное РКО и связанные платежи?", "Удаление ПКО", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Удаление записи из таблицы Payment
                string deletePaymentQuery = $"DELETE FROM public.\"Payment\"\r\n" +
                    $"WHERE \"Name\" IN (SELECT \"Name\" FROM public.\"RKO\");";
                DataDB.ExecuteQuery(deletePaymentQuery);

                // Удаление записи из таблицы PKO
                string deleteRKOQuery = $"DELETE FROM public.\"RKO\" WHERE \"RkoID\" = {rkoID}";
                DataDB.ExecuteQuery(deleteRKOQuery);

                // Обновление данных в DataGridView
                LoadDataIntoDataGridView();
                Log.Insert(mainMDIForm.userID, "Удален Расходный кассовый ордер №" + rkoID.ToString());
            }
        }
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = paymentsGrid.SelectedRows[0];
            int rkoID = Convert.ToInt32(selectedRow.Cells["RkoID"].Value);
            DataDB rkoRepository = new DataDB();

            string query = $"SELECT p.\"RkoID\", p.\"RkoDate\" AS \"Дата\", p.\"RkoNum\" AS \"Номер\", " +
               $"p.\"PurchInvID\" AS \"Инвойс\", p.\"ContractorID\", c.\"Name\" AS \"Контрагент\", " +
               $"p.\"OrgID\", o.\"Name\" AS \"Организация\", p.\"Sum\" AS \"Сумма\", p.\"Name\" AS \"Основание\" " +
               $"FROM public.\"RKO\" p " +
               $"LEFT JOIN public.\"Organization\" o ON p.\"OrgID\" = o.\"OrganizationID\" " +
               $"LEFT JOIN public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\" " +
               $"WHERE p.\"RkoID\" = {rkoID}";
            DataTable rkoData = rkoRepository.FillFormWithQueryResult(query);

            EditRKOForm editForm = new EditRKOForm(rkoData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
        private void paymentsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = paymentsGrid.SelectedRows[0];
            int rkoID = Convert.ToInt32(selectedRow.Cells["RkoID"].Value);
            DataDB rkoRepository = new DataDB();

            string query = $"SELECT p.\"RkoID\", p.\"RkoDate\" AS \"Дата\", p.\"RkoNum\" AS \"Номер\", " +
               $"p.\"PurchInvID\" AS \"Инвойс\", p.\"ContractorID\", c.\"Name\" AS \"Контрагент\", " +
               $"p.\"OrgID\", o.\"Name\" AS \"Организация\", p.\"Sum\" AS \"Сумма\", p.\"Name\" AS \"Основание\" " +
               $"FROM public.\"RKO\" p " +
               $"LEFT JOIN public.\"Organization\" o ON p.\"OrgID\" = o.\"OrganizationID\" " +
               $"LEFT JOIN public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\" " +
               $"WHERE p.\"RkoID\" = {rkoID}";
            DataTable rkoData = rkoRepository.FillFormWithQueryResult(query);

            EditRKOForm editForm = new EditRKOForm(rkoData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = toolStripTextBox1.Text.Trim();

            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)paymentsGrid.DataSource).DefaultView;

                // Создаем фильтр для всех интересующих нас столбцов
                dv.RowFilter = string.Format(
                    "CONVERT(Дата, 'System.String')  LIKE '%{0}%' OR " +
                    "CONVERT(Сумма, 'System.String')  LIKE '%{0}%' OR " +
                    "[Примечание] LIKE '%{0}%'",
                    searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)paymentsGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
