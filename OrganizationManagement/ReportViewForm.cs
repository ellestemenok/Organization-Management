using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class ReportViewForm : Form
    {

        private readonly IReportDataProvider _dataProvider;

        public ReportViewForm(IReportDataProvider dataProvider)
        {
            InitializeComponent();
            _dataProvider = dataProvider;
            LoadReport();
        }

        private void LoadReport()
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = _dataProvider.ReportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(_dataProvider.GetReportDataSource());
            reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }
    }
}
