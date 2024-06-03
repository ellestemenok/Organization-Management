using DatabaseLibrary;
using OrganizationManagement._dataTables;
using System;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.RoutesEdit
{
    public partial class EditRouteForm : Form
    {
        private int routeID; // Переменная для хранения идентификатора маршрута.
        private DateTime date;
        private DataTable contractorsData; // Таблица с данными о контрагентах.
        private DataTable routesData; // Таблица с данными о маршрутах.
        // Конструктор класса, инициализирующий компоненты формы и принимающий таблицы с данными о маршрутах и контрагентах.
        public EditRouteForm(DataTable routesData, DataTable contractorsData)
        {
            InitializeComponent();
            this.routesData = routesData; // Сохранение таблицы с данными о маршрутах.
            this.contractorsData = contractorsData; // Сохранение таблицы с данными о контрагентах.
            dateTimePicker1.Value = DateTime.Now;
            if (routesData.Rows.Count > 0)
            {
                routeID = Convert.ToInt32(routesData.Rows[0]["RouteID"]);
                nameField.Text = routesData.Rows[0]["Name"].ToString();
            }
        }
        private void EditRouteForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        // Метод для загрузки данных о контрагентах в таблицу DataGridView.
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
            routeAdrsGrid.Columns["BelongsToRoute"].Width =120;
            routeAdrsGrid.Columns["ContractorName"].Width = 300;
        }
        // Обработчик события нажатия кнопки "Сохранить".
        private void saveButton_Click(object sender, EventArgs e)
        {
            string newName ="";
            // Сохраняем измененное название маршрута
            if (routesData.Rows.Count > 0)
            {
                newName = nameField.Text.Trim();
                routesData.Rows[0]["Name"] = newName;
                Route.UpdateRouteName(routeID, newName); // метод реализован для обновления названия маршрута
            }
            // Сохраняем изменения в маршрутах контрагентов
            foreach (DataRow contractor in contractorsData.Rows)
            {
                Contractor.UpdateContractorRoute(contractor["Name"].ToString(), contractor["RouteID"]);
            }
            MessageBox.Show("Изменения сохранены.");
            Log.Insert(mainMDIForm.userID, "Отредактирован маршрут " + newName);
            Close(); // Закрываем форму после сохранения изменений
        }
        // Обработчик события клика по ячейке в таблице DataGridView.
        private void routeAdrsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == routeAdrsGrid.Columns["BelongsToRoute"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)routeAdrsGrid.Rows[e.RowIndex].Cells["BelongsToRoute"];
                bool isChecked = !(bool)checkBox.Value; // Предполагаемое новое значение

                string contractorName = routeAdrsGrid.Rows[e.RowIndex].Cells["ContractorName"].Value.ToString();
                // Обновление значения RouteID для выбранного контрагента.
                foreach (DataRow contractor in contractorsData.Rows)
                {
                    if (contractor["Name"].ToString() == contractorName)
                    {
                        if (isChecked)
                        {
                            contractor["RouteID"] = routeID;
                        }
                        else
                        {
                            // Проверяем, не установлен ли уже RouteID равным 1
                            if (Convert.ToInt32(contractor["RouteID"]) == 1)
                            {
                                checkBox.Value = true; // Оставляем галочку, если RouteID уже 1
                            }
                            else
                            {
                                contractor["RouteID"] = 1; // Устанавливаем RouteID равным 1
                            }
                        }
                        break;
                    }
                }
                LoadDataIntoDataGridView();
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            IReportDataProvider provider = new RouteSheetReportDataProvider(routeID, date);
            ReportViewForm viewForm = new ReportViewForm(provider);
            viewForm.MdiParent = ActiveForm;
            viewForm.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.Date;
        }
    }
}