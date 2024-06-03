using DatabaseLibrary;  // Подключение библиотеки для работы с базой данных
using System;
using System.Windows.Forms;

namespace OrganizationManagement.CashboxEdit
{
    // Класс, представляющий форму для добавления кассового отчета
    public partial class AddCashboxForm : Form
    {
        // Конструктор формы
        public AddCashboxForm()
        {
            InitializeComponent();  // Инициализация компонентов формы
        }
        // Обработчик события нажатия на кнопку "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение даты из элемента dateTimePicker
            DateTime date = dateTimePicker1.Value.Date;
            // Формирование названия кассового отчета
            string name = "Кассовый отчет за " + date.ToShortDateString();
            // Проверка, существует ли уже кассовый отчет за эту дату
            if (Cashbox.Exists(date))
            {
                // Показ сообщения об ошибке, если отчет уже существует
                MessageBox.Show("Кассовый отчет за эту дату уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Вставка нового кассового отчета в базу данных
                Cashbox.Insert(name, date);
                // Закрытие текущей формы
                Close();
                // Получение идентификатора нового кассового отчета
                int cashboxID = Convert.ToInt32(DataDB.ExecuteScalarQuery($"SELECT \"CashboxID\" FROM public.\"Cashbox\" WHERE \"CashboxDate\" = '{date}'"));
                // Создание и показ формы для редактирования кассового отчета
                CashboxEditForm editForm = new CashboxEditForm(cashboxID);
                editForm.MdiParent = ActiveForm;  // Установка родительской формы
                editForm.Show();  // Показ формы
            }
        }
        // Обработчик события загрузки формы
        private void AddCashboxForm_Load(object sender, EventArgs e)
        {
            // Открытие соединения с базой данных
            Autorization.OpenConnection();
        }
    }
}
