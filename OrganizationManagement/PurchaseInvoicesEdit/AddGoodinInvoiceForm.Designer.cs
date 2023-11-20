namespace OrganizationManagement.PurchaseInvoicesEdit
{
    partial class AddGoodinInvoiceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.goodBox = new System.Windows.Forms.ComboBox();
            this.quantField = new System.Windows.Forms.TextBox();
            this.unitsField = new System.Windows.Forms.TextBox();
            this.priceField = new System.Windows.Forms.TextBox();
            this.sumField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Товар:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Количество:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ед. изм.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Цена:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Сумма:";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 8F);
            this.saveButton.Location = new System.Drawing.Point(280, 151);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // goodBox
            // 
            this.goodBox.FormattingEnabled = true;
            this.goodBox.Location = new System.Drawing.Point(85, 30);
            this.goodBox.Name = "goodBox";
            this.goodBox.Size = new System.Drawing.Size(295, 21);
            this.goodBox.TabIndex = 10;
            this.goodBox.SelectedIndexChanged += new System.EventHandler(this.goodBox_SelectedIndexChanged);
            // 
            // quantField
            // 
            this.quantField.Location = new System.Drawing.Point(122, 63);
            this.quantField.Name = "quantField";
            this.quantField.Size = new System.Drawing.Size(67, 20);
            this.quantField.TabIndex = 11;
            this.quantField.TextChanged += new System.EventHandler(this.quantField_TextChanged);
            // 
            // unitsField
            // 
            this.unitsField.Location = new System.Drawing.Point(264, 63);
            this.unitsField.Name = "unitsField";
            this.unitsField.ReadOnly = true;
            this.unitsField.Size = new System.Drawing.Size(116, 20);
            this.unitsField.TabIndex = 11;
            // 
            // priceField
            // 
            this.priceField.Location = new System.Drawing.Point(80, 96);
            this.priceField.Name = "priceField";
            this.priceField.ReadOnly = true;
            this.priceField.Size = new System.Drawing.Size(109, 20);
            this.priceField.TabIndex = 11;
            // 
            // sumField
            // 
            this.sumField.Location = new System.Drawing.Point(271, 96);
            this.sumField.Name = "sumField";
            this.sumField.ReadOnly = true;
            this.sumField.Size = new System.Drawing.Size(109, 20);
            this.sumField.TabIndex = 11;
            // 
            // AddGoodinInvoiceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 193);
            this.Controls.Add(this.unitsField);
            this.Controls.Add(this.sumField);
            this.Controls.Add(this.priceField);
            this.Controls.Add(this.quantField);
            this.Controls.Add(this.goodBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "AddGoodinInvoiceForm";
            this.ShowIcon = false;
            this.Text = "Добавление товара в спецификацию";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox goodBox;
        private System.Windows.Forms.TextBox quantField;
        private System.Windows.Forms.TextBox unitsField;
        private System.Windows.Forms.TextBox priceField;
        private System.Windows.Forms.TextBox sumField;
    }
}