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
            this.label1 = new System.Windows.Forms.Label();
            this.dataRecordView = new System.Windows.Forms.DataGridView();
            this.AttributeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHistory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataRecordView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(159, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Record";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataRecordView
            // 
            this.dataRecordView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRecordView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttributeType,
            this.DataValue});
            this.dataRecordView.Location = new System.Drawing.Point(52, 59);
            this.dataRecordView.Name = "dataRecordView";
            this.dataRecordView.Size = new System.Drawing.Size(332, 233);
            this.dataRecordView.TabIndex = 1;
            this.dataRecordView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataRecordView_CellContentClick);
            // 
            // AttributeType
            // 
            this.AttributeType.HeaderText = "Attribute";
            this.AttributeType.Name = "AttributeType";
            // 
            // DataValue
            // 
            this.DataValue.HeaderText = "Data";
            this.DataValue.Name = "DataValue";
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.Gray;
            this.btnHistory.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.Transparent;
            this.btnHistory.Location = new System.Drawing.Point(288, 298);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(96, 47);
            this.btnHistory.TabIndex = 2;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(429, 378);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.dataRecordView);
            this.Controls.Add(this.label1);
            this.Name = "Record";
            this.Text = "Data Wrangler Record";
            ((System.ComponentModel.ISupportInitialize)(this.dataRecordView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataRecordView;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataValue;
        private System.Windows.Forms.Button btnHistory;
    }
}