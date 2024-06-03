using Microsoft.Reporting.WinForms;

namespace OrganizationManagement
{
    // Интерфейс, который должен реализовать поставщик данных для отчетов
    public interface IReportDataProvider
    {
        // Метод для получения источника данных отчета
        ReportDataSource GetReportDataSource();

        // Свойство для получения пути к файлу отчета
        string ReportPath { get; }
    }
}
