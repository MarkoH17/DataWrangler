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
            this.lblEditRecord = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtRecId = new System.Windows.Forms.TextBox();
            this.txtRecType = new System.Windows.Forms.TextBox();
            this.lblTypeId = new System.Windows.Forms.Label();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.gridAuditHistory = new System.Windows.Forms.DataGridView();
            this.tabAttributes = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditHistory)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEditRecord
            // 
            this.lblEditRecord.AutoSize = true;
            this.lblEditRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditRecord.ForeColor = System.Drawing.Color.Black;
            this.lblEditRecord.Location = new System.Drawing.Point(67, 9);
            this.lblEditRecord.Name = "lblEditRecord";
            this.lblEditRecord.Size = new System.Drawing.Size(183, 37);
            this.lblEditRecord.TabIndex = 0;
            this.lblEditRecord.Text = "Edit Record";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 61);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(56, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Record ID";
            // 
            // txtRecId
            // 
            this.txtRecId.Enabled = false;
            this.txtRecId.Location = new System.Drawing.Point(87, 58);
            this.txtRecId.Name = "txtRecId";
            this.txtRecId.ReadOnly = true;
            this.txtRecId.Size = new System.Drawing.Size(241, 20);
            this.txtRecId.TabIndex = 2;
            // 
            // txtRecType
            // 
            this.txtRecType.Enabled = false;
            this.txtRecType.Location = new System.Drawing.Point(87, 91);
            this.txtRecType.Name = "txtRecType";
            this.txtRecType.ReadOnly = true;
            this.txtRecType.Size = new System.Drawing.Size(241, 20);
            this.txtRecType.TabIndex = 3;
            // 
            // lblTypeId
            // 
            this.lblTypeId.AutoSize = true;
            this.lblTypeId.Location = new System.Drawing.Point(12, 91);
            this.lblTypeId.Name = "lblTypeId";
            this.lblTypeId.Size = new System.Drawing.Size(69, 13);
            this.lblTypeId.TabIndex = 4;
            this.lblTypeId.Text = "Record Type";
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.gridAuditHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 22);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(305, 187);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "History";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // gridAuditHistory
            // 
            this.gridAuditHistory.AllowUserToAddRows = false;
            this.gridAuditHistory.AllowUserToDeleteRows = false;
            this.gridAuditHistory.AllowUserToResizeRows = false;
            this.gridAuditHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAuditHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAuditHistory.Location = new System.Drawing.Point(3, 3);
            this.gridAuditHistory.Name = "gridAuditHistory";
            this.gridAuditHistory.ReadOnly = true;
            this.gridAuditHistory.RowHeadersVisible = false;
            this.gridAuditHistory.Size = new System.Drawing.Size(299, 181);
            this.gridAuditHistory.TabIndex = 0;
            this.gridAuditHistory.VirtualMode = true;
            this.gridAuditHistory.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridAuditHistory_CellValueNeeded);
            // 
            // tabAttributes
            // 
            this.tabAttributes.AutoScroll = true;
            this.tabAttributes.Location = new System.Drawing.Point(4, 22);
            this.tabAttributes.Name = "tabAttributes";
            this.tabAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributes.Size = new System.Drawing.Size(305, 187);
            this.tabAttributes.TabIndex = 0;
            this.tabAttributes.Text = "Attributes";
            this.tabAttributes.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAttributes);
            this.tabControl1.Controls.Add(this.tabHistory);
            this.tabControl1.Location = new System.Drawing.Point(15, 129);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(313, 213);
            this.tabControl1.TabIndex = 5;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(253, 348);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(172, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAttachments
            // 
            this.btnAttachments.Location = new System.Drawing.Point(15, 348);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(75, 23);
            this.btnAttachments.TabIndex = 8;
            this.btnAttachments.Text = "Attachments";
            this.btnAttachments.UseVisualStyleBackColor = true;
            // 
            // EditRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(346, 378);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTypeId);
            this.Controls.Add(this.txtRecType);
            this.Controls.Add(this.txtRecId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblEditRecord);
            this.Name = "EditRecord";
            this.Text = "Data Wrangler Record";
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditHistory)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEditRecord;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtRecId;
        private System.Windows.Forms.TextBox txtRecType;
        private System.Windows.Forms.Label lblTypeId;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.TabPage tabAttributes;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAttachments;
        private System.Windows.Forms.DataGridView gridAuditHistory;
    }
}