using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class StorageContentsForm : Form
    {
        public StorageContentsForm()
        {
            InitializeComponent();
        }
        private void StorageContentsForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }
        private void StorageContentsForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            string query = "SELECT \"Name\" FROM public.\"Storage\";";
            DataDB.LoadCategoriesIntoTreeView(query, storagesView);
        }
        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT e.\"ContentID\",\r\n" +
                "g.\"ArticleNumber\" as \"Артикул\", \r\n" +
                "g.\"Name\" as \"Товар\", \r\n" +
                "e.\"ExpendedQuantity\" as \"Расход\", \r\n" +
                "e.\"ReceivedQuantity\" as \"Приход\", \r\n" +
                "e.\"RemainingQuantity\" as \"Остаток\" \r\n" +
                "FROM public.\"StorageContent\" AS e\r\n" +
                "JOIN public.\"Good\" AS g ON g.\"GoodID\" = e.\"ProductID\"\r\n" +
                "WHERE e.\"RemainingQuantity\" != 0\r\n" +
                "ORDER BY g.\"ArticleNumber\" ASC;";
            DataDB.FillDataGridViewWithQueryResult(storageGoodsGrid, query);
            storageGoodsGrid.Columns["ContentID"].Visible = false;
            storageGoodsGrid.Columns["Артикул"].Width = 60;
            storageGoodsGrid.Columns["Товар"].Width = 250;
            storageGoodsGrid.Columns["Расход"].Width = 65;
            storageGoodsGrid.Columns["Приход"].Width = 65;
            storageGoodsGrid.Columns["Остаток"].Width = 65;

        }
        private void storagesView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Получите выбранный узел
            TreeNode selectedNode = e.Node;
            int nodename = selectedNode.Index + 1;
            if (selectedNode != null)
            {
                string query = "SELECT e.\"ContentID\",\r\n" +
                "g.\"ArticleNumber\" as \"Артикул\", \r\n" +
                "g.\"Name\" as \"Товар\", \r\n" +
                "e.\"ExpendedQuantity\" as \"Расход\", \r\n" +
                "e.\"ReceivedQuantity\" as \"Приход\", \r\n" +
                "e.\"RemainingQuantity\" as \"Остаток\" \r\n" +
                "FROM public.\"StorageContent\" AS e\r\n" +
                "JOIN public.\"Good\" AS g ON g.\"GoodID\" = e.\"ProductID\"\r\n" +
                $"WHERE e.\"RemainingQuantity\" != 0 AND e.\"StorageID\" = {nodename}\r\n" +
                "ORDER BY g.\"ArticleNumber\" ASC;";

                DataDB.FillDataGridViewWithQueryResult(storageGoodsGrid, query);
                storageGoodsGrid.Columns["ContentID"].Visible = false;
                storageGoodsGrid.Columns["Артикул"].Width = 60;
                storageGoodsGrid.Columns["Товар"].Width = 250;
                storageGoodsGrid.Columns["Расход"].Width = 65;
                storageGoodsGrid.Columns["Приход"].Width = 65;
                storageGoodsGrid.Columns["Остаток"].Width = 65;
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddPurchaseInvoiceForm addForm = new AddPurchaseInvoiceForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            AddExpenditureInvoiceForm addForm = new AddExpenditureInvoiceForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }

        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = filterBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)storageGoodsGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("Артикул LIKE '%{0}%' OR Товар LIKE '%{0}%'", searchText);
            }
            else
            {
                ((DataTable)storageGoodsGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
