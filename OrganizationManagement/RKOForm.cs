using DatabaseLibrary;
using OrganizationManagement.PKOnRKOEdit;
using System;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class RKOForm : Form
    {
        public RKOForm()
        {
            InitializeComponent();
        }

        private void RKOForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }

        private void RKOForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT p.\"RkoID\", " +
                           "p.\"RkoDate\" AS \"Дата\", " +
                           "p.\"RkoNum\" AS \"Номер\", " +
                           "o.\"Name\" AS \"Выписан на\", " +
                           "c.\"Name\" AS \"Принято от\", " +
                           "p.\"Sum\" AS \"Сумма\", " +
                           "p.\"Name\" AS \"Основание\" " +
                           "FROM public.\"RKO\" p " +
                           "LEFT JOIN public.\"Organization\" o ON p.\"OrgID\" = o.\"OrganizationID\" " +
                           "LEFT JOIN public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\" " +
                           "ORDER BY p.\"RkoID\" DESC;";
            DataDB.FillDataGridViewWithQueryResult(rkoGrid, query);
            rkoGrid.Columns["RkoID"].Visible = false;
            rkoGrid.Columns["Дата"].Width = 100;
            rkoGrid.Columns["Номер"].Width = 50;

        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddRKOForm addForm = new AddRKOForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = rkoGrid.SelectedRows[0];
            int rkoID = Convert.ToInt32(selectedRow.Cells["RkoID"].Value);

            // Подтверждение удаления от пользователя
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранное РКО и связанные платежи?", "Удаление ПКО", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Удаление записи из таблицы Payment
                string deletePaymentQuery = $"DELETE FROM public.\"Payment\"\r\n" +
                    $"WHERE \"Name\" IN (SELECT \"Name\" FROM public.\"RKO\");";
                DataDB.ExecuteQuery(deletePaymentQuery);

                // Удаление записи из таблицы PKO
                string deletePKOQuery = $"DELETE FROM public.\"RKO\" WHERE \"RkoID\" = {rkoID}";
                DataDB.ExecuteQuery(deletePKOQuery);

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
            DataGridViewRow selectedRow = rkoGrid.SelectedRows[0];
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
        private void pkoGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = rkoGrid.SelectedRows[0];
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
        private void RKOForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Autorization.CloseConnection();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = toolStripTextBox1.Text.Trim();

            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)rkoGrid.DataSource).DefaultView;

                // Создаем фильтр для всех интересующих нас столбцов
                dv.RowFilter = string.Format(
                    "CONVERT(Дата, 'System.String')  LIKE '%{0}%' OR " +
                    "CONVERT(Номер, 'System.String')  LIKE '%{0}%' OR " +
                    "CONVERT(Сумма, 'System.String')  LIKE '%{0}%' OR " +
                    "[Выписан на] LIKE '%{0}%' OR " +
                    "[Принято от] LIKE '%{0}%' OR " +
                    "[Основание] LIKE '%{0}%'",
                    searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)rkoGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
