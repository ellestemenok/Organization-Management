using DatabaseLibrary;
using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;

namespace OrganizationManagement._dataTables
{
    public class InvoiceDT
    {
        // Поля организации
        public string OrganizationFullName { get; set; }
        public string OrganizationOGRN { get; set; }
        public bool OrganizationPayingVAT { get; set; }
        public string OrganizationLegalAddress { get; set; }
        public string OrganizationINN { get; set; }
        public string OrganizationKPP { get; set; }
        public string OrganizationConsigneeAddress { get; set; }

        // Поля накладной
        public DateTime InvoiceDate { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal InvoiceTotalAmount { get; set; }

        // Поля расчетного счета
        public string PaymentAccountName { get; set; }
        public string PaymentAccountNumber { get; set; }
        public string PaymentAccountBankName { get; set; }
        public string PaymentAccountCorrAccount { get; set; }
        public string PaymentAccountBIK { get; set; }

        // Поля контрагента
        public string ContractorConsigneeAddress { get; set; }
        public string ContractorFullName { get; set; }
        public string ContractorLegalAddress { get; set; }
        public string ContractorINN { get; set; }
        public string ContractorKPP { get; set; }

        // Поля товара
        public string GoodName { get; set; }
        public decimal GoodTradePrice { get; set; }

        // Поля детали расходной накладной
        public decimal ExpenditureInvoiceDetailQuantity { get; set; }
        public decimal ExpenditureInvoiceDetailTotal { get; set; }

        // Поля единицы измерения
        public int MeasureUnitOkeiID { get; set; }
        public string MeasureUnitName { get; set; }

        // Метод для получения данных отчета по указанному идентификатору накладной
        public List<InvoiceDT> GetInvoiceReportData(int invoiceId)
        {
            var invoiceReportData = new List<InvoiceDT>();

            // Создание и открытие соединения с базой данных
            using (var connection = new NpgsqlConnection(Autorization.connectionString))
            {
                connection.Open();
                // SQL-запрос для извлечения данных из нескольких таблиц
                string sql = @"
            SELECT 
                org.""FullName"" AS OrganizationFullName,
                org.""OGRN"" AS OrganizationOGRN,
                org.""PayingVAT"" AS OrganizationPayingVAT,
                org.""LegalAddress"" AS OrganizationLegalAddress,
                org.""INN"" AS OrganizationINN,
                org.""KPP"" AS OrganizationKPP,
                org.""ConsigneeAddress"" AS OrganizationConsigneeAddress,
                inv.""InvoiceDate"" AS InvoiceDate,
                inv.""InvoiceNumber"" AS InvoiceNumber,
                inv.""TotalAmount"" AS InvoiceTotalAmount,
                pa.""Name"" AS PaymentAccountName,
                pa.""AccountNumber"" AS PaymentAccountNumber,
                pa.""BankName"" AS PaymentAccountBankName,
                pa.""СorrAccount"" AS PaymentAccountCorrAccount,
                pa.""BIK"" AS PaymentAccountBIK,
                cont.""ConsigneeAddress"" AS ContractorConsigneeAddress,
                cont.""FullName"" AS ContractorFullName,
                cont.""LegalAddress"" AS ContractorLegalAddress,
                cont.""INN"" AS ContractorINN,
                cont.""KPP"" AS ContractorKPP,
                prod.""Name"" AS GoodName,
                prod.""TradePrice"" AS GoodTradePrice,
                det.""Quantity"" AS ExpenditureInvoiceDetailQuantity,
                det.""Total"" AS ExpenditureInvoiceDetailTotal,
                mu.""okeiID"" AS MeasureUnitOkeiID,
                mu.""Name"" AS MeasureUnitName
            FROM 
                public.""Invoice"" inv
            JOIN 
                public.""Organization"" org ON org.""OrganizationID"" = inv.""OrgID""
            JOIN 
                public.""PaymentAccount"" pa ON pa.""AccountID"" = inv.""PaymentID""
            JOIN 
                public.""Contractor"" cont ON cont.""ContractorID"" = inv.""ContractorID""
            JOIN 
                public.""ExpenditureInvoiceDetail"" det ON det.""InvoiceID"" = inv.""ExpInvID""
            JOIN 
                public.""Good"" prod ON prod.""GoodID"" = det.""ProductID""
            JOIN 
                public.""MeasureUnit"" mu ON mu.""UnitID"" = prod.""MeasureUnitID""
            WHERE 
                inv.""InvoiceID"" = @InvoiceID";

                // Создание и настройка команды для выполнения SQL-запроса
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceID", invoiceId);

                    // Выполнение запроса и чтение результатов
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Добавление каждой строки данных в список
                            invoiceReportData.Add(new InvoiceDT
                            {
                                OrganizationFullName = reader.GetString(0),
                                OrganizationOGRN = reader.GetString(1),
                                OrganizationPayingVAT = reader.GetBoolean(2),
                                OrganizationLegalAddress = reader.GetString(3),
                                OrganizationINN = reader.GetString(4),
                                OrganizationKPP = reader.GetString(5),
                                OrganizationConsigneeAddress = reader.GetString(6),
                                InvoiceDate = reader.GetDateTime(7).Date,
                                InvoiceNumber = reader.GetInt32(8),
                                InvoiceTotalAmount = reader.GetDecimal(9),
                                PaymentAccountName = reader.GetString(10),
                                PaymentAccountNumber = reader.GetString(11),
                                PaymentAccountBankName = reader.GetString(12),
                                PaymentAccountCorrAccount = reader.GetString(13),
                                PaymentAccountBIK = reader.GetString(14),
                                ContractorConsigneeAddress = reader.GetString(15),
                                ContractorFullName = reader.GetString(16),
                                ContractorLegalAddress = reader.GetString(17),
                                ContractorINN = reader.GetString(18),
                                ContractorKPP = reader.GetString(19),
                                GoodName = reader.GetString(20),
                                GoodTradePrice = reader.GetDecimal(21),
                                ExpenditureInvoiceDetailQuantity = reader.GetDecimal(22),
                                ExpenditureInvoiceDetailTotal = reader.GetDecimal(23),
                                MeasureUnitOkeiID = reader.GetInt32(24),
                                MeasureUnitName = reader.GetString(25)
                            });
                        }
                    }
                }
            }

            return invoiceReportData; // Возвращение списка данных отчета
        }
    }
    // Класс, реализующий интерфейс IReportDataProvider для предоставления данных отчета
    public class InvoiceReportDataProvider : IReportDataProvider
    {
        private readonly int _invoiceId;
        // Конструктор, принимающий идентификатор накладной
        public InvoiceReportDataProvider(int invoiceId)
        {
            _invoiceId = invoiceId;
        }

        // Метод для получения источника данных для отчета
        public ReportDataSource GetReportDataSource()
        {
            var data = new InvoiceDT().GetInvoiceReportData(_invoiceId);
            return new ReportDataSource("InvoiceDT", data);
        }

        // Свойство для получения пути к файлу отчета
        public string ReportPath
        {
            get
            {
                // Получение пути к текущему исполняемому файлу приложения
                var exeFolder = AppDomain.CurrentDomain.BaseDirectory;
                // Формирование полного пути к файлу RDLC
                return Path.Combine(exeFolder, "_reports", "InvoiceReport.rdlc");
            }
        }
    }
}