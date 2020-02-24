namespace DataWrangler
{
    partial class Import
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
            this.comboImport = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPathAddr = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.folderImport = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSearchFold = new System.Windows.Forms.Button();
            this.listColumn = new System.Windows.Forms.ListBox();
            this.listField = new System.Windows.Forms.ListBox();
            this.listType = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboImport
            // 
            this.comboImport.FormattingEnabled = true;
            this.comboImport.Location = new System.Drawing.Point(381, 276);
            this.comboImport.Name = "comboImport";
            this.comboImport.Size = new System.Drawing.Size(255, 21);
            this.comboImport.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(288, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Import";
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.BackColor = System.Drawing.Color.SandyBrown;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Transparent;
            this.btnImport.Location = new System.Drawing.Point(481, 303);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 30);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.SandyBrown;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(562, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // txtPathAddr
            // 
            this.txtPathAddr.Location = new System.Drawing.Point(203, 82);
            this.txtPathAddr.Name = "txtPathAddr";
            this.txtPathAddr.Size = new System.Drawing.Size(327, 20);
            this.txtPathAddr.TabIndex = 4;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(156, 83);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(41, 20);
            this.lblPath.TabIndex = 5;
            this.lblPath.Text = "Path";
            // 
            // folderImport
            // 
            this.folderImport.HelpRequest += new System.EventHandler(this.folderImport_HelpRequest);
            // 
            // btnSearchFold
            // 
            this.btnSearchFold.AutoSize = true;
            this.btnSearchFold.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSearchFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchFold.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearchFold.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearchFold.Location = new System.Drawing.Point(536, 75);
            this.btnSearchFold.Name = "btnSearchFold";
            this.btnSearchFold.Size = new System.Drawing.Size(43, 31);
            this.btnSearchFold.TabIndex = 6;
            this.btnSearchFold.Text = "...";
            this.btnSearchFold.UseVisualStyleBackColor = false;
            // 
            // listColumn
            // 
            this.listColumn.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listColumn.FormattingEnabled = true;
            this.listColumn.ItemHeight = 20;
            this.listColumn.Location = new System.Drawing.Point(77, 130);
            this.listColumn.Name = "listColumn";
            this.listColumn.Size = new System.Drawing.Size(255, 104);
            this.listColumn.TabIndex = 7;
            // 
            // listField
            // 
            this.listField.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listField.FormattingEnabled = true;
            this.listField.ItemHeight = 20;
            this.listField.Location = new System.Drawing.Point(381, 130);
            this.listField.Name = "listField";
            this.listField.Size = new System.Drawing.Size(255, 104);
            this.listField.TabIndex = 8;
            // 
            // listType
            // 
            this.listType.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listType.FormattingEnabled = true;
            this.listType.ItemHeight = 20;
            this.listType.Location = new System.Drawing.Point(77, 282);
            this.listType.Name = "listType";
            this.listType.Size = new System.Drawing.Size(255, 104);
            this.listType.TabIndex = 9;
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(699, 425);
            this.Controls.Add(this.listType);
            this.Controls.Add(this.listField);
            this.Controls.Add(this.listColumn);
            this.Controls.Add(this.btnSearchFold);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPathAddr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboImport);
            this.Name = "Import";
            this.Text = "Data Wrangler Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPathAddr;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.FolderBrowserDialog folderImport;
        private System.Windows.Forms.Button btnSearchFold;
        private System.Windows.Forms.ListBox listColumn;
        private System.Windows.Forms.ListBox listField;
        private System.Windows.Forms.ListBox listType;
    }
}