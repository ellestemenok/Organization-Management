using DatabaseLibrary;
using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;

namespace OrganizationManagement._dataTables
{
    public class RouteSheetDT
    {
        // Свойства для хранения информации о маршрутном листе
        public DateTime ShipmentDate { get; set; }
        public string DriverName { get; set; }
        public string RouteName { get; set; }
        public int InvoiceNumber { get; set; }
        public string ContractorName { get; set; }
        public string ContractorFullName { get; set; }
        public string ContractorTelephone { get; set; }
        public decimal TotalAmount { get; set; }

        // Метод для получения данных маршрутного листа по дате отгрузки
        public List<RouteSheetDT> GetRouteSheetData(int routeID, DateTime shipmentDate)
        {
            var routeSheetData = new List<RouteSheetDT>();

            // Создание и открытие соединения с базой данных
            using (var connection = new NpgsqlConnection(Autorization.connectionString))
            {
                connection.Open();

                // SQL-запрос для извлечения данных из нескольких таблиц
                string sql = @"
                    SELECT 
                        inv.""InvoiceDate"",
                        dr.""Name"" AS DriverName,
                        rt.""Name"" AS RouteName,
                        inv.""InvoiceNumber"",
                        cont.""Name"" AS ContractorName,
                        cont.""ConsigneeAddress"" AS ContractorFullName,
                        cont.""Telephone"" AS ContractorTelephone,
                        inv.""TotalAmount""
                    FROM 
                        public.""ExpenditureInvoice"" inv
                    JOIN 
                        public.""Contractor"" cont ON cont.""ContractorID"" = inv.""ContractorID""
                    JOIN 
                        public.""Route"" rt ON rt.""RouteID"" = cont.""RouteID""
                    JOIN 
                        public.""Driver"" dr ON dr.""RouteID"" = rt.""RouteID""
                    WHERE 
                        inv.""InvoiceDate"" = @ShipmentDate AND rt.""RouteID"" = @RouteID";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ShipmentDate", shipmentDate);
                    command.Parameters.AddWithValue("@RouteID", routeID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            routeSheetData.Add(new RouteSheetDT
                            {
                                ShipmentDate = reader.GetDateTime(0).Date,
                                DriverName = reader.GetString(1),
                                RouteName = reader.GetString(2),
                                InvoiceNumber = reader.GetInt32(3),
                                ContractorName = reader.GetString(4),
                                ContractorFullName = reader.GetString(5),
                                ContractorTelephone = reader.GetString(6),
                                TotalAmount = reader.GetDecimal(7)
                            });
                        }
                    }
                }
            }

            return routeSheetData; // Возвращение списка данных маршрутного листа
        }
    }

    public class RouteSheetReportDataProvider : IReportDataProvider
    {
        private readonly int _routeID;
        private readonly DateTime _shipmentDate;

        // Конструктор, принимающий дату отгрузки
        public RouteSheetReportDataProvider(int routeID, DateTime shipmentDate)
        {
            _shipmentDate = shipmentDate;
            _routeID = routeID;
        }

        // Метод для получения источника данных для отчета
        public ReportDataSource GetReportDataSource()
        {
            var data = new RouteSheetDT().GetRouteSheetData(_routeID, _shipmentDate);
            return new ReportDataSource("RouteSheetDT", data);
        }

        // Свойство для получения пути к файлу отчета
        public string ReportPath
        {
            get
            {
                // Получение пути к текущему исполняемому файлу приложения
                var exeFolder = AppDomain.CurrentDomain.BaseDirectory;
                // Формирование полного пути к файлу RDLC
                return Path.Combine(exeFolder, "_reports", "RouteSheetReport.rdlc");
            }
        }
    }
}
