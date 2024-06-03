using DatabaseLibrary;
using System;
using System.Windows.Forms;
namespace OrganizationManagement.StoragesEdit
{
    public partial class AddStorageForm : Form // Объявление класса формы добавления склада, наследующего класс Form.
    {
        public AddStorageForm() // Определение конструктора класса формы.
        {
            InitializeComponent(); // Инициализация компонентов формы.
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameField.Text; // Получение текста из поля ввода имени склада.
            bool isMain = mainCheckBox.Checked; // Получение значения флажка "Главный склад".
            bool isFree = freeCheckBox.Checked; // Получение значения флажка "Свободный склад".
            Storage.Insert(name, isMain, isFree); // Вставка нового склада в базу данных.
            Log.Insert(mainMDIForm.userID, "Создан склад " + name); // Вставка записи в журнал о создании нового склада.
            Close(); // Закрытие формы добавления склада после сохранения.
        }
    }
}
