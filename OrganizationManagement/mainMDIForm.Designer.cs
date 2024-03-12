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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.водителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналыДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenditureInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseinvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.storagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storageStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStripMain.Font = new System.Drawing.Font("Verdana", 8F);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.журналыДокументовToolStripMenuItem,
            this.toolStripMenuItem1,
            this.окнаToolStripMenuItem});
            this.menuStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(879, 31);
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
            this.measureUnitsToolStripMenuItem,
            this.toolStripSeparator1,
            this.водителиToolStripMenuItem,
            this.routesToolStripMenuItem});
            this.справочникиToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.справочникиToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.справочникиToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3);
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 21);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // organizationRequisitesToolStripMenuItem
            // 
            this.organizationRequisitesToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.organizationRequisitesToolStripMenuItem.Image = global::OrganizationManagement.Properties.Resources.storeIcon;
            this.organizationRequisitesToolStripMenuItem.Name = "organizationRequisitesToolStripMenuItem";
            this.organizationRequisitesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.organizationRequisitesToolStripMenuItem.Text = "Реквизиты организации";
            this.organizationRequisitesToolStripMenuItem.Click += new System.EventHandler(this.organizationRequisitesToolStripMenuItem_Click);
            // 
            // nomenclatureToolStripMenuItem
            // 
            this.nomenclatureToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenclatureToolStripMenuItem.Name = "nomenclatureToolStripMenuItem";
            this.nomenclatureToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.nomenclatureToolStripMenuItem.Text = "Номенклатура";
            this.nomenclatureToolStripMenuItem.Click += new System.EventHandler(this.nomenclatureToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // contractorsToolStripMenuItem
            // 
            this.contractorsToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contractorsToolStripMenuItem.Image = global::OrganizationManagement.Properties.Resources.contractorsIcon;
            this.contractorsToolStripMenuItem.Name = "contractorsToolStripMenuItem";
            this.contractorsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.contractorsToolStripMenuItem.Text = "Контрагенты";
            this.contractorsToolStripMenuItem.Click += new System.EventHandler(this.contractorsToolStripMenuItem_Click);
            // 
            // measureUnitsToolStripMenuItem
            // 
            this.measureUnitsToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.measureUnitsToolStripMenuItem.Name = "measureUnitsToolStripMenuItem";
            this.measureUnitsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.measureUnitsToolStripMenuItem.Text = "Единицы измерения";
            this.measureUnitsToolStripMenuItem.Click += new System.EventHandler(this.measureUnitsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // водителиToolStripMenuItem
            // 
            this.водителиToolStripMenuItem.Name = "водителиToolStripMenuItem";
            this.водителиToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.водителиToolStripMenuItem.Text = "Водители";
            // 
            // routesToolStripMenuItem
            // 
            this.routesToolStripMenuItem.Name = "routesToolStripMenuItem";
            this.routesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.routesToolStripMenuItem.Text = "Маршруты";
            this.routesToolStripMenuItem.Click += new System.EventHandler(this.routesToolStripMenuItem_Click);
            // 
            // журналыДокументовToolStripMenuItem
            // 
            this.журналыДокументовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expenditureInvoicesToolStripMenuItem,
            this.purchaseinvoicesToolStripMenuItem});
            this.журналыДокументовToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.журналыДокументовToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.журналыДокументовToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3);
            this.журналыДокументовToolStripMenuItem.Name = "журналыДокументовToolStripMenuItem";
            this.журналыДокументовToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.журналыДокументовToolStripMenuItem.Size = new System.Drawing.Size(143, 21);
            this.журналыДокументовToolStripMenuItem.Text = "Журналы документов";
            // 
            // expenditureInvoicesToolStripMenuItem
            // 
            this.expenditureInvoicesToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expenditureInvoicesToolStripMenuItem.Name = "expenditureInvoicesToolStripMenuItem";
            this.expenditureInvoicesToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.expenditureInvoicesToolStripMenuItem.Text = "Журнал расходных накладных";
            this.expenditureInvoicesToolStripMenuItem.Click += new System.EventHandler(this.expenditureInvoicesToolStripMenuItem_Click);
            // 
            // purchaseinvoicesToolStripMenuItem
            // 
            this.purchaseinvoicesToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.purchaseinvoicesToolStripMenuItem.Name = "purchaseinvoicesToolStripMenuItem";
            this.purchaseinvoicesToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.purchaseinvoicesToolStripMenuItem.Text = "Журнал приходных накладных";
            this.purchaseinvoicesToolStripMenuItem.Click += new System.EventHandler(this.purchaseinvoicesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storagesToolStripMenuItem,
            this.storageStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(2);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 21);
            this.toolStripMenuItem1.Text = "Склад";
            // 
            // storagesToolStripMenuItem
            // 
            this.storagesToolStripMenuItem.Name = "storagesToolStripMenuItem";
            this.storagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.storagesToolStripMenuItem.Text = "Склады";
            this.storagesToolStripMenuItem.Click += new System.EventHandler(this.storagesToolStripMenuItem_Click);
            // 
            // storageStripMenuItem
            // 
            this.storageStripMenuItem.Font = new System.Drawing.Font("Verdana", 8F);
            this.storageStripMenuItem.Name = "storageStripMenuItem";
            this.storageStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.storageStripMenuItem.Text = "Товар на складах";
            this.storageStripMenuItem.Click += new System.EventHandler(this.storageStripMenuItem_Click);
            // 
            // окнаToolStripMenuItem
            // 
            this.окнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.minimizeallToolStripMenuItem,
            this.toolStripSeparator3,
            this.closeToolStripMenuItem});
            this.окнаToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.окнаToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.окнаToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3);
            this.окнаToolStripMenuItem.Name = "окнаToolStripMenuItem";
            this.окнаToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.окнаToolStripMenuItem.Size = new System.Drawing.Size(45, 21);
            this.окнаToolStripMenuItem.Text = "Окна";
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8F);
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.verticalToolStripMenuItem.Text = "Черепицей";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8F);
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.cascadeToolStripMenuItem.Text = "Каскадом";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // minimizeallToolStripMenuItem
            // 
            this.minimizeallToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8F);
            this.minimizeallToolStripMenuItem.Name = "minimizeallToolStripMenuItem";
            this.minimizeallToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.minimizeallToolStripMenuItem.Text = "Свернуть все";
            this.minimizeallToolStripMenuItem.Click += new System.EventHandler(this.minimizeallToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8F);
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.closeToolStripMenuItem.Text = "Закрыть";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.BackColor = System.Drawing.Color.White;
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usernameStripStatusLabel,
            this.toolStripDateTime});
            this.statusStripMain.Location = new System.Drawing.Point(0, 516);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStripMain.Size = new System.Drawing.Size(879, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // usernameStripStatusLabel
            // 
            this.usernameStripStatusLabel.Font = new System.Drawing.Font("Verdana", 8F);
            this.usernameStripStatusLabel.Name = "usernameStripStatusLabel";
            this.usernameStripStatusLabel.Size = new System.Drawing.Size(64, 17);
            this.usernameStripStatusLabel.Text = "username";
            // 
            // toolStripDateTime
            // 
            this.toolStripDateTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripDateTime.Font = new System.Drawing.Font("Verdana", 8F);
            this.toolStripDateTime.ForeColor = System.Drawing.Color.Black;
            this.toolStripDateTime.Name = "toolStripDateTime";
            this.toolStripDateTime.Size = new System.Drawing.Size(802, 17);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(879, 538);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem журналыДокументовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenditureInvoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseinvoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeallToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDateTime;
        private System.Windows.Forms.Timer timerForDatetime;
        private System.Windows.Forms.ToolStripStatusLabel usernameStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem storageStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem водителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem routesToolStripMenuItem;
    }
}

