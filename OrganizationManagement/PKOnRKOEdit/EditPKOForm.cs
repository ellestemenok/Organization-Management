﻿using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace OrganizationManagement.PKOnRKOEdit
{
    public partial class EditPKOForm : Form // Объявление класса формы редактирования ПКО
    {
        private int pkoID; // Поле для хранения ID ПКО
        // Конструктор класса, принимающий данные о ПКО в виде таблицы данных
        public EditPKOForm(DataTable pkoData)
        {
            InitializeComponent(); // Инициализация компонентов формы
            sumBox.KeyPress += KeyPressEvent.textBox_KeyPressMoney; // Привязка обработчика события нажатия клавиш для поля суммы
            DataDB.LoadDataIntoComboBox(contractorBox, "SELECT \"ContractorID\", \"Name\" FROM public.\"Contractor\" ORDER BY \"ContractorID\" ASC");
            DataDB.LoadDataIntoComboBox(orgBox, "SELECT \"OrganizationID\", \"Name\" FROM public.\"Organization\" WHERE \"OrganizationID\" = 1");
            DataDB.LoadDataIntoComboBox(invBox, "SELECT \"InvoiceID\", CAST(\"InvoiceNumber\" AS VARCHAR) AS \"InvoiceNumber\" FROM public.\"ExpenditureInvoice\" ORDER BY \"InvoiceID\" ASC");
            // Если есть данные о ПКО
            if (pkoData.Rows.Count > 0)
            {
                DataRow row = pkoData.Rows[0];
                pkoID = Convert.ToInt32(row["PkoID"]);
                dateTimePicker.Value = Convert.ToDateTime(row["Дата"]);
                numField.Text = row["Номер"].ToString();
                invBox.Text = row["Инвойс"].ToString();
                orgBox.Text = row["Организация"].ToString();
                contractorBox.Text = row["Контрагент"].ToString();
                sumBox.Text = row["Сумма"].ToString();
                nameField.Text = row["Основание"].ToString();
            }
        }
        // Обработчик события нажатия кнопки "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker.Value; // Получение значения даты
            int contractorID = 0; // Инициализация ID контрагента
            int number = Convert.ToInt32(numField.Text); // Получение значения номера
            int invoiceID = 0; // Инициализация ID инвойса
            if (invBox.SelectedItem != null)
            {
                var invItem = (KeyValuePair<int, string>)invBox.SelectedItem;
                invoiceID = invItem.Key;
            }
            double sum = Convert.ToDouble(sumBox.Text);
            if (contractorBox.SelectedItem != null)
            {
                var contractorItem = (KeyValuePair<int, string>)contractorBox.SelectedItem;
                contractorID = contractorItem.Key;
            }
            string name = nameField.Text; // Получение значения основания
            PKO.Update(pkoID, date, number, contractorID, invoiceID, sum, name);
            UpdatePaymentRecord(pkoID, date, "Приходный кассовый ордер №" + number, contractorID, sum);
            Log.Insert(mainMDIForm.userID, "Отредактирован Приходный кассовый ордер №" + number.ToString());
            Close(); // Закрытие формы после сохранения
        }
        // Метод для обновления записи в таблице Payment
        private void UpdatePaymentRecord(int pkoID, DateTime date, string name, int contractorID, double sum)
        {
            // Находим ID записи Payment, связанной с данным ПКО
            string findPaymentQuery = $"SELECT \"PaymentID\" FROM public.\"Payment\" WHERE \"Name\" IN (SELECT \"Name\" FROM public.\"PKO\" WHERE \"PkoID\"={pkoID});";
            object paymentID = DataDB.ExecuteScalarQuery(findPaymentQuery);
            if (paymentID != null)
            {
                // Обновляем запись в таблице Payment
                string updatePaymentQuery = $"UPDATE public.\"Payment\" SET " +
                    $"\"Name\" = '{name}', " +
                    $"\"ContractorID\" = {contractorID}, " +
                    $"\"Sum\" = {sum.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                    $"\"Time\" = '{date.TimeOfDay}' " +
                    $"WHERE \"PaymentID\" = {paymentID}";
                DataDB.ExecuteQuery(updatePaymentQuery);
            }
            else
            {
                // Здесь можете добавить логику на случай, если связанная запись в Payment отсутствует
                MessageBox.Show("Связанная запись платежа не найдена. Обновление не выполнено.", "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Обработчик события загрузки формы
        private void EditPKOForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }
    }
}
