using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement.CashboxEdit
{
    public partial class CashboxEditForm : Form
    {
        private int cashboxID;
        public CashboxEditForm(int cashID)
        {
            InitializeComponent();
            cashboxID = cashID;
            Autorization.OpenConnection();
        }

        private void CashboxEdit_Load(object sender, EventArgs e)
        {
            label1.Text = DataDB.ExecuteScalarQuery($"SELECT \"Name\" FROM public.\"Cashbox\" WHERE \"CashboxID\"={cashboxID}");
        }

        private void LoadDataIntoDataGridView()
        {
            string query = "SELECT \r\n    " +
                "p.\"PaymentID\",\r\n    " +
                "p.\"Name\" AS \"Описание платежа\",\r\n    " +
                "p.\"Type\" AS \"Тип\",\r\n    " +
                "p.\"Sum\" AS \"Сумма\",\r\n    " +
                "c.\"Name\" AS \"Контрагент\"\r\n" +
                "FROM \r\n    public.\"Payment\" p\r\n" +
                "LEFT JOIN \r\n    public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                $"WHERE \r\n    p.\"CashboxID\" = {cashboxID};\r\n";
            DataDB.FillDataGridViewWithQueryResult(specGrid, query);
            specGrid.Columns["PaymentID"].Visible = false;
        }

        private void CashboxEdit_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            label5.Text = DataDB.ExecuteScalarQuery($"SELECT ABS(COALESCE(SUM(\"Sum\"), 0)) \r\nFROM public.\"Payment\"\r\nWHERE \"CashboxID\" = {cashboxID} AND \"Sum\" < 0;");
            label6.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(SUM(\"Sum\"), 0) \r\nFROM public.\"Payment\"\r\nWHERE \"CashboxID\" = {cashboxID} AND \"Sum\" > 0;");
            label7.Text = DataDB.ExecuteScalarQuery($"SELECT \"TotalAmount\" FROM public.\"Cashbox\" WHERE \"CashboxID\" ={cashboxID};");
        }

        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddPaymentForm addForm = new AddPaymentForm(cashboxID);
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }

    }
}
