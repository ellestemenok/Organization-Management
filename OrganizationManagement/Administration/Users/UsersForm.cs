using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement
{
    // Класс, представляющий форму управления пользователями
    public partial class UsersForm : Form
    {
        // Конструктор формы
        public UsersForm()
        {
            InitializeComponent();  // Инициализация компонентов формы
        }
        // Обработчик события загрузки формы
        private void UsersForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();  // Открытие соединения с базой данных
        }
        // Обработчик события активации формы
        private void UsersForm_Enter(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();  // Загрузка данных в DataGridView
        }
        // Метод загрузки данных в DataGridView
        public void LoadDataIntoDataGridView()
        {
            // SQL-запрос для получения данных о пользователях
            string query = "SELECT \"UserID\", CONCAT(\"FullName\", ' - ', \"Role\")  AS \"Имя пользователя\", \"isActive\" AS \"Активный\" FROM public.\"User\" ORDER BY \"UserID\" ASC;";
            DataDB.FillDataGridViewWithQueryResult(usersGrid, query);  // Заполнение DataGridView результатами запросе
            // Скрытие колонки с UserID и настройка ширины колонки "Активный"
            usersGrid.Columns["UserID"].Visible = false;
            usersGrid.Columns["Активный"].Width = 100;
        }
        // Обработчик события нажатия на кнопку "Добавить"
        private void addItem_Click(object sender, EventArgs e)
        {
            AddUserForm addForm = new AddUserForm();  // Создание формы для добавления пользователя
            addForm.MdiParent = ActiveForm;  // Установка родительской формы
            addForm.Show();  // Показ формы
        }
        // Обработчик события нажатия на кнопку "Удалить"
        private void delItem_Click(object sender, EventArgs e)
        {
            // Подтверждение удаления элемента
            DialogResult result = MessageBox.Show("Удалить элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Удаление выбранного пользователя
                DataGridViewRow selectedRow = usersGrid.SelectedRows[0];
                int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
                User.Delete(userID);  // Вызов метода удаления пользователя
                LoadDataIntoDataGridView();  // Обновление данных в DataGridView
            }
        }
        // Обработчик события нажатия на кнопку "Обновить"
        private void refreshGrid_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();  // Обновление данных в DataGridView
        }

        // Обработчик события нажатия на кнопку "Редактировать"
        private void editItem_Click(object sender, EventArgs e)
        {
            // Редактирование выбранного пользователя
            DataGridViewRow selectedRow = usersGrid.SelectedRows[0];
            int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            DataDB usersRepository = new DataDB();

            // SQL-запрос для получения данных о выбранном пользователе
            string query = $"SELECT * FROM public.\"User\" WHERE \"UserID\" = {userID}";
            DataTable usersData = usersRepository.FillFormWithQueryResult(query);

            // Создание и показ формы редактирования пользователя
            EditUserForm editForm = new EditUserForm(usersData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }

        // Обработчик события двойного щелчка по ячейке DataGridView
        private void editItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Редактирование выбранного пользователя
            DataGridViewRow selectedRow = usersGrid.SelectedRows[0];
            int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            DataDB usersRepository = new DataDB();

            // SQL-запрос для получения данных о выбранном пользователе
            string query = $"SELECT * FROM public.\"User\" WHERE \"UserID\" = {userID}";
            DataTable usersData = usersRepository.FillFormWithQueryResult(query);

            // Создание и показ формы редактирования пользователя
            EditUserForm editForm = new EditUserForm(usersData);
            editForm.MdiParent = ActiveForm;
            editForm.Show();
        }

        // Обработчик события изменения текста в TextBox
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Получаем текст из TextBox
            string searchText = toolStripTextBox1.Text.Trim();

            // Применяем фильтр к DataGridView
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dv = ((DataTable)usersGrid.DataSource).DefaultView;
                dv.RowFilter = string.Format("[Имя пользователя] LIKE '%{0}%'", searchText);
            }
            else
            {
                // Если текст в TextBox пуст, сбросить фильтр
                ((DataTable)usersGrid.DataSource).DefaultView.RowFilter = string.Empty;
            }
        }
    }
}
