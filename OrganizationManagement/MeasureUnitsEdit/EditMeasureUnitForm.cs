using DatabaseLibrary;
using System;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.MeasureUnitsEdit
{
    public partial class EditMeasureUnitForm : Form // Объявление класса формы редактирования единицы измерения
    {
        private int unitID; // Поле для хранения ID единицы измерения
        // Конструктор класса, принимающий таблицу данных о единице измерения
        public EditMeasureUnitForm(DataTable measureunitsData)
        {
            InitializeComponent();// Инициализация компонентов формы
            okeiField.KeyPress += KeyPressEvent.textBox_KeyPressNumber;
            // Заполнение полей формы данными из таблицы, если таковые есть
            if (measureunitsData.Rows.Count > 0)
            {
                unitID = Convert.ToInt32(measureunitsData.Rows[0]["UnitID"]);
                okeiField.Text = measureunitsData.Rows[0]["okeiID"].ToString();
                nameField.Text = measureunitsData.Rows[0]["Name"].ToString();
                fullnameField.Text = measureunitsData.Rows[0]["FullName"].ToString();
                fractionalCheckBox.Checked = Convert.ToBoolean(measureunitsData.Rows[0]["Fractional"]);
            }
        }
        // Обработчик события нажатия кнопки "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            string name = nameField.Text;
            string okeiID = okeiField.Text;
            string fullname = fullnameField.Text;
            bool fractional = fractionalCheckBox.Checked;
            // Обновление данных об единице измерения в базе данных
            MeasureUnit.Update(unitID, Convert.ToInt32(okeiID), name, fullname, fractional);
            // Закрытие формы после сохранения
            Close();
        }
    }
}
