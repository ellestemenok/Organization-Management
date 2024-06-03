namespace OrganizationManagement.InvoicesEdit
{
    partial class EditInvoiceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.expNumField = new System.Windows.Forms.TextBox();
            this.sumField = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.givenBox = new System.Windows.Forms.CheckBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.reasonBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gruzPolBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.contractorBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.orgBox = new System.Windows.Forms.TextBox();
            this.paymentBox = new System.Windows.Forms.ComboBox();
            this.gruzOtprBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.specGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.specGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.expNumField);
            this.groupBox1.Controls.Add(this.sumField);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.givenBox);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.reasonBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.gruzPolBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.contractorBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.orgBox);
            this.groupBox1.Controls.Add(this.paymentBox);
            this.groupBox1.Controls.Add(this.gruzOtprBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numField);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Реквизиты документа";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(309, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "К расходной накладной №";
            // 
            // expNumField
            // 
            this.expNumField.Location = new System.Drawing.Point(482, 177);
            this.expNumField.Name = "expNumField";
            this.expNumField.ReadOnly = true;
            this.expNumField.Size = new System.Drawing.Size(127, 20);
            this.expNumField.TabIndex = 21;
            // 
            // sumField
            // 
            this.sumField.Location = new System.Drawing.Point(154, 177);
            this.sumField.Name = "sumField";
            this.sumField.ReadOnly = true;
            this.sumField.Size = new System.Drawing.Size(127, 20);
            this.sumField.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Сумма:";
            // 
            // givenBox
            // 
            this.givenBox.AutoSize = true;
            this.givenBox.Location = new System.Drawing.Point(540, 22);
            this.givenBox.Name = "givenBox";
            this.givenBox.Size = new System.Drawing.Size(69, 17);
            this.givenBox.TabIndex = 18;
            this.givenBox.Text = "Отдана";
            this.givenBox.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(312, 20);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(162, 20);
            this.dateTimePicker.TabIndex = 17;
            this.dateTimePicker.Value = new System.DateTime(2024, 4, 30, 0, 0, 0, 0);
            // 
            // reasonBox
            // 
            this.reasonBox.Location = new System.Drawing.Point(154, 151);
            this.reasonBox.Name = "reasonBox";
            this.reasonBox.ReadOnly = true;
            this.reasonBox.Size = new System.Drawing.Size(455, 20);
            this.reasonBox.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Основание:";
            // 
            // gruzPolBox
            // 
            this.gruzPolBox.Location = new System.Drawing.Point(154, 125);
            this.gruzPolBox.Name = "gruzPolBox";
            this.gruzPolBox.ReadOnly = true;
            this.gruzPolBox.Size = new System.Drawing.Size(455, 20);
            this.gruzPolBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Грузополучатель:";
            // 
            // contractorBox
            // 
            this.contractorBox.Enabled = false;
            this.contractorBox.FormattingEnabled = true;
            this.contractorBox.Location = new System.Drawing.Point(154, 98);
            this.contractorBox.Name = "contractorBox";
            this.contractorBox.Size = new System.Drawing.Size(455, 21);
            this.contractorBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Контрагент:";
            // 
            // orgBox
            // 
            this.orgBox.Location = new System.Drawing.Point(154, 46);
            this.orgBox.Name = "orgBox";
            this.orgBox.ReadOnly = true;
            this.orgBox.Size = new System.Drawing.Size(239, 20);
            this.orgBox.TabIndex = 10;
            // 
            // paymentBox
            // 
            this.paymentBox.FormattingEnabled = true;
            this.paymentBox.Location = new System.Drawing.Point(454, 45);
            this.paymentBox.Name = "paymentBox";
            this.paymentBox.Size = new System.Drawing.Size(155, 21);
            this.paymentBox.TabIndex = 9;
            // 
            // gruzOtprBox
            // 
            this.gruzOtprBox.Location = new System.Drawing.Point(154, 72);
            this.gruzOtprBox.Name = "gruzOtprBox";
            this.gruzOtprBox.ReadOnly = true;
            this.gruzOtprBox.Size = new System.Drawing.Size(455, 20);
            this.gruzOtprBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "от";
            // 
            // numField
            // 
            this.numField.Location = new System.Drawing.Point(154, 20);
            this.numField.Name = "numField";
            this.numField.Size = new System.Drawing.Size(127, 20);
            this.numField.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Грузоотправитель:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Р/счет:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Организация:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Счет-фактура №";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.specGrid);
            this.groupBox2.Controls.Add(this.menuStrip1);
            this.groupBox2.Location = new System.Drawing.Point(12, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 264);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Спецификация документа";
            // 
            // specGrid
            // 
            this.specGrid.AllowUserToAddRows = false;
            this.specGrid.AllowUserToDeleteRows = false;
            this.specGrid.AllowUserToResizeRows = false;
            this.specGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.specGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.specGrid.BackgroundColor = System.Drawing.Color.White;
            this.specGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.specGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.specGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.specGrid.Location = new System.Drawing.Point(3, 43);
            this.specGrid.Name = "specGrid";
            this.specGrid.ReadOnly = true;
            this.specGrid.RowHeadersVisible = false;
            this.specGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.specGrid.Size = new System.Drawing.Size(654, 218);
            this.specGrid.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItem,
            this.delItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(654, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addItem
            // 
            this.addItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addItem.Image = global::OrganizationManagement.Properties.Resources.invoiceAddIcon;
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(28, 20);
            this.addItem.Text = " ";
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // delItem
            // 
            this.delItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delItem.Image = global::OrganizationManagement.Properties.Resources.invoiceDeleteIcon;
            this.delItem.Name = "delItem";
            this.delItem.Size = new System.Drawing.Size(28, 20);
            this.delItem.Text = " ";
            this.delItem.Click += new System.EventHandler(this.delItem_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 8F);
            this.saveButton.Location = new System.Drawing.Point(572, 492);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // printButton
            // 
            this.printButton.Font = new System.Drawing.Font("Verdana", 8F);
            this.printButton.Location = new System.Drawing.Point(15, 492);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(100, 30);
            this.printButton.TabIndex = 9;
            this.printButton.Text = "Печать";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // EditInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 533);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "EditInvoiceForm";
            this.ShowIcon = false;
            this.Text = "Редактировать счет-фактуру";
            this.Enter += new System.EventHandler(this.AddInvoiceForm_Enter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.specGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox contractorBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox orgBox;
        private System.Windows.Forms.ComboBox paymentBox;
        private System.Windows.Forms.TextBox gruzOtprBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numField;
        private System.Windows.Forms.TextBox gruzPolBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox givenBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox reasonBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addItem;
        private System.Windows.Forms.ToolStripMenuItem delItem;
        private System.Windows.Forms.DataGridView specGrid;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox sumField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox expNumField;
        private System.Windows.Forms.Button printButton;
    }
}