using DatabaseLibrary;
using System;
using OrganizationManagement.PKOnRKOEdit;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    // Класс формы для работы с платежами по расходным накладным, унаследованный от Form
    public partial class PaymentsForExpForm : Form
    {
        int invoiceID;// Поле для хранения идентификатора накладной
        // Конструктор формы PaymentsForExpForm
        public PaymentsForExpForm(int expInvID)
        {
            InitializeComponent(); // Инициализация компонентов формы
            invoiceID = expInvID; // Инициализация поля invoiceID
            Text += invoiceID.ToString(); // Добавление идентификатора накладной в заголовок формы
        }
        // Обработчик события загрузки формы
        private void PaymentsForExpForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection(); // Открытие соединения с базой данных
        }
        // Обработчик события входа в форму
        private void PaymentsForExpForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView(); // Загрузка данных в DataGridView
        }
        // Метод для загрузки данных в DataGridView
        public void LoadDataIntoDataGridView()
        {
            string query = "SELECT \"PkoID\", " +
                "\"PkoDate\" AS \"Дата\", " +
                "\"Sum\" AS \"Сумма\", " +
                $"\"Name\" AS \"Примечание\" FROM public.\"PKO\" WHERE \"ExpInvID\" = {invoiceID}";
            DataDB.FillDataGridViewWithQueryResult(paymentsGrid, query); // Заполнение DataGridView результатом запроса
            paymentsGrid.Columns["PkoID"].Visible = false; // Скрытие столбца PkoID
        }
        // Обработчик события клика по кнопке добавления элемента
        private void addItem_Click(object sender, EventArgs e)
        {
            AddPKOForm addForm = new AddPKOForm(invoiceID); // Создание формы для добавления ПКО
            addForm.MdiParent = ActiveForm; // Установка родительской формы
            addForm.Show(); // Отображение формы
        }
        // Обработчик события клика по кнопке удаления элемента
        private void delItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = paymentsGrid.SelectedRows[0];
            int pkoID = Convert.ToInt32(selectedRow.Cells["PkoID"].Value);

            // Подтверждение удаления от пользователя
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранное ПКО и связанные платежи?", "Удаление ПКО", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Удаление записи из таблицы Payment
                string deletePaymentQuery = $"DELETE FROM public.\"Payment\"\r\n" +
                    $"WHERE \"Name\" IN (SELECT \"Name\" FROM public.\"PKO\");";
                DataDB.ExecuteQuery(deletePaymentQuery);
                Log.Insert(mainMDIForm.userID, "Удален Приходный кассовый ордер №" + pkoID.ToString());
                // Удаление записи из таблицы PKO
                string deletePKOQuery = $"DELETE FROM public.\"PKO\" WHERE \"PkoID\" = {pkoID}";
                DataDB.ExecuteQuery(deletePKOQuery);
                // Обновление данных в DataGridView
                LoadDataIntoDataGridView();
                
            }
        }
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView(); // Обновление данных в DataGridView
        }
        // Обработчик события клика по кнопке редактирования элемента
        private void editItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = paymentsGrid.SelectedRows[0];
            int pkoID = Convert.ToInt32(selectedRow.Cells["PkoID"].Value);
            DataDB pkoRepository = new DataDB();
            // Запрос для получения данных ПКО
            string query = $"SELECT p.\"PkoID\", p.\"PkoDate\" AS \"Дата\", p.\"PkoNum\" AS \"Номер\", " +
               $"p.\"ExpInvID\" AS \"Инвойс\", p.\"ContractorID\", c.\"Name\" AS \"Контрагент\", " +
               $"p.\"OrgID\", o.\"Name\" AS \"Организация\", p.\"Sum\" AS \"Сумма\", p.\"Name\" AS \"Основание\" " +
               $"FROM public.\"PKO\" p " +
               $"LEFT JOIN public.\"Organization\" o ON p.\"OrgID\" = o.\"OrganizationID\" " +
               $"LEFT JOIN public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\" " +
               $"WHERE p.\"PkoID\" = {pkoID}";
            DataTable pkoData = pkoRepository.FillFormWithQueryResult(query);
            // Создание формы для редактирования ПКО
            EditPKOForm editForm = new EditPKOForm(pkoData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }
        // Обработчик события двойного клика по ячейке DataGridView
        private void paymentsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = paymentsGrid.SelectedRows[0];
            int pkoID = Convert.ToInt32(selectedRow.Cells["PkoID"].Value);
            DataDB pkoRepository = new DataDB();
            // Запрос для получения данных ПКО
            string query = $"SELECT p.\"PkoID\", p.\"PkoDate\" AS \"Дата\", p.\"PkoNum\" AS \"Номер\", " +
               $"p.\"ExpInvID\" AS \"Инвойс\", p.\"ContractorID\", c.\"Name\" AS \"Контрагент\", " +
               $"p.\"OrgID\", o.\"Name\" AS \"Организация\", p.\"Sum\" AS \"Сумма\", p.\"Name\" AS \"Основание\" " +
               $"FROM public.\"PKO\" p " +
               $"LEFT JOIN public.\"Organization\" o ON p.\"OrgID\" = o.\"OrganizationID\" " +
               $"LEFT JOIN public.\"Contractor\" c ON p.\"ContractorID\" = c.\"ContractorID\" " +
               $"WHERE p.\"PkoID\" = {pkoID}";
            DataTable pkoData = pkoRepository.FillFormWithQueryResult(query);
            // Создание формы для редактирования ПКО
            EditPKOForm editForm = new EditPKOForm(pkoData);
            editForm.MdiParent = ActiveForm;// Установка родительской формы
            editForm.Show();// Отображение формы
        }
        // Обработчик события изменения текста в TextBox
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = toolStripTextBox1.Text.Trim();
            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)paymentsGrid.DataSource).DefaultView;

                // Создаем фильтр для всех интересующих нас столбцов
                dv.RowFilter = string.Format(
                    "CONVERT(Дата, 'System.String')  LIKE '%{0}%' OR " +
                    "CONVERT(Сумма, 'System.String')  LIKE '%{0}%' OR " +
                    "[Примечание] LIKE '%{0}%'",
                    searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)paymentsGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
