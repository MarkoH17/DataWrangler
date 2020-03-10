namespace DataWrangler.Forms
{
    partial class ManageRecords
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
            this.lblView = new System.Windows.Forms.Label();
            this.gridRecords = new System.Windows.Forms.DataGridView();
            this.txtRowCnt = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.comboRecType = new System.Windows.Forms.ComboBox();
            this.lblRecType = new System.Windows.Forms.Label();
            this.lblField = new System.Windows.Forms.Label();
            this.comboField = new System.Windows.Forms.ComboBox();
            this.lblFieldSearch = new System.Windows.Forms.Label();
            this.txtFieldSearch = new System.Windows.Forms.TextBox();
            this.btnAdvSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.ForeColor = System.Drawing.Color.Black;
            this.lblView.Location = new System.Drawing.Point(294, 21);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(259, 37);
            this.lblView.TabIndex = 3;
            this.lblView.Text = "Manage Records";
            // 
            // gridRecords
            // 
            this.gridRecords.AllowUserToAddRows = false;
            this.gridRecords.AllowUserToDeleteRows = false;
            this.gridRecords.AllowUserToResizeRows = false;
            this.gridRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRecords.Enabled = false;
            this.gridRecords.Location = new System.Drawing.Point(12, 106);
            this.gridRecords.Name = "gridRecords";
            this.gridRecords.ReadOnly = true;
            this.gridRecords.RowHeadersVisible = false;
            this.gridRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRecords.Size = new System.Drawing.Size(776, 311);
            this.gridRecords.TabIndex = 4;
            this.gridRecords.VirtualMode = true;
            this.gridRecords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRecords_CellDoubleClick);
            this.gridRecords.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValueNeeded);
            this.gridRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridRecords_MouseClick);
            // 
            // txtRowCnt
            // 
            this.txtRowCnt.Enabled = false;
            this.txtRowCnt.Location = new System.Drawing.Point(687, 424);
            this.txtRowCnt.Name = "txtRowCnt";
            this.txtRowCnt.ReadOnly = true;
            this.txtRowCnt.Size = new System.Drawing.Size(100, 20);
            this.txtRowCnt.TabIndex = 5;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(646, 427);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(35, 13);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Count";
            // 
            // comboRecType
            // 
            this.comboRecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRecType.FormattingEnabled = true;
            this.comboRecType.Location = new System.Drawing.Point(87, 80);
            this.comboRecType.Name = "comboRecType";
            this.comboRecType.Size = new System.Drawing.Size(137, 21);
            this.comboRecType.TabIndex = 7;
            this.comboRecType.SelectedIndexChanged += new System.EventHandler(this.comboRecType_SelectedIndexChanged);
            // 
            // lblRecType
            // 
            this.lblRecType.AutoSize = true;
            this.lblRecType.Location = new System.Drawing.Point(12, 82);
            this.lblRecType.Name = "lblRecType";
            this.lblRecType.Size = new System.Drawing.Size(69, 13);
            this.lblRecType.TabIndex = 8;
            this.lblRecType.Text = "Record Type";
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(453, 82);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(29, 13);
            this.lblField.TabIndex = 9;
            this.lblField.Text = "Field";
            // 
            // comboField
            // 
            this.comboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboField.Enabled = false;
            this.comboField.FormattingEnabled = true;
            this.comboField.Location = new System.Drawing.Point(488, 80);
            this.comboField.Name = "comboField";
            this.comboField.Size = new System.Drawing.Size(121, 21);
            this.comboField.TabIndex = 10;
            this.comboField.SelectedIndexChanged += new System.EventHandler(this.comboField_SelectedIndexChanged);
            // 
            // lblFieldSearch
            // 
            this.lblFieldSearch.AutoSize = true;
            this.lblFieldSearch.Location = new System.Drawing.Point(615, 82);
            this.lblFieldSearch.Name = "lblFieldSearch";
            this.lblFieldSearch.Size = new System.Drawing.Size(66, 13);
            this.lblFieldSearch.TabIndex = 11;
            this.lblFieldSearch.Text = "Field Search";
            // 
            // txtFieldSearch
            // 
            this.txtFieldSearch.Enabled = false;
            this.txtFieldSearch.Location = new System.Drawing.Point(687, 80);
            this.txtFieldSearch.Name = "txtFieldSearch";
            this.txtFieldSearch.Size = new System.Drawing.Size(100, 20);
            this.txtFieldSearch.TabIndex = 12;
            this.txtFieldSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFieldSearch_KeyDown);
            // 
            // btnAdvSearch
            // 
            this.btnAdvSearch.Location = new System.Drawing.Point(12, 420);
            this.btnAdvSearch.Name = "btnAdvSearch";
            this.btnAdvSearch.Size = new System.Drawing.Size(111, 23);
            this.btnAdvSearch.TabIndex = 13;
            this.btnAdvSearch.Text = "Advanced Search...";
            this.btnAdvSearch.UseVisualStyleBackColor = true;
            // 
            // ManageRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAdvSearch);
            this.Controls.Add(this.txtFieldSearch);
            this.Controls.Add(this.lblFieldSearch);
            this.Controls.Add(this.comboField);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.lblRecType);
            this.Controls.Add(this.comboRecType);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtRowCnt);
            this.Controls.Add(this.gridRecords);
            this.Controls.Add(this.lblView);
            this.Name = "ManageRecords";
            this.Text = "Data Wrangler View";
            this.Load += new System.EventHandler(this.ManageRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.DataGridView gridRecords;
        private System.Windows.Forms.TextBox txtRowCnt;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox comboRecType;
        private System.Windows.Forms.Label lblRecType;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox comboField;
        private System.Windows.Forms.Label lblFieldSearch;
        private System.Windows.Forms.TextBox txtFieldSearch;
        private System.Windows.Forms.Button btnAdvSearch;
    }
}