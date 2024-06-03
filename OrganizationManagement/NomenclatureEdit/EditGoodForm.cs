using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.NomenclatureEdit
{
    public partial class EditGoodForm : Form // Объявление класса формы редактирования товара
    {
        private int goodID; // Поле для хранения ID товара
        // Конструктор класса, принимающий таблицу данных о товаре
        public EditGoodForm(DataTable goodsData)
        {
            InitializeComponent(); // Инициализация компонентов формы
            // Загрузка данных в комбо-боксы для выбора категории товара и единицы измерения
            DataDB.LoadDataIntoComboBox(groupBox, "SELECT \"CategoryID\", \"Name\" FROM public.\"GoodCategory\" ORDER BY \"CategoryID\" ASC");
            DataDB.LoadDataIntoComboBox(measureunitBox, "SELECT \"UnitID\", \"Name\" FROM public.\"MeasureUnit\" ORDER BY \"UnitID\" ASC");
            // Привязка обработчиков событий для ограничения ввода в определенных полях
            netcostField.KeyPress += KeyPressEvent.textBox_KeyPressMoney;
            vatField.KeyPress += KeyPressEvent.textBox_KeyPressPercent;
            trademarginField.KeyPress += KeyPressEvent.textBox_KeyPressPercent;
            // Заполнение полей формы данными из таблицы, если таковые есть
            if (goodsData.Rows.Count > 0)
            {
                goodID = Convert.ToInt32(goodsData.Rows[0]["GoodID"]);
                nameField.Text = goodsData.Rows[0]["Name"].ToString();
                articleField.Text = goodsData.Rows[0]["ArticleNumber"].ToString();

                groupBox.Text = goodsData.Rows[0]["CategoryName"].ToString();
                measureunitBox.Text = goodsData.Rows[0]["UnitName"].ToString();

                archivecheckBox.Checked = Convert.ToBoolean(goodsData.Rows[0]["InArchive"]);
                netcostField.Text = goodsData.Rows[0]["NetCost"].ToString();
                vatField.Text = goodsData.Rows[0]["VAT"].ToString();
                costWoVatField.Text = goodsData.Rows[0]["TradePrice"].ToString();
                tradepriceField.Text = goodsData.Rows[0]["TradePrice"].ToString();
                trademarginField.Text = goodsData.Rows[0]["TradeMargin"].ToString();
                descriptionField.Text = goodsData.Rows[0]["Description"].ToString();
            }
        }
        // Обработчик события нажатия кнопки "Сохранить"
        private void goodSave_Click(object sender, EventArgs e)
        {
            string name = nameField.Text; // Получение данных из полей формы
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
            // Получение данных о чекбоксе "В архиве"
            bool archivecheck = archivecheckBox.Checked;
            double netcost = Convert.ToDouble(netcostField.Text);
            double vat = Convert.ToDouble(vatField.Text);
            double costwovat = Convert.ToDouble(costWoVatField.Text);
            double tradeprice = Convert.ToDouble(tradepriceField.Text);
            double trademargin = Convert.ToDouble(trademarginField.Text);
            string description = descriptionField.Text;
            // Обновление данных о товаре в базе данных
            Good.Update(goodID, name, article, measureunitID, groupID, archivecheck, netcost, vat, costwovat, tradeprice, trademargin, description);
            Log.Insert(mainMDIForm.userID, "Отредактирован товар " + name);
            Close();
        }
        // Обработчик события покидания поля "Себестоимость"
        private void netcostField_Leave(object sender, EventArgs e)
        {
            // Получение и конвертация данных из поля "Себестоимость"
            double netcost = Convert.ToDouble(netcostField.Text);
            // Получение и конвертация данных из поля "НДС"
            double vat = Convert.ToDouble(vatField.Text) * 0.01;
            double trademargin = Convert.ToDouble(trademarginField.Text) * 0.01;
            // Получение и конвертация данных из поля "Торговая наценка"
            costWoVatField.Text = Math.Round(netcost - netcost * vat, 2).ToString();
            tradepriceField.Text = Math.Round(netcost + netcost * trademargin, 2).ToString();
        }
        // Обработчик события покидания поля "НДС"
        private void vatField_Leave(object sender, EventArgs e)
        {
            double netcost = Convert.ToDouble(netcostField.Text);
            double vat = Convert.ToDouble(vatField.Text) * 0.01;
            // Вычисление и заполнение поля "Себестоимость без НДС"
            double costWoVat = Math.Round(netcost - netcost * vat, 2);
            costWoVatField.Text = costWoVat.ToString();
        }
        // Обработчик события покидания поля "Торговая наценка"
        private void trademarginField_Leave(object sender, EventArgs e)
        {
            // Получение и конвертация данных из поля "Себестоимость"
            double netcost = Convert.ToDouble(netcostField.Text);
            double trademargin = Convert.ToDouble(trademarginField.Text) * 0.01;
            // Вычисление и заполнение поля "Цена продажи"
            double tradeprice = Math.Round(netcost + netcost * trademargin, 2);
            tradepriceField.Text = tradeprice.ToString();
        }

    }
}
