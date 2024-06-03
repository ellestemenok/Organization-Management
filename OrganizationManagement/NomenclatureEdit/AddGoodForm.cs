using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace OrganizationManagement.NomenclatureEdit
{
    public partial class AddGoodForm : Form// Объявление класса формы добавления товара
    {
        // Конструктор класса
        public AddGoodForm()
        {
            InitializeComponent();// Инициализация компонентов формы
            DataDB.LoadDataIntoComboBox(groupBox, "SELECT \"CategoryID\", \"Name\" FROM public.\"GoodCategory\" ORDER BY \"CategoryID\" ASC");
            DataDB.LoadDataIntoComboBox(measureunitBox, "SELECT \"UnitID\", \"Name\" FROM public.\"MeasureUnit\" ORDER BY \"UnitID\" ASC");
            // Установка значения по умолчанию в комбо-боксах
            groupBox.Text = ((KeyValuePair<int, string>)groupBox.Items[0]).Value;
            measureunitBox.Text = ((KeyValuePair<int, string>)measureunitBox.Items[0]).Value;
            // Привязка обработчиков событий для ограничения ввода в определенных полях
            netcostField.KeyPress += KeyPressEvent.textBox_KeyPressMoney;
            vatField.KeyPress += KeyPressEvent.textBox_KeyPressPercent;
            trademarginField.KeyPress += KeyPressEvent.textBox_KeyPressPercent;
        }
        // Обработчик события нажатия кнопки "Сохранить"
        private void goodSave_Click(object sender, EventArgs e)
        {
            // Получение данных из полей формы
            string name = nameField.Text;
            string article = articleField.Text;
            int measureunitID = 0;
            int groupID = 0;
            // Получение ID выбранной единицы измерения
            if (measureunitBox.SelectedItem != null)
            {
                var measureunitItem = (KeyValuePair<int, string>)measureunitBox.SelectedItem;
                measureunitID = measureunitItem.Key;
            }
            // Получение ID выбранной категории товара
            if (groupBox.SelectedItem != null)
            {
                var groupItem = (KeyValuePair<int, string>)groupBox.SelectedItem;
                groupID = groupItem.Key;
            }
            // Получение данных о чекбоксе "Архив"
            bool archivecheck = archivecheckBox.Checked;
            // Получение числовых значений из полей и их конвертация
            double netcost = Convert.ToDouble(netcostField.Text);
            double vat = Convert.ToDouble(vatField.Text);
            double costwovat = Convert.ToDouble(costWoVatField.Text);
            double tradeprice = Convert.ToDouble(tradepriceField.Text);
            double trademargin = Convert.ToDouble(trademarginField.Text);
            string description = descriptionField.Text;
            // Вставка новой записи о товаре в базу данных
            Good.Insert(name, article, measureunitID, groupID, archivecheck, netcost, vat, 
                costwovat, tradeprice, trademargin,  description);
            Log.Insert(mainMDIForm.userID, "Создан товар " + name);
            Close();
        }
        // Обработчик события покидания поля "Себестоимость"
        private void netcostField_Leave(object sender, EventArgs e)
        {
            double netcost = Convert.ToDouble(netcostField.Text);

            double vat = Convert.ToDouble(vatField.Text) * 0.01;
            double trademargin = Convert.ToDouble(trademarginField.Text) * 0.01;

            costWoVatField.Text = Math.Round(netcost - netcost * vat, 2).ToString();
            tradepriceField.Text = Math.Round(netcost + netcost * trademargin, 2).ToString();
        }
        // Обработчик события покидания поля "НДС"
        private void vatField_Leave(object sender, EventArgs e)
        {
            double netcost = Convert.ToDouble(netcostField.Text);
            double vat = Convert.ToDouble(vatField.Text) * 0.01;

            double costWoVat = Math.Round(netcost - netcost * vat, 2);

            costWoVatField.Text = costWoVat.ToString();
        }
        // Обработчик события покидания поля "Торговая наценка"
        private void trademarginField_Leave(object sender, EventArgs e)
        {
            double netcost = Convert.ToDouble(netcostField.Text);
            double trademargin = Convert.ToDouble(trademarginField.Text) * 0.01;

            double tradeprice = Math.Round(netcost + netcost * trademargin, 2);

            tradepriceField.Text = tradeprice.ToString();
        }
    }
}
