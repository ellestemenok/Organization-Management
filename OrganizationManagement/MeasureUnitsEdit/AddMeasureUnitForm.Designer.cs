namespace OrganizationManagement.MeasureUnitsEdit
{
    partial class AddMeasureUnitForm
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
            this.fullnameField = new System.Windows.Forms.TextBox();
            this.nameField = new System.Windows.Forms.TextBox();
            this.okeiField = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fractionalCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fullnameField
            // 
            this.fullnameField.Location = new System.Drawing.Point(211, 103);
            this.fullnameField.Name = "fullnameField";
            this.fullnameField.Size = new System.Drawing.Size(258, 20);
            this.fullnameField.TabIndex = 20;
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(211, 73);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(258, 20);
            this.nameField.TabIndex = 19;
            // 
            // okeiField
            // 
            this.okeiField.Location = new System.Drawing.Point(211, 43);
            this.okeiField.Name = "okeiField";
            this.okeiField.Size = new System.Drawing.Size(258, 20);
            this.okeiField.TabIndex = 18;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 8F);
            this.saveButton.Location = new System.Drawing.Point(369, 169);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(8);
            this.label3.Size = new System.Drawing.Size(130, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Полное название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(8);
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Краткое название:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8);
            this.label1.Size = new System.Drawing.Size(60, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "ОКЕИ:";
            // 
            // fractionalCheckBox
            // 
            this.fractionalCheckBox.AutoSize = true;
            this.fractionalCheckBox.Location = new System.Drawing.Point(28, 144);
            this.fractionalCheckBox.Name = "fractionalCheckBox";
            this.fractionalCheckBox.Size = new System.Drawing.Size(136, 17);
            this.fractionalCheckBox.TabIndex = 21;
            this.fractionalCheckBox.Text = "Является дробным";
            this.fractionalCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddMeasureUnitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.fractionalCheckBox);
            this.Controls.Add(this.fullnameField);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.okeiField);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.Name = "AddMeasureUnitForm";
            this.ShowIcon = false;
            this.Text = "Добавить единицу измерения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fullnameField;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.TextBox okeiField;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox fractionalCheckBox;
    }
}