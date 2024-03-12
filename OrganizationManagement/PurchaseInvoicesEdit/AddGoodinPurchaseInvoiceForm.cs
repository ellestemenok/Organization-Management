using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.PurchaseInvoicesEdit
{
    public partial class AddGoodinPurchaseInvoiceForm : Form
    { 
        private int invoiceID;
        public AddGoodinPurchaseInvoiceForm(int id)
        {
            InitializeComponent();
            invoiceID = id;
            DataDB.LoadDataIntoComboBox(goodBox, "SELECT \"GoodID\", " +
                "\"Name\" FROM public.\"Good\" " +
                "ORDER BY \"Name\" ASC");

            goodBox.Text = ((KeyValuePair<int, string>)goodBox.Items[0]).Value;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            int selectedgoodID = ((KeyValuePair<int, string>)goodBox.SelectedItem).Key;
            int quantity = Convert.ToInt32(quantField.Text);

            PurchaseInvoice.AddProductToInvoice(invoiceID, selectedgoodID, quantity);
            Close();
        }
        private void goodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedgoodID = ((KeyValuePair<int, string>)goodBox.SelectedItem).Key;
            DataDB goodsRepository = new DataDB();
            DataTable goodData = goodsRepository.FillFormWithQueryResult("SELECT u.\"Name\", " +
                "\"TradePrice\" \r\nFROM public.\"Good\" as g\r\n" +
                "JOIN public.\"MeasureUnit\" AS u ON g.\"MeasureUnitID\" = u.\"UnitID\"\r\n" +
                $"WHERE \"GoodID\" = {selectedgoodID}");
            if (goodData != null && goodData.Rows.Count > 0)
            {
                // Заполнение полей значениями из базы данных
                unitsField.Text = goodData.Rows[0]["Name"].ToString();
                priceField.Text = goodData.Rows[0]["TradePrice"].ToString();
            }
        }
        private void CalculateSum()
        {
            if (int.TryParse(quantField.Text, out int quantity) && double.TryParse(priceField.Text, out double price))
            {
                sumField.Text = (quantity * price).ToString();
            }
            else
            {
                sumField.Text = string.Empty;
            }
        }
        private void quantField_TextChanged(object sender, EventArgs e)
        {
            CalculateSum();
        }
    }
}
