using DatabaseLibrary;
using System;
using System.Windows.Forms;
namespace OrganizationManagement.MeasureUnitsEdit
{
    public partial class AddMeasureUnitForm : Form
    {
        public AddMeasureUnitForm()
        {
            InitializeComponent();
            okeiField.KeyPress += KeyPressEvent.textBox_KeyPressNumber;
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