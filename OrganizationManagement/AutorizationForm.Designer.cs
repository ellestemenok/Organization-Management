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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutorizationForm));
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
            this.label1.Location = new System.Drawing.Point(77, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пользователь:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F);
            this.label2.Location = new System.Drawing.Point(128, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Пароль:";
            // 
            // autorizationButton
            // 
            this.autorizationButton.Font = new System.Drawing.Font("Verdana", 8F);
            this.autorizationButton.Location = new System.Drawing.Point(132, 130);
            this.autorizationButton.Margin = new System.Windows.Forms.Padding(0);
            this.autorizationButton.Name = "autorizationButton";
            this.autorizationButton.Size = new System.Drawing.Size(267, 31);
            this.autorizationButton.TabIndex = 1;
            this.autorizationButton.Text = "Войти";
            this.autorizationButton.UseVisualStyleBackColor = true;
            this.autorizationButton.Click += new System.EventHandler(this.autorizationButton_Click);
            // 
            // usernameField
            // 
            this.usernameField.Font = new System.Drawing.Font("Verdana", 8F);
            this.usernameField.Location = new System.Drawing.Point(211, 36);
            this.usernameField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usernameField.Name = "usernameField";
            this.usernameField.Size = new System.Drawing.Size(252, 24);
            this.usernameField.TabIndex = 4;
            // 
            // passwordField
            // 
            this.passwordField.Font = new System.Drawing.Font("Verdana", 8F);
            this.passwordField.Location = new System.Drawing.Point(211, 76);
            this.passwordField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.Size = new System.Drawing.Size(252, 24);
            this.passwordField.TabIndex = 5;
            // 
            // AutorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 186);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.usernameField);
            this.Controls.Add(this.autorizationButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "AutorizationForm";
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