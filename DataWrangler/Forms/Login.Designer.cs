using System.Windows.Forms;
using MetroFramework.Controls;
namespace DataWrangler.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.txtUserName = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.chckRemember = new MetroFramework.Controls.MetroCheckBox();
            this.chckShowPass = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Gray;
            this.btnLogin.Enabled = false;
            this.btnLogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(295, 251);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(56, 34);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            // 
            // 
            // 
            this.txtUserName.CustomButton.Image = null;
            this.txtUserName.CustomButton.Location = new System.Drawing.Point(149, 2);
            this.txtUserName.CustomButton.Name = "";
            this.txtUserName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txtUserName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUserName.CustomButton.TabIndex = 1;
            this.txtUserName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUserName.CustomButton.UseSelectable = true;
            this.txtUserName.CustomButton.Visible = false;
            this.txtUserName.DisplayIcon = true;
            this.txtUserName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUserName.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.txtUserName.Icon = ((System.Drawing.Image)(resources.GetObject("txtUserName.Icon")));
            this.txtUserName.IconRight = true;
            this.txtUserName.Lines = new string[] {
        "Username"};
            this.txtUserName.Location = new System.Drawing.Point(184, 145);
            this.txtUserName.MaxLength = 62;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUserName.SelectedText = "";
            this.txtUserName.SelectionLength = 0;
            this.txtUserName.SelectionStart = 0;
            this.txtUserName.ShortcutsEnabled = true;
            this.txtUserName.Size = new System.Drawing.Size(167, 20);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Text = "Username";
            this.txtUserName.UseSelectable = true;
            this.txtUserName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUserName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtUserName.GotFocus += new System.EventHandler(this.txtUserName_Focus);
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(149, 2);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.DisplayIcon = true;
            this.txtPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPassword.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.txtPassword.Icon = ((System.Drawing.Image)(resources.GetObject("txtPassword.Icon")));
            this.txtPassword.IconRight = true;
            this.txtPassword.Lines = new string[] {
        "Password"};
            this.txtPassword.Location = new System.Drawing.Point(184, 180);
            this.txtPassword.MaxLength = 32;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "Password";
            this.txtPassword.UseSelectable = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.TextChanged += new System.EventHandler(this.ChckUserPassTxt_OnChange);
            this.txtPassword.GotFocus += new System.EventHandler(this.txtPassword_Focus);
            // 
            // chckRemember
            // 
            this.chckRemember.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chckRemember.AutoSize = true;
            this.chckRemember.BackColor = System.Drawing.Color.Gainsboro;
            this.chckRemember.ForeColor = System.Drawing.Color.Black;
            this.chckRemember.Location = new System.Drawing.Point(184, 206);
            this.chckRemember.Name = "chckRemember";
            this.chckRemember.Size = new System.Drawing.Size(137, 15);
            this.chckRemember.TabIndex = 5;
            this.chckRemember.Text = "Remember Username";
            this.chckRemember.UseSelectable = true;
            // 
            // chckShowPass
            // 
            this.chckShowPass.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chckShowPass.AutoSize = true;
            this.chckShowPass.BackColor = System.Drawing.Color.Gainsboro;
            this.chckShowPass.Checked = true;
            this.chckShowPass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckShowPass.ForeColor = System.Drawing.Color.Black;
            this.chckShowPass.Location = new System.Drawing.Point(184, 229);
            this.chckShowPass.Name = "chckShowPass";
            this.chckShowPass.Size = new System.Drawing.Size(105, 15);
            this.chckShowPass.TabIndex = 6;
            this.chckShowPass.Text = "Show Password";
            this.chckShowPass.UseSelectable = true;
            this.chckShowPass.CheckedChanged += new System.EventHandler(this.chckShowPass_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(169, 109);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(120, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Please login below.";
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 367);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.chckShowPass);
            this.Controls.Add(this.chckRemember);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnLogin);
            this.Name = "Login";
            this.Text = "Data Wrangler Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroButton btnLogin;
        private MetroTextBox txtUserName;
        private MetroTextBox txtPassword;
        private MetroCheckBox chckRemember;
        private MetroCheckBox chckShowPass;
        private MetroLabel metroLabel1;
    }
}