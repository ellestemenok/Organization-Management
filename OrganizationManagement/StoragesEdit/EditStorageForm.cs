using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement.StoragesEdit
{
    public partial class EditStorageForm : Form
    {
        private int storageID;
        public EditStorageForm(DataTable storagesData)
        {
            InitializeComponent();

            if (storagesData.Rows.Count > 0)
            {
                storageID = Convert.ToInt32(storagesData.Rows[0]["StorageID"]);
                nameField.Text = storagesData.Rows[0]["Name"].ToString();
                mainCheckBox.Checked = Convert.ToBoolean(storagesData.Rows[0]["isMain"]); ;
                freeCheckBox.Checked = Convert.ToBoolean(storagesData.Rows[0]["isFree"]);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            bool isMain = mainCheckBox.Checked;
            bool isFree = freeCheckBox.Checked;

            Storage.Update(storageID, name, isMain, isFree);
            Close();
        }
    }
}
