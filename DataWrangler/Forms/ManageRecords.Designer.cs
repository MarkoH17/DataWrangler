using System.Windows.Forms;
using MetroFramework.Controls;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRowCnt = new MetroFramework.Controls.MetroTextBox();
            this.lblCount = new MetroFramework.Controls.MetroLabel();
            this.comboRecType = new MetroFramework.Controls.MetroComboBox();
            this.lblField = new MetroFramework.Controls.MetroLabel();
            this.lblFieldSearch = new MetroFramework.Controls.MetroLabel();
            this.txtFieldSearch = new MetroFramework.Controls.MetroTextBox();
            this.btnAdvSearch = new MetroFramework.Controls.MetroButton();
            this.lblHorSep1 = new MetroFramework.Controls.MetroLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.subTblCol3 = new System.Windows.Forms.TableLayoutPanel();
            this.subTblCol1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecType = new MetroFramework.Controls.MetroLabel();
            this.subTblCol2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboField = new MetroFramework.Controls.MetroComboBox();
            this.lblHorSep2 = new MetroFramework.Controls.MetroLabel();
            this.gridRecords = new MetroFramework.Controls.MetroGrid();
            this.tableLayoutPanel1.SuspendLayout();
            this.subTblCol3.SuspendLayout();
            this.subTblCol1.SuspendLayout();
            this.subTblCol2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRowCnt
            // 
            this.txtRowCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtRowCnt.CustomButton.Image = null;
            this.txtRowCnt.CustomButton.Location = new System.Drawing.Point(62, 1);
            this.txtRowCnt.CustomButton.Name = "";
            this.txtRowCnt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRowCnt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRowCnt.CustomButton.TabIndex = 1;
            this.txtRowCnt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRowCnt.CustomButton.UseSelectable = true;
            this.txtRowCnt.CustomButton.Visible = false;
            this.txtRowCnt.Enabled = false;
            this.txtRowCnt.Lines = new string[0];
            this.txtRowCnt.Location = new System.Drawing.Point(904, 514);
            this.txtRowCnt.MaxLength = 32767;
            this.txtRowCnt.Name = "txtRowCnt";
            this.txtRowCnt.PasswordChar = '\0';
            this.txtRowCnt.ReadOnly = true;
            this.txtRowCnt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRowCnt.SelectedText = "";
            this.txtRowCnt.SelectionLength = 0;
            this.txtRowCnt.SelectionStart = 0;
            this.txtRowCnt.ShortcutsEnabled = true;
            this.txtRowCnt.Size = new System.Drawing.Size(84, 23);
            this.txtRowCnt.TabIndex = 5;
            this.txtRowCnt.UseSelectable = true;
            this.txtRowCnt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRowCnt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(854, 514);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(44, 19);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Count";
            // 
            // comboRecType
            // 
            this.comboRecType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboRecType.FormattingEnabled = true;
            this.comboRecType.ItemHeight = 23;
            this.comboRecType.Location = new System.Drawing.Point(97, 6);
            this.comboRecType.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.comboRecType.Name = "comboRecType";
            this.comboRecType.Size = new System.Drawing.Size(215, 29);
            this.comboRecType.TabIndex = 7;
            this.comboRecType.UseSelectable = true;
            this.comboRecType.SelectedIndexChanged += new System.EventHandler(this.comboRecType_SelectedIndexChanged);
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblField.Location = new System.Drawing.Point(3, 0);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(38, 40);
            this.lblField.TabIndex = 9;
            this.lblField.Text = "Field";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFieldSearch
            // 
            this.lblFieldSearch.AutoSize = true;
            this.lblFieldSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFieldSearch.Location = new System.Drawing.Point(3, 0);
            this.lblFieldSearch.Name = "lblFieldSearch";
            this.lblFieldSearch.Size = new System.Drawing.Size(80, 40);
            this.lblFieldSearch.TabIndex = 11;
            this.lblFieldSearch.Text = "Field Search";
            this.lblFieldSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFieldSearch
            // 
            // 
            // 
            // 
            this.txtFieldSearch.CustomButton.Image = null;
            this.txtFieldSearch.CustomButton.Location = new System.Drawing.Point(193, 2);
            this.txtFieldSearch.CustomButton.Name = "";
            this.txtFieldSearch.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.txtFieldSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFieldSearch.CustomButton.TabIndex = 1;
            this.txtFieldSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFieldSearch.CustomButton.UseSelectable = true;
            this.txtFieldSearch.CustomButton.Visible = false;
            this.txtFieldSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFieldSearch.Enabled = false;
            this.txtFieldSearch.Lines = new string[0];
            this.txtFieldSearch.Location = new System.Drawing.Point(89, 3);
            this.txtFieldSearch.MaxLength = 32767;
            this.txtFieldSearch.Name = "txtFieldSearch";
            this.txtFieldSearch.PasswordChar = '\0';
            this.txtFieldSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFieldSearch.SelectedText = "";
            this.txtFieldSearch.SelectionLength = 0;
            this.txtFieldSearch.SelectionStart = 0;
            this.txtFieldSearch.ShortcutsEnabled = true;
            this.txtFieldSearch.Size = new System.Drawing.Size(225, 34);
            this.txtFieldSearch.TabIndex = 12;
            this.txtFieldSearch.UseSelectable = true;
            this.txtFieldSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFieldSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFieldSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFieldSearch_KeyDown);
            // 
            // btnAdvSearch
            // 
            this.btnAdvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdvSearch.Enabled = false;
            this.btnAdvSearch.Location = new System.Drawing.Point(12, 514);
            this.btnAdvSearch.Name = "btnAdvSearch";
            this.btnAdvSearch.Size = new System.Drawing.Size(111, 23);
            this.btnAdvSearch.TabIndex = 13;
            this.btnAdvSearch.Text = "Advanced Search...";
            this.btnAdvSearch.UseSelectable = true;
            // 
            // lblHorSep1
            // 
            this.lblHorSep1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorSep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHorSep1.Location = new System.Drawing.Point(15, 120);
            this.lblHorSep1.Name = "lblHorSep1";
            this.lblHorSep1.Size = new System.Drawing.Size(962, 2);
            this.lblHorSep1.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.subTblCol3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.subTblCol1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.subTblCol2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 71);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(965, 46);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // subTblCol3
            // 
            this.subTblCol3.ColumnCount = 2;
            this.subTblCol3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.subTblCol3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.subTblCol3.Controls.Add(this.lblFieldSearch, 0, 0);
            this.subTblCol3.Controls.Add(this.txtFieldSearch, 1, 0);
            this.subTblCol3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subTblCol3.Location = new System.Drawing.Point(645, 3);
            this.subTblCol3.Name = "subTblCol3";
            this.subTblCol3.RowCount = 1;
            this.subTblCol3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.subTblCol3.Size = new System.Drawing.Size(317, 40);
            this.subTblCol3.TabIndex = 16;
            // 
            // subTblCol1
            // 
            this.subTblCol1.ColumnCount = 2;
            this.subTblCol1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.subTblCol1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.subTblCol1.Controls.Add(this.lblRecType, 0, 0);
            this.subTblCol1.Controls.Add(this.comboRecType, 1, 0);
            this.subTblCol1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subTblCol1.Location = new System.Drawing.Point(3, 3);
            this.subTblCol1.Name = "subTblCol1";
            this.subTblCol1.RowCount = 1;
            this.subTblCol1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.subTblCol1.Size = new System.Drawing.Size(315, 40);
            this.subTblCol1.TabIndex = 16;
            // 
            // lblRecType
            // 
            this.lblRecType.AutoSize = true;
            this.lblRecType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecType.Location = new System.Drawing.Point(3, 0);
            this.lblRecType.Name = "lblRecType";
            this.lblRecType.Size = new System.Drawing.Size(88, 40);
            this.lblRecType.TabIndex = 8;
            this.lblRecType.Text = "Record Type";
            this.lblRecType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subTblCol2
            // 
            this.subTblCol2.ColumnCount = 2;
            this.subTblCol2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.subTblCol2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.subTblCol2.Controls.Add(this.lblField, 0, 0);
            this.subTblCol2.Controls.Add(this.comboField, 1, 0);
            this.subTblCol2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subTblCol2.Location = new System.Drawing.Point(324, 3);
            this.subTblCol2.Name = "subTblCol2";
            this.subTblCol2.RowCount = 1;
            this.subTblCol2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.subTblCol2.Size = new System.Drawing.Size(315, 40);
            this.subTblCol2.TabIndex = 16;
            // 
            // comboField
            // 
            this.comboField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboField.Enabled = false;
            this.comboField.FormattingEnabled = true;
            this.comboField.ItemHeight = 23;
            this.comboField.Location = new System.Drawing.Point(47, 6);
            this.comboField.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.comboField.Name = "comboField";
            this.comboField.Size = new System.Drawing.Size(265, 29);
            this.comboField.TabIndex = 10;
            this.comboField.UseSelectable = true;
            this.comboField.SelectedIndexChanged += new System.EventHandler(this.comboField_SelectedIndexChanged);
            // 
            // lblHorSep2
            // 
            this.lblHorSep2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorSep2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHorSep2.Location = new System.Drawing.Point(12, 504);
            this.lblHorSep2.Margin = new System.Windows.Forms.Padding(0);
            this.lblHorSep2.Name = "lblHorSep2";
            this.lblHorSep2.Size = new System.Drawing.Size(976, 2);
            this.lblHorSep2.TabIndex = 16;
            // 
            // gridRecords
            // 
            this.gridRecords.AllowUserToAddRows = false;
            this.gridRecords.AllowUserToDeleteRows = false;
            this.gridRecords.AllowUserToResizeRows = false;
            this.gridRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRecords.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridRecords.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridRecords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRecords.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridRecords.Enabled = false;
            this.gridRecords.EnableHeadersVisualStyles = false;
            this.gridRecords.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridRecords.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridRecords.Location = new System.Drawing.Point(12, 127);
            this.gridRecords.MultiSelect = false;
            this.gridRecords.Name = "gridRecords";
            this.gridRecords.ReadOnly = true;
            this.gridRecords.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridRecords.RowHeadersVisible = false;
            this.gridRecords.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRecords.Size = new System.Drawing.Size(965, 368);
            this.gridRecords.TabIndex = 4;
            this.gridRecords.VirtualMode = true;
            this.gridRecords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRecords_CellDoubleClick);
            this.gridRecords.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridRecords_CellValueNeeded);
            this.gridRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridRecords_MouseClick);
            // 
            // ManageRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.lblHorSep2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblHorSep1);
            this.Controls.Add(this.btnAdvSearch);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtRowCnt);
            this.Controls.Add(this.gridRecords);
            this.MinimumSize = new System.Drawing.Size(1000, 550);
            this.Name = "ManageRecords";
            this.Text = "Manage Records";
            this.Load += new System.EventHandler(this.ManageRecords_Load);
            this.Resize += new System.EventHandler(this.ManageRecords_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.subTblCol3.ResumeLayout(false);
            this.subTblCol3.PerformLayout();
            this.subTblCol1.ResumeLayout(false);
            this.subTblCol1.PerformLayout();
            this.subTblCol2.ResumeLayout(false);
            this.subTblCol2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroTextBox txtRowCnt;
        private MetroLabel lblCount;
        private MetroComboBox comboRecType;
        private MetroLabel lblField;
        private MetroLabel lblFieldSearch;
        private MetroTextBox txtFieldSearch;
        private MetroButton btnAdvSearch;
        private MetroLabel lblHorSep1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel subTblCol1;
        private MetroLabel lblRecType;
        private TableLayoutPanel subTblCol2;
        private MetroComboBox comboField;
        private TableLayoutPanel subTblCol3;
        private MetroLabel lblHorSep2;
        private MetroGrid gridRecords;
    }
}