namespace OrganizationManagement.StoragesEdit
{
    partial class AddStorageForm
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
            this.nameField = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.mainCheckBox = new System.Windows.Forms.CheckBox();
            this.freeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(148, 27);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(258, 20);
            this.nameField.TabIndex = 19;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 8F);
            this.saveButton.Location = new System.Drawing.Point(306, 63);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(8);
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Краткое название:";
            // 
            // mainCheckBox
            // 
            this.mainCheckBox.AutoSize = true;
            this.mainCheckBox.Location = new System.Drawing.Point(23, 53);
            this.mainCheckBox.Name = "mainCheckBox";
            this.mainCheckBox.Size = new System.Drawing.Size(122, 17);
            this.mainCheckBox.TabIndex = 21;
            this.mainCheckBox.Text = "Основной склад";
            this.mainCheckBox.UseVisualStyleBackColor = true;
            // 
            // freeCheckBox
            // 
            this.freeCheckBox.AutoSize = true;
            this.freeCheckBox.Location = new System.Drawing.Point(23, 76);
            this.freeCheckBox.Name = "freeCheckBox";
            this.freeCheckBox.Size = new System.Drawing.Size(133, 17);
            this.freeCheckBox.TabIndex = 22;
            this.freeCheckBox.Text = "Свободный склад";
            this.freeCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddStorageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 115);
            this.Controls.Add(this.freeCheckBox);
            this.Controls.Add(this.mainCheckBox);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.Name = "AddStorageForm";
            this.ShowIcon = false;
            this.Text = "Добавить новый склад";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox mainCheckBox;
        private System.Windows.Forms.CheckBox freeCheckBox;
    }
}