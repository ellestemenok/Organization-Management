using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.StoragesEdit
{
    public partial class EditStorageForm : Form // Объявление класса формы редактирования склада, наследующего класс Form.
    {
        private int storageID;
        public EditStorageForm(DataTable storagesData) // Конструктор класса формы, принимающий таблицу данных о складах.
        {
            InitializeComponent(); // Инициализация компонентов формы.

            if (storagesData.Rows.Count > 0) // Проверка наличия данных в таблице складов.
            {
                storageID = Convert.ToInt32(storagesData.Rows[0]["StorageID"]); // Получение идентификатора склада.
                nameField.Text = storagesData.Rows[0]["Name"].ToString(); // Заполнение поля имени склада.
                mainCheckBox.Checked = Convert.ToBoolean(storagesData.Rows[0]["isMain"]); // Установка значения флажка "Главный склад".
                freeCheckBox.Checked = Convert.ToBoolean(storagesData.Rows[0]["isFree"]); // Установка значения флажка "Свободный склад".
            }
        }
        private void saveButton_Click(object sender, EventArgs e) // Обработчик события нажатия кнопки "Сохранить".
        {
            string name = nameField.Text; // Получение текста из поля ввода имени склада.
            bool isMain = mainCheckBox.Checked; // Получение значения флажка "Главный склад".
            bool isFree = freeCheckBox.Checked; // Получение значения флажка "Свободный склад".

            Storage.Update(storageID, name, isMain, isFree); // Обновление данных о складе в базе данных.
            Log.Insert(mainMDIForm.userID, "Отредактирован склад " + name); // Вставка записи в журнал о редактировании склада.

            Close(); // Закрытие формы редактирования склада после сохранения.
        }
    }
}