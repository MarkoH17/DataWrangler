namespace DataWrangler
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chckRemember = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chckShowPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Gray;
            this.btnLogin.Font = new System.Drawing.Font("Book Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(307, 285);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(56, 34);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Book Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(196, 141);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(167, 21);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "Enter your username...";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Book Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(196, 204);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(167, 21);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Enter your password...";
            // 
            // lblUsername
            // 
            this.lblUsername.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Gainsboro;
            this.lblUsername.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(195, 115);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(81, 20);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Gainsboro;
            this.lblPassword.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(195, 178);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(79, 20);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // chckRemember
            // 
            this.chckRemember.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chckRemember.AutoSize = true;
            this.chckRemember.BackColor = System.Drawing.Color.Gainsboro;
            this.chckRemember.Font = new System.Drawing.Font("Book Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckRemember.ForeColor = System.Drawing.Color.Black;
            this.chckRemember.Location = new System.Drawing.Point(196, 230);
            this.chckRemember.Name = "chckRemember";
            this.chckRemember.Size = new System.Drawing.Size(131, 19);
            this.chckRemember.TabIndex = 5;
            this.chckRemember.Text = "Remember Username";
            this.chckRemember.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Bernard MT Condensed", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(159, 41);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(245, 62);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Data Wrangler";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // chckShowPass
            // 
            this.chckShowPass.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chckShowPass.AutoSize = true;
            this.chckShowPass.BackColor = System.Drawing.Color.Gainsboro;
            this.chckShowPass.Font = new System.Drawing.Font("Book Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckShowPass.ForeColor = System.Drawing.Color.Black;
            this.chckShowPass.Location = new System.Drawing.Point(196, 253);
            this.chckShowPass.Name = "chckShowPass";
            this.chckShowPass.Size = new System.Drawing.Size(105, 19);
            this.chckShowPass.TabIndex = 7;
            this.chckShowPass.Text = "Show Password";
            this.chckShowPass.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(541, 367);
            this.Controls.Add(this.chckShowPass);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.chckRemember);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnLogin);
            this.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Login";
            this.Text = "Data Wrangler Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox chckRemember;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chckShowPass;
    }
}