using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OrganizationManagement.PurchaseInvoicesEdit
{
    public partial class AddGoodinExpenditureInvoiceForm : Form
    { 
        private int invoiceID;// Идентификатор расходной накладной
        // Конструктор формы добавления товара в расходную накладную
        public AddGoodinExpenditureInvoiceForm(int id)
        {
            InitializeComponent();
            invoiceID = id;
            // Загрузка данных в комбо-бокс
            DataDB.LoadDataIntoComboBox(goodBox, "SELECT \"GoodID\", " +
                "\"Name\" FROM public.\"Good\" " +
                "ORDER BY \"Name\" ASC");
            // Установка значения по умолчанию в комбо-боксе и добавление обработчика события нажатия клавиши
            goodBox.Text = ((KeyValuePair<int, string>)goodBox.Items[0]).Value;
            quantField.KeyPress += KeyPressEvent.textBox_KeyPressMeasureUnit;
        }
        // Обработчик клика по кнопке сохранения
        private void saveButton_Click(object sender, EventArgs e)
        {
            int selectedgoodID = ((KeyValuePair<int, string>)goodBox.SelectedItem).Key;
            double quantity = 0;
            if (quantField.Text != "")
            {
                quantity = Convert.ToDouble(quantField.Text);
            }
            // Добавление товара в расходную накладную и закрытие формы
            ExpenditureInvoice.AddProductToInvoice(invoiceID, selectedgoodID, quantity);
            Close();
        }
        // Обработчик изменения выбранного товара
        private void goodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedgoodID = ((KeyValuePair<int, string>)goodBox.SelectedItem).Key;
            DataDB goodsRepository = new DataDB();
            DataTable goodData = goodsRepository.FillFormWithQueryResult("SELECT u.\"Name\", u.\"Fractional\", " +
                "\"TradePrice\" \r\nFROM public.\"Good\" as g\r\n" +
                "JOIN public.\"MeasureUnit\" AS u ON g.\"MeasureUnitID\" = u.\"UnitID\"\r\n" +
                $"WHERE \"GoodID\" = {selectedgoodID}");
            if (goodData != null && goodData.Rows.Count > 0)
            {
                // Заполнение полей значениями из базы данных
                unitsField.Text = goodData.Rows[0]["Name"].ToString();
                priceField.Text = goodData.Rows[0]["TradePrice"].ToString();

                // Установка обработчика в зависимости от делимости единицы измерения
                if (Convert.ToBoolean(goodData.Rows[0]["Fractional"]))
                {
                    quantField.KeyPress -= KeyPressEvent.textBox_KeyPressNumber; // Удалить обработчик для чисел, если он был добавлен
                    quantField.KeyPress += KeyPressEvent.textBox_KeyPressMeasureUnit; // Добавить обработчик для делимых единиц измерения
                }
                else
                {
                    quantField.KeyPress -= KeyPressEvent.textBox_KeyPressMeasureUnit; // Удалить обработчик для делимых единиц, если он был добавлен
                    quantField.KeyPress += KeyPressEvent.textBox_KeyPressNumber; // Добавить обработчик для неделимых единиц измерения
                }
            }
        }
        // Метод для вычисления суммы товара
        private void CalculateSum()
        {
            if (double.TryParse(quantField.Text, out double quantity) && double.TryParse(priceField.Text, out double price))
            {
                sumField.Text = (quantity * price).ToString();
            }
            else
            {
                sumField.Text = string.Empty;
            }
        }
        // Обработчик изменения текста поля количества
        private void quantField_TextChanged(object sender, EventArgs e)
        {
            CalculateSum();
        }
    }
}
