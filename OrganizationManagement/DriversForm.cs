using DatabaseLibrary;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Npgsql;
using OrganizationManagement.DriversEdit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class DriversForm : Form
    {

        public DriversForm()
        {
            InitializeComponent();
           
        }
        private void DriversForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void DriversForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }

        private void DriversForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Autorization.CloseConnection();
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT d.\"DriverID\", d.\"Name\" AS \"Имя водителя\", r.\"Name\" AS \"Маршрут\" " +
                   "FROM public.\"Driver\" d " +
                   "LEFT JOIN public.\"Route\" r ON d.\"RouteID\" = r.\"RouteID\" " +
                   "ORDER BY d.\"DriverID\" ASC";
            DataDB.FillDataGridViewWithQueryResult(driversGrid, query);
            driversGrid.Columns["DriverID"].Visible = false;
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = driversGrid.SelectedRows[0];
                int driverID = Convert.ToInt32(selectedRow.Cells["DriverID"].Value);
                Log.Insert(mainMDIForm.userID, "Удален водитель " + selectedRow.Cells["Имя водителя"].Value.ToString());
                Driver.Delete(driverID);
                LoadDataIntoDataGridView();
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddDriverForm addForm = new AddDriverForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();

        }

        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = driversGrid.SelectedRows[0];
            int driverID = Convert.ToInt32(selectedRow.Cells["DriverID"].Value);
            DataDB driversRepository = new DataDB();

            string query = $"SELECT \"DriverID\", \"Name\", \"RouteID\" FROM public.\"Driver\" WHERE \"DriverID\" = {driverID}";

            DataTable driversData = driversRepository.FillFormWithQueryResult(query);

            EditDriverForm editForm = new EditDriverForm(driversData);
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
                DataView dv = ((DataTable)driversGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("[Имя водителя] LIKE '%{0}%' OR Маршрут LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)driversGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }

        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
    }
}
