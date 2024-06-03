using System;
using System.Windows.Forms;
using DatabaseLibrary;
using OrganizationManagement.CashboxEdit;
using OrganizationManagement.PKOnRKOEdit;

namespace OrganizationManagement
{
    public partial class mainMDIForm : Form
    {
        public static int userID; // статическая переменная для хранения id пользователя
        public static string userRole; // статическая переменная для хранения роли пользователя
        // Метод для установки Id пользователя
        public static void SetUserID(int id) {  userID = id; }
        // Метод для установки роли пользователя
        public static void SetUserRole(string role) { userRole = role; }

        public mainMDIForm()
        {
            InitializeComponent(); //инициализация компонента
            usernameStripStatusLabel.Text = Autorization.fullName;
            // Проверка роли пользователя и установка видимости пункта меню
            adminStripMenuItem.Visible = userRole == "Администратор"; // меню админа видно, только если у юзера роль = Администратор
            timerForDatetime.Start();
            toolStripDateTime.Text = DateTime.Now.ToLongDateString() + " " +
            DateTime.Now.ToLongTimeString();
            Log.Insert(userID, "Вход в систему");
        }
        //запуск таймера
        private void timerForDatetime_Tick(object sender, EventArgs e)
        {
            toolStripDateTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }
        //открытие окна реквизитов организации
        private void organizationRequisitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrganizationRequisitesForm newMDIChild = new OrganizationRequisitesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //действия при закрытии окна
        private void MainMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите завершить работу?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Log.Insert(userID, "Выход из системы");
                Autorization.CloseConnection(); //закрытие соединения с БД
                Dispose();
                Application.Exit();
            }
            else { e.Cancel = true; }
        }
        //открытие окна единиц измерения
        private void measureUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeasureUnitsForm newMDIChild = new MeasureUnitsForm();
            newMDIChild.MdiParent= this;
            newMDIChild.Show();
        }
        //открытие окна номенклатуры
        private void nomenclatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NomenclatureForm newMDIChild = new NomenclatureForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна контрагентов
        private void contractorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContractorsForm newMDIChild = new ContractorsForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна приходных накладных
        private void purchaseinvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseInvoicesForm newMDIChild = new PurchaseInvoicesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна расходных накладных
        private void expenditureInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenditureInvoicesForm newMDIChild = new ExpenditureInvoicesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //отображение окон черепицей
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        //отображение окон каскадом
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        //закрытие дочернего окна
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }
        }
        //свернуть все  дочерние окна
        private void minimizeallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.WindowState = FormWindowState.Minimized;
            }
        }
        //открытие товаров на складах
        private void storageStripMenuItem_Click(object sender, EventArgs e)
        {
            StorageContentsForm newMDIChild = new StorageContentsForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна со складом
        private void storagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoragesForm newMDIChild = new StoragesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна с маршрутами
        private void routesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoutesForm newMDIChild = new RoutesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна с водителями
        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriversForm newMDIChild = new DriversForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна со счет-фактурами
        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoicesForm newMDIChild = new InvoicesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна с кассами
        private void cashboxJournalStripMenuItem3_Click(object sender, EventArgs e)
        {
            CashboxForm newMDIChild = new CashboxForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна с сегодняшней кассой
        private void cashboxTodayStripMenuItem_Click(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
            string query = $"SELECT \"CashboxID\" FROM public.\"Cashbox\" WHERE \"CashboxDate\" = '{DateTime.Today:yyyy-MM-dd}'";
            object result = DataDB.ExecuteScalarQuery(query);

            //если касса есть, то она открывается
            if (result != null && int.TryParse(result.ToString(), out int cashID))
            {
                CashboxEditForm newMDIChild = new CashboxEditForm(cashID);
                newMDIChild.MdiParent = this;
                newMDIChild.Show();
            }
            else //если кассы нет, то надо ее создать
            {
                var userChoice = MessageBox.Show("Кассы не существует. Создать?", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (userChoice == DialogResult.Yes)
                {
                    AddCashboxForm newMDIChild = new AddCashboxForm();
                    newMDIChild.MdiParent = this;
                    newMDIChild.Show();
                }
            }
        }
        //открытие окна с пко
        private void pkoJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PKOForm newMDIChild = new PKOForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна с рко
        private void rkoJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RKOForm newMDIChild = new RKOForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна с создание пко
        private void pkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPKOForm newMDIChild = new AddPKOForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна с созданием рко
        private void rkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRKOForm newMDIChild = new AddRKOForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна с пользователями
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm newMDIChild = new UsersForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
        //открытие окна журнала действий
        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogForm newMDIChild = new LogForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
    }
}
