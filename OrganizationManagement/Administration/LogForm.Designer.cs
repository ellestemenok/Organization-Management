namespace OrganizationManagement
{
    partial class LogForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.filterLable = new System.Windows.Forms.ToolStripMenuItem();
            this.logGrid = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshGrid,
            this.filterLable});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshGrid
            // 
            this.refreshGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshGrid.Image = global::OrganizationManagement.Properties.Resources.refreshIcon;
            this.refreshGrid.Name = "refreshGrid";
            this.refreshGrid.Size = new System.Drawing.Size(28, 20);
            this.refreshGrid.Text = " ";
            this.refreshGrid.Click += new System.EventHandler(this.refreshGrid_Click);
            // 
            // filterLable
            // 
            this.filterLable.Font = new System.Drawing.Font("Verdana", 8F);
            this.filterLable.Name = "filterLable";
            this.filterLable.Size = new System.Drawing.Size(61, 20);
            this.filterLable.Text = "Фильтр";
            // 
            // logGrid
            // 
            this.logGrid.AllowUserToAddRows = false;
            this.logGrid.AllowUserToDeleteRows = false;
            this.logGrid.AllowUserToResizeRows = false;
            this.logGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.logGrid.BackgroundColor = System.Drawing.Color.White;
            this.logGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.logGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.logGrid.Location = new System.Drawing.Point(0, 24);
            this.logGrid.Name = "logGrid";
            this.logGrid.ReadOnly = true;
            this.logGrid.RowHeadersVisible = false;
            this.logGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.logGrid.Size = new System.Drawing.Size(584, 337);
            this.logGrid.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // LogForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.logGrid);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "LogForm";
            this.ShowIcon = false;
            this.Text = "Журнал событий";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.Enter += new System.EventHandler(this.UsersForm_Enter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem refreshGrid;
        private System.Windows.Forms.ToolStripMenuItem filterLable;
        private System.Windows.Forms.DataGridView logGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}