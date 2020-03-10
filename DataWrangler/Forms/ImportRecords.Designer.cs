using MetroFramework.Controls;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImport = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.txtPathAddr = new MetroFramework.Controls.MetroTextBox();
            this.lblPath = new MetroFramework.Controls.MetroLabel();
            this.btnChooseFile = new MetroFramework.Controls.MetroButton();
            this.comboImportOptions = new MetroFramework.Controls.MetroComboBox();
            this.lblImportMode = new MetroFramework.Controls.MetroLabel();
            this.lblFieldAssignment = new MetroFramework.Controls.MetroLabel();
            this.lblRecordType = new MetroFramework.Controls.MetroLabel();
            this.gridFieldAssignment = new MetroFramework.Controls.MetroGrid();
            this.comboRecordTypeSelector = new MetroFramework.Controls.MetroComboBox();
            this.txtRecordTypeName = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldAssignment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.AutoSize = true;
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(360, 488);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 29);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseSelectable = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(441, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            // 
            // txtPathAddr
            // 
            this.txtPathAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPathAddr.CustomButton.Image = null;
            this.txtPathAddr.CustomButton.Location = new System.Drawing.Point(309, 1);
            this.txtPathAddr.CustomButton.Name = "";
            this.txtPathAddr.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPathAddr.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPathAddr.CustomButton.TabIndex = 1;
            this.txtPathAddr.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPathAddr.CustomButton.UseSelectable = true;
            this.txtPathAddr.CustomButton.Visible = false;
            this.txtPathAddr.Enabled = false;
            this.txtPathAddr.Lines = new string[0];
            this.txtPathAddr.Location = new System.Drawing.Point(107, 84);
            this.txtPathAddr.MaxLength = 32767;
            this.txtPathAddr.Name = "txtPathAddr";
            this.txtPathAddr.PasswordChar = '\0';
            this.txtPathAddr.ReadOnly = true;
            this.txtPathAddr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPathAddr.SelectedText = "";
            this.txtPathAddr.SelectionLength = 0;
            this.txtPathAddr.SelectionStart = 0;
            this.txtPathAddr.ShortcutsEnabled = true;
            this.txtPathAddr.Size = new System.Drawing.Size(331, 23);
            this.txtPathAddr.TabIndex = 1;
            this.txtPathAddr.UseSelectable = true;
            this.txtPathAddr.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPathAddr.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 85);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(91, 19);
            this.lblPath.TabIndex = 5;
            this.lblPath.Text = "Excel File Path";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseFile.AutoSize = true;
            this.btnChooseFile.Location = new System.Drawing.Point(444, 81);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(72, 29);
            this.btnChooseFile.TabIndex = 6;
            this.btnChooseFile.Text = "Browse";
            this.btnChooseFile.UseSelectable = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // comboImportOptions
            // 
            this.comboImportOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboImportOptions.Enabled = false;
            this.comboImportOptions.FormattingEnabled = true;
            this.comboImportOptions.ItemHeight = 23;
            this.comboImportOptions.Items.AddRange(new object[] {
            "New Record Type",
            "Existing Record Type"});
            this.comboImportOptions.Location = new System.Drawing.Point(107, 120);
            this.comboImportOptions.Name = "comboImportOptions";
            this.comboImportOptions.Size = new System.Drawing.Size(409, 29);
            this.comboImportOptions.TabIndex = 2;
            this.comboImportOptions.UseSelectable = true;
            this.comboImportOptions.SelectedIndexChanged += new System.EventHandler(this.comboImportOptions_SelectedIndexChanged);
            // 
            // lblImportMode
            // 
            this.lblImportMode.AutoSize = true;
            this.lblImportMode.Location = new System.Drawing.Point(12, 125);
            this.lblImportMode.Name = "lblImportMode";
            this.lblImportMode.Size = new System.Drawing.Size(89, 19);
            this.lblImportMode.TabIndex = 8;
            this.lblImportMode.Text = "Import Mode";
            // 
            // lblFieldAssignment
            // 
            this.lblFieldAssignment.AutoSize = true;
            this.lblFieldAssignment.Location = new System.Drawing.Point(12, 205);
            this.lblFieldAssignment.Name = "lblFieldAssignment";
            this.lblFieldAssignment.Size = new System.Drawing.Size(113, 19);
            this.lblFieldAssignment.TabIndex = 12;
            this.lblFieldAssignment.Text = "Field Assignments";
            // 
            // lblRecordType
            // 
            this.lblRecordType.AutoSize = true;
            this.lblRecordType.Location = new System.Drawing.Point(12, 165);
            this.lblRecordType.Name = "lblRecordType";
            this.lblRecordType.Size = new System.Drawing.Size(82, 19);
            this.lblRecordType.TabIndex = 13;
            this.lblRecordType.Text = "Record Type";
            // 
            // gridFieldAssignment
            // 
            this.gridFieldAssignment.AllowUserToAddRows = false;
            this.gridFieldAssignment.AllowUserToDeleteRows = false;
            this.gridFieldAssignment.AllowUserToResizeRows = false;
            this.gridFieldAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFieldAssignment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridFieldAssignment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridFieldAssignment.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridFieldAssignment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridFieldAssignment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridFieldAssignment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFieldAssignment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridFieldAssignment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFieldAssignment.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridFieldAssignment.Enabled = false;
            this.gridFieldAssignment.EnableHeadersVisualStyles = false;
            this.gridFieldAssignment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridFieldAssignment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridFieldAssignment.Location = new System.Drawing.Point(15, 227);
            this.gridFieldAssignment.MultiSelect = false;
            this.gridFieldAssignment.Name = "gridFieldAssignment";
            this.gridFieldAssignment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFieldAssignment.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridFieldAssignment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridFieldAssignment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFieldAssignment.Size = new System.Drawing.Size(501, 255);
            this.gridFieldAssignment.TabIndex = 11;
            this.gridFieldAssignment.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFieldAssignment_CellEndEdit);
            this.gridFieldAssignment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridFieldAssignment_MouseClick);
            // 
            // comboRecordTypeSelector
            // 
            this.comboRecordTypeSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboRecordTypeSelector.Enabled = false;
            this.comboRecordTypeSelector.FormattingEnabled = true;
            this.comboRecordTypeSelector.ItemHeight = 23;
            this.comboRecordTypeSelector.Location = new System.Drawing.Point(107, 165);
            this.comboRecordTypeSelector.Name = "comboRecordTypeSelector";
            this.comboRecordTypeSelector.Size = new System.Drawing.Size(409, 29);
            this.comboRecordTypeSelector.TabIndex = 3;
            this.comboRecordTypeSelector.UseSelectable = true;
            this.comboRecordTypeSelector.SelectedIndexChanged += new System.EventHandler(this.comboRecordTypeSelector_SelectedIndexChanged);
            // 
            // txtRecordTypeName
            // 
            this.txtRecordTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtRecordTypeName.CustomButton.Image = null;
            this.txtRecordTypeName.CustomButton.Location = new System.Drawing.Point(-22, 1);
            this.txtRecordTypeName.CustomButton.Name = "";
            this.txtRecordTypeName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRecordTypeName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRecordTypeName.CustomButton.TabIndex = 1;
            this.txtRecordTypeName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRecordTypeName.CustomButton.UseSelectable = true;
            this.txtRecordTypeName.CustomButton.Visible = false;
            this.txtRecordTypeName.Lines = new string[0];
            this.txtRecordTypeName.Location = new System.Drawing.Point(214, 39);
            this.txtRecordTypeName.MaxLength = 32767;
            this.txtRecordTypeName.Name = "txtRecordTypeName";
            this.txtRecordTypeName.PasswordChar = '\0';
            this.txtRecordTypeName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRecordTypeName.SelectedText = "";
            this.txtRecordTypeName.SelectionLength = 0;
            this.txtRecordTypeName.SelectionStart = 0;
            this.txtRecordTypeName.ShortcutsEnabled = true;
            this.txtRecordTypeName.Size = new System.Drawing.Size(0, 23);
            this.txtRecordTypeName.TabIndex = 14;
            this.txtRecordTypeName.UseSelectable = true;
            this.txtRecordTypeName.Visible = false;
            this.txtRecordTypeName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRecordTypeName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtRecordTypeName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRecordTypeName_KeyUp);
            // 
            // ImportRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 528);
            this.Controls.Add(this.txtRecordTypeName);
            this.Controls.Add(this.comboRecordTypeSelector);
            this.Controls.Add(this.lblRecordType);
            this.Controls.Add(this.lblFieldAssignment);
            this.Controls.Add(this.gridFieldAssignment);
            this.Controls.Add(this.lblImportMode);
            this.Controls.Add(this.comboImportOptions);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPathAddr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.MinimumSize = new System.Drawing.Size(528, 528);
            this.Name = "ImportRecords";
            this.Text = "Import Records";
            this.Resize += new System.EventHandler(this.ImportRecords_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldAssignment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroButton btnImport;
        private MetroButton btnCancel;
        private MetroTextBox txtPathAddr;
        private MetroLabel lblPath;
        private MetroButton btnChooseFile;
        private MetroComboBox comboImportOptions;
        private MetroLabel lblImportMode;
        private MetroLabel lblFieldAssignment;
        private MetroLabel lblRecordType;
        private MetroGrid gridFieldAssignment;
        private MetroComboBox comboRecordTypeSelector;
        private MetroTextBox txtRecordTypeName;
    }
}