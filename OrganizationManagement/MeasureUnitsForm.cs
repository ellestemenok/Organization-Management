using DatabaseLibrary;
using OrganizationManagement.MeasureUnitsEdit;
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class MeasureUnitsForm : Form
    {
        public MeasureUnitsForm()
        {
            InitializeComponent(); //инициализация компонента
        }
        private void MeasureUnits_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();//открытие соединения с БД
        }
        private void MeasureUnits_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();//отображение содержимого окна
        }
        public void LoadDataIntoDataGridView()
        {
            //Выборка столбцов и записей для отображения в dataGridView
            string query = "SELECT \"UnitID\", " +
                "\"okeiID\" AS \"Код по ОКЕИ\", " +
                "\"Name\" AS \"Краткое название\", " +
                "\"FullName\" AS \"Полное название\"," +
                " \"Fractional\" AS \"Делится?\" " +
                "FROM public.\"MeasureUnit\" " +
                "ORDER BY \"UnitID\" ASC;";
            DataDB.FillDataGridViewWithQueryResult(measureunitsGrid, query);
            measureunitsGrid.Columns["UnitID"].Visible = false;
        }
        //добавление ед. измерения
        private void addItem_Click(object sender, EventArgs e)
        {
            AddMeasureUnitForm addForm = new AddMeasureUnitForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        //удаление ед. измерения
        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = measureunitsGrid.SelectedRows[0];
                int unitID = Convert.ToInt32(selectedRow.Cells["UnitID"].Value);
                Log.Insert(mainMDIForm.userID, "Удалена единица измерения " + selectedRow.Cells["Полное название"].Value.ToString()); // создание лога об удалении ед. измерения
                MeasureUnit.Delete(unitID);
                LoadDataIntoDataGridView();
            }
        }
        //обновление содержимого страницы
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        //редактирование единицы измерения
        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = measureunitsGrid.SelectedRows[0];
            int unitID = Convert.ToInt32(selectedRow.Cells["UnitID"].Value);
            DataDB measureunitsRepository = new DataDB();
            string query = $"SELECT * FROM public.\"MeasureUnit\" WHERE \"UnitID\" = {unitID}";
            DataTable measureunitsData = measureunitsRepository.FillFormWithQueryResult(query);
            EditMeasureUnitForm editForm = new EditMeasureUnitForm(measureunitsData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
        //редактирование единицы измерения даблкликом
        private void measureunitsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int unitID = Convert.ToInt32(measureunitsGrid.Rows[e.RowIndex].Cells["UnitID"].Value);
                DataDB measureunitsRepository = new DataDB();
                string query = $"SELECT * FROM public.\"MeasureUnit\" WHERE \"UnitID\" = {unitID}";
                DataTable measureunitsData = measureunitsRepository.FillFormWithQueryResult(query);
                EditMeasureUnitForm editForm = new EditMeasureUnitForm(measureunitsData);
                editForm.MdiParent = ActiveForm;
                editForm.Show();
            }
        }
        //фильтр для поиска записей
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = toolStripTextBox1.Text.Trim();

            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)measureunitsGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("CONVERT([Код по ОКЕИ], 'System.String') LIKE '%{0}%' OR [Краткое название] LIKE '%{0}%' OR [Полное название] LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)measureunitsGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
