namespace OrganizationManagement.RoutesEdit
{
    partial class EditRouteForm
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
            this.nameField = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.routeAdrsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.routeAdrsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(95, 12);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(258, 20);
            this.nameField.TabIndex = 18;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 8F);
            this.saveButton.Location = new System.Drawing.Point(372, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 29);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8);
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Название:";
            // 
            // routeAdrsGrid
            // 
            this.routeAdrsGrid.AllowUserToAddRows = false;
            this.routeAdrsGrid.AllowUserToDeleteRows = false;
            this.routeAdrsGrid.AllowUserToResizeRows = false;
            this.routeAdrsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.routeAdrsGrid.BackgroundColor = System.Drawing.Color.White;
            this.routeAdrsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.routeAdrsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.routeAdrsGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.routeAdrsGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.routeAdrsGrid.Location = new System.Drawing.Point(0, 42);
            this.routeAdrsGrid.Name = "routeAdrsGrid";
            this.routeAdrsGrid.ReadOnly = true;
            this.routeAdrsGrid.RowHeadersVisible = false;
            this.routeAdrsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.routeAdrsGrid.Size = new System.Drawing.Size(484, 365);
            this.routeAdrsGrid.TabIndex = 19;
            this.routeAdrsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.routeAdrsGrid_CellValueChanged);
            // 
            // EditRouteForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 407);
            this.Controls.Add(this.routeAdrsGrid);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.Name = "EditRouteForm";
            this.ShowIcon = false;
            this.Text = "Редактировать маршрут";
            ((System.ComponentModel.ISupportInitialize)(this.routeAdrsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView routeAdrsGrid;
    }
}