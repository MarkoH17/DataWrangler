namespace DataWrangler.Forms
{
    partial class ManageRecordTypes
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
            this.EditRecordTypeButton = new MetroFramework.Controls.MetroButton();
            this.DeleteRecordTypeButton = new MetroFramework.Controls.MetroButton();
            this.CreateRecordTypeButton = new MetroFramework.Controls.MetroButton();
            this.RecordTypeGridView = new MetroFramework.Controls.MetroGrid();
            ((System.ComponentModel.ISupportInitialize)(this.RecordTypeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditRecordTypeButton
            // 
            this.EditRecordTypeButton.Enabled = false;
            this.EditRecordTypeButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.EditRecordTypeButton.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.EditRecordTypeButton.Location = new System.Drawing.Point(421, 403);
            this.EditRecordTypeButton.Name = "EditRecordTypeButton";
            this.EditRecordTypeButton.Size = new System.Drawing.Size(106, 23);
            this.EditRecordTypeButton.TabIndex = 1;
            this.EditRecordTypeButton.Text = "Edit Record Type";
            this.EditRecordTypeButton.UseSelectable = true;
            this.EditRecordTypeButton.Click += new System.EventHandler(this.EditRecordTypeButton_Click);
            // 
            // DeleteRecordTypeButton
            // 
            this.DeleteRecordTypeButton.Enabled = false;
            this.DeleteRecordTypeButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.DeleteRecordTypeButton.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.DeleteRecordTypeButton.Location = new System.Drawing.Point(533, 403);
            this.DeleteRecordTypeButton.Name = "DeleteRecordTypeButton";
            this.DeleteRecordTypeButton.Size = new System.Drawing.Size(118, 23);
            this.DeleteRecordTypeButton.TabIndex = 2;
            this.DeleteRecordTypeButton.Text = "Delete Record Type";
            this.DeleteRecordTypeButton.UseSelectable = true;
            // 
            // CreateRecordTypeButton
            // 
            this.CreateRecordTypeButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.CreateRecordTypeButton.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.CreateRecordTypeButton.Location = new System.Drawing.Point(657, 403);
            this.CreateRecordTypeButton.Name = "CreateRecordTypeButton";
            this.CreateRecordTypeButton.Size = new System.Drawing.Size(120, 23);
            this.CreateRecordTypeButton.TabIndex = 3;
            this.CreateRecordTypeButton.Text = "Create Record Type";
            this.CreateRecordTypeButton.UseSelectable = true;
            // 
            // RecordTypeGridView
            // 
            this.RecordTypeGridView.AllowUserToAddRows = false;
            this.RecordTypeGridView.AllowUserToDeleteRows = false;
            this.RecordTypeGridView.AllowUserToResizeRows = false;
            this.RecordTypeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RecordTypeGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RecordTypeGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RecordTypeGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.RecordTypeGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RecordTypeGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RecordTypeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RecordTypeGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.RecordTypeGridView.EnableHeadersVisualStyles = false;
            this.RecordTypeGridView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.RecordTypeGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RecordTypeGridView.Location = new System.Drawing.Point(23, 63);
            this.RecordTypeGridView.Name = "RecordTypeGridView";
            this.RecordTypeGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RecordTypeGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.RecordTypeGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RecordTypeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RecordTypeGridView.Size = new System.Drawing.Size(754, 334);
            this.RecordTypeGridView.TabIndex = 4;
            this.RecordTypeGridView.VirtualMode = true;
            this.RecordTypeGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.RecordTypeGridView_CellValueNeeded);
            this.RecordTypeGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RecordTypeGridView_MouseClick);
            // 
            // ManageRecordTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RecordTypeGridView);
            this.Controls.Add(this.CreateRecordTypeButton);
            this.Controls.Add(this.DeleteRecordTypeButton);
            this.Controls.Add(this.EditRecordTypeButton);
            this.Name = "ManageRecordTypes";
            this.Text = "Record Type Management";
            ((System.ComponentModel.ISupportInitialize)(this.RecordTypeGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton EditRecordTypeButton;
        private MetroFramework.Controls.MetroButton DeleteRecordTypeButton;
        private MetroFramework.Controls.MetroButton CreateRecordTypeButton;
        private MetroFramework.Controls.MetroGrid RecordTypeGridView;
    }
}