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

namespace OrganizationManagement.MeasureUnitsEdit
{
    public partial class AddMeasureUnitForm : Form
    {
        public AddMeasureUnitForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            string okeiID = okeiField.Text;
            string fullname = fullnameField.Text;
            bool fractional = fractionalCheckBox.Checked;

            MeasureUnit.Insert(Convert.ToInt32(okeiID), name, fullname, fractional);
            Close();
        }
    }
}
