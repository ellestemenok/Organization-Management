using DatabaseLibrary;
using System;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }
        private void UsersForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
            dateTimePicker1.Value = DateTime.Now;
        }
        private void UsersForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT \"LogID\", \"LogDate\" AS \"Дата и время\", \"LogText\" AS \"Действие\", u.\"FullName\" AS \"Пользователь\"\r\n" +
                "FROM public.\"Log\" l\r\nLEFT JOIN public.\"User\" u ON u.\"UserID\" = l.\"UserID\";";
            DataDB.FillDataGridViewWithQueryResult(logGrid, query);
            logGrid.Columns["LogID"].Visible = false;
        }
        
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Форматируем выбранную дату для соответствия формату даты в SQL
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // Обновляем SQL-запрос, чтобы отфильтровать логи по выбранной дате
            string query = $"SELECT \"LogID\", \"LogDate\" AS \"Дата и время\", \"LogText\" AS \"Действие\", u.\"FullName\" AS \"Пользователь\"\r\n" +
                           $"FROM public.\"Log\" l\r\nLEFT JOIN public.\"User\" u ON u.\"UserID\" = l.\"UserID\"\r\n" +
                           $"WHERE CAST(l.\"LogDate\" AS DATE) = '{selectedDate}';";

            // Загружаем данные с учетом фильтра в DataGridView
            DataDB.FillDataGridViewWithQueryResult(logGrid, query);
            logGrid.Columns["LogID"].Visible = false;
        }
    }
}
