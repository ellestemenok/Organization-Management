using DatabaseLibrary;
using OrganizationManagement.PKOnRKOEdit;

using OrganizationManagement.PKOnRKOEdit;
using System;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class PKOForm : Form
    {
        public PKOForm()
        {
            InitializeComponent();
        }

        private void PKOForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }

        private void PKOForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT p.\"PkoID\", " +
                           "p.\"PkoDate\" AS \"Дата\", " +
                           "p.\"PkoNum\" AS \"Номер\", " +
                           "o.\"Name\" AS \"Выписан на\", " +
                           "c.\"Name\" AS \"Принято от\", " +
                           "p.\"Sum\" AS \"Сумма\", " +
                           "p.\"Name\" AS \"Основание\" " +
                           "FROM public.\"PKO\" p " +
                           "LEFT JOIN public.\"Organization\" o ON p.\"OrgID\" = o.\"OrganizationID\" " +
                           "LEFT JOIN public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\" " +
                           "ORDER BY p.\"PkoID\" DESC;";
            DataDB.FillDataGridViewWithQueryResult(pkoGrid, query);
            pkoGrid.Columns["PkoID"].Visible = false;
            pkoGrid.Columns["Дата"].Width = 100;
            pkoGrid.Columns["Номер"].Width = 50;

        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddPKOForm addForm = new AddPKOForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = pkoGrid.SelectedRows[0];
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
            DataGridViewRow selectedRow = pkoGrid.SelectedRows[0];
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
        private void pkoGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = pkoGrid.SelectedRows[0];
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
        private void PKOForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Autorization.CloseConnection();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = toolStripTextBox1.Text.Trim();

            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)pkoGrid.DataSource).DefaultView;

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
                ((DataTable)pkoGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
