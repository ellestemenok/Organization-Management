using DatabaseLibrary;
using OrganizationManagement.PurchaseInvoicesEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement.InvoicesEdit
{
    public partial class EditInvoiceForm : Form
    {
        private int invoiceID;
        public EditInvoiceForm(DataTable invoicesData)
        {
            InitializeComponent();

            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(paymentBox, "SELECT \"AccountID\", \"Name\" FROM public.\"PaymentAccount\" ORDER BY \"AccountID\" ASC");

            if (invoicesData != null && invoicesData.Rows.Count > 0)
            {
                DataRow row = invoicesData.Rows[0]; // Предполагаем, что данные одной накладной передаются в DataTable

                invoiceID = Convert.ToInt32(row["InvoiceID"]);
                orgBox.Text = row["OrgName"].ToString();
                gruzOtprBox.Text = row["OrgConsigneeAddress"].ToString();
                dateTimePicker.Value = Convert.ToDateTime(row["InvoiceDate"]);
                numField.Text = row["InvoiceNumber"].ToString();
                givenBox.Checked = Convert.ToBoolean(row["Given"]);
                contractorBox.Text = row["ContractorName"].ToString();
                gruzPolBox.Text = row["ConsigneeAddress"].ToString();
                paymentBox.Text = row["Name"].ToString();
                sumField.Text = row["TotalAmount"].ToString();
                expNumField.Text = row["ExpInvID"].ToString();
                reasonBox.Text = row["Reason"].ToString();
            }

            UpdateQuantnPrice();
        }

        public void LoadDataIntoDataGridView()
        { 
            int expID;
            if (int.TryParse(expNumField.Text, out expID))
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
                            "FROM public.\"ExpenditureInvoice\" pid\r\n" +
                            "JOIN public.\"ExpenditureInvoiceDetail\" pd ON pid.\"InvoiceID\" = pd.\"InvoiceID\"\r\n" +
                            "JOIN public.\"Good\" g ON pd.\"ProductID\" = g.\"GoodID\"\r\n" +
                            "JOIN public.\"MeasureUnit\" mu ON g.\"MeasureUnitID\" = mu.\"UnitID\"\r\n" +
                            $"WHERE pid.\"InvoiceID\" = {expID}; ";
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
        }
        private void AddInvoiceForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            UpdateQuantnPrice();
        }


        private void contractorBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateQuantnPrice()
        {
            sumField.Text = DataDB.ExecuteScalarQuery($"SELECT \"TotalAmount\" FROM public.\"Invoice\"\r\nWHERE \"InvoiceID\"={invoiceID};");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime invoiceDate = dateTimePicker.Value;
            int contractorID = 0;
            int paymentID = 0;
            int number = Convert.ToInt32(numField.Text);

            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }

            if (paymentBox.SelectedItem != null)
            {
                var paymentItem = (KeyValuePair<int, string>)paymentBox.SelectedItem;
                paymentID = paymentItem.Key;
            }

            int? expNum; // Объявляем переменную как nullable int
            if (int.TryParse(expNumField.Text, out int parsedValue))
            {
                expNum = parsedValue; // Присваиваем expNum значение parsedValue, если преобразование успешно
            }
            else
            {
                expNum = null; // Устанавливаем expNum в null, если ввод не может быть преобразован в число
            }

            bool isGiven = givenBox.Checked;

            Invoice.Update(invoiceID, invoiceDate, number, contractorID, paymentID, isGiven, expNum);

            // Закрываем форму после сохранения
            Close();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            DateTime invoiceDate = dateTimePicker.Value;
            int contractorID = 0;
            int paymentID = 0;
            int number = Convert.ToInt32(numField.Text);

            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }

            if (paymentBox.SelectedItem != null)
            {
                var paymentItem = (KeyValuePair<int, string>)paymentBox.SelectedItem;
                paymentID = paymentItem.Key;
            }
            int? expNum; // Объявляем переменную как nullable int
            if (int.TryParse(expNumField.Text, out int parsedValue))
            {
                expNum = parsedValue; // Присваиваем expNum значение parsedValue, если преобразование успешно
                AddGoodinExpenditureInvoiceForm addForm = new AddGoodinExpenditureInvoiceForm(parsedValue);
                addForm.MdiParent = ActiveForm;
                addForm.Show();
            }
            else
            {
                expNum = null; // Устанавливаем expNum в null, если ввод не может быть преобразован в число
            }
            bool isGiven = givenBox.Checked;
            Invoice.Update(invoiceID, invoiceDate, number, contractorID, paymentID, isGiven, expNum);
            Log.Insert(mainMDIForm.userID, "Отредактирована счет-фактура №" + number.ToString());

            
            UpdateQuantnPrice();
        }

        private void AddInvoiceForm_Load(object sender, EventArgs e)
        {
            
        }

        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = specGrid.SelectedRows[0];
            int detailID = Convert.ToInt32(selectedRow.Cells["DetailID"].Value);
            ExpenditureInvoice.DeleteDetail(detailID);
            UpdateQuantnPrice();
            LoadDataIntoDataGridView();
        }
    }
}
