using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.ContractorEdit
{
    public partial class EditContractorForm : Form
    {
        private int contractorID;
        public EditContractorForm(DataTable contractorsTable)
        {
            InitializeComponent();
            DataDB.LoadDataIntoComboBox(groupBox, "SELECT \"CategoryID\", \"Name\" FROM public.\"ContractorCategory\" ORDER BY \"CategoryID\" ASC");
            DataDB.LoadDataIntoComboBox(routeBox, "SELECT \"RouteID\", \"Name\" FROM public.\"Route\" ORDER BY \"RouteID\" ASC");

            if (contractorsTable.Rows.Count > 0)
            {
                contractorID = Convert.ToInt32(contractorsTable.Rows[0]["ContractorID"]);

                typeBox.Text = contractorsTable.Rows[0]["Type"].ToString();
                nameField.Text = contractorsTable.Rows[0]["Name"].ToString();
                fullnameField.Text = contractorsTable.Rows[0]["FullName"].ToString();
                groupBox.Text = contractorsTable.Rows[0]["CategoryName"].ToString();
                telephoneField.Text = contractorsTable.Rows[0]["Telephone"].ToString();
                emailField.Text = contractorsTable.Rows[0]["Email"].ToString();
                innField.Text = contractorsTable.Rows[0]["INN"].ToString();
                kppField.Text = contractorsTable.Rows[0]["KPP"].ToString();
                okpoField.Text = contractorsTable.Rows[0]["OKPO"].ToString();
                oktmoField.Text = contractorsTable.Rows[0]["OKTMO"].ToString();
                ogrnField.Text = contractorsTable.Rows[0]["OGRN"].ToString();
                paymentField.Text = contractorsTable.Rows[0]["PaymentAccount"].ToString();
                bankField.Text = contractorsTable.Rows[0]["Bank"].ToString();
                bikField.Text = contractorsTable.Rows[0]["BIK"].ToString();
                corrField.Text = contractorsTable.Rows[0]["CorrAccount"].ToString();
                postAddrField.Text = contractorsTable.Rows[0]["PostAddress"].ToString();
                legaladdrField.Text = contractorsTable.Rows[0]["LegalAddress"].ToString();
                consaddrField.Text = contractorsTable.Rows[0]["ConsigneeAddress"].ToString();
                directorField.Text = contractorsTable.Rows[0]["Director"].ToString();
                genaccountantField.Text = contractorsTable.Rows[0]["GeneralAccountant"].ToString();
                reasonField.Text = contractorsTable.Rows[0]["Reason"].ToString();
                descriptionField.Text = contractorsTable.Rows[0]["Description"].ToString();
                managerField.Text = contractorsTable.Rows[0]["Manager"].ToString();
                routeBox.Text = contractorsTable.Rows[0]["RouteName"].ToString();
            }
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

            int routeID = 0;
            if (routeBox.SelectedItem != null)
            {
                var routeItem = (KeyValuePair<int, string>)routeBox.SelectedItem;
                routeID = routeItem.Key;
            }
            Contractor.Update(contractorID, type, name, fullname, telephone, email, inn, kpp, okpo, oktmo, ogrn,
                paymentacc, bank, bik, corr, postadrr, legaladdr, consaddr, director, accountant,
                reason, groupID, manager, description, routeID);
            Close();
        }
    }
}
