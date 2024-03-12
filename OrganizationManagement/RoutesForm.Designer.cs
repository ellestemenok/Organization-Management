namespace OrganizationManagement.RoutesEdit
{
    partial class RoutesForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.filterLable = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBox = new System.Windows.Forms.ToolStripTextBox();
            this.routesGrid = new System.Windows.Forms.DataGridView();
            this.editItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routesGrid)).BeginInit();
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
            this.filterBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addItem
            // 
            this.addItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addItem.Image = global::OrganizationManagement.Properties.Resources.invoiceAddIcon;
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(28, 20);
            this.addItem.Text = " ";
            this.addItem.Click += new System.EventHandler(this.addItem_Click_1);
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
            this.filterBox.Size = new System.Drawing.Size(174, 20);
            this.filterBox.TextChanged += new System.EventHandler(this.filterBox_TextChanged);
            // 
            // routesGrid
            // 
            this.routesGrid.AllowUserToAddRows = false;
            this.routesGrid.AllowUserToDeleteRows = false;
            this.routesGrid.AllowUserToResizeRows = false;
            this.routesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.routesGrid.BackgroundColor = System.Drawing.Color.White;
            this.routesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.routesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.routesGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.routesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routesGrid.Location = new System.Drawing.Point(0, 24);
            this.routesGrid.Name = "routesGrid";
            this.routesGrid.ReadOnly = true;
            this.routesGrid.RowHeadersVisible = false;
            this.routesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.routesGrid.Size = new System.Drawing.Size(684, 437);
            this.routesGrid.TabIndex = 4;
            this.routesGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.routesGrid_CellDoubleClick);
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
            // RoutesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.routesGrid);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RoutesForm";
            this.ShowIcon = false;
            this.Text = "Маршруты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoutesForm_FormClosing);
            this.Load += new System.EventHandler(this.RoutesForm_Load);
            this.Enter += new System.EventHandler(this.RoutesForm_Enter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addItem;
        private System.Windows.Forms.ToolStripMenuItem delItem;
        private System.Windows.Forms.ToolStripMenuItem refreshGrid;
        private System.Windows.Forms.ToolStripMenuItem filterLable;
        private System.Windows.Forms.ToolStripTextBox filterBox;
        private System.Windows.Forms.DataGridView routesGrid;
        private System.Windows.Forms.ToolStripMenuItem editItem;
    }
}