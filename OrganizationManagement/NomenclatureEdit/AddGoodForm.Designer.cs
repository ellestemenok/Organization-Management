namespace OrganizationManagement.NomenclatureEdit
{
    partial class AddGoodForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.archivecheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.ComboBox();
            this.measureunitBox = new System.Windows.Forms.ComboBox();
            this.articleField = new System.Windows.Forms.TextBox();
            this.nameField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.costWoVatField = new System.Windows.Forms.TextBox();
            this.vatField = new System.Windows.Forms.TextBox();
            this.netcostField = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.retailmarginField = new System.Windows.Forms.TextBox();
            this.retailpriceField = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trademarginField = new System.Windows.Forms.TextBox();
            this.tradepriceField = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.descriptionField = new System.Windows.Forms.TextBox();
            this.goodSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 254);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.archivecheckBox);
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Controls.Add(this.measureunitBox);
            this.tabPage1.Controls.Add(this.articleField);
            this.tabPage1.Controls.Add(this.nameField);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(536, 227);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Общие свойства";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // archivecheckBox
            // 
            this.archivecheckBox.AutoSize = true;
            this.archivecheckBox.Location = new System.Drawing.Point(19, 185);
            this.archivecheckBox.Name = "archivecheckBox";
            this.archivecheckBox.Size = new System.Drawing.Size(93, 18);
            this.archivecheckBox.TabIndex = 24;
            this.archivecheckBox.Text = "Архивный ";
            this.archivecheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupBox.FormattingEnabled = true;
            this.groupBox.Items.AddRange(new object[] {
            "Индивидуальный предприниматель",
            "Организация"});
            this.groupBox.Location = new System.Drawing.Point(98, 125);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(402, 22);
            this.groupBox.TabIndex = 23;
            // 
            // measureunitBox
            // 
            this.measureunitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.measureunitBox.FormattingEnabled = true;
            this.measureunitBox.Location = new System.Drawing.Point(362, 94);
            this.measureunitBox.Name = "measureunitBox";
            this.measureunitBox.Size = new System.Drawing.Size(138, 22);
            this.measureunitBox.TabIndex = 23;
            // 
            // articleField
            // 
            this.articleField.Location = new System.Drawing.Point(98, 94);
            this.articleField.Name = "articleField";
            this.articleField.Size = new System.Drawing.Size(100, 22);
            this.articleField.TabIndex = 22;
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(145, 31);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(355, 22);
            this.nameField.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(8);
            this.label4.Size = new System.Drawing.Size(74, 30);
            this.label4.TabIndex = 20;
            this.label4.Text = "Группа:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(8);
            this.label3.Size = new System.Drawing.Size(158, 30);
            this.label3.TabIndex = 19;
            this.label3.Text = "Единица измерения:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(8);
            this.label2.Size = new System.Drawing.Size(80, 30);
            this.label2.TabIndex = 19;
            this.label2.Text = "Артикул:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8);
            this.label1.Size = new System.Drawing.Size(124, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Наименование:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.costWoVatField);
            this.tabPage3.Controls.Add(this.vatField);
            this.tabPage3.Controls.Add(this.netcostField);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(536, 227);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Цена";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // costWoVatField
            // 
            this.costWoVatField.Location = new System.Drawing.Point(382, 53);
            this.costWoVatField.Name = "costWoVatField";
            this.costWoVatField.ReadOnly = true;
            this.costWoVatField.Size = new System.Drawing.Size(121, 22);
            this.costWoVatField.TabIndex = 24;
            this.costWoVatField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vatField
            // 
            this.vatField.Location = new System.Drawing.Point(137, 53);
            this.vatField.Name = "vatField";
            this.vatField.Size = new System.Drawing.Size(121, 22);
            this.vatField.TabIndex = 23;
            this.vatField.Text = "20";
            this.vatField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vatField.Leave += new System.EventHandler(this.vatField_Leave);
            // 
            // netcostField
            // 
            this.netcostField.Location = new System.Drawing.Point(137, 24);
            this.netcostField.Name = "netcostField";
            this.netcostField.Size = new System.Drawing.Size(121, 22);
            this.netcostField.TabIndex = 22;
            this.netcostField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.netcostField.Leave += new System.EventHandler(this.netcostField_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.retailmarginField);
            this.groupBox2.Controls.Add(this.retailpriceField);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(274, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 90);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Розница";
            // 
            // retailmarginField
            // 
            this.retailmarginField.Location = new System.Drawing.Point(185, 23);
            this.retailmarginField.Name = "retailmarginField";
            this.retailmarginField.Size = new System.Drawing.Size(49, 22);
            this.retailmarginField.TabIndex = 25;
            this.retailmarginField.Text = "30";
            this.retailmarginField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.retailmarginField.Leave += new System.EventHandler(this.retailmarginField_Leave);
            // 
            // retailpriceField
            // 
            this.retailpriceField.Location = new System.Drawing.Point(68, 53);
            this.retailpriceField.Name = "retailpriceField";
            this.retailpriceField.ReadOnly = true;
            this.retailpriceField.Size = new System.Drawing.Size(166, 22);
            this.retailpriceField.TabIndex = 23;
            this.retailpriceField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 48);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(8);
            this.label10.Size = new System.Drawing.Size(61, 30);
            this.label10.TabIndex = 26;
            this.label10.Text = "Цена:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 18);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(8);
            this.label11.Size = new System.Drawing.Size(178, 30);
            this.label11.TabIndex = 25;
            this.label11.Text = "Розничная наценка, %:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trademarginField);
            this.groupBox1.Controls.Add(this.tradepriceField);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(18, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 90);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Опт";
            // 
            // trademarginField
            // 
            this.trademarginField.Location = new System.Drawing.Point(182, 23);
            this.trademarginField.Name = "trademarginField";
            this.trademarginField.Size = new System.Drawing.Size(49, 22);
            this.trademarginField.TabIndex = 25;
            this.trademarginField.Text = "15";
            this.trademarginField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.trademarginField.Leave += new System.EventHandler(this.trademarginField_Leave);
            // 
            // tradepriceField
            // 
            this.tradepriceField.Location = new System.Drawing.Point(65, 53);
            this.tradepriceField.Name = "tradepriceField";
            this.tradepriceField.ReadOnly = true;
            this.tradepriceField.Size = new System.Drawing.Size(166, 22);
            this.tradepriceField.TabIndex = 23;
            this.tradepriceField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(8);
            this.label9.Size = new System.Drawing.Size(61, 30);
            this.label9.TabIndex = 26;
            this.label9.Text = "Цена:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(8);
            this.label8.Size = new System.Drawing.Size(164, 30);
            this.label8.TabIndex = 25;
            this.label8.Text = "Оптовая наценка, %:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(8);
            this.label7.Size = new System.Drawing.Size(118, 30);
            this.label7.TabIndex = 8;
            this.label7.Text = "Цена без НДС:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(8);
            this.label6.Size = new System.Drawing.Size(126, 30);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ставка НДС, %:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(8);
            this.label5.Size = new System.Drawing.Size(119, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "Учетная цена:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.descriptionField);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(536, 228);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Описание";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(8);
            this.label12.Size = new System.Drawing.Size(148, 30);
            this.label12.TabIndex = 8;
            this.label12.Text = "Краткое описание:";
            // 
            // descriptionField
            // 
            this.descriptionField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.descriptionField.Location = new System.Drawing.Point(0, 33);
            this.descriptionField.Multiline = true;
            this.descriptionField.Name = "descriptionField";
            this.descriptionField.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.descriptionField.Size = new System.Drawing.Size(536, 195);
            this.descriptionField.TabIndex = 0;
            // 
            // goodSave
            // 
            this.goodSave.Font = new System.Drawing.Font("Verdana", 9F);
            this.goodSave.Location = new System.Drawing.Point(432, 260);
            this.goodSave.Name = "goodSave";
            this.goodSave.Size = new System.Drawing.Size(100, 30);
            this.goodSave.TabIndex = 2;
            this.goodSave.Text = "Сохранить";
            this.goodSave.UseVisualStyleBackColor = true;
            this.goodSave.Click += new System.EventHandler(this.goodSave_Click);
            // 
            // AddGoodForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 296);
            this.Controls.Add(this.goodSave);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddGoodForm";
            this.ShowIcon = false;
            this.Text = "Добавить товар";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox articleField;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.ComboBox groupBox;
        private System.Windows.Forms.ComboBox measureunitBox;
        private System.Windows.Forms.CheckBox archivecheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox costWoVatField;
        private System.Windows.Forms.TextBox vatField;
        private System.Windows.Forms.TextBox netcostField;
        private System.Windows.Forms.TextBox trademarginField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox retailmarginField;
        private System.Windows.Forms.TextBox retailpriceField;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tradepriceField;
        private System.Windows.Forms.TextBox descriptionField;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button goodSave;
    }
}