using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }
        private void UsersForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }
        private void UsersForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT \"UserID\", CONCAT(\"FullName\", ' - ', \"Role\")  AS \"Имя пользователя\", \"isActive\" AS \"Активный\" FROM public.\"User\" ORDER BY \"UserID\" ASC;";
            DataDB.FillDataGridViewWithQueryResult(usersGrid, query);
            usersGrid.Columns["UserID"].Visible = false;
            usersGrid.Columns["Активный"].Width = 100;
        }
        private void addItem_Click(object sender, EventArgs e)
        {
            AddUserForm addForm = new AddUserForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = usersGrid.SelectedRows[0];
                int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
                User.Delete(userID);
                LoadDataIntoDataGridView();
            }
        }
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = usersGrid.SelectedRows[0];
            int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            DataDB usersRepository = new DataDB();

            string query = $"SELECT * FROM public.\"User\" WHERE \"UserID\" = {userID}";
            DataTable usersData = usersRepository.FillFormWithQueryResult(query);

            EditUserForm editForm = new EditUserForm(usersData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
        private void editItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = usersGrid.SelectedRows[0];
            int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            DataDB usersRepository = new DataDB();

            string query = $"SELECT * FROM public.\"User\" WHERE \"UserID\" = {userID}";
            DataTable usersData = usersRepository.FillFormWithQueryResult(query);

            EditUserForm editForm = new EditUserForm(usersData);
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
                DataView dv = ((DataTable)usersGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("[Имя пользователя] LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)usersGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
