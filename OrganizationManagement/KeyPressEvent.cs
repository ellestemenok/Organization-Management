using System;
using System.Linq;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public class KeyPressEvent
    {
        //ввод чисел в формате [рубли,копейки (2 знака после запятой)]
        public static void textBox_KeyPressMoney(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или запятой
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; // Отменяем ввод, если символ не является цифрой или запятой
            }

            // Проверяем, что введена только одна запятая
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(','))
            {
                e.Handled = true;
            }

            // Проверяем, что после запятой не более двух цифр
            if ((sender as TextBox).Text.Contains(','))
            {
                string[] parts = (sender as TextBox).Text.Split(',');
                if (parts.Length > 1 && parts[1].Length >= 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        //ввод процентов (от 0 до 100)
        public static void textBox_KeyPressPercent(object sender, KeyPressEventArgs e)
        {
            // Проверка, является ли введенный символ цифрой, Backspace или Delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отклонить ввод, если это не цифра, Backspace или Delete
            }

            // Если введенный символ - цифра
            if (char.IsDigit(e.KeyChar))
            {
                string newText = (sender as TextBox).Text + e.KeyChar;
                int value;
                if (!int.TryParse(newText, out value) || value < 0 || value > 100)
                {
                    e.Handled = true; // Отклонить ввод, если число не в пределах от 0 до 100
                }
            }
        }
        //ввод только цифр
        public static void textBox_KeyPressNumber(object sender, KeyPressEventArgs e)
        {
            // Проверка, является ли введенный символ цифрой, Backspace или Delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отклонить ввод, если это не цифра, Backspace или Delete
            }
        }
    }
}
