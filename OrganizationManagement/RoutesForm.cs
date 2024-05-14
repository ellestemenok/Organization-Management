using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;
using OrganizationManagement.RoutesEdit;

namespace OrganizationManagement
{
    public partial class RoutesForm : Form
    {
        public RoutesForm()
        {
            InitializeComponent();
        }

        private void RoutesForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }

        private void RoutesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Autorization.CloseConnection();
        }

        private void RoutesForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        public void LoadDataIntoDataGridView()
        {
            routesGrid.DataSource = null;
            string query = "SELECT  r.\"RouteID\" AS \"№\", " +
                "r.\"Name\" AS \"Название\", " +
                "COUNT(rp.\"ContractorID\") AS \"Количество точек\" " +
                "FROM public.\"Route\" r LEFT JOIN public.\"Contractor\" rp ON r.\"RouteID\" = rp.\"RouteID\" " +
                "GROUP BY r.\"RouteID\", r.\"Name\" ORDER BY r.\"RouteID\"";
            
            DataDB.FillDataGridViewWithQueryResult(routesGrid, query);
            routesGrid.Columns["№"].Visible = false;
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = routesGrid.SelectedRows[0];
                int routeID = Convert.ToInt32(selectedRow.Cells["№"].Value);

                // Проверка на запрещенный к удалению маршрут
                if (routeID == 1)
                {
                    MessageBox.Show("Удаление этого маршрута запрещено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перемещение контрагентов маршрута в запись с RouteID = 1
                string updateContractorsQuery = $"UPDATE public.\"Contractor\" SET \"RouteID\" = 1 WHERE \"RouteID\" = {routeID}";
                DataDB.ExecuteQuery(updateContractorsQuery);
                Log.Insert(mainMDIForm.userID, "Удален маршрут " + selectedRow.Cells["Название"].Value.ToString());
                // Удаление маршрута
                Route.Delete(routeID);
                LoadDataIntoDataGridView();
                
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddRouteForm addForm = new AddRouteForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = routesGrid.SelectedRows[0];
            int routeID = Convert.ToInt32(selectedRow.Cells["№"].Value);
            DataDB routesRepository = new DataDB();

            string routeQuery = $"SELECT * FROM public.\"Route\" WHERE \"RouteID\" = {routeID}";
            DataTable routeData = routesRepository.FillFormWithQueryResult(routeQuery);

            string contractorsQuery = "SELECT * FROM public.\"Contractor\""; // Запрос на получение данных о контрагентах
            DataTable contractorsData = routesRepository.FillFormWithQueryResult(contractorsQuery);

            EditRouteForm editForm = new EditRouteForm(routeData, contractorsData); // Передача данных о контрагентах в конструктор
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }

        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = filterBox.Text.Trim();

            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)routesGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("Название LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)routesGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }

        private void routesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = routesGrid.SelectedRows[0];
                int routeID = Convert.ToInt32(selectedRow.Cells["№"].Value);
                DataDB routesRepository = new DataDB();

                string routeQuery = $"SELECT * FROM public.\"Route\" WHERE \"RouteID\" = {routeID}";
                DataTable routeData = routesRepository.FillFormWithQueryResult(routeQuery);

                string contractorsQuery = "SELECT * FROM public.\"Contractor\""; // Запрос на получение данных о контрагентах
                DataTable contractorsData = routesRepository.FillFormWithQueryResult(contractorsQuery);

                EditRouteForm editForm = new EditRouteForm(routeData, contractorsData); // Передача данных о контрагентах в конструктор
                editForm.MdiParent = ActiveForm;
                editForm.Show();
            }
        }

        private void refreshGrid_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDataIntoDataGridView();

            }
            catch (Exception ex) { MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
