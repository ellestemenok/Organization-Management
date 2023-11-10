﻿using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement.NomenclatureEdit
{
    public partial class AddGoodForm : Form
    {
        public AddGoodForm()
        {
            InitializeComponent();
        }

        private void AddGoodForm_Enter(object sender, EventArgs e)
        {
            DataDB.LoadDataIntoComboBox(groupBox, "SELECT \"CategoryID\", \"Name\" FROM public.\"GoodCategory\" ORDER BY \"CategoryID\" ASC");
            DataDB.LoadDataIntoComboBox(measureunitBox, "SELECT \"UnitID\", \"Name\" FROM public.\"MeasureUnit\" ORDER BY \"UnitID\" ASC");
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

            Good.Insert(name, article, measureunitID, groupID, archivecheck, netcost, vat, costwovat, tradeprice, retailprice, trademargin, retailmargin, description);
            Close();
        }

        private void netcostField_Leave(object sender, EventArgs e)
        {
            double netcost = Convert.ToDouble(netcostField.Text);

            double vat = Convert.ToDouble(vatField.Text) * 0.01;
            double trademargin = Convert.ToDouble(trademarginField.Text) * 0.01;
            double retailmargin = Convert.ToDouble(retailmarginField.Text) * 0.01;

            costWoVatField.Text = (netcost - netcost * vat).ToString();
            tradepriceField.Text = (netcost + netcost * trademargin).ToString();
            retailpriceField.Text = (netcost + netcost * retailmargin).ToString(); 
        }
    }
}
