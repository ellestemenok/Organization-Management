using DatabaseLibrary;
using System;
using System.Windows.Forms;
namespace OrganizationManagement.StoragesEdit
{
    public partial class AddStorageForm : Form
    {
        public AddStorageForm()
        {
            InitializeComponent();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            bool isMain = mainCheckBox.Checked;
            bool isFree = freeCheckBox.Checked;

            Storage.Insert(name, isMain, isFree);
            Close();
        }
    }
}
