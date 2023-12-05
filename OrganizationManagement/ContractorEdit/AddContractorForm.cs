using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrganizationManagement.ContractorEdit
{
    public partial class AddContractorForm : Form
    {
        public AddContractorForm()
        {
            InitializeComponent();
            DataDB.LoadDataIntoComboBox(groupBox, "SELECT \"CategoryID\", \"Name\" " +
                "FROM public.\"ContractorCategory\" " +
                "ORDER BY \"CategoryID\" ASC");
            typeBox.Text = typeBox.Items[0].ToString();
            groupBox.Text = ((KeyValuePair<int, string>)groupBox.Items[0]).Value;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string type = typeBox.Text;
            string name = nameField.Text;
            string fullname = fullnameField.Text;
            int groupID = 0;
            if (groupBox.SelectedItem != null)
            {
                var groupItem = (KeyValuePair<int, string>)groupBox.SelectedItem;
                groupID = groupItem.Key;
            }
            string telephone = telephoneField.Text;
            string email = emailField.Text;
            string inn = innField.Text;
            string kpp = kppField.Text;
            string okpo = okpoField.Text;
            string oktmo = oktmoField.Text;
            string ogrn = ogrnField.Text;
            string paymentacc = paymentField.Text;
            string bank = bankField.Text;
            string bik = bikField.Text;
            string corr = corrField.Text;
            string postadrr = postAddrField.Text;
            string legaladdr = legaladdrField.Text;
            string consaddr = consaddrField.Text;
            string director = directorField.Text;
            string accountant = genaccountantField.Text;
            string manager = managerField.Text;
            string reason = reasonField.Text;
            string description = descriptionField.Text;

            Contractor.Insert(type, name, fullname, telephone, email, inn, kpp, okpo, oktmo, ogrn,
                paymentacc, bank, bik, corr, postadrr, legaladdr, consaddr, director, accountant,
                reason, groupID, manager, description);
            Close();
        }
    }
}
