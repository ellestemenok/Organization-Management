using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.RoutesEdit
{
    public partial class EditRouteForm : Form
    {
        private int routeID;
        private DataTable contractorsData;
        private DataTable routesData;
        public EditRouteForm(DataTable routesData, DataTable contractorsData)
        {

            InitializeComponent();
            this.routesData = routesData;
            this.contractorsData = contractorsData; // Сохраняем данные о контрагентах

            if (routesData.Rows.Count > 0)
            {
                routeID = Convert.ToInt32(routesData.Rows[0]["RouteID"]);
                nameField.Text = routesData.Rows[0]["Name"].ToString();
            }
      
            LoadDataIntoDataGridView();
            
        }
        public void LoadDataIntoDataGridView()
        {
            // Очищаем таблицу перед загрузкой новых данных
            routeAdrsGrid.Rows.Clear();
            routeAdrsGrid.Columns.Clear(); // Очищаем все столбцы

            // Создаем столбец с галочками
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Принадлежность к маршруту";
            checkBoxColumn.Name = "BelongsToRoute";
            routeAdrsGrid.Columns.Add(checkBoxColumn);

            // Добавляем колонки для имени контрагента и адреса грузополучателя
            routeAdrsGrid.Columns.Add("ContractorName", "Контрагент");
            routeAdrsGrid.Columns.Add("ConsigneeAddress", "Грузополучатель");

            // Загружаем данные о контрагентах в таблицу
            foreach (DataRow contractor in contractorsData.Rows)
            {
                // Проверяем наличие столбца RouteID в таблице контрагентов
                if (contractor.Table.Columns.Contains("RouteID"))
                {
                    // Добавляем новую строку в таблицу с данными контрагента
                    int rowIndex = routeAdrsGrid.Rows.Add(false, contractor["Name"], contractor["ConsigneeAddress"]);

                    // Проверяем, принадлежит ли контрагент к данному маршруту (по RouteID)
                    if (Convert.ToInt32(contractor["RouteID"]) == routeID)
                    {
                        routeAdrsGrid.Rows[rowIndex].Cells["BelongsToRoute"].Value = true;
                    }
                }
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {

            // Route.Update(....);
            // Close();
        }

        private void routeAdrsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что изменение произошло в колонке с чекбоксами
            if (e.ColumnIndex == routeAdrsGrid.Columns["BelongsToRoute"].Index && e.RowIndex >= 0)
            {
                // Получаем новое состояние чекбокса
                bool isChecked = Convert.ToBoolean(routeAdrsGrid.Rows[e.RowIndex].Cells["BelongsToRoute"].Value);

                // Получаем информацию о контрагенте
                string contractorName = routeAdrsGrid.Rows[e.RowIndex].Cells["ContractorName"].Value.ToString();

                // Обновляем данные о маршрутах контрагента в зависимости от состояния чекбокса
                foreach (DataRow contractor in contractorsData.Rows)
                {
                    if (contractor["Name"].ToString() == contractorName)
                    {
                        contractor["RouteID"] = isChecked ? routeID : DBNull.Value;
                        break;
                    }
                }

                // Обновляем данные в DataGridView
                LoadDataIntoDataGridView();
            }
        }
    }
}
