using DatabaseLibrary;
using OrganizationManagement.StoragesEdit;
using System;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class StoragesForm : Form
    {
        public StoragesForm()
        {
            InitializeComponent();
        }

        private void StoragesForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }

        private void StoragesForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT \"StorageID\", " +
                "\"Name\" AS \"Название\", " +
                "\"isMain\" AS \"Основной склад\", " +
                "\"isFree\" AS \"Свободный склад\" " +
                "FROM public.\"Storage\" ORDER BY \"StorageID\" ASC;";
            DataDB.FillDataGridViewWithQueryResult(storagesGrid, query);
            storagesGrid.Columns["StorageID"].Visible = false;
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddStorageForm addForm = new AddStorageForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = storagesGrid.SelectedRows[0];
                int storageID = Convert.ToInt32(selectedRow.Cells["StorageID"].Value);
                Log.Insert(mainMDIForm.userID, "Удален склад " + selectedRow.Cells["Название"].Value.ToString());
                Storage.Delete(storageID);
                LoadDataIntoDataGridView();
                
            }
        }
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = storagesGrid.SelectedRows[0];
            int storageID = Convert.ToInt32(selectedRow.Cells["StorageID"].Value);
            DataDB storagesRepository = new DataDB();

            string query = $"SELECT * FROM public.\"Storage\" WHERE \"StorageID\" = {storageID}";
            DataTable storagesData = storagesRepository.FillFormWithQueryResult(query);

            EditStorageForm editForm = new EditStorageForm(storagesData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
        private void storagesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int storageID = Convert.ToInt32(storagesGrid.Rows[e.RowIndex].Cells["StorageID"].Value);
                DataDB storagesRepository = new DataDB();

                string query = $"SELECT * FROM public.\"Storage\" WHERE \"StorageID\" = {storageID}";
                DataTable storagesData = storagesRepository.FillFormWithQueryResult(query);

                EditStorageForm editForm = new EditStorageForm(storagesData);
                editForm.MdiParent = ActiveForm;
                editForm.Show();
            }
        }
        private void StoragesForm_FormClosing(object sender, FormClosingEventArgs e)
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
                DataView dv = ((DataTable)storagesGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("Название LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)storagesGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
