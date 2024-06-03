using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class ReportViewForm : Form
    {
        private readonly IReportDataProvider _dataProvider;
        public ReportViewForm(IReportDataProvider dataProvider)
        {
            InitializeComponent(); // Инициализация компонентов формы
            _dataProvider = dataProvider; // Сохранение ссылки на провайдера данных
            LoadReport(); // Загрузка отчета
        }
        private void LoadReport()
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local; // Установка локального режима обработки отчета
            reportViewer1.LocalReport.ReportPath = _dataProvider.ReportPath; // Установка пути к файлу отчета
            reportViewer1.LocalReport.DataSources.Clear(); // Очистка источников данных отчета
            reportViewer1.LocalReport.DataSources.Add(_dataProvider.GetReportDataSource()); // Добавление нового источника данных для отчета
            reportViewer1.RefreshReport(); // Обновление отображения отчета

            // Настройка режима отображения и масштаба отчета
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout); // Установка режима отображения в виде макета для печати
            reportViewer1.ZoomMode = ZoomMode.Percent; // Установка режима масштабирования по процентам
            reportViewer1.ZoomPercent = 100; // Установка масштаба в 100%
        }
    }
}
