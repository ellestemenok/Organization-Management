using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace OrganizationManagement.CashboxEdit
{
    // Класс, представляющий форму для добавления платежа
    public partial class AddPaymentForm : Form
    {
        private int cashboxID;  // Поле для хранения идентификатора кассового отчета
        // Конструктор формы, принимающий идентификатор кассового отчета
        public AddPaymentForm(int cashID)
        {
            InitializeComponent();  // Инициализация компонентов формы
            Autorization.OpenConnection();  // Открытие соединения с базой данных
            cashboxID = cashID;  // Сохранение идентификатора кассового отчета
            // Добавление обработчика события нажатия клавиш для поля ввода суммы
            sumBox.KeyPress += KeyPressEvent.textBox_KeyPressMoney;
            // Загрузка данных в выпадающий список контрагентов
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            // Установка первого элемента как выбранного
            contractorBox.Text = ((KeyValuePair<int, string>)contractorBox.Items[0]).Value;
            typeBox.Text = typeBox.Items[0].ToString();
        }
        // Обработчик события нажатия на кнопку "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение значения из элементов формы
            DateTime time = dateTimePicker.Value;
            string type = typeBox.Text;
            double sum = Convert.ToDouble(sumBox.Text);
            int? contractorID = null;
            // Проверка, выбран ли элемент в выпадающем списке контрагентов
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;  // Получение идентификатора контрагента
            }
            // Получение имени из текстового поля
            string name = nameField.Text;
            // Добавление платежа в базу данных
            Cashbox.AddPayment(time, type, sum, contractorID, name, cashboxID, mainMDIForm.userID);
            // Закрытие текущей формы
            Close();
        }
    }
}
