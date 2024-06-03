namespace OrganizationManagement
{
    partial class StoragesForm
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
            this.storagesGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storagesGrid)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(548, 24);
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
            // storagesGrid
            // 
            this.storagesGrid.AllowUserToAddRows = false;
            this.storagesGrid.AllowUserToDeleteRows = false;
            this.storagesGrid.AllowUserToResizeRows = false;
            this.storagesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.storagesGrid.BackgroundColor = System.Drawing.Color.White;
            this.storagesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.storagesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storagesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storagesGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.storagesGrid.Location = new System.Drawing.Point(0, 24);
            this.storagesGrid.Name = "storagesGrid";
            this.storagesGrid.ReadOnly = true;
            this.storagesGrid.RowHeadersVisible = false;
            this.storagesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.storagesGrid.Size = new System.Drawing.Size(548, 336);
            this.storagesGrid.TabIndex = 1;
            this.storagesGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.storagesGrid_CellDoubleClick);
            // 
            // StoragesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(548, 360);
            this.Controls.Add(this.storagesGrid);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "StoragesForm";
            this.ShowIcon = false;
            this.Text = "Склады";
            this.Load += new System.EventHandler(this.StoragesForm_Load);
            this.Enter += new System.EventHandler(this.StoragesForm_Enter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storagesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem addItem;
        private System.Windows.Forms.ToolStripMenuItem delItem;
        private System.Windows.Forms.ToolStripMenuItem editItem;
        private System.Windows.Forms.ToolStripMenuItem refreshGrid;
        private System.Windows.Forms.ToolStripMenuItem filterLable;
        private System.Windows.Forms.DataGridView storagesGrid;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}