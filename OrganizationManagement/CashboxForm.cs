using DatabaseLibrary;
using OrganizationManagement.CashboxEdit;
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class CashboxForm : Form
    {
        public CashboxForm()
        {
            InitializeComponent(); //инициализация окна
        }
        private void CashboxForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection(); //открывается соединение с БД
        }
        private void CashboxForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView(); //отображение данных в dataGridView
        }
        private void LoadDataIntoDataGridView()
        {
            //выборка столбцов и записей для отображения
            string query = "SELECT \"CashboxID\", " +
                "\"Name\" AS \"Название\", " +
                "\"TotalAmount\" AS \"Сумма\" " +
                "FROM public.\"Cashbox\" " +
                "ORDER BY \"CashboxID\" DESC;";
            DataDB.FillDataGridViewWithQueryResult(cashboxGrid, query);
            cashboxGrid.Columns["CashboxID"].Visible = false;
        }
        //добавление новой кассы
        private void addItem_Click(object sender, EventArgs e)
        {
            AddCashboxForm addForm = new AddCashboxForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        //обновление содержимого окна
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        //редактирование выбранной кассы
        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = cashboxGrid.SelectedRows[0];
            int cashboxID = Convert.ToInt32(selectedRow.Cells["CashboxID"].Value);
            CashboxEditForm editForm = new CashboxEditForm(cashboxID);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
        //редактирование выбранной кассы по даблклику по строке
        private void cashboxGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = cashboxGrid.SelectedRows[0];
                int cashboxID = Convert.ToInt32(selectedRow.Cells["CashboxID"].Value);
                CashboxEditForm editForm = new CashboxEditForm(cashboxID);
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
                DataView dv = ((DataTable)cashboxGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("CONVERT([Сумма], 'System.String') LIKE '%{0}%' OR [Название] LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)cashboxGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
