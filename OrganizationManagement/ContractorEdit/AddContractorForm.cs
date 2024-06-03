using Dadata;
using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
namespace OrganizationManagement.ContractorEdit
{
    public partial class AddContractorForm : Form
    {
        public AddContractorForm()
        {
            InitializeComponent();
            typeBox.Text = typeBox.Items[0].ToString(); // тайбокс = ип, ооо и т.д.
            DataDB.LoadDataIntoComboBox(groupBox, "SELECT \"CategoryID\", \"Name\" " + // загрузка в групбокс категорий контрагентов (покупатель, продавец)
                "FROM public.\"ContractorCategory\" " +
                "ORDER BY \"CategoryID\" ASC");
            groupBox.Text = ((KeyValuePair<int, string>)groupBox.Items[0]).Value; // отображение вариантов в боксе

            DataDB.LoadDataIntoComboBox(routeBox, "SELECT \"RouteID\", \"Name\" " + // загрузка в групбокс маршрутов
                "FROM public.\"Route\" " +
                "ORDER BY \"RouteID\" ASC");
            routeBox.Text = ((KeyValuePair<int, string>)routeBox.Items[0]).Value; // отображение маршрутов в боксе
        }
        // Обработчик события нажатия на кнопку "Сохранить"
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получение значений из элементов формы
            string type = typeBox.Text;
            string name = nameField.Text;
            string fullname = fullnameField.Text;
            int groupID = 0;
            if (groupBox.SelectedItem != null)
            {
                var groupItem = (KeyValuePair<int, string>)groupBox.SelectedItem;
                groupID = groupItem.Key;
            }
            // Получение значений из текстовых полей
            string telephone = telephoneField.Text;
            string email = emailField.Text;
            string inn = innField.Text;
            string kpp = kppField.Text;
            string okpo = okpoField.Text;
            string oktmo = oktmoField.Text;
            string ogrn = ogrnField.Text;
            string paymentacc = paymentField.Text;
            string bank = bankField.Text;
            string bik = bikField.Text;
            string corr = corrField.Text;
            string postadrr = postAddrField.Text;
            string legaladdr = legaladdrField.Text;
            string consaddr = consaddrField.Text;
            string director = directorField.Text;
            string accountant = genaccountantField.Text;
            string manager = managerField.Text;
            string reason = reasonField.Text;
            string description = descriptionField.Text;
            int routeID = 0;
            if (routeBox.SelectedItem != null)
            {
                var routeItem = (KeyValuePair<int, string>)routeBox.SelectedItem;
                routeID = routeItem.Key;
            }
            // Вставка данных в таблицу контрагентов
            Contractor.Insert(type, name, fullname, telephone, email, inn, kpp, okpo, oktmo, ogrn,
                paymentacc, bank, bik, corr, postadrr, legaladdr, consaddr, director, accountant,
                reason, groupID, manager, description, routeID);
            // Логирование добавления контрагента
            Log.Insert(mainMDIForm.userID, "Добавлен контрагент " + name);
            Close();
        }
        // Обработчик события нажатия на кнопку для получения данных из API
        private async void api_btn_Click(object sender, EventArgs e)
        {
            var token = ConfigurationManager.AppSettings["ApiToken"];
            var api = new SuggestClientAsync(token);

            try
            {
                var result = await api.FindParty(innField.Text);
                if (result.suggestions.Count > 0)
                {
                    var data = result.suggestions[0].data;
                    string type = data.type.ToString();

                    // Установка категории в typeBox в зависимости от типа
                    if (type == "LEGAL")
                    {
                        // Установка значений для юридического лица
                        kppField.Text = data.kpp;
                        directorField.Text = data.management.name;
                        typeBox.SelectedIndex = typeBox.FindStringExact("Организация");
                    }
                    else
                    {
                        // Установка значений для индивидуального предпринимателя
                        directorField.Text = $"{data.fio.surname} {data.fio.name} {data.fio.patronymic}";
                        typeBox.SelectedIndex = typeBox.FindStringExact("Индивидуальный предприниматель");
                    }

                    nameField.Text = data.name.short_with_opf;
                    fullnameField.Text = data.name.full_with_opf;
                    okpoField.Text = data.okpo;
                    ogrnField.Text = data.ogrn;
                    oktmoField.Text = data.oktmo;
                    postAddrField.Text = data.address.value;
                    legaladdrField.Text = data.address.value;
                }
                else
                {
                    MessageBox.Show("Компания не найдена.");
                }
            }
            catch
            {
                MessageBox.Show("Нет соединения с базой предпринимателей.");
            }
            
        }
        // Обработчик события нажатия на ссылку для генерации грузополучателя
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            consaddrField.Text = nameField.Text + "; " + legaladdrField.Text;
        }
    }
}
