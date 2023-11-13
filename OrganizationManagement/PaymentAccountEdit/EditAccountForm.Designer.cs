namespace OrganizationManagement.AccountEdit
{
    partial class EditAccountForm
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
            this.bikField = new System.Windows.Forms.TextBox();
            this.corrField = new System.Windows.Forms.TextBox();
            this.bankField = new System.Windows.Forms.TextBox();
            this.numberField = new System.Windows.Forms.TextBox();
            this.nameField = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bikField
            // 
            this.bikField.Location = new System.Drawing.Point(204, 134);
            this.bikField.Name = "bikField";
            this.bikField.Size = new System.Drawing.Size(258, 22);
            this.bikField.TabIndex = 22;
            // 
            // corrField
            // 
            this.corrField.Location = new System.Drawing.Point(204, 104);
            this.corrField.Name = "corrField";
            this.corrField.Size = new System.Drawing.Size(258, 22);
            this.corrField.TabIndex = 21;
            // 
            // bankField
            // 
            this.bankField.Location = new System.Drawing.Point(204, 74);
            this.bankField.Name = "bankField";
            this.bankField.Size = new System.Drawing.Size(258, 22);
            this.bankField.TabIndex = 20;
            // 
            // numberField
            // 
            this.numberField.Location = new System.Drawing.Point(204, 44);
            this.numberField.Name = "numberField";
            this.numberField.Size = new System.Drawing.Size(258, 22);
            this.numberField.TabIndex = 19;
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(204, 14);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(258, 22);
            this.nameField.TabIndex = 18;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 9F);
            this.saveButton.Location = new System.Drawing.Point(363, 167);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(8);
            this.label5.Size = new System.Drawing.Size(53, 30);
            this.label5.TabIndex = 12;
            this.label5.Text = "БИК:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(8);
            this.label4.Size = new System.Drawing.Size(191, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "Корреспондентский счет:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(8);
            this.label3.Size = new System.Drawing.Size(79, 30);
            this.label3.TabIndex = 14;
            this.label3.Text = "В банке:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(8);
            this.label2.Size = new System.Drawing.Size(131, 30);
            this.label2.TabIndex = 15;
            this.label2.Text = "Расчетный счет:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8);
            this.label1.Size = new System.Drawing.Size(90, 30);
            this.label1.TabIndex = 16;
            this.label1.Text = "Название:";
            // 
            // EditAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.bikField);
            this.Controls.Add(this.corrField);
            this.Controls.Add(this.bankField);
            this.Controls.Add(this.numberField);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EditAccount";
            this.ShowIcon = false;
            this.Text = "Изменение расчетного счета";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bikField;
        private System.Windows.Forms.TextBox corrField;
        private System.Windows.Forms.TextBox bankField;
        private System.Windows.Forms.TextBox numberField;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}