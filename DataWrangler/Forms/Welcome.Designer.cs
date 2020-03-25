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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.radioExistingSystem = new MetroFramework.Controls.MetroRadioButton();
            this.radioNewSystem = new MetroFramework.Controls.MetroRadioButton();
            this.FileBrowseButton = new MetroFramework.Controls.MetroButton();
            this.btnNext = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.FilePathBox = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.radioExistingSystem);
            this.metroPanel1.Controls.Add(this.radioNewSystem);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(79, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(260, 66);
            this.metroPanel1.TabIndex = 10;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // radioExistingSystem
            // 
            this.radioExistingSystem.AutoSize = true;
            this.radioExistingSystem.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.radioExistingSystem.Location = new System.Drawing.Point(3, 34);
            this.radioExistingSystem.Name = "radioExistingSystem";
            this.radioExistingSystem.Size = new System.Drawing.Size(259, 25);
            this.radioExistingSystem.TabIndex = 3;
            this.radioExistingSystem.Text = "Connect to Existing Database";
            this.radioExistingSystem.UseSelectable = true;
            this.radioExistingSystem.CheckedChanged += new System.EventHandler(this.radioExistingSystem_CheckedChanged);
            // 
            // radioNewSystem
            // 
            this.radioNewSystem.AutoSize = true;
            this.radioNewSystem.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.radioNewSystem.Location = new System.Drawing.Point(3, 3);
            this.radioNewSystem.Name = "radioNewSystem";
            this.radioNewSystem.Size = new System.Drawing.Size(197, 25);
            this.radioNewSystem.TabIndex = 2;
            this.radioNewSystem.Text = "Create New Database";
            this.radioNewSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioNewSystem.UseSelectable = true;
            this.radioNewSystem.CheckedChanged += new System.EventHandler(this.radioNewSystem_CheckedChanged);
            // 
            // FileBrowseButton
            // 
            this.FileBrowseButton.Enabled = false;
            this.FileBrowseButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.FileBrowseButton.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.FileBrowseButton.Location = new System.Drawing.Point(377, 149);
            this.FileBrowseButton.Name = "FileBrowseButton";
            this.FileBrowseButton.Size = new System.Drawing.Size(27, 24);
            this.FileBrowseButton.TabIndex = 11;
            this.FileBrowseButton.Text = ". . .";
            this.FileBrowseButton.UseSelectable = true;
            this.FileBrowseButton.Click += new System.EventHandler(this.FileBrowseButton_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnNext.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnNext.Location = new System.Drawing.Point(343, 190);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(61, 25);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next";
            this.btnNext.UseSelectable = true;
            this.btnNext.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 149);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(61, 19);
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "File Path:";
            // 
            // FilePathBox
            // 
            // 
            // 
            // 
            this.FilePathBox.CustomButton.Image = null;
            this.FilePathBox.CustomButton.Location = new System.Drawing.Point(259, 1);
            this.FilePathBox.CustomButton.Name = "";
            this.FilePathBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.FilePathBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.FilePathBox.CustomButton.TabIndex = 1;
            this.FilePathBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FilePathBox.CustomButton.UseSelectable = true;
            this.FilePathBox.CustomButton.Visible = false;
            this.FilePathBox.Enabled = false;
            this.FilePathBox.Lines = new string[0];
            this.FilePathBox.Location = new System.Drawing.Point(90, 149);
            this.FilePathBox.MaxLength = 32767;
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.PasswordChar = '\0';
            this.FilePathBox.ReadOnly = true;
            this.FilePathBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FilePathBox.SelectedText = "";
            this.FilePathBox.SelectionLength = 0;
            this.FilePathBox.SelectionStart = 0;
            this.FilePathBox.ShortcutsEnabled = true;
            this.FilePathBox.Size = new System.Drawing.Size(281, 23);
            this.FilePathBox.TabIndex = 14;
            this.FilePathBox.UseSelectable = true;
            this.FilePathBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.FilePathBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 231);
            this.Controls.Add(this.FilePathBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.FileBrowseButton);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Welcome";
            this.Resizable = false;
            this.Text = "First Time Setup";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroRadioButton radioExistingSystem;
        private MetroFramework.Controls.MetroRadioButton radioNewSystem;
        private MetroFramework.Controls.MetroButton FileBrowseButton;
        private MetroFramework.Controls.MetroButton btnNext;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox FilePathBox;
    }
}