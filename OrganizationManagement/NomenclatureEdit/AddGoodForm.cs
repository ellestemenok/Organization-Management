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
            DataDB.LoadDataIntoComboBox(groupBox, "SELECT \"CategoryID\", \"Name\" FROM public.\"GoodCategory\"");
            DataDB.LoadDataIntoComboBox(measureunitBox, "SELECT \"UnitID\", \"Name\" FROM public.\"MeasureUnit\"");
        }

        private void goodSave_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            string article = articleField.Text;
            int measureunitID = Convert.ToInt32(measureunitBox.ValueMember);
            int groupID = Convert.ToInt32(groupBox.ValueMember);
            bool archivecheck = archivecheckBox.Checked;
            double netcost = Convert.ToDouble(netcostField.Text);
            double vat = Convert.ToDouble(vatField.Text);
            double costwovat = Convert.ToDouble(costWoVatField.Text);
            double tradeprice = Convert.ToDouble(tradepriceField.Text);
            double retailprice = Convert.ToDouble(retailpriceField.Text);
            double trademargin = Convert.ToDouble(trademarginField.Text);
            double retailmargin = Convert.ToDouble(retailmarginField.Text);
            string description = descriptionField.Text;
        }
    }
}
