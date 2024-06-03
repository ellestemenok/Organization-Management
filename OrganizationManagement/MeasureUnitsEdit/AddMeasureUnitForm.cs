using DatabaseLibrary;
using System;
using System.Windows.Forms;
namespace OrganizationManagement.MeasureUnitsEdit
{
    public partial class AddMeasureUnitForm : Form // Объявление класса формы добавления единиц измерения
    {
        public AddMeasureUnitForm()
        {
            InitializeComponent(); // Инициализация компонентов формы
            // Привязка обработчика события нажатия клавиши к полю ввода для ограничения ввода только числовых значений
            okeiField.KeyPress += KeyPressEvent.textBox_KeyPressNumber;
        }
        // Обработчик события нажатия кнопки "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            string name = nameField.Text;
            string okeiID = okeiField.Text;
            string fullname = fullnameField.Text;
            bool fractional = fractionalCheckBox.Checked;
            // Вставка новой записи об единице измерения в базу данных
            MeasureUnit.Insert(Convert.ToInt32(okeiID), name, fullname, fractional);
            // Закрытие формы после сохранения
            Close();
        }
    }
}