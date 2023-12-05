using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement.NomenclatureEdit
{
    public partial class EditPurchaseInvoiceForm : Form
    {
        private int goodID;
        public EditPurchaseInvoiceForm(DataTable goodsData)
        {
            InitializeComponent();

            DataDB.LoadDataIntoComboBox(groupBox, "SELECT \"CategoryID\", \"Name\" FROM public.\"GoodCategory\" ORDER BY \"CategoryID\" ASC");
            DataDB.LoadDataIntoComboBox(measureunitBox, "SELECT \"UnitID\", \"Name\" FROM public.\"MeasureUnit\" ORDER BY \"UnitID\" ASC");
            
            netcostField.KeyPress += KeyPressEvent.textBox_KeyPressMoney;
            vatField.KeyPress += KeyPressEvent.textBox_KeyPressPercent;
            retailmarginField.KeyPress += KeyPressEvent.textBox_KeyPressPercent;
            trademarginField.KeyPress += KeyPressEvent.textBox_KeyPressPercent;

            if (goodsData.Rows.Count > 0)
            {
                goodID = Convert.ToInt32(goodsData.Rows[0]["GoodID"]);
                nameField.Text = goodsData.Rows[0]["Name"].ToString();
                articleField.Text = goodsData.Rows[0]["ArticleNumber"].ToString();

                groupBox.Text = goodsData.Rows[0]["CategoryName"].ToString();
                measureunitBox.Text = goodsData.Rows[0]["UnitName"].ToString();

                archivecheckBox.Checked = Convert.ToBoolean(goodsData.Rows[0]["InArchive"]);
                netcostField.Text = goodsData.Rows[0]["NetCost"].ToString();
                vatField.Text = goodsData.Rows[0]["VAT"].ToString();
                costWoVatField.Text = goodsData.Rows[0]["TradePrice"].ToString();
                tradepriceField.Text = goodsData.Rows[0]["TradePrice"].ToString();
                retailpriceField.Text = goodsData.Rows[0]["RetailPrice"].ToString();
                trademarginField.Text = goodsData.Rows[0]["TradeMargin"].ToString();
                retailmarginField.Text = goodsData.Rows[0]["RetailMargin"].ToString();
                descriptionField.Text = goodsData.Rows[0]["Description"].ToString();
            }
        }

        private void goodSave_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            string article = articleField.Text;
            int measureunitID = 0;
            int groupID = 0;

            if (measureunitBox.SelectedItem != null)
            {
                var measureunitItem = (KeyValuePair<int, string>)measureunitBox.SelectedItem;
                measureunitID = measureunitItem.Key;
            }

            if (groupBox.SelectedItem != null)
            {
                var groupItem = (KeyValuePair<int, string>)groupBox.SelectedItem;
                groupID = groupItem.Key;
            }

            bool archivecheck = archivecheckBox.Checked;
            double netcost = Convert.ToDouble(netcostField.Text);
            double vat = Convert.ToDouble(vatField.Text);
            double costwovat = Convert.ToDouble(costWoVatField.Text);
            double tradeprice = Convert.ToDouble(tradepriceField.Text);
            double retailprice = Convert.ToDouble(retailpriceField.Text);
            double trademargin = Convert.ToDouble(trademarginField.Text);
            double retailmargin = Convert.ToDouble(retailmarginField.Text);
            string description = descriptionField.Text;

            Good.Update(goodID, name, article, measureunitID, groupID, archivecheck, netcost, vat, costwovat, tradeprice, retailprice, trademargin, retailmargin, description);
            Close();
        }

        private void netcostField_Leave(object sender, EventArgs e)
        {
            double netcost = Convert.ToDouble(netcostField.Text);

            double vat = Convert.ToDouble(vatField.Text) * 0.01;
            double trademargin = Convert.ToDouble(trademarginField.Text) * 0.01;
            double retailmargin = Convert.ToDouble(retailmarginField.Text) * 0.01;

            costWoVatField.Text = Math.Round(netcost - netcost * vat, 2).ToString();
            tradepriceField.Text = Math.Round(netcost + netcost * trademargin, 2).ToString();
            retailpriceField.Text = Math.Round(netcost + netcost * retailmargin, 2).ToString(); 
        }
        private void vatField_Leave(object sender, EventArgs e)
        {
            double netcost = Convert.ToDouble(netcostField.Text);
            double vat = Convert.ToDouble(vatField.Text) * 0.01;

            double costWoVat = Math.Round(netcost - netcost * vat, 2);

            costWoVatField.Text = costWoVat.ToString();
        }
        private void trademarginField_Leave(object sender, EventArgs e)
        {
            double netcost = Convert.ToDouble(netcostField.Text);
            double trademargin = Convert.ToDouble(trademarginField.Text) * 0.01;

            double tradeprice = Math.Round(netcost + netcost * trademargin, 2);

            tradepriceField.Text = tradeprice.ToString();
        }

        private void retailmarginField_Leave(object sender, EventArgs e)
        {
            double netcost = Convert.ToDouble(netcostField.Text);
            double retailmargin = Convert.ToDouble(retailmarginField.Text) * 0.01;

            double retailprice = Math.Round(netcost + netcost * retailmargin, 2);

            retailpriceField.Text = retailprice.ToString();
        }
    }
}
