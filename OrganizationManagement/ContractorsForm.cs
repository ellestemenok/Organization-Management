using DatabaseLibrary;
using OrganizationManagement.ContractorEdit;
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class ContractorsForm : Form
    {
        public ContractorsForm()
        {
            InitializeComponent();
        }

        private void ContractorsForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT \"ContractorID\", " +
                "\"Name\" AS \"Краткое название\", " +
                "\"FullName\" AS \"Полное название\", " +
                "\"Telephone\" AS \"Телефон\" " +
                "FROM public.\"Contractor\" " +
                "ORDER BY \"ContractorID\";";
            DataDB.FillDataGridViewWithQueryResult(contractorsGrid, query);
            contractorsGrid.Columns["ContractorID"].Visible = false;
            contractorsGrid.Columns["Краткое название"].Width = 110;
            contractorsGrid.Columns["Телефон"].Width = 100;
        }

        private void ContractorsForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            string query = "SELECT \"Name\" FROM public.\"ContractorCategory\"";
            DataDB.LoadCategoriesIntoTreeView(query,categoryView);
        }



        private void addItem_Click(object sender, EventArgs e)
        {
            AddContractorForm addForm = new AddContractorForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = contractorsGrid.SelectedRows[0];
                int contactorID = Convert.ToInt32(selectedRow.Cells["ContractorID"].Value);
                Contractor.Delete(contactorID);
                LoadDataIntoDataGridView();
            }
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = contractorsGrid.SelectedRows[0];
            int contractorID = Convert.ToInt32(selectedRow.Cells["ContractorID"].Value);
            DataDB contractorsRepository = new DataDB();

            string query = "SELECT \"ContractorID\", " +
                "\r\n\"Type\", Con.\"Name\", " +
                "\r\n\"FullName\", \"Telephone\", " +
                "\r\n\"Email\", \"INN\", \"KPP\", \"OKPO\", " +
                "\"OKTMO\", \r\n\"OGRN\", \"PaymentAccount\", " +
                "\r\n\"Bank\", \"BIK\", \"CorrAccount\", " +
                "\r\n\"PostAddress\", \"LegalAddress\", \r\n\"ConsigneeAddress\", " +
                "\"Director\", \"GeneralAccountant\", \"Reason\", " +
                "\r\nCategory.\"Name\" AS CategoryName, \r\n\"Description\", " +
                "\r\n\"Manager\"\r\n\tFROM public.\"Contractor\" as Con\r\n\t" +
                "JOIN public.\"ContractorCategory\" as Category\r\n\tON Category.\"CategoryID\" = Con.\"CategoryID\"\r\n\t" +
                $"WHERE \"ContractorID\" = {contractorID};";
            DataTable contractorsData = contractorsRepository.FillFormWithQueryResult(query);

            EditContractorForm editForm = new EditContractorForm(contractorsData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }

        private void contractorsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int contractorID = Convert.ToInt32(contractorsGrid.Rows[e.RowIndex].Cells["ContractorID"].Value);
                DataDB contractorsRepository = new DataDB();

                string query = "SELECT \"ContractorID\", " +
                    "\r\n\"Type\", Con.\"Name\", " +
                    "\r\n\"FullName\", \"Telephone\", " +
                    "\r\n\"Email\", \"INN\", \"KPP\", \"OKPO\", " +
                    "\"OKTMO\", \r\n\"OGRN\", \"PaymentAccount\", " +
                    "\r\n\"Bank\", \"BIK\", \"CorrAccount\", " +
                    "\r\n\"PostAddress\", \"LegalAddress\", \r\n\"ConsigneeAddress\", " +
                    "\"Director\", \"GeneralAccountant\", \"Reason\", " +
                    "\r\nCategory.\"Name\" AS CategoryName, \r\n\"Description\", " +
                    "\r\n\"Manager\"\r\n\tFROM public.\"Contractor\" as Con\r\n\t" +
                    "JOIN public.\"ContractorCategory\" as Category\r\n\tON Category.\"CategoryID\" = Con.\"CategoryID\"\r\n\t" +
                    $"WHERE \"ContractorID\" = {contractorID};";
                DataTable contractorsData = contractorsRepository.FillFormWithQueryResult(query);

                EditContractorForm editForm = new EditContractorForm(contractorsData);
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
                string query = "SELECT \"ContractorID\", " +
                    "\"Name\" AS \"Краткое название\", " +
                    "\"FullName\" AS \"Полное название\", " +
                    "\"Telephone\" AS \"Телефон\" " +
                    "FROM public.\"Contractor\" " +
                    $"WHERE \"CategoryID\" = {nodename} " +
                    "ORDER BY \"ContractorID\";";
                DataDB.FillDataGridViewWithQueryResult(contractorsGrid, query);
                contractorsGrid.Columns["ContractorID"].Visible = false;
                contractorsGrid.Columns["Телефон"].Width = 100;
            }
        }
        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = filterBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)contractorsGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("[Краткое название] LIKE '%{0}%' OR [Полное название] LIKE '%{0}%' " +
                    "OR [Телефон] LIKE '%{0}%'", searchText);
            }
            else
            {
                ((DataTable)contractorsGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
