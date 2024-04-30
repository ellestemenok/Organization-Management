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

namespace OrganizationManagement.InvoicesEdit
{
    public partial class AddInvoiceForm : Form
    {
        private int invoiceID;
        public AddInvoiceForm()
        {
            InitializeComponent();
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");

            var orgData = DataDB.ExecuteScalarQuery("SELECT \"Name\" FROM public.\"Organization\" WHERE \"OrganizationID\" = 1");
            orgBox.Text = orgData.ToString();

            DataDB.LoadDataIntoComboBox(paymentBox, "SELECT \"AccountID\", \"Name\" FROM public.\"PaymentAccount\" ORDER BY \"AccountID\" ASC");

            var gruzotprData = DataDB.ExecuteScalarQuery("SELECT \"Name\" || ', ' || \"LegalAddress\" FROM public.\"Organization\" WHERE \"OrganizationID\" = 1");
            gruzOtprBox.Text = gruzotprData.ToString();

            var gruzpolData = DataDB.ExecuteScalarQuery("SELECT \"Name\" || ', ' || \"LegalAddress\" FROM public.\"Contractor\" WHERE \"ContractorID\" = 1");
            gruzPolBox.Text = gruzpolData.ToString();

            var reasonData = DataDB.ExecuteScalarQuery("SELECT \"Reason\" FROM public.\"Contractor\" WHERE \"ContractorID\" = 1");
            reasonBox.Text = reasonData.ToString();

            Invoice.Insert(DateTime.Today, 1, 1);

            invoiceID = Convert.ToInt32(DataDB.ExecuteScalarQuery("SELECT MAX(\"InvoiceID\") FROM public.\"Invoice\";"));
            numField.Text = DataDB.ExecuteScalarQuery("SELECT MAX(\"InvoiceNumber\") FROM public.\"Invoice\";");
            dateTimePicker.Value = DateTime.Today;

            if (contractorBox.Items.Count > 0)
            {
                contractorBox.Text = ((KeyValuePair<int, string>)contractorBox.Items[0]).Value;
            }
        }

        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT\r\n" +
                "pid.\"InvoiceID\"," +
                "pd.\"DetailID\", " +
                "g.\"ArticleNumber\" AS \"Артикул\",\r\n" +
                "g.\"Name\" AS \"Название\",\r\n" +
                "pd.\"Quantity\" AS \"Кол-во\",\r\n" +
                "mu.\"Name\" AS \"Ед. изм.\",\r\n" +
                "g.\"TradePrice\" AS \"Цена\",\r\n" +
                "pd.\"Total\" AS \"Стоимость\"\r\n" +
                "FROM public.\"Invoice\" pid\r\n" +
                "JOIN public.\"InvoiceDetail\" pd ON pid.\"InvoiceID\" = pd.\"InvoiceID\"\r\n" +
                "JOIN public.\"Good\" g ON pd.\"ProductID\" = g.\"GoodID\"\r\n" +
                "JOIN public.\"MeasureUnit\" mu ON g.\"MeasureUnitID\" = mu.\"UnitID\"\r\n" +
                $"WHERE pid.\"InvoiceID\" = {invoiceID}; ";
            DataDB.FillDataGridViewWithQueryResult(specGrid, query);
            specGrid.Columns["InvoiceID"].Visible = false;
            specGrid.Columns["DetailID"].Visible = false;
            specGrid.Columns["Артикул"].Width = 70;
            specGrid.Columns["Название"].Width = 200;
            specGrid.Columns["Кол-во"].Width = 55;
            specGrid.Columns["Ед. изм."].Width = 45;
            specGrid.Columns["Цена"].Width = 60;
            specGrid.Columns["Стоимость"].Width = 90;
        }

        private void orgBox_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void contractorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedgoodID = ((KeyValuePair<int, string>)contractorBox.SelectedItem).Key;
            DataDB contractorRepository = new DataDB();
            DataTable contrData = contractorRepository.FillFormWithQueryResult(
                "SELECT \"ContractorID\", " +
                "\"Reason\",  \"ConsigneeAddress\" \r\n" +
                "FROM public.\"Contractor\" \r\n" +
                $"WHERE \"ContractorID\" = {selectedgoodID};");
            if (contrData != null && contrData.Rows.Count > 0)
            {
                reasonBox.Text = contrData.Rows[0]["Reason"].ToString();
                gruzPolBox.Text = contrData.Rows[0]["ConsigneeAddress"].ToString();
            }
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = specGrid.SelectedRows[0];
            int detailID = Convert.ToInt32(selectedRow.Cells["DetailID"].Value);
            Invoice.DeleteDetail(detailID);
        }
    }
}
