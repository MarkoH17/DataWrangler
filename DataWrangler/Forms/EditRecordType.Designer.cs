using System.Windows.Forms;
using MetroFramework.Controls;

namespace DataWrangler.Forms
{
    partial class EditRecordType
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
            this.lblRecTypeId = new MetroFramework.Controls.MetroLabel();
            this.txtRecId = new MetroFramework.Controls.MetroTextBox();
            this.txtRecTypeName = new MetroFramework.Controls.MetroTextBox();
            this.lblTypeName = new MetroFramework.Controls.MetroLabel();
            this.tabAttributes = new MetroFramework.Controls.MetroTabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.gridAuditHistory = new MetroFramework.Controls.MetroGrid();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tabAttributes.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecTypeId
            // 
            this.lblRecTypeId.AutoSize = true;
            this.lblRecTypeId.Location = new System.Drawing.Point(12, 62);
            this.lblRecTypeId.Name = "lblRecTypeId";
            this.lblRecTypeId.Size = new System.Drawing.Size(67, 19);
            this.lblRecTypeId.TabIndex = 1;
            this.lblRecTypeId.Text = "Record ID";
            // 
            // txtRecId
            // 
            // 
            // 
            // 
            this.txtRecId.CustomButton.Image = null;
            this.txtRecId.CustomButton.Location = new System.Drawing.Point(41, 1);
            this.txtRecId.CustomButton.Name = "";
            this.txtRecId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRecId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRecId.CustomButton.TabIndex = 1;
            this.txtRecId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRecId.CustomButton.UseSelectable = true;
            this.txtRecId.CustomButton.Visible = false;
            this.txtRecId.Enabled = false;
            this.txtRecId.Lines = new string[0];
            this.txtRecId.Location = new System.Drawing.Point(85, 61);
            this.txtRecId.MaxLength = 32767;
            this.txtRecId.Name = "txtRecId";
            this.txtRecId.PasswordChar = '\0';
            this.txtRecId.ReadOnly = true;
            this.txtRecId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRecId.SelectedText = "";
            this.txtRecId.SelectionLength = 0;
            this.txtRecId.SelectionStart = 0;
            this.txtRecId.ShortcutsEnabled = true;
            this.txtRecId.Size = new System.Drawing.Size(63, 23);
            this.txtRecId.TabIndex = 2;
            this.txtRecId.UseSelectable = true;
            this.txtRecId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRecId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtRecTypeName
            // 
            this.txtRecTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtRecTypeName.CustomButton.Image = null;
            this.txtRecTypeName.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.txtRecTypeName.CustomButton.Name = "";
            this.txtRecTypeName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRecTypeName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRecTypeName.CustomButton.TabIndex = 1;
            this.txtRecTypeName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRecTypeName.CustomButton.UseSelectable = true;
            this.txtRecTypeName.CustomButton.Visible = false;
            this.txtRecTypeName.Lines = new string[0];
            this.txtRecTypeName.Location = new System.Drawing.Point(242, 61);
            this.txtRecTypeName.MaxLength = 32767;
            this.txtRecTypeName.Name = "txtRecTypeName";
            this.txtRecTypeName.PasswordChar = '\0';
            this.txtRecTypeName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRecTypeName.SelectedText = "";
            this.txtRecTypeName.SelectionLength = 0;
            this.txtRecTypeName.SelectionStart = 0;
            this.txtRecTypeName.ShortcutsEnabled = true;
            this.txtRecTypeName.Size = new System.Drawing.Size(175, 23);
            this.txtRecTypeName.TabIndex = 3;
            this.txtRecTypeName.UseSelectable = true;
            this.txtRecTypeName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRecTypeName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtRecTypeName.TextChanged += new System.EventHandler(this.txtRecType_TextChanged);
            // 
            // lblTypeName
            // 
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Location = new System.Drawing.Point(154, 62);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(76, 19);
            this.lblTypeName.TabIndex = 4;
            this.lblTypeName.Text = "Type Name";
            // 
            // tabAttributes
            // 
            this.tabAttributes.AutoScroll = true;
            this.tabAttributes.Controls.Add(this.tableLayoutPanel1);
            this.tabAttributes.HorizontalScrollbar = true;
            this.tabAttributes.HorizontalScrollbarBarColor = true;
            this.tabAttributes.HorizontalScrollbarHighlightOnWheel = false;
            this.tabAttributes.HorizontalScrollbarSize = 10;
            this.tabAttributes.Location = new System.Drawing.Point(4, 38);
            this.tabAttributes.Name = "tabAttributes";
            this.tabAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributes.Size = new System.Drawing.Size(408, 284);
            this.tabAttributes.TabIndex = 0;
            this.tabAttributes.Text = "Attributes";
            this.tabAttributes.UseVisualStyleBackColor = true;
            this.tabAttributes.VerticalScrollbar = true;
            this.tabAttributes.VerticalScrollbarBarColor = true;
            this.tabAttributes.VerticalScrollbarHighlightOnWheel = false;
            this.tabAttributes.VerticalScrollbarSize = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 278F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 278);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAttributes);
            this.tabControl1.Controls.Add(this.tabHistory);
            this.tabControl1.Location = new System.Drawing.Point(12, 99);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(416, 326);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.UseSelectable = true;
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.gridAuditHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 38);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(408, 284);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "History";
            // 
            // gridAuditHistory
            // 
            this.gridAuditHistory.AllowUserToAddRows = false;
            this.gridAuditHistory.AllowUserToDeleteRows = false;
            this.gridAuditHistory.AllowUserToResizeColumns = false;
            this.gridAuditHistory.AllowUserToResizeRows = false;
            this.gridAuditHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAuditHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridAuditHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridAuditHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridAuditHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAuditHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAuditHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAuditHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridAuditHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAuditHistory.EnableHeadersVisualStyles = false;
            this.gridAuditHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridAuditHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridAuditHistory.Location = new System.Drawing.Point(0, 0);
            this.gridAuditHistory.MultiSelect = false;
            this.gridAuditHistory.Name = "gridAuditHistory";
            this.gridAuditHistory.ReadOnly = true;
            this.gridAuditHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAuditHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridAuditHistory.RowHeadersVisible = false;
            this.gridAuditHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridAuditHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAuditHistory.Size = new System.Drawing.Size(408, 284);
            this.gridAuditHistory.TabIndex = 0;
            this.gridAuditHistory.VirtualMode = true;
            this.gridAuditHistory.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridAuditHistory_CellValueNeeded);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(353, 431);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Close";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(272, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroLabel1.Location = new System.Drawing.Point(12, 94);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(416, 2);
            this.metroLabel1.TabIndex = 8;
            // 
            // EditRecordType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 464);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.txtRecTypeName);
            this.Controls.Add(this.txtRecId);
            this.Controls.Add(this.lblRecTypeId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRecordType";
            this.Resizable = false;
            this.Text = "Edit Record Type";
            this.tabAttributes.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroLabel lblRecTypeId;
        private MetroTextBox txtRecId;
        private MetroTextBox txtRecTypeName;
        private MetroLabel lblTypeName;
        private MetroTabPage tabAttributes;
        private MetroTabControl tabControl1;
        private MetroButton btnUpdate;
        private MetroButton btnCancel;
        private MetroLabel metroLabel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TabPage tabHistory;
        private MetroGrid gridAuditHistory;
    }
}