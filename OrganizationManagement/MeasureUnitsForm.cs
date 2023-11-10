using DatabaseLibrary;
using OrganizationManagement.AccountEdit;
using OrganizationManagement.MeasureUnitsEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class MeasureUnitsForm : Form
    {
        public MeasureUnitsForm()
        {
            InitializeComponent();
        }

        private void MeasureUnits_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }

        private void MeasureUnits_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT \"UnitID\", " +
                "\"okeiID\" AS \"Код по ОКЕИ\", " +
                "\"Name\" AS \"Краткое название\", " +
                "\"FullName\" AS \"Полное название\"," +
                " \"Fractional\" AS \"Делится?\" " +
                "FROM public.\"MeasureUnit\";";
            DataDB.FillDataGridViewWithQueryResult(measureunitsGrid, query);
            measureunitsGrid.Columns["UnitID"].Visible = false;
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddMeasureUnitForm addForm = new AddMeasureUnitForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = measureunitsGrid.SelectedRows[0];
            int unitID = Convert.ToInt32(selectedRow.Cells["UnitID"].Value);
            MeasureUnit.Delete(unitID);
            LoadDataIntoDataGridView();
        }

        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

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


        private void MeasureUnits_FormClosing(object sender, FormClosingEventArgs e)
        {
            Autorization.CloseConnection();
        }
    }
}
