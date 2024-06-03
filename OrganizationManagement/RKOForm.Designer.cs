namespace OrganizationManagement
{
    partial class RKOForm
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
            this.addItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.filterLable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.rkoGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rkoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItem,
            this.delItem,
            this.editItem,
            this.refreshGrid,
            this.filterLable,
            this.toolStripTextBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(705, 24);
            this.menuStrip1.TabIndex = 0;
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
            // editItem
            // 
            this.editItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editItem.Image = global::OrganizationManagement.Properties.Resources.invoiceEditIcon;
            this.editItem.Name = "editItem";
            this.editItem.Size = new System.Drawing.Size(28, 20);
            this.editItem.Text = " ";
            this.editItem.Click += new System.EventHandler(this.editItem_Click);
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
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.White;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Verdana", 8F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 20);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // rkoGrid
            // 
            this.rkoGrid.AllowUserToAddRows = false;
            this.rkoGrid.AllowUserToDeleteRows = false;
            this.rkoGrid.AllowUserToResizeRows = false;
            this.rkoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rkoGrid.BackgroundColor = System.Drawing.Color.White;
            this.rkoGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.rkoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rkoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rkoGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rkoGrid.Location = new System.Drawing.Point(0, 24);
            this.rkoGrid.Name = "rkoGrid";
            this.rkoGrid.ReadOnly = true;
            this.rkoGrid.RowHeadersVisible = false;
            this.rkoGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rkoGrid.Size = new System.Drawing.Size(705, 415);
            this.rkoGrid.TabIndex = 1;
            this.rkoGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pkoGrid_CellDoubleClick);
            // 
            // RKOForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 439);
            this.Controls.Add(this.rkoGrid);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "RKOForm";
            this.ShowIcon = false;
            this.Text = "Журнал расходных кассовых ордеров";
            this.Load += new System.EventHandler(this.RKOForm_Load);
            this.Enter += new System.EventHandler(this.RKOForm_Enter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rkoGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem delItem;
        private System.Windows.Forms.ToolStripMenuItem refreshGrid;
        private System.Windows.Forms.ToolStripMenuItem filterLable;
        private System.Windows.Forms.DataGridView rkoGrid;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addItem;
        private System.Windows.Forms.ToolStripMenuItem editItem;
    }
}