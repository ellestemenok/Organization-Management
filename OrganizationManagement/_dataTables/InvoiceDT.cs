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
        // Organization fields
        public string OrganizationFullName { get; set; }
        public string OrganizationOGRN { get; set; }
        public bool OrganizationPayingVAT { get; set; }
        public string OrganizationLegalAddress { get; set; }
        public string OrganizationINN { get; set; }
        public string OrganizationKPP { get; set; }
        public string OrganizationConsigneeAddress { get; set; }

        // Invoice fields
        public DateTime InvoiceDate { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal InvoiceTotalAmount { get; set; }

        // PaymentAccount fields
        public string PaymentAccountName { get; set; }
        public string PaymentAccountNumber { get; set; }
        public string PaymentAccountBankName { get; set; }
        public string PaymentAccountCorrAccount { get; set; }
        public string PaymentAccountBIK { get; set; }

        // Contractor fields
        public string ContractorConsigneeAddress { get; set; }
        public string ContractorFullName { get; set; }
        public string ContractorLegalAddress { get; set; }
        public string ContractorINN { get; set; }
        public string ContractorKPP { get; set; }

        // Good fields
        public string GoodName { get; set; }
        public decimal GoodTradePrice { get; set; }

        // ExpenditureInvoiceDetail fields
        public decimal ExpenditureInvoiceDetailQuantity { get; set; }
        public decimal ExpenditureInvoiceDetailTotal { get; set; }

        // MeasureUnit fields
        public int MeasureUnitOkeiID { get; set; }
        public string MeasureUnitName { get; set; }

        public List<InvoiceDT> GetInvoiceReportData(int invoiceId)
        {
            var invoiceReportData = new List<InvoiceDT>();

            using (var connection = new NpgsqlConnection(Autorization.connectionString))
            {
                connection.Open();
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

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceID", invoiceId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
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

            return invoiceReportData;
        }
    }
        public class InvoiceReportDataProvider : IReportDataProvider
    {
        private readonly int _invoiceId;

        public InvoiceReportDataProvider(int invoiceId)
        {
            _invoiceId = invoiceId;
        }

        public ReportDataSource GetReportDataSource()
        {
            var data = new InvoiceDT().GetInvoiceReportData(_invoiceId);
            return new ReportDataSource("InvoiceDT", data);
        }

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