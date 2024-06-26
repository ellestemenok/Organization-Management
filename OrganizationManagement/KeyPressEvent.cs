﻿using System;
using System.Linq;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public class KeyPressEvent
    {
        //ввод чисел в формате [ (-)рубли,копейки (2 знака после запятой)]
        public static void textBox_KeyPressMoney(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Проверяем, является ли введенный символ цифрой, запятой или минусом
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '-')
            {
                e.Handled = true; // Отменяем ввод, если символ не соответствует условиям
            }

            // Разрешаем ввод минуса только если он в начале и если текстбокс уже не содержит минус
            if (e.KeyChar == '-' && (textBox.Text.Length != 0 || textBox.Text.Contains("-")))
            {
                e.Handled = true;
            }

            // Проверяем, что введена только одна запятая
            if (e.KeyChar == ',' && textBox.Text.Contains(','))
            {
                e.Handled = true;
            }

            // Проверяем, что после запятой не более двух цифр
            if (textBox.Text.Contains(','))
            {
                string[] parts = textBox.Text.Split(',');
                if (parts.Length > 1 && parts[1].Length >= 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        //ввод чисел в формате [ *,??? (3 знака после запятой)]
        public static void textBox_KeyPressMeasureUnit(object sender, KeyPressEventArgs e)
        {

            TextBox textBox = sender as TextBox;
            // Разрешаем ввод только цифр, запятой и управляющих символов (например, Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Отклоняем символ
            }
            else if (e.KeyChar == ',')
            {
                // Разрешаем ввод запятой только если она еще не введена и не в начале строки
                if (textBox.Text.Contains(",") || textBox.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if (char.IsDigit(e.KeyChar))
            {
                // Проверяем, введены ли цифры после запятой
                if (textBox.Text.Contains(","))
                {
                    int commaIndex = textBox.Text.IndexOf(',');
                    int cursorPosition = textBox.SelectionStart;  // Позиция курсора

                    // Если курсор находится после запятой и уже введено три цифры, предотвращаем ввод
                    if (cursorPosition > commaIndex && textBox.Text.Substring(commaIndex + 1).Length >= 3)
                    {
                        e.Handled = true;
                    }
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
