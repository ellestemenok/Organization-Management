namespace OrganizationManagement
{
    partial class CashboxForm
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
            this.editItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.filterLable = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBox = new System.Windows.Forms.ToolStripTextBox();
            this.cashboxGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashboxGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItem,
            this.editItem,
            this.refreshGrid,
            this.filterLable,
            this.filterBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
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
            // filterBox
            // 
            this.filterBox.BackColor = System.Drawing.Color.White;
            this.filterBox.Font = new System.Drawing.Font("Verdana", 8F);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(150, 20);
            this.filterBox.TextChanged += new System.EventHandler(this.filterBox_TextChanged);
            // 
            // cashboxGrid
            // 
            this.cashboxGrid.AllowUserToAddRows = false;
            this.cashboxGrid.AllowUserToDeleteRows = false;
            this.cashboxGrid.AllowUserToResizeRows = false;
            this.cashboxGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cashboxGrid.BackgroundColor = System.Drawing.Color.White;
            this.cashboxGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.cashboxGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cashboxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cashboxGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cashboxGrid.Location = new System.Drawing.Point(0, 24);
            this.cashboxGrid.Name = "cashboxGrid";
            this.cashboxGrid.ReadOnly = true;
            this.cashboxGrid.RowHeadersVisible = false;
            this.cashboxGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cashboxGrid.Size = new System.Drawing.Size(734, 307);
            this.cashboxGrid.TabIndex = 1;
            this.cashboxGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cashboxGrid_CellDoubleClick);
            // 
            // CashboxForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 331);
            this.Controls.Add(this.cashboxGrid);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "CashboxForm";
            this.ShowIcon = false;
            this.Text = "Журнал кассовых отчетов";
            this.Load += new System.EventHandler(this.CashboxForm_Load);
            this.Enter += new System.EventHandler(this.CashboxForm_Enter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashboxGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem addItem;
        private System.Windows.Forms.ToolStripMenuItem editItem;
        private System.Windows.Forms.ToolStripMenuItem refreshGrid;
        private System.Windows.Forms.ToolStripMenuItem filterLable;
        private System.Windows.Forms.DataGridView cashboxGrid;
        private System.Windows.Forms.ToolStripTextBox filterBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}