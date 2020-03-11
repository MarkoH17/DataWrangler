using System.Windows.Forms;
using MetroFramework.Controls;

namespace DataWrangler.Forms
{
    partial class EditRecord
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
            this.lblId = new MetroFramework.Controls.MetroLabel();
            this.txtRecId = new MetroFramework.Controls.MetroTextBox();
            this.txtRecType = new MetroFramework.Controls.MetroTextBox();
            this.lblTypeId = new MetroFramework.Controls.MetroLabel();
            this.tabHistory = new MetroFramework.Controls.MetroTabPage();
            this.gridAuditHistory = new MetroFramework.Controls.MetroGrid();
            this.tabAttributes = new MetroFramework.Controls.MetroTabPage();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabAttachments = new MetroFramework.Controls.MetroTabPage();
            this.listAttachments = new MetroFramework.Controls.MetroListView();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditHistory)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabAttachments.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 62);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(67, 19);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Record ID";
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
            // txtRecType
            // 
            // 
            // 
            // 
            this.txtRecType.CustomButton.Image = null;
            this.txtRecType.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.txtRecType.CustomButton.Name = "";
            this.txtRecType.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRecType.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRecType.CustomButton.TabIndex = 1;
            this.txtRecType.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRecType.CustomButton.UseSelectable = true;
            this.txtRecType.CustomButton.Visible = false;
            this.txtRecType.Enabled = false;
            this.txtRecType.Lines = new string[0];
            this.txtRecType.Location = new System.Drawing.Point(242, 61);
            this.txtRecType.MaxLength = 32767;
            this.txtRecType.Name = "txtRecType";
            this.txtRecType.PasswordChar = '\0';
            this.txtRecType.ReadOnly = true;
            this.txtRecType.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRecType.SelectedText = "";
            this.txtRecType.SelectionLength = 0;
            this.txtRecType.SelectionStart = 0;
            this.txtRecType.ShortcutsEnabled = true;
            this.txtRecType.Size = new System.Drawing.Size(175, 23);
            this.txtRecType.TabIndex = 3;
            this.txtRecType.UseSelectable = true;
            this.txtRecType.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRecType.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblTypeId
            // 
            this.lblTypeId.AutoSize = true;
            this.lblTypeId.Location = new System.Drawing.Point(154, 62);
            this.lblTypeId.Name = "lblTypeId";
            this.lblTypeId.Size = new System.Drawing.Size(82, 19);
            this.lblTypeId.TabIndex = 4;
            this.lblTypeId.Text = "Record Type";
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.gridAuditHistory);
            this.tabHistory.HorizontalScrollbarBarColor = true;
            this.tabHistory.HorizontalScrollbarHighlightOnWheel = false;
            this.tabHistory.HorizontalScrollbarSize = 10;
            this.tabHistory.Location = new System.Drawing.Point(4, 38);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(408, 284);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "History";
            this.tabHistory.UseVisualStyleBackColor = true;
            this.tabHistory.VerticalScrollbarBarColor = true;
            this.tabHistory.VerticalScrollbarHighlightOnWheel = false;
            this.tabHistory.VerticalScrollbarSize = 10;
            // 
            // gridAuditHistory
            // 
            this.gridAuditHistory.AllowUserToAddRows = false;
            this.gridAuditHistory.AllowUserToDeleteRows = false;
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
            this.gridAuditHistory.Location = new System.Drawing.Point(3, 3);
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
            this.gridAuditHistory.Size = new System.Drawing.Size(402, 278);
            this.gridAuditHistory.TabIndex = 0;
            this.gridAuditHistory.VirtualMode = true;
            this.gridAuditHistory.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridAuditHistory_CellValueNeeded);
            // 
            // tabAttributes
            // 
            this.tabAttributes.AutoScroll = true;
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAttributes);
            this.tabControl.Controls.Add(this.tabAttachments);
            this.tabControl.Controls.Add(this.tabHistory);
            this.tabControl.Location = new System.Drawing.Point(12, 99);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 1;
            this.tabControl.Size = new System.Drawing.Size(416, 326);
            this.tabControl.TabIndex = 5;
            this.tabControl.UseSelectable = true;
            // 
            // tabAttachments
            // 
            this.tabAttachments.Controls.Add(this.listAttachments);
            this.tabAttachments.HorizontalScrollbarBarColor = true;
            this.tabAttachments.HorizontalScrollbarHighlightOnWheel = false;
            this.tabAttachments.HorizontalScrollbarSize = 10;
            this.tabAttachments.Location = new System.Drawing.Point(4, 38);
            this.tabAttachments.Name = "tabAttachments";
            this.tabAttachments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttachments.Size = new System.Drawing.Size(408, 284);
            this.tabAttachments.TabIndex = 2;
            this.tabAttachments.Text = "Attachments";
            this.tabAttachments.UseVisualStyleBackColor = true;
            this.tabAttachments.VerticalScrollbarBarColor = true;
            this.tabAttachments.VerticalScrollbarHighlightOnWheel = false;
            this.tabAttachments.VerticalScrollbarSize = 10;
            // 
            // listAttachments
            // 
            this.listAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAttachments.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listAttachments.FullRowSelect = true;
            this.listAttachments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listAttachments.Location = new System.Drawing.Point(3, 3);
            this.listAttachments.MultiSelect = false;
            this.listAttachments.Name = "listAttachments";
            this.listAttachments.OwnerDraw = true;
            this.listAttachments.Scrollable = false;
            this.listAttachments.Size = new System.Drawing.Size(402, 278);
            this.listAttachments.TabIndex = 0;
            this.listAttachments.UseCompatibleStateImageBehavior = false;
            this.listAttachments.UseSelectable = true;
            this.listAttachments.View = System.Windows.Forms.View.Details;
            this.listAttachments.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listAttachments_MouseUp);
            // 
            // btnUpdate
            // 
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
            // EditRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 464);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblTypeId);
            this.Controls.Add(this.txtRecType);
            this.Controls.Add(this.txtRecId);
            this.Controls.Add(this.lblId);
            this.Name = "EditRecord";
            this.Resizable = false;
            this.Text = "Edit Record";
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditHistory)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabAttachments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroLabel lblId;
        private MetroTextBox txtRecId;
        private MetroTextBox txtRecType;
        private MetroLabel lblTypeId;
        private MetroTabPage tabHistory;
        private MetroTabPage tabAttributes;
        private MetroTabControl tabControl;
        private MetroButton btnUpdate;
        private MetroButton btnCancel;
        private MetroGrid gridAuditHistory;
        private MetroTabPage tabAttachments;
        private MetroLabel metroLabel1;
        private MetroListView listAttachments;
    }
}