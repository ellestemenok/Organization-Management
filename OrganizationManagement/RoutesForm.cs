using DatabaseLibrary;
using OrganizationManagement.StoragesEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement.RoutesEdit
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
            Autorization.CloseConnection();
        }

        private void RoutesForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT  r.\"RouteID\" AS \"№\", " +
                "r.\"Name\" AS \"Название\", " +
                "COUNT(rp.\"ContractorID\") AS \"Количество точек\" " +
                "FROM public.\"Route\" r LEFT JOIN public.\"Contractor\" rp ON r.\"RouteID\" = rp.\"RouteID\" " +
                "GROUP BY r.\"RouteID\", r.\"Name\" ORDER BY r.\"RouteID\"";
            DataDB.FillDataGridViewWithQueryResult(routesGrid, query);
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = routesGrid.SelectedRows[0];
                int routeID = Convert.ToInt32(selectedRow.Cells["№"].Value);
                Storage.Delete(routeID);
                LoadDataIntoDataGridView();
            }
        }

        private void addItem_Click_1(object sender, EventArgs e)
        {
            //AddRouteForm addForm = new AddRouteForm();
            //addForm.MdiParent = ActiveForm;
            //addForm.Show();
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            //DataGridViewRow selectedRow = routesGrid.SelectedRows[0];
            //int routeID = Convert.ToInt32(selectedRow.Cells["№"].Value);
            //DataDB routesRepository = new DataDB();

            //string query = $"SELECT * FROM public.\"Route\" WHERE \"RouteID\" = {routeID}";
            //DataTable routesData = routesRepository.FillFormWithQueryResult(query);

            //EditRouteForm editForm = new EditRouteForm(routesData);
            //editForm.MdiParent = ActiveForm;
            //editForm.Show();
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
            LoadDataIntoDataGridView();
        }
    }
}
