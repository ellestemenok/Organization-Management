using DatabaseLibrary; // Импорт библиотеки для работы с базой данных
using System;
using System.Windows.Forms;

namespace OrganizationManagement // Объявление пространства имен для управления организацией
{
    public partial class AddAccountForm : Form // Объявление класса формы добавления счета
    {
        // Конструктор класса
        public AddAccountForm()
        {
            InitializeComponent(); // Инициализация компонентов формы
        }

        // Обработчик события нажатия кнопки "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            string name = nameField.Text;
            string accountNumber = numberField.Text;
            string bankName = bankField.Text;
            string corrAccount = corrField.Text;
            string bik = bikField.Text;

            // Вставка нового счета в базу данных
            Requisites.InsertPaymentAccount(name, accountNumber, bankName, corrAccount, bik);

            // Журналирование действия
            Log.Insert(mainMDIForm.userID, "Создан р/c " + accountNumber);

            // Закрытие формы после сохранения
            Close();
        }
    }
}
