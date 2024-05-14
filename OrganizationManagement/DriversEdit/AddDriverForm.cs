using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
namespace OrganizationManagement.DriversEdit
{
    public partial class AddDriverForm : Form
    {
        public AddDriverForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string driverName = nameField.Text;
            Driver.Insert(driverName);
            Log.Insert(mainMDIForm.userID, "Создан водитель " + driverName);
            Close(); 
        }
    }
}