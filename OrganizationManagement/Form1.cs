using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void ShowReport(DataTable organizationDetails, DataTable paymentAccounts)
        {
            // Загружаем отчет
            this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\elza-\\Desktop\\testing\\КУРСОВОЕ ПРОЕКТИРОВАНИЕ\\OrganizationManagement\\OrganizationManagement\\_reports\\orgInfo.rdlc";

            // Очищаем предыдущие источники данных, если они есть
            this.reportViewer1.LocalReport.DataSources.Clear();

            // Добавляем новые источники данных
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("OrganizationDetails", organizationDetails));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("PaymentAccounts", paymentAccounts));

            // Обновляем отчет для отображения данных
            this.reportViewer1.RefreshReport();
        }
    }
}
