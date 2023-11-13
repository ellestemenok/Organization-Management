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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizationRequisitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nomenclatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contractorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measureUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кассаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кассаСегодняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналыДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналРасходныхНакладныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseinvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.журналыДокументовToolStripMenuItem,
            this.toolStripMenuItem1,
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
            this.кассаСегодняToolStripMenuItem});
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
            this.кассаСегодняToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.кассаСегодняToolStripMenuItem.Text = "Касса сегодня";
            // 
            // журналыДокументовToolStripMenuItem
            // 
            this.журналыДокументовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.журналРасходныхНакладныхToolStripMenuItem,
            this.purchaseinvoicesToolStripMenuItem});
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
            // purchaseinvoicesToolStripMenuItem
            // 
            this.purchaseinvoicesToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.purchaseinvoicesToolStripMenuItem.Name = "purchaseinvoicesToolStripMenuItem";
            this.purchaseinvoicesToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.purchaseinvoicesToolStripMenuItem.Text = "Журнал приходных накладных";
            this.purchaseinvoicesToolStripMenuItem.Click += new System.EventHandler(this.purchaseinvoicesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(2);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 22);
            this.toolStripMenuItem1.Text = "Склад";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem5.Text = "Товар на складах";
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem журналыДокументовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналРасходныхНакладныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseinvoicesToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    }
}

