using DatabaseLibrary;
using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;

namespace OrganizationManagement._dataTables
{
    // Класс, представляющий данные детализации счета на покупку
    public class PurchInvoiceDetailDT
    {
        // Поля данных счета
        public string OrganizationName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string StorageName { get; set; }
        public string ContractorName { get; set; }
        public string ContractorReason { get; set; }
        public string ArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string MeasureUnit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal TotalAmount { get; set; }
        // Метод для получения данных отчета по номеру счета
        public List<PurchInvoiceDetailDT> GetInvoiceReportData(int invoiceId)
        { 
            // Список для хранения данных счета
            var invoiceReportData = new List<PurchInvoiceDetailDT>();

            // Создание и открытие соединения с базой данных
            using (var connection = new NpgsqlConnection(Autorization.connectionString))
            {
                connection.Open();

                // SQL-запрос для извлечения данных из соответствующих таблиц
                string sql = @"
                    SELECT 
                        org.""Name"" AS OrganizationName,
                        inv.""InvoiceNumber"",
                        inv.""InvoiceDate"",
                        stor.""Name"" AS StorageName,
                        cont.""Name"" AS ContractorName,
                        cont.""Reason"" AS ContractorReason,
                        prod.""ArticleNumber"",
                        prod.""Name"" AS ProductName,
                        mu.""Name"" AS MeasureUnit,
                        det.""Quantity"",
                        det.""Total"" / det.""Quantity"" AS Price,
                        det.""Total"",
                        inv.""TotalAmount""
                    FROM 
                        public.""PurchaseInvoice"" inv
                    JOIN 
                        public.""Organization"" org ON org.""OrganizationID"" = 1
                    JOIN 
                        public.""Storage"" stor ON stor.""StorageID"" = inv.""StorageID""
                    JOIN 
                        public.""Contractor"" cont ON cont.""ContractorID"" = inv.""ContractorID""
                    JOIN 
                        public.""PurchaseInvoiceDetail"" det ON det.""InvoiceID"" = inv.""InvoiceID""
                    JOIN 
                        public.""Good"" prod ON prod.""GoodID"" = det.""ProductID""
                    JOIN 
                        public.""MeasureUnit"" mu ON mu.""UnitID"" = prod.""MeasureUnitID""
                    WHERE 
                        inv.""InvoiceID"" = @InvoiceID";

                // Выполнение команды SQL с использованием параметра InvoiceID
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    // Чтение данных из результата запроса
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            invoiceReportData.Add(new PurchInvoiceDetailDT
                            {
                                OrganizationName = reader.GetString(0),
                                InvoiceNumber = reader.GetInt32(1),
                                InvoiceDate = reader.GetDateTime(2).Date,
                                StorageName = reader.GetString(3),
                                ContractorName = reader.GetString(4),
                                ContractorReason = reader.GetString(5),
                                ArticleNumber = reader.GetString(6),
                                ProductName = reader.GetString(7),
                                MeasureUnit = reader.GetString(8),
                                Quantity = reader.GetDecimal(9),
                                Price = reader.GetDecimal(10),
                                Total = reader.GetDecimal(11),
                                TotalAmount = reader.GetDecimal(12)
                            });
                        }
                    }
                }
            }

            return invoiceReportData; // Возвращение списка данных счета
        }
    }

    // Класс, реализующий интерфейс IReportDataProvider для предоставления данных отчета счета на покупку
    public class PurchInvoiceReportDataProvider : IReportDataProvider
    {
        private readonly int _invoiceId;

        // Конструктор принимает идентификатор счета на покупку
        public PurchInvoiceReportDataProvider(int invoiceId)
        {
            _invoiceId = invoiceId;
        }

        // Метод для получения источника данных для отчета
        public ReportDataSource GetReportDataSource()
        {
            var data = new PurchInvoiceDetailDT().GetInvoiceReportData(_invoiceId);
            return new ReportDataSource("PurchInvoiceDetailDT", data);
        }

        // Свойство для получения пути к файлу отчета
        public string ReportPath
        {
            get
            {
                // Получение пути к текущему исполняемому файлу приложения
                var exeFolder = AppDomain.CurrentDomain.BaseDirectory;
                // Формирование полного пути к файлу RDLC
                return Path.Combine(exeFolder, "_reports", "PurchInvoiceReport.rdlc");
            }
        }
    }
}