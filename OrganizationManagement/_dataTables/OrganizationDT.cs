using DatabaseLibrary;
using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;

namespace OrganizationManagement._dataTables
{
    public class OrganizationDT
    {
        public int OrganizationID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string ConsigneeAddress { get; set; }
        public string PostAddress { get; set; }
        public string LegalAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string OKPO { get; set; }
        public string OKVAD { get; set; }
        public string OGRN { get; set; }
        public string Director { get; set; }
        public string GeneralAccountant { get; set; }
        public bool PayingVAT { get; set; }
        public string OKPD { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string CorrAccount { get; set; }
        public string BIK { get; set; }

        public List<OrganizationDT> GetOrganizationData()
        {
            var organizations = new List<OrganizationDT>();
            using (var connection = new NpgsqlConnection(Autorization.connectionString))
            {
                connection.Open();
                string sql = "SELECT o.*, p.\"AccountID\", p.\"Name\" as AccountName, p.\"AccountNumber\", " +
                    "p.\"BankName\", p.\"СorrAccount\", p.\"BIK\" FROM public.\"Organization\" o " +
                    "LEFT JOIN public.\"PaymentAccount\" p ON o.\"OrganizationID\" = p.\"OrganizationID\" " +
                    "WHERE o.\"OrganizationID\" = 1";
                using (var command = new NpgsqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        organizations.Add(new OrganizationDT
                        {
                            OrganizationID = reader.GetInt32(0),
                            Type = reader.GetString(1),
                            Name = reader.GetString(2),
                            FullName = reader.GetString(3),
                            ConsigneeAddress = reader.GetString(4),
                            PostAddress = reader.GetString(5),
                            LegalAddress = reader.GetString(6),
                            TelephoneNumber = reader.GetString(7),
                            Email = reader.GetString(8),
                            INN = reader.GetString(9),
                            KPP = reader.GetString(10),
                            OKPO = reader.GetString(11),
                            OKVAD = reader.GetString(12),
                            OGRN = reader.GetString(13),
                            Director = reader.GetString(14),
                            GeneralAccountant = reader.GetString(15),
                            PayingVAT = reader.GetBoolean(16),
                            OKPD = reader.GetString(17),
                            // Платежные счета
                            AccountID = reader.IsDBNull(18) ? 0 : reader.GetInt32(18),
                            AccountName = reader.IsDBNull(19) ? null : reader.GetString(19),
                            AccountNumber = reader.IsDBNull(20) ? null : reader.GetString(20),
                            BankName = reader.IsDBNull(21) ? null : reader.GetString(21),
                            CorrAccount = reader.IsDBNull(22) ? null : reader.GetString(22),
                            BIK = reader.IsDBNull(23) ? null : reader.GetString(23)
                        });
                    }
                }
            }
            return organizations;
        }
    }

    public class OrganizationReportDataProvider : IReportDataProvider
    {
        public ReportDataSource GetReportDataSource()
        {
            var x = new OrganizationDT();
            var data = x.GetOrganizationData();
            return new ReportDataSource("OrganizationDT", data);
        }

        public string ReportPath
        {
            get
            {
                // Получение пути к текущему исполняемому файлу приложения
                var exeFolder = AppDomain.CurrentDomain.BaseDirectory;
                // Формирование полного пути к файлу RDLC
                return Path.Combine(exeFolder, "_reports", "OrgReport.rdlc");
            }
        }
    }
}