namespace DataWrangler.Forms
{
    partial class ImportRecords
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPathAddr = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.comboImportOptions = new System.Windows.Forms.ComboBox();
            this.lblImportMode = new System.Windows.Forms.Label();
            this.lblFieldAssignment = new System.Windows.Forms.Label();
            this.lblNewRecordType = new System.Windows.Forms.Label();
            this.gridFieldAssignment = new System.Windows.Forms.DataGridView();
            this.comboRecordTypeSelector = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldAssignment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(288, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Import";
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.BackColor = System.Drawing.Color.Gray;
            this.btnImport.Enabled = false;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Transparent;
            this.btnImport.Location = new System.Drawing.Point(531, 453);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 30);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(612, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // txtPathAddr
            // 
            this.txtPathAddr.Location = new System.Drawing.Point(131, 82);
            this.txtPathAddr.Name = "txtPathAddr";
            this.txtPathAddr.ReadOnly = true;
            this.txtPathAddr.Size = new System.Drawing.Size(327, 20);
            this.txtPathAddr.TabIndex = 4;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(12, 80);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(113, 20);
            this.lblPath.TabIndex = 5;
            this.lblPath.Text = "Excel File Path\r\n";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.AutoSize = true;
            this.btnChooseFile.BackColor = System.Drawing.Color.Gray;
            this.btnChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFile.ForeColor = System.Drawing.Color.Transparent;
            this.btnChooseFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChooseFile.Location = new System.Drawing.Point(464, 73);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(72, 31);
            this.btnChooseFile.TabIndex = 6;
            this.btnChooseFile.Text = "Browse";
            this.btnChooseFile.UseVisualStyleBackColor = false;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // comboImportOptions
            // 
            this.comboImportOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboImportOptions.Enabled = false;
            this.comboImportOptions.FormattingEnabled = true;
            this.comboImportOptions.Items.AddRange(new object[] {
            "New Record Type",
            "Existing Record Type"});
            this.comboImportOptions.Location = new System.Drawing.Point(117, 125);
            this.comboImportOptions.Name = "comboImportOptions";
            this.comboImportOptions.Size = new System.Drawing.Size(341, 21);
            this.comboImportOptions.TabIndex = 7;
            this.comboImportOptions.SelectedIndexChanged += new System.EventHandler(this.comboImportOptions_SelectedIndexChanged);
            // 
            // lblImportMode
            // 
            this.lblImportMode.AutoSize = true;
            this.lblImportMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportMode.Location = new System.Drawing.Point(12, 126);
            this.lblImportMode.Name = "lblImportMode";
            this.lblImportMode.Size = new System.Drawing.Size(99, 20);
            this.lblImportMode.TabIndex = 8;
            this.lblImportMode.Text = "Import Mode";
            // 
            // lblFieldAssignment
            // 
            this.lblFieldAssignment.AutoSize = true;
            this.lblFieldAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldAssignment.Location = new System.Drawing.Point(12, 204);
            this.lblFieldAssignment.Name = "lblFieldAssignment";
            this.lblFieldAssignment.Size = new System.Drawing.Size(139, 20);
            this.lblFieldAssignment.TabIndex = 12;
            this.lblFieldAssignment.Text = "Field Assignments";
            // 
            // lblNewRecordType
            // 
            this.lblNewRecordType.AutoSize = true;
            this.lblNewRecordType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewRecordType.Location = new System.Drawing.Point(12, 163);
            this.lblNewRecordType.Name = "lblNewRecordType";
            this.lblNewRecordType.Size = new System.Drawing.Size(99, 20);
            this.lblNewRecordType.TabIndex = 13;
            this.lblNewRecordType.Text = "Record Type";
            // 
            // gridFieldAssignment
            // 
            this.gridFieldAssignment.AllowUserToAddRows = false;
            this.gridFieldAssignment.AllowUserToResizeRows = false;
            this.gridFieldAssignment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridFieldAssignment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridFieldAssignment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFieldAssignment.Enabled = false;
            this.gridFieldAssignment.Location = new System.Drawing.Point(16, 227);
            this.gridFieldAssignment.Name = "gridFieldAssignment";
            this.gridFieldAssignment.RowHeadersVisible = false;
            this.gridFieldAssignment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFieldAssignment.Size = new System.Drawing.Size(671, 220);
            this.gridFieldAssignment.TabIndex = 11;
            this.gridFieldAssignment.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFieldAssignment_CellEndEdit);
            this.gridFieldAssignment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridFieldAssignment_MouseClick);
            // 
            // comboRecordTypeSelector
            // 
            this.comboRecordTypeSelector.Enabled = false;
            this.comboRecordTypeSelector.FormattingEnabled = true;
            this.comboRecordTypeSelector.Location = new System.Drawing.Point(117, 165);
            this.comboRecordTypeSelector.Name = "comboRecordTypeSelector";
            this.comboRecordTypeSelector.Size = new System.Drawing.Size(341, 21);
            this.comboRecordTypeSelector.TabIndex = 15;
            this.comboRecordTypeSelector.SelectedIndexChanged += new System.EventHandler(this.comboRecordTypeSelector_SelectedIndexChanged);
            // 
            // ImportRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(699, 495);
            this.Controls.Add(this.comboRecordTypeSelector);
            this.Controls.Add(this.lblNewRecordType);
            this.Controls.Add(this.lblFieldAssignment);
            this.Controls.Add(this.gridFieldAssignment);
            this.Controls.Add(this.lblImportMode);
            this.Controls.Add(this.comboImportOptions);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPathAddr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Name = "ImportRecords";
            this.Text = "Data Wrangler Import";
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldAssignment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPathAddr;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.ComboBox comboImportOptions;
        private System.Windows.Forms.Label lblImportMode;
        private System.Windows.Forms.Label lblFieldAssignment;
        private System.Windows.Forms.Label lblNewRecordType;
        private System.Windows.Forms.DataGridView gridFieldAssignment;
        private System.Windows.Forms.ComboBox comboRecordTypeSelector;
    }
}