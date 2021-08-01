namespace Medivest_BarCodePrinter
{
    partial class Form_PrintSticker
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearcgVal = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.cbxSelectAll = new System.Windows.Forms.CheckBox();
            this.cboPrinterNames = new System.Windows.Forms.ComboBox();
            this.lbPrinters = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tbWhs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(960, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.tbSearcgVal);
            this.groupBox1.Controls.Add(this.lbSearch);
            this.groupBox1.Controls.Add(this.cbxSelectAll);
            this.groupBox1.Controls.Add(this.cboPrinterNames);
            this.groupBox1.Controls.Add(this.lbPrinters);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.tbWhs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1298, 175);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSearch.Location = new System.Drawing.Point(895, 92);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Visible = false;
            // 
            // tbSearcgVal
            // 
            this.tbSearcgVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tbSearcgVal.Location = new System.Drawing.Point(428, 92);
            this.tbSearcgVal.Name = "tbSearcgVal";
            this.tbSearcgVal.Size = new System.Drawing.Size(440, 27);
            this.tbSearcgVal.TabIndex = 1;
            this.tbSearcgVal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearcgVal_KeyUp);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(309, 96);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(53, 20);
            this.lbSearch.TabIndex = 0;
            this.lbSearch.Text = "Search";
            // 
            // cbxSelectAll
            // 
            this.cbxSelectAll.AutoSize = true;
            this.cbxSelectAll.Location = new System.Drawing.Point(896, 62);
            this.cbxSelectAll.Name = "cbxSelectAll";
            this.cbxSelectAll.Size = new System.Drawing.Size(93, 24);
            this.cbxSelectAll.TabIndex = 5;
            this.cbxSelectAll.Text = "Select All";
            this.cbxSelectAll.UseVisualStyleBackColor = true;
            this.cbxSelectAll.Click += new System.EventHandler(this.cbxSelectAll_Click);
            // 
            // cboPrinterNames
            // 
            this.cboPrinterNames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboPrinterNames.FormattingEnabled = true;
            this.cboPrinterNames.Location = new System.Drawing.Point(428, 56);
            this.cboPrinterNames.Name = "cboPrinterNames";
            this.cboPrinterNames.Size = new System.Drawing.Size(440, 28);
            this.cboPrinterNames.TabIndex = 4;
            // 
            // lbPrinters
            // 
            this.lbPrinters.AutoSize = true;
            this.lbPrinters.Location = new System.Drawing.Point(309, 60);
            this.lbPrinters.Name = "lbPrinters";
            this.lbPrinters.Size = new System.Drawing.Size(96, 20);
            this.lbPrinters.TabIndex = 0;
            this.lbPrinters.Text = "Select Printer";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPrint.Location = new System.Drawing.Point(896, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 29);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print Selected";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.brnPrint_Click);
            // 
            // tbWhs
            // 
            this.tbWhs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tbWhs.Location = new System.Drawing.Point(428, 21);
            this.tbWhs.Name = "tbWhs";
            this.tbWhs.Size = new System.Drawing.Size(440, 27);
            this.tbWhs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warehouse";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvItems);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1298, 559);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(3, 23);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.Size = new System.Drawing.Size(1292, 533);
            this.dgvItems.TabIndex = 2;
            this.dgvItems.Text = "dataGridView1";
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellClick);
            // 
            // Form_PrintSticker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 734);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_PrintSticker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items Master List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_PrintSticker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox tbWhs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.ComboBox cboPrinterNames;
        private System.Windows.Forms.Label lbPrinters;
        private System.Windows.Forms.CheckBox cbxSelectAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearcgVal;
        private System.Windows.Forms.Label lbSearch;
    }
}