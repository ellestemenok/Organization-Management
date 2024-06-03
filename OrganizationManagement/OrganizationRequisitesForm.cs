using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DatabaseLibrary;
using OrganizationManagement._dataTables;
using OrganizationManagement.AccountEdit;

namespace OrganizationManagement
{
    public partial class OrganizationRequisitesForm : Form
    {
        public OrganizationRequisitesForm()
        {
            InitializeComponent(); //инициализация компонента
        }
        private void OrganizationRequisites_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView(); //отображение содержимого окна
        }
        private void OrganizationRequisites_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection(); //открытие соединения с БД

            string query = "SELECT * FROM \"Organization\" LIMIT 1";
            DataDB organizationRepository = new DataDB();
            DataTable organizationData = organizationRepository.FillFormWithQueryResult(query);
            // заполнение полей окна
            if (organizationData.Rows.Count > 0)
            {
                typeField.Text = organizationData.Rows[0]["Type"].ToString();
                nameField.Text = organizationData.Rows[0]["Name"].ToString();
                fullnameField.Text = organizationData.Rows[0]["FullName"].ToString();
                consAddrField.Text = organizationData.Rows[0]["ConsigneeAddress"].ToString();
                postAddrField.Text = organizationData.Rows[0]["PostAddress"].ToString();
                legalAddrField.Text = organizationData.Rows[0]["LegalAddress"].ToString();
                telephoneField.Text = organizationData.Rows[0]["TelephoneNumber"].ToString();
                emailField.Text = organizationData.Rows[0]["Email"].ToString();
                innField.Text = organizationData.Rows[0]["INN"].ToString();
                kppField.Text = organizationData.Rows[0]["KPP"].ToString();
                okpoField.Text = organizationData.Rows[0]["OKPO"].ToString();
                okpdField.Text = organizationData.Rows[0]["OKPD"].ToString();
                okvadField.Text = organizationData.Rows[0]["OKVAD"].ToString();
                ogrnField.Text = organizationData.Rows[0]["OGRN"].ToString();
                directorField.Text = organizationData.Rows[0]["Director"].ToString();
                genaccountantField.Text = organizationData.Rows[0]["GeneralAccountant"].ToString();
                payingVATcheckBox.Checked = Convert.ToBoolean(organizationData.Rows[0]["PayingVAT"]);
            }
        }        
        public void LoadDataIntoDataGridView() //заполняем таблицу списком счетов
        {
            string query = "SELECT \"AccountID\" AS \"№\", " +
                "\"Name\" AS \"Имя счета\", " +
                "\"AccountNumber\" AS \"Номер счета\", " +
                "\"BankName\" AS \"В банке\"  " +
                "FROM public.\"PaymentAccount\"" +
                "ORDER BY \"AccountID\" ASC";
            DataDB.FillDataGridViewWithQueryResult(accountsGrid, query);
            accountsGrid.Columns["№"].Visible = false;
        }
        //обновление реквизитов организации
        private void orgSave_Click(object sender, EventArgs e)
        {
            Requisites.Update(1,typeField.Text,nameField.Text,fullnameField.Text,
                    consAddrField.Text,postAddrField.Text,legalAddrField.Text,
                    telephoneField.Text,emailField.Text,
                    innField.Text,kppField.Text,okpoField.Text,okvadField.Text,ogrnField.Text,
                    directorField.Text,genaccountantField.Text,
                    payingVATcheckBox.Checked, okpdField.Text);
            Log.Insert(mainMDIForm.userID, "Отредактирована организация"); // лог об изменении организации
            Close();
        }
        //редактировать расчетный счет организации
        private void accountsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int accountID = Convert.ToInt32(accountsGrid.Rows[e.RowIndex].Cells["№"].Value);
                DataDB paymentAccountRepository = new DataDB();
                string query = $"SELECT * FROM public.\"PaymentAccount\" WHERE \"AccountID\" = {accountID}";
                DataTable accountData = paymentAccountRepository.FillFormWithQueryResult(query);
                EditAccountForm editForm = new EditAccountForm(accountData);
                editForm.MdiParent = ActiveForm;
                editForm.Show();
            }
        }
        // добавить расчетный счет организации
        private void addAccButton_Click(object sender, EventArgs e)
        {
            AddAccountForm addForm = new AddAccountForm();
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
        // удалить расчетный счет организации
        private void delAccButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = accountsGrid.SelectedRows[0];
                int accountID = Convert.ToInt32(selectedRow.Cells["№"].Value);
                Log.Insert(mainMDIForm.userID, "Удален расчетный счет " + selectedRow.Cells["Номер счета"].Value.ToString()); // создание лога об удалении р/с
                Requisites.DeletePaymentAccount(accountID);
                LoadDataIntoDataGridView();
            }
        }
        // печать реквизитов и р/с организации
        private void orgPrint_Click(object sender, EventArgs e)
        {
            IReportDataProvider provider = new OrganizationReportDataProvider();
            ReportViewForm viewForm = new ReportViewForm(provider);
            viewForm.MdiParent = ActiveForm;
            viewForm.Show();
        }
    }
}
