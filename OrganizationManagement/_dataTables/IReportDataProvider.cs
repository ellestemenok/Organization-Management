using Microsoft.Reporting.WinForms;

namespace OrganizationManagement
{
    public interface IReportDataProvider
    {
        ReportDataSource GetReportDataSource();
        string ReportPath { get; }
    }
}
