namespace OrganizationManagement
{
    partial class AutorizationForm
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
            this.autorizationButton = new System.Windows.Forms.Button();
            this.usernameField = new System.Windows.Forms.TextBox();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F);
            this.label1.Location = new System.Drawing.Point(58, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пользователь:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F);
            this.label2.Location = new System.Drawing.Point(96, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Пароль:";
            // 
            // autorizationButton
            // 
            this.autorizationButton.Font = new System.Drawing.Font("Verdana", 8F);
            this.autorizationButton.Location = new System.Drawing.Point(99, 106);
            this.autorizationButton.Margin = new System.Windows.Forms.Padding(0);
            this.autorizationButton.Name = "autorizationButton";
            this.autorizationButton.Size = new System.Drawing.Size(200, 25);
            this.autorizationButton.TabIndex = 1;
            this.autorizationButton.Text = "Войти";
            this.autorizationButton.UseVisualStyleBackColor = true;
            this.autorizationButton.Click += new System.EventHandler(this.autorizationButton_Click);
            // 
            // usernameField
            // 
            this.usernameField.Font = new System.Drawing.Font("Verdana", 8F);
            this.usernameField.Location = new System.Drawing.Point(158, 29);
            this.usernameField.Name = "usernameField";
            this.usernameField.Size = new System.Drawing.Size(190, 20);
            this.usernameField.TabIndex = 4;
            this.usernameField.Text = "postgres";
            // 
            // passwordField
            // 
            this.passwordField.Font = new System.Drawing.Font("Verdana", 8F);
            this.passwordField.Location = new System.Drawing.Point(158, 62);
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.Size = new System.Drawing.Size(190, 20);
            this.passwordField.TabIndex = 5;
            this.passwordField.Text = "5215";
            // 
            // AutorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 151);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.usernameField);
            this.Controls.Add(this.autorizationButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AutorizationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход в систему";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button autorizationButton;
        public System.Windows.Forms.TextBox usernameField;
        public System.Windows.Forms.TextBox passwordField;
    }
}