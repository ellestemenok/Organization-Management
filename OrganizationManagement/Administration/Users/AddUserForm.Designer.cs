namespace OrganizationManagement
{
    partial class AddUserForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fioField = new System.Windows.Forms.TextBox();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.roleBox = new System.Windows.Forms.ComboBox();
            this.isActiveBox = new System.Windows.Forms.CheckBox();
            this.loginField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 8F);
            this.saveButton.Location = new System.Drawing.Point(218, 150);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ф.И.О.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Пароль:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Роль:";
            // 
            // fioField
            // 
            this.fioField.Location = new System.Drawing.Point(75, 19);
            this.fioField.Name = "fioField";
            this.fioField.Size = new System.Drawing.Size(233, 20);
            this.fioField.TabIndex = 12;
            // 
            // passwordField
            // 
            this.passwordField.Location = new System.Drawing.Point(75, 71);
            this.passwordField.Name = "passwordField";
            this.passwordField.Size = new System.Drawing.Size(233, 20);
            this.passwordField.TabIndex = 13;
            // 
            // roleBox
            // 
            this.roleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleBox.FormattingEnabled = true;
            this.roleBox.Items.AddRange(new object[] {
            "Администратор",
            "Менеджер"});
            this.roleBox.Location = new System.Drawing.Point(75, 97);
            this.roleBox.Name = "roleBox";
            this.roleBox.Size = new System.Drawing.Size(233, 21);
            this.roleBox.TabIndex = 14;
            // 
            // isActiveBox
            // 
            this.isActiveBox.AutoSize = true;
            this.isActiveBox.Location = new System.Drawing.Point(75, 124);
            this.isActiveBox.Name = "isActiveBox";
            this.isActiveBox.Size = new System.Drawing.Size(83, 17);
            this.isActiveBox.TabIndex = 15;
            this.isActiveBox.Text = "Активный";
            this.isActiveBox.UseVisualStyleBackColor = true;
            // 
            // loginField
            // 
            this.loginField.Location = new System.Drawing.Point(75, 45);
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(233, 20);
            this.loginField.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Логин:";
            // 
            // AddUserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 192);
            this.Controls.Add(this.loginField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.isActiveBox);
            this.Controls.Add(this.roleBox);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.fioField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "AddUserForm";
            this.ShowIcon = false;
            this.Text = "Добавление пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fioField;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.ComboBox roleBox;
        private System.Windows.Forms.CheckBox isActiveBox;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.Label label4;
    }
}