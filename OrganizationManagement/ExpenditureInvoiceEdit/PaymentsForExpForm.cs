using DatabaseLibrary;
using System;
using OrganizationManagement.PKOnRKOEdit;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class PaymentsForExpForm : Form
    {
        int invoiceID;
        public PaymentsForExpForm(int expInvID)
        {
            InitializeComponent();
            invoiceID = expInvID;
            Text += invoiceID.ToString();
        }
        private void PaymentsForExpForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }
        private void PaymentsForExpForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT \"PkoID\", " +
                "\"PkoDate\" AS \"Дата\", " +
                "\"Sum\" AS \"Сумма\", " +
                $"\"Name\" AS \"Примечание\" FROM public.\"PKO\" WHERE \"ExpInvID\" = {invoiceID}";
            DataDB.FillDataGridViewWithQueryResult(paymentsGrid, query);
            paymentsGrid.Columns["PkoID"].Visible = false;
        }
        private void addItem_Click(object sender, EventArgs e)
        {
            AddPKOForm addForm = new AddPKOForm(invoiceID);
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = paymentsGrid.SelectedRows[0];
            int pkoID = Convert.ToInt32(selectedRow.Cells["PkoID"].Value);

            // Подтверждение удаления от пользователя
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранное ПКО и связанные платежи?", "Удаление ПКО", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Удаление записи из таблицы Payment
                string deletePaymentQuery = $"DELETE FROM public.\"Payment\"\r\n" +
                    $"WHERE \"Name\" IN (SELECT \"Name\" FROM public.\"PKO\");";
                DataDB.ExecuteQuery(deletePaymentQuery);

                // Удаление записи из таблицы PKO
                string deletePKOQuery = $"DELETE FROM public.\"PKO\" WHERE \"PkoID\" = {pkoID}";
                DataDB.ExecuteQuery(deletePKOQuery);

                // Обновление данных в DataGridView
                LoadDataIntoDataGridView();
            }
        }
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = paymentsGrid.SelectedRows[0];
            int pkoID = Convert.ToInt32(selectedRow.Cells["PkoID"].Value);
            DataDB pkoRepository = new DataDB();

            string query = $"SELECT p.\"PkoID\", p.\"PkoDate\" AS \"Дата\", p.\"PkoNum\" AS \"Номер\", " +
               $"p.\"ExpInvID\" AS \"Инвойс\", p.\"ContractorID\", c.\"Name\" AS \"Контрагент\", " +
               $"p.\"OrgID\", o.\"Name\" AS \"Организация\", p.\"Sum\" AS \"Сумма\", p.\"Name\" AS \"Основание\" " +
               $"FROM public.\"PKO\" p " +
               $"LEFT JOIN public.\"Organization\" o ON p.\"OrgID\" = o.\"OrganizationID\" " +
               $"LEFT JOIN public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\" " +
               $"WHERE p.\"PkoID\" = {pkoID}";
            DataTable pkoData = pkoRepository.FillFormWithQueryResult(query);

            EditPKOForm editForm = new EditPKOForm(pkoData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
        private void paymentsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = paymentsGrid.SelectedRows[0];
            int pkoID = Convert.ToInt32(selectedRow.Cells["PkoID"].Value);
            DataDB pkoRepository = new DataDB();

            string query = $"SELECT p.\"PkoID\", p.\"PkoDate\" AS \"Дата\", p.\"PkoNum\" AS \"Номер\", " +
               $"p.\"ExpInvID\" AS \"Инвойс\", p.\"ContractorID\", c.\"Name\" AS \"Контрагент\", " +
               $"p.\"OrgID\", o.\"Name\" AS \"Организация\", p.\"Sum\" AS \"Сумма\", p.\"Name\" AS \"Основание\" " +
               $"FROM public.\"PKO\" p " +
               $"LEFT JOIN public.\"Organization\" o ON p.\"OrgID\" = o.\"OrganizationID\" " +
               $"LEFT JOIN public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\" " +
               $"WHERE p.\"PkoID\" = {pkoID}";
            DataTable pkoData = pkoRepository.FillFormWithQueryResult(query);

            EditPKOForm editForm = new EditPKOForm(pkoData);
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
