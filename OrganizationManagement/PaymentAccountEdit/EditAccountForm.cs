using DatabaseLibrary; // Импорт библиотеки для работы с базой данных
using System;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement.AccountEdit // Объявление пространства имен для формы редактирования счета
{
    public partial class EditAccountForm : Form // Объявление класса формы редактирования счета
    {
        private int accountID; // Поле для хранения ID счета
        // Конструктор класса, принимающий таблицу данных о счете
        public EditAccountForm(DataTable accountData)
        {
            InitializeComponent(); // Инициализация компонентов формы
            // Заполнение полей формы данными из таблицы, если таковые есть
            if (accountData.Rows.Count > 0)
            {
                accountID = Convert.ToInt32(accountData.Rows[0]["AccountID"]); // Получение ID счета из таблицы
                nameField.Text = accountData.Rows[0]["Name"].ToString(); // Заполнение поля "Название"
                numberField.Text = accountData.Rows[0]["AccountNumber"].ToString(); // Заполнение поля "Номер счета"
                bankField.Text = accountData.Rows[0]["BankName"].ToString(); // Заполнение поля "Наименование банка"
                corrField.Text = accountData.Rows[0]["СorrAccount"].ToString(); // Заполнение поля "Корреспондентский счет"
                bikField.Text = accountData.Rows[0]["BIK"].ToString(); // Заполнение поля "БИК"
            }
        }
        // Обработчик события нажатия кнопки "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            string name = nameField.Text;
            string accountNumber = numberField.Text;
            string bankname = bankField.Text;
            string corrAccount = corrField.Text;
            string bik = bikField.Text;
            // Обновление данных о счете в базе данных
            Requisites.UpdatePaymentAccount(accountID, name, accountNumber, bankname, corrAccount, bik);
            // Журналирование действия
            Log.Insert(mainMDIForm.userID, "Отредактирован р/c " + accountNumber);
            // Закрытие формы после сохранения
            Close();
        }
    }
}
