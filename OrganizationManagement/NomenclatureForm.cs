﻿using DatabaseLibrary;
using OrganizationManagement.NomenclatureEdit;
using System;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement
{
    public partial class NomenclatureForm : Form
    {
        public NomenclatureForm()
        {
            InitializeComponent();//инициализация компонента
        }
        private void NomenclatureForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();//открытие соединения с БД
        }
        public void LoadDataIntoDataGridView()
        {
            //Выборка столбцов и записей для отображения в dataGridView
            string query = "SELECT \"GoodID\", " +
                "\"ArticleNumber\" as Артикул,  " +
                "\"Name\" as Название " +
                "FROM public.\"Good\" as Good " +
                "ORDER BY \"ArticleNumber\" ASC ;";
            DataDB.FillDataGridViewWithQueryResult(goodsGrid, query);
            goodsGrid.Columns["GoodID"].Visible = false;
            goodsGrid.Columns["Артикул"].Width = 100;
        }
        //отображение содержимого окна
        private void NomenclatureForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            string query = "SELECT \"Name\" FROM public.\"GoodCategory\"";
            DataDB.LoadCategoriesIntoTreeView(query,categoryView);

        }
        //добавление записи
        private void addItem_Click(object sender, EventArgs e)
        {
            AddGoodForm addForm = new AddGoodForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        //удаление записи
        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { 
                DataGridViewRow selectedRow = goodsGrid.SelectedRows[0];
                int goodID = Convert.ToInt32(selectedRow.Cells["GoodID"].Value);
                Log.Insert(mainMDIForm.userID, "Удален товар " + selectedRow.Cells["Название"].Value.ToString()); // создание лога об удалении товара
                Good.Delete(goodID);
                LoadDataIntoDataGridView();
            }
        }
        //редактирование товара
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
        //редактирование товара даблкликом
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
        //обновление содержимого страницы
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        //выборка товаров по категориям
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
        //фильтр для поиска записей
        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = filterBox.Text.Trim();
            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)goodsGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("Артикул LIKE '%{0}%' OR Название LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)goodsGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}