using DatabaseLibrary;
using OrganizationManagement.MeasureUnitsEdit;
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
            string query = "SELECT \"GoodID\", " +
                "\"ArticleNumber\" as Артикул,  " +
                "\"Name\" as Название " +
                "FROM public.\"Good\" as Good " +
                "ORDER BY \"ArticleNumber\" ASC ;";
            DataDB.FillDataGridViewWithQueryResult(goodsGrid, query);
            goodsGrid.Columns["GoodID"].Visible = false;
            goodsGrid.Columns["Артикул"].Width = 100;
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
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { 
                DataGridViewRow selectedRow = goodsGrid.SelectedRows[0];
                int goodID = Convert.ToInt32(selectedRow.Cells["GoodID"].Value);
                Good.Delete(goodID);
                LoadDataIntoDataGridView();
            }
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = goodsGrid.SelectedRows[0];
            int goodID = Convert.ToInt32(selectedRow.Cells["GoodID"].Value);
            DataDB goodsRepository = new DataDB();

            string query = "SELECT \"GoodID\", " +
                    "\r\nGood.\"Name\", " +
                    "\r\nGood.\"ArticleNumber\", " +
                    "\r\nUnits.\"Name\" as \"UnitName\", " +
                    "\r\nGood.\"Description\", " +
                    "\r\n\"InArchive\", " +
                    "\"VAT\", \r\n\"TradeMargin\", " +
                    "\"RetailMargin\", \r\n\"NetCost\", " +
                    "\"TradePrice\", \r\n\"RetailPrice\", " +
                    "\r\nCategory.\"Name\" as \"CategoryName\" \r\n\t" +
                    "FROM public.\"Good\" as Good\r\n\t" +
                    "JOIN public.\"GoodCategory\" as Category\r\n\t" +
                    "ON Category.\"CategoryID\" = Good.\"CategoryID\"\r\n\t" +
                    "JOIN public.\"MeasureUnit\" as Units\r\n\t" +
                    "ON Units.\"UnitID\" = Good.\"MeasureUnitID\"\r\n\t" +
                    $"WHERE \"GoodID\" = {goodID}\r\n\t;";
            DataTable goodsData = goodsRepository.FillFormWithQueryResult(query);

            EditGoodForm editForm = new EditGoodForm(goodsData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }

        private void goodsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int goodID = Convert.ToInt32(goodsGrid.Rows[e.RowIndex].Cells["GoodID"].Value);
                DataDB goodsRepository = new DataDB();

                string query = "SELECT \"GoodID\", " +
                    "\r\nGood.\"Name\", " +
                    "\r\nGood.\"ArticleNumber\", " +
                    "\r\nUnits.\"Name\" as \"UnitName\", " +
                    "\r\nGood.\"Description\", " +
                    "\r\n\"InArchive\", " +
                    "\"VAT\", \r\n\"TradeMargin\", " +
                    "\"RetailMargin\", \r\n\"NetCost\", " +
                    "\"TradePrice\", \r\n\"RetailPrice\", " +
                    "\r\nCategory.\"Name\" as \"CategoryName\" \r\n\t" +
                    "FROM public.\"Good\" as Good\r\n\t" +
                    "JOIN public.\"GoodCategory\" as Category\r\n\t" +
                    "ON Category.\"CategoryID\" = Good.\"CategoryID\"\r\n\t" +
                    "JOIN public.\"MeasureUnit\" as Units\r\n\t" +
                    "ON Units.\"UnitID\" = Good.\"MeasureUnitID\"\r\n\t" +
                    $"WHERE \"GoodID\" = {goodID}\r\n\t;";
                DataTable goodsData = goodsRepository.FillFormWithQueryResult(query);

                EditGoodForm editForm = new EditGoodForm(goodsData);
                editForm.MdiParent = ActiveForm;
                editForm.Show();
            }
        }
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void categoryView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Получите выбранный узел
            TreeNode selectedNode = e.Node;
            int nodename = selectedNode.Index + 1;
            if (selectedNode != null)
            {
                string query = "SELECT \"GoodID\", " +
                    "\"ArticleNumber\" as \"Артикул\", " +
                    "\"Name\" as \"Название\", " +
                    "\"CategoryID\" " +
                    "FROM public.\"Good\" as Good " +
                    $"WHERE \"CategoryID\" = {nodename} " +
                    "ORDER BY \"ArticleNumber\" ASC;";

                DataDB.FillDataGridViewWithQueryResult(goodsGrid, query);
                goodsGrid.Columns["GoodID"].Visible = false;
                goodsGrid.Columns["CategoryID"].Visible = false;
            }
        }

        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = filterBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)goodsGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("Артикул LIKE '%{0}%' OR Название LIKE '%{0}%'", searchText);
            }
            else
            {
                ((DataTable)goodsGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
