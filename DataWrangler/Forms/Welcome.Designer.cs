using System.Windows.Forms;
using MetroFramework.Controls;
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
            this.btnNext = new MetroFramework.Controls.MetroButton();
            this.btnBrowse = new MetroFramework.Controls.MetroButton();
            this.lblDatabasePath = new MetroFramework.Controls.MetroLabel();
            this.txtPath = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.rdioExistingSystem = new MetroFramework.Controls.MetroRadioButton();
            this.rdioNewSystem = new MetroFramework.Controls.MetroRadioButton();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnNext.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnNext.Location = new System.Drawing.Point(380, 187);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(65, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseSelectable = true;
            this.btnNext.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnBrowse.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnBrowse.Location = new System.Drawing.Point(415, 137);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = ". . .";
            this.btnBrowse.UseSelectable = true;
            this.btnBrowse.Click += new System.EventHandler(this.FileBrowseButton_Click);
            // 
            // lblDatabasePath
            // 
            this.lblDatabasePath.AutoSize = true;
            this.lblDatabasePath.Location = new System.Drawing.Point(23, 137);
            this.lblDatabasePath.Name = "lblDatabasePath";
            this.lblDatabasePath.Size = new System.Drawing.Size(58, 19);
            this.lblDatabasePath.TabIndex = 2;
            this.lblDatabasePath.Text = "DB Path:";
            // 
            // txtPath
            // 
            // 
            // 
            // 
            this.txtPath.CustomButton.Image = null;
            this.txtPath.CustomButton.Location = new System.Drawing.Point(300, 1);
            this.txtPath.CustomButton.Name = "";
            this.txtPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPath.CustomButton.TabIndex = 1;
            this.txtPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPath.CustomButton.UseSelectable = true;
            this.txtPath.CustomButton.Visible = false;
            this.txtPath.Enabled = false;
            this.txtPath.Lines = new string[0];
            this.txtPath.Location = new System.Drawing.Point(87, 137);
            this.txtPath.MaxLength = 32767;
            this.txtPath.Name = "txtPath";
            this.txtPath.PasswordChar = '\0';
            this.txtPath.ReadOnly = true;
            this.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPath.SelectedText = "";
            this.txtPath.SelectionLength = 0;
            this.txtPath.SelectionStart = 0;
            this.txtPath.ShortcutsEnabled = true;
            this.txtPath.Size = new System.Drawing.Size(322, 23);
            this.txtPath.TabIndex = 3;
            this.txtPath.UseSelectable = true;
            this.txtPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.rdioExistingSystem);
            this.metroPanel1.Controls.Add(this.rdioNewSystem);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(113, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(248, 64);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // rdioExistingSystem
            // 
            this.rdioExistingSystem.AutoSize = true;
            this.rdioExistingSystem.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.rdioExistingSystem.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.rdioExistingSystem.Location = new System.Drawing.Point(3, 34);
            this.rdioExistingSystem.Name = "rdioExistingSystem";
            this.rdioExistingSystem.Size = new System.Drawing.Size(248, 25);
            this.rdioExistingSystem.TabIndex = 6;
            this.rdioExistingSystem.Text = "Connect to Existing Database";
            this.rdioExistingSystem.UseSelectable = true;
            this.rdioExistingSystem.Click += new System.EventHandler(this.radioExistingSystem_CheckedChanged);
            // 
            // rdioNewSystem
            // 
            this.rdioNewSystem.AutoSize = true;
            this.rdioNewSystem.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.rdioNewSystem.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.rdioNewSystem.Location = new System.Drawing.Point(3, 3);
            this.rdioNewSystem.Name = "rdioNewSystem";
            this.rdioNewSystem.Size = new System.Drawing.Size(191, 25);
            this.rdioNewSystem.TabIndex = 5;
            this.rdioNewSystem.Text = "Create New Database";
            this.rdioNewSystem.UseSelectable = true;
            this.rdioNewSystem.Click += new System.EventHandler(this.radioNewSystem_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnExit.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnExit.Location = new System.Drawing.Point(23, 187);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(58, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 227);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblDatabasePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnNext);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Welcome";
            this.Resizable = false;
            this.Text = "First Time Setup";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroButton btnNext;
        private MetroButton btnBrowse;
        private MetroLabel lblDatabasePath;
        private MetroTextBox txtPath;
        private MetroPanel metroPanel1;
        private MetroRadioButton rdioExistingSystem;
        private MetroRadioButton rdioNewSystem;
        private MetroButton btnExit;
    }
}