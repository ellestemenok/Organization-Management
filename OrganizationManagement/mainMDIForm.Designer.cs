namespace OrganizationManagement
{
    partial class MainMDI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMDI));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizationRequisitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nomenclatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contractorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measureUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кассаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кассаСегодняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кассовыйОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйЗаказПокупателяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйЗаказПоставщикуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.журналЗаказовПокупателейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналЗаказовПоставщикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приходнаяНакладнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расходнаяНакладнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналыДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналРасходныхНакладныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналПриходныхНакладныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.черепицейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.usernameStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerForDatetime = new System.Windows.Forms.Timer(this.components);
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.White;
            this.menuStripMain.Font = new System.Drawing.Font("Verdana", 9F);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.кассаToolStripMenuItem,
            this.заказыToolStripMenuItem,
            this.документыToolStripMenuItem,
            this.журналыДокументовToolStripMenuItem,
            this.окнаToolStripMenuItem});
            this.menuStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1005, 32);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.organizationRequisitesToolStripMenuItem,
            this.nomenclatureToolStripMenuItem,
            this.toolStripSeparator2,
            this.contractorsToolStripMenuItem,
            this.measureUnitsToolStripMenuItem});
            this.справочникиToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.справочникиToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.справочникиToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3);
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // organizationRequisitesToolStripMenuItem
            // 
            this.organizationRequisitesToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.organizationRequisitesToolStripMenuItem.Image = global::OrganizationManagement.Properties.Resources.storeIcon;
            this.organizationRequisitesToolStripMenuItem.Name = "organizationRequisitesToolStripMenuItem";
            this.organizationRequisitesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.organizationRequisitesToolStripMenuItem.Text = "Реквизиты организации";
            this.organizationRequisitesToolStripMenuItem.Click += new System.EventHandler(this.organizationRequisitesToolStripMenuItem_Click);
            // 
            // nomenclatureToolStripMenuItem
            // 
            this.nomenclatureToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenclatureToolStripMenuItem.Name = "nomenclatureToolStripMenuItem";
            this.nomenclatureToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.nomenclatureToolStripMenuItem.Text = "Номенклатура";
            this.nomenclatureToolStripMenuItem.Click += new System.EventHandler(this.nomenclatureToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(228, 6);
            // 
            // contractorsToolStripMenuItem
            // 
            this.contractorsToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contractorsToolStripMenuItem.Image = global::OrganizationManagement.Properties.Resources.contractorsIcon;
            this.contractorsToolStripMenuItem.Name = "contractorsToolStripMenuItem";
            this.contractorsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.contractorsToolStripMenuItem.Text = "Контрагенты";
            this.contractorsToolStripMenuItem.Click += new System.EventHandler(this.contractorsToolStripMenuItem_Click);
            // 
            // measureUnitsToolStripMenuItem
            // 
            this.measureUnitsToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.measureUnitsToolStripMenuItem.Name = "measureUnitsToolStripMenuItem";
            this.measureUnitsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.measureUnitsToolStripMenuItem.Text = "Единицы измерения";
            this.measureUnitsToolStripMenuItem.Click += new System.EventHandler(this.measureUnitsToolStripMenuItem_Click);
            // 
            // кассаToolStripMenuItem
            // 
            this.кассаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кассаСегодняToolStripMenuItem,
            this.кассовыйОтчетToolStripMenuItem});
            this.кассаToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.кассаToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.кассаToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3);
            this.кассаToolStripMenuItem.Name = "кассаToolStripMenuItem";
            this.кассаToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.кассаToolStripMenuItem.Size = new System.Drawing.Size(51, 22);
            this.кассаToolStripMenuItem.Text = "Касса";
            // 
            // кассаСегодняToolStripMenuItem
            // 
            this.кассаСегодняToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.кассаСегодняToolStripMenuItem.Image = global::OrganizationManagement.Properties.Resources.cashIcon;
            this.кассаСегодняToolStripMenuItem.Name = "кассаСегодняToolStripMenuItem";
            this.кассаСегодняToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.кассаСегодняToolStripMenuItem.Text = "Касса сегодня";
            // 
            // кассовыйОтчетToolStripMenuItem
            // 
            this.кассовыйОтчетToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.кассовыйОтчетToolStripMenuItem.Name = "кассовыйОтчетToolStripMenuItem";
            this.кассовыйОтчетToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.кассовыйОтчетToolStripMenuItem.Text = "Журнал кассовых отчетов";
            // 
            // заказыToolStripMenuItem
            // 
            this.заказыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйЗаказПокупателяToolStripMenuItem,
            this.новыйЗаказПоставщикуToolStripMenuItem,
            this.toolStripSeparator1,
            this.журналЗаказовПокупателейToolStripMenuItem,
            this.журналЗаказовПоставщикаToolStripMenuItem});
            this.заказыToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.заказыToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.заказыToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3);
            this.заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            this.заказыToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.заказыToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            this.заказыToolStripMenuItem.Text = "Заказы";
            // 
            // новыйЗаказПокупателяToolStripMenuItem
            // 
            this.новыйЗаказПокупателяToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.новыйЗаказПокупателяToolStripMenuItem.Name = "новыйЗаказПокупателяToolStripMenuItem";
            this.новыйЗаказПокупателяToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.новыйЗаказПокупателяToolStripMenuItem.Text = "Новый заказ покупателя";
            // 
            // новыйЗаказПоставщикуToolStripMenuItem
            // 
            this.новыйЗаказПоставщикуToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.новыйЗаказПоставщикуToolStripMenuItem.Name = "новыйЗаказПоставщикуToolStripMenuItem";
            this.новыйЗаказПоставщикуToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.новыйЗаказПоставщикуToolStripMenuItem.Text = "Новый заказ поставщику";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // журналЗаказовПокупателейToolStripMenuItem
            // 
            this.журналЗаказовПокупателейToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.журналЗаказовПокупателейToolStripMenuItem.Name = "журналЗаказовПокупателейToolStripMenuItem";
            this.журналЗаказовПокупателейToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.журналЗаказовПокупателейToolStripMenuItem.Text = "Журнал заказов покупателей";
            // 
            // журналЗаказовПоставщикаToolStripMenuItem
            // 
            this.журналЗаказовПоставщикаToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.журналЗаказовПоставщикаToolStripMenuItem.Name = "журналЗаказовПоставщикаToolStripMenuItem";
            this.журналЗаказовПоставщикаToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.журналЗаказовПоставщикаToolStripMenuItem.Text = "Журнал заказов поставщикам";
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приходнаяНакладнаяToolStripMenuItem,
            this.расходнаяНакладнаяToolStripMenuItem});
            this.документыToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.документыToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.документыToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3);
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // приходнаяНакладнаяToolStripMenuItem
            // 
            this.приходнаяНакладнаяToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.приходнаяНакладнаяToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("приходнаяНакладнаяToolStripMenuItem.Image")));
            this.приходнаяНакладнаяToolStripMenuItem.Name = "приходнаяНакладнаяToolStripMenuItem";
            this.приходнаяНакладнаяToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.приходнаяНакладнаяToolStripMenuItem.Text = "Приходная накладная";
            // 
            // расходнаяНакладнаяToolStripMenuItem
            // 
            this.расходнаяНакладнаяToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.расходнаяНакладнаяToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("расходнаяНакладнаяToolStripMenuItem.Image")));
            this.расходнаяНакладнаяToolStripMenuItem.Name = "расходнаяНакладнаяToolStripMenuItem";
            this.расходнаяНакладнаяToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.расходнаяНакладнаяToolStripMenuItem.Text = "Расходная накладная";
            // 
            // журналыДокументовToolStripMenuItem
            // 
            this.журналыДокументовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.журналРасходныхНакладныхToolStripMenuItem,
            this.журналПриходныхНакладныхToolStripMenuItem});
            this.журналыДокументовToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.журналыДокументовToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.журналыДокументовToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3);
            this.журналыДокументовToolStripMenuItem.Name = "журналыДокументовToolStripMenuItem";
            this.журналыДокументовToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.журналыДокументовToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.журналыДокументовToolStripMenuItem.Text = "Журналы документов";
            // 
            // журналРасходныхНакладныхToolStripMenuItem
            // 
            this.журналРасходныхНакладныхToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.журналРасходныхНакладныхToolStripMenuItem.Name = "журналРасходныхНакладныхToolStripMenuItem";
            this.журналРасходныхНакладныхToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.журналРасходныхНакладныхToolStripMenuItem.Text = "Журнал расходных накладных";
            // 
            // журналПриходныхНакладныхToolStripMenuItem
            // 
            this.журналПриходныхНакладныхToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.журналПриходныхНакладныхToolStripMenuItem.Name = "журналПриходныхНакладныхToolStripMenuItem";
            this.журналПриходныхНакладныхToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.журналПриходныхНакладныхToolStripMenuItem.Text = "Журнал приходных накладных";
            // 
            // окнаToolStripMenuItem
            // 
            this.окнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.черепицейToolStripMenuItem,
            this.каскадомToolStripMenuItem,
            this.свернутьВсеToolStripMenuItem,
            this.toolStripSeparator3,
            this.закрытьToolStripMenuItem});
            this.окнаToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.окнаToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.окнаToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3);
            this.окнаToolStripMenuItem.Name = "окнаToolStripMenuItem";
            this.окнаToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.окнаToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.окнаToolStripMenuItem.Text = "Окна";
            // 
            // черепицейToolStripMenuItem
            // 
            this.черепицейToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.черепицейToolStripMenuItem.Name = "черепицейToolStripMenuItem";
            this.черепицейToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.черепицейToolStripMenuItem.Text = "Черепицей";
            // 
            // каскадомToolStripMenuItem
            // 
            this.каскадомToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.каскадомToolStripMenuItem.Name = "каскадомToolStripMenuItem";
            this.каскадомToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.каскадомToolStripMenuItem.Text = "Каскадом";
            // 
            // свернутьВсеToolStripMenuItem
            // 
            this.свернутьВсеToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.свернутьВсеToolStripMenuItem.Name = "свернутьВсеToolStripMenuItem";
            this.свернутьВсеToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.свернутьВсеToolStripMenuItem.Text = "Свернуть все";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // statusStripMain
            // 
            this.statusStripMain.BackColor = System.Drawing.Color.White;
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usernameStripStatusLabel,
            this.toolStripDateTime});
            this.statusStripMain.Location = new System.Drawing.Point(0, 556);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1005, 23);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // usernameStripStatusLabel
            // 
            this.usernameStripStatusLabel.Font = new System.Drawing.Font("Verdana", 9F);
            this.usernameStripStatusLabel.Name = "usernameStripStatusLabel";
            this.usernameStripStatusLabel.Size = new System.Drawing.Size(70, 18);
            this.usernameStripStatusLabel.Text = "username";
            // 
            // toolStripDateTime
            // 
            this.toolStripDateTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripDateTime.Font = new System.Drawing.Font("Verdana", 9F);
            this.toolStripDateTime.ForeColor = System.Drawing.Color.Black;
            this.toolStripDateTime.Name = "toolStripDateTime";
            this.toolStripDateTime.Size = new System.Drawing.Size(920, 18);
            this.toolStripDateTime.Spring = true;
            this.toolStripDateTime.Text = "toolStripDateTime";
            this.toolStripDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerForDatetime
            // 
            this.timerForDatetime.Interval = 1000;
            this.timerForDatetime.Tick += new System.EventHandler(this.timerForDatetime_Tick);
            // 
            // MainMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1005, 579);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "MainMDI";
            this.Text = "Планерно-диспетчерский отдел";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMDI_FormClosing);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizationRequisitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nomenclatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measureUnitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кассаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кассаСегодняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кассовыйОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйЗаказПокупателяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйЗаказПоставщикуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналЗаказовПокупателейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналЗаказовПоставщикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приходнаяНакладнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расходнаяНакладнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналыДокументовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналРасходныхНакладныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналПриходныхНакладныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem черепицейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDateTime;
        private System.Windows.Forms.Timer timerForDatetime;
        private System.Windows.Forms.ToolStripStatusLabel usernameStripStatusLabel;
    }
}

