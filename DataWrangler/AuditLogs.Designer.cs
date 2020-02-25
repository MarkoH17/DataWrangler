namespace DataWrangler
{
    partial class AuditLogs
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
            this.comboUserSelect = new System.Windows.Forms.ComboBox();
            this.btnLookUp = new System.Windows.Forms.Button();
            this.lblAuditLogs = new System.Windows.Forms.Label();
            this.dataAuditLogs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataAuditLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // comboUserSelect
            // 
            this.comboUserSelect.FormattingEnabled = true;
            this.comboUserSelect.Location = new System.Drawing.Point(140, 116);
            this.comboUserSelect.Name = "comboUserSelect";
            this.comboUserSelect.Size = new System.Drawing.Size(371, 23);
            this.comboUserSelect.TabIndex = 0;
            this.comboUserSelect.Text = "Select a user...";
            // 
            // btnLookUp
            // 
            this.btnLookUp.BackColor = System.Drawing.Color.Gray;
            this.btnLookUp.ForeColor = System.Drawing.Color.Transparent;
            this.btnLookUp.Location = new System.Drawing.Point(532, 116);
            this.btnLookUp.Name = "btnLookUp";
            this.btnLookUp.Size = new System.Drawing.Size(75, 23);
            this.btnLookUp.TabIndex = 1;
            this.btnLookUp.Text = "Look Up";
            this.btnLookUp.UseVisualStyleBackColor = false;
            // 
            // lblAuditLogs
            // 
            this.lblAuditLogs.AutoSize = true;
            this.lblAuditLogs.Font = new System.Drawing.Font("Bernard MT Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditLogs.Location = new System.Drawing.Point(260, 9);
            this.lblAuditLogs.Name = "lblAuditLogs";
            this.lblAuditLogs.Size = new System.Drawing.Size(215, 57);
            this.lblAuditLogs.TabIndex = 2;
            this.lblAuditLogs.Text = "Audit Logs";
            // 
            // dataAuditLogs
            // 
            this.dataAuditLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAuditLogs.Location = new System.Drawing.Point(140, 179);
            this.dataAuditLogs.Name = "dataAuditLogs";
            this.dataAuditLogs.Size = new System.Drawing.Size(467, 251);
            this.dataAuditLogs.TabIndex = 3;
            // 
            // AuditLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(717, 471);
            this.Controls.Add(this.dataAuditLogs);
            this.Controls.Add(this.lblAuditLogs);
            this.Controls.Add(this.btnLookUp);
            this.Controls.Add(this.comboUserSelect);
            this.Font = new System.Drawing.Font("Book Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AuditLogs";
            this.Text = "Data Wrangler Audit Logs";
            ((System.ComponentModel.ISupportInitialize)(this.dataAuditLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboUserSelect;
        private System.Windows.Forms.Button btnLookUp;
        private System.Windows.Forms.Label lblAuditLogs;
        private System.Windows.Forms.DataGridView dataAuditLogs;
    }
}