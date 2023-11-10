using DatabaseLibrary;
using OrganizationManagement.NomenclatureEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrganizationManagement
{
    public partial class NomenclatureForm : Form
    {
        public NomenclatureForm()
        {
            InitializeComponent();
        }

        private void NomenclatureForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT \"GoodID\", \"ArticleNumber\" as Артикул,  " +
                "\"Name\" as Название, " +
                "\"RetailPrice\" as Цена " +
                "FROM public.\"Good\" as Good " +
                "ORDER BY \"GoodID\" ASC ;";
            DataDB.FillDataGridViewWithQueryResult(goodsGrid, query);
            goodsGrid.Columns["GoodID"].Visible = false;
        }

        private void NomenclatureForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            string query = "SELECT \"Name\" FROM public.\"GoodCategory\"";
            DataDB.LoadCategoriesIntoTreeView(query,categoryView);

        }



        private void addItem_Click(object sender, EventArgs e)
        {
            AddGoodForm addForm = new AddGoodForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();

        }

        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = goodsGrid.SelectedRows[0];
            int goodID = Convert.ToInt32(selectedRow.Cells["GoodID"].Value);
            Good.Delete(goodID);
            LoadDataIntoDataGridView();
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            //EditGoodForm editForm = new EditGoodForm();
            //editForm.MdiParent = ActiveForm;
            //editForm.Show();
        }
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        private void goodsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
