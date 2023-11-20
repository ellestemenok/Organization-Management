using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseLibrary;
using Npgsql;

namespace OrganizationManagement
{
    public partial class MainMDI : Form
    {
        public MainMDI()
        {
            InitializeComponent();
            usernameStripStatusLabel.Text = Autorization.username;
            timerForDatetime.Start();
            toolStripDateTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void timerForDatetime_Tick(object sender, EventArgs e)
        {
            toolStripDateTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void organizationRequisitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrganizationRequisitesForm newMDIChild = new OrganizationRequisitesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void MainMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите завершить работу?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Autorization.CloseConnection();
                Dispose();
                Application.Exit();
            }
            else { e.Cancel = true; }
        }

        private void measureUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeasureUnitsForm newMDIChild = new MeasureUnitsForm();
            newMDIChild.MdiParent= this;
            newMDIChild.Show();
        }

        private void nomenclatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NomenclatureForm newMDIChild = new NomenclatureForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void contractorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContractorsForm newMDIChild = new ContractorsForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void purchaseinvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseInvoicesForm newMDIChild = new PurchaseInvoicesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void expenditureInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenditureInvoicesForm newMDIChild = new ExpenditureInvoicesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
    }
}
