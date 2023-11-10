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
using static System.Net.Mime.MediaTypeNames;

namespace OrganizationManagement
{
    public partial class MainMDI : Form
    {
        public MainMDI()
        {
            InitializeComponent();
            usernameStripStatusLabel.Text = "postgres";
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
            Autorization.CloseConnection();
            Dispose();
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
    }
}
