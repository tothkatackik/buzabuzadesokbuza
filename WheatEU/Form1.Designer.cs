namespace WheatEU
{
    partial class BuzaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IncompleteDataItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiagramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PieChartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BarChartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineChartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuzaDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuzaDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataMenuItem,
            this.DiagramMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1384, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DataMenuItem
            // 
            this.DataMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.IncompleteDataItem});
            this.DataMenuItem.Name = "DataMenuItem";
            this.DataMenuItem.Size = new System.Drawing.Size(57, 20);
            this.DataMenuItem.Text = "Adatok";
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(156, 22);
            this.OpenMenuItem.Text = "Megnyitás";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // IncompleteDataItem
            // 
            this.IncompleteDataItem.Checked = true;
            this.IncompleteDataItem.CheckOnClick = true;
            this.IncompleteDataItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncompleteDataItem.Enabled = false;
            this.IncompleteDataItem.Name = "IncompleteDataItem";
            this.IncompleteDataItem.Size = new System.Drawing.Size(156, 22);
            this.IncompleteDataItem.Text = "Hiányos adatok";
            this.IncompleteDataItem.CheckedChanged += new System.EventHandler(this.IncompleteDataItem_CheckedChanged);
            // 
            // DiagramMenuItem
            // 
            this.DiagramMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PieChartMenuItem,
            this.BarChartMenuItem,
            this.LineChartMenuItem});
            this.DiagramMenuItem.Name = "DiagramMenuItem";
            this.DiagramMenuItem.Size = new System.Drawing.Size(77, 20);
            this.DiagramMenuItem.Text = "Diagramok";
            // 
            // PieChartMenuItem
            // 
            this.PieChartMenuItem.Name = "PieChartMenuItem";
            this.PieChartMenuItem.Size = new System.Drawing.Size(180, 22);
            this.PieChartMenuItem.Text = "Kör (országok)";
            this.PieChartMenuItem.Click += new System.EventHandler(this.PieChartMenuItem_Click);
            // 
            // BarChartMenuItem
            // 
            this.BarChartMenuItem.Name = "BarChartMenuItem";
            this.BarChartMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BarChartMenuItem.Text = "Sáv (kategóriák)";
            this.BarChartMenuItem.Click += new System.EventHandler(this.BarChartMenuItem_Click);
            // 
            // LineChartMenuItem
            // 
            this.LineChartMenuItem.Name = "LineChartMenuItem";
            this.LineChartMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LineChartMenuItem.Text = "Vonal (HU, RO, PL)";
            this.LineChartMenuItem.Click += new System.EventHandler(this.LineChartMenuItem_Click);
            // 
            // BuzaDataGrid
            // 
            this.BuzaDataGrid.AllowUserToAddRows = false;
            this.BuzaDataGrid.AllowUserToDeleteRows = false;
            this.BuzaDataGrid.AllowUserToResizeColumns = false;
            this.BuzaDataGrid.AllowUserToResizeRows = false;
            this.BuzaDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuzaDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BuzaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BuzaDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.BuzaDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.BuzaDataGrid.Location = new System.Drawing.Point(0, 27);
            this.BuzaDataGrid.Name = "BuzaDataGrid";
            this.BuzaDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.BuzaDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BuzaDataGrid.Size = new System.Drawing.Size(1164, 533);
            this.BuzaDataGrid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1179, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategória:";
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.Enabled = false;
            this.CategoryComboBox.Items.AddRange(new object[] {
            "Minden kategória...",
            "Törpe",
            "Kicsi",
            "Közepes",
            "Nagy",
            "Óriási"});
            this.CategoryComboBox.Location = new System.Drawing.Point(1183, 68);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(179, 21);
            this.CategoryComboBox.TabIndex = 3;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // BuzaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 561);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuzaDataGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1400, 600);
            this.Name = "BuzaForm";
            this.Text = "Búzatermelés EU";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuzaDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DataMenuItem;
        private System.Windows.Forms.DataGridView BuzaDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IncompleteDataItem;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.ToolStripMenuItem DiagramMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PieChartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BarChartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LineChartMenuItem;
    }
}

