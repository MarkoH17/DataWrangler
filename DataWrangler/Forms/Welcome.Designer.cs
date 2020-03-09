namespace DataWrangler.Forms
{
    partial class Welcome
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
            this.NextButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioNewSystem = new System.Windows.Forms.RadioButton();
            this.radioExistingSystem = new System.Windows.Forms.RadioButton();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.FileBrowseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NextButton
            // 
            this.NextButton.Enabled = false;
            this.NextButton.Location = new System.Drawing.Point(413, 286);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(207, 45);
            this.NextButton.TabIndex = 3;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path";
            // 
            // radioNewSystem
            // 
            this.radioNewSystem.AutoSize = true;
            this.radioNewSystem.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNewSystem.Location = new System.Drawing.Point(17, 17);
            this.radioNewSystem.Name = "radioNewSystem";
            this.radioNewSystem.Size = new System.Drawing.Size(174, 24);
            this.radioNewSystem.TabIndex = 5;
            this.radioNewSystem.TabStop = true;
            this.radioNewSystem.Text = "Create new database";
            this.radioNewSystem.UseVisualStyleBackColor = true;
            // 
            // radioExistingSystem
            // 
            this.radioExistingSystem.AutoSize = true;
            this.radioExistingSystem.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioExistingSystem.Location = new System.Drawing.Point(17, 41);
            this.radioExistingSystem.Name = "radioExistingSystem";
            this.radioExistingSystem.Size = new System.Drawing.Size(251, 24);
            this.radioExistingSystem.TabIndex = 6;
            this.radioExistingSystem.TabStop = true;
            this.radioExistingSystem.Text = "Connect to an existing database";
            this.radioExistingSystem.UseVisualStyleBackColor = true;
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(196, 208);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.ReadOnly = true;
            this.FilePathBox.Size = new System.Drawing.Size(379, 20);
            this.FilePathBox.TabIndex = 7;
            // 
            // FileBrowseButton
            // 
            this.FileBrowseButton.Location = new System.Drawing.Point(581, 208);
            this.FileBrowseButton.Name = "FileBrowseButton";
            this.FileBrowseButton.Size = new System.Drawing.Size(27, 21);
            this.FileBrowseButton.TabIndex = 8;
            this.FileBrowseButton.Text = "...";
            this.FileBrowseButton.UseVisualStyleBackColor = true;
            this.FileBrowseButton.Click += new System.EventHandler(this.FileBrowseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioExistingSystem);
            this.groupBox1.Controls.Add(this.radioNewSystem);
            this.groupBox1.Location = new System.Drawing.Point(152, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FileBrowseButton);
            this.Controls.Add(this.FilePathBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NextButton);
            this.Name = "Welcome";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioNewSystem;
        private System.Windows.Forms.RadioButton radioExistingSystem;
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Button FileBrowseButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}