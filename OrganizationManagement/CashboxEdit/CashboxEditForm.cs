using DatabaseLibrary;
using System;
using System.Windows.Forms;

namespace OrganizationManagement.CashboxEdit
{
    public partial class CashboxEditForm : Form
    {
        private int cashboxID;
        public CashboxEditForm(int cashID)
        {
            InitializeComponent(); //инициализация компонента
            cashboxID = cashID;
            Autorization.OpenConnection(); //открытие соединения
        }
        private void CashboxEdit_Load(object sender, EventArgs e) // загрузка окна
        {
            label1.Text = DataDB.ExecuteScalarQuery($"SELECT \"Name\" FROM public.\"Cashbox\" WHERE \"CashboxID\"={cashboxID}");
        }
        private void LoadDataIntoDataGridView()
        {
            //отображение данных в таблице
            string query = "SELECT \r\n    " +
                "p.\"PaymentID\"," +
                "p.\"Name\" AS \"Описание платежа\",\r\n    " +
                "p.\"Type\" AS \"Тип\",\r\n    " +
                "p.\"Sum\" AS \"Сумма\",\r\n    " +
                "c.\"Name\" AS \"Контрагент\", " +
                "u.\"FullName\" AS \"Пользователь\" \r\n    " +
                "FROM \r\n    public.\"Payment\" p\r\n" +
                "LEFT JOIN \r\n    public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\"\r\n" +
                "LEFT JOIN \r\n    public.\"User\" u ON p.\"CreatedBy\" = u.\"UserID\"\r\n" +
                $"WHERE \r\n    p.\"CashboxID\" = {cashboxID};\r\n";
            DataDB.FillDataGridViewWithQueryResult(specGrid, query);
            specGrid.Columns["PaymentID"].Visible = false;
        }
        private void CashboxEdit_Enter(object sender, EventArgs e) //вход в кассу
        {
            LoadDataIntoDataGridView();
            label5.Text = DataDB.ExecuteScalarQuery($"SELECT ABS(COALESCE(SUM(\"Sum\"), 0)) \r\nFROM public.\"Payment\"\r\nWHERE \"CashboxID\" = {cashboxID} AND \"Sum\" < 0;");
            label6.Text = DataDB.ExecuteScalarQuery($"SELECT COALESCE(SUM(\"Sum\"), 0) \r\nFROM public.\"Payment\"\r\nWHERE \"CashboxID\" = {cashboxID} AND \"Sum\" > 0;");
            label7.Text = DataDB.ExecuteScalarQuery($"SELECT \"TotalAmount\" FROM public.\"Cashbox\" WHERE \"CashboxID\" ={cashboxID};");
        }
        private void refreshGrid_Click(object sender, EventArgs e) //обновление таблицы
        {
            LoadDataIntoDataGridView();
        }
        //добавление платежа
        private void addItem_Click(object sender, EventArgs e)
        {
            AddPaymentForm addForm = new AddPaymentForm(cashboxID);
            addForm.MdiParent = ActiveForm;
            addForm.Show();
        }
    }
}
