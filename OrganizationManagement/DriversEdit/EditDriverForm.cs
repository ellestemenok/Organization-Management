using DatabaseLibrary;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace OrganizationManagement.DriversEdit
{
    public partial class EditDriverForm : Form
    {
        private int driverID;
        private DataTable driversData;

        public EditDriverForm(DataTable driversData)
        {
            InitializeComponent();

            this.driversData = driversData;

            if (driversData.Rows.Count > 0)
            {
                DataDB.LoadDataIntoComboBox(routesBox, "SELECT \"RouteID\", \"Name\" FROM public.\"Route\" WHERE \"RouteID\" <> 1 ORDER BY \"RouteID\" ASC");
                driverID = Convert.ToInt32(driversData.Rows[0]["DriverID"]);
                nameField.Text = driversData.Rows[0]["Name"].ToString();
               
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            int? routeID = null; // Используем Nullable<int> для возможности присвоения null
            if (routesBox.SelectedItem != null)
            {
                routeID = ((KeyValuePair<int, string>)routesBox.SelectedItem).Key;

                // Подготовка запроса и параметров для сброса маршрута у других водителей
                string resetRouteQuery = "UPDATE public.\"Driver\" SET \"RouteID\" = NULL WHERE \"RouteID\" = @RouteID AND \"DriverID\" != @DriverID";
                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@RouteID", routeID),
                    new NpgsqlParameter("@DriverID", driverID)
                };

                // Сброс маршрута у других водителей
                DataDB.ExecuteQueryWithParams(resetRouteQuery, parameters);
            }

            // Обновляем информацию для текущего водителя
            Driver.Update(driverID, name, routeID.HasValue ? routeID.Value : (object)DBNull.Value); // Передаём DBNull.Value, если routeID == null
            Close();
        }
    }
}