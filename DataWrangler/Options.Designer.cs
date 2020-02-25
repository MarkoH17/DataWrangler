namespace DataWrangler
{
    partial class Options
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
            this.comboDatabase = new System.Windows.Forms.ComboBox();
            this.lblOptions = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.chckAddEncrypt = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboDatabase
            // 
            this.comboDatabase.FormattingEnabled = true;
            this.comboDatabase.Location = new System.Drawing.Point(56, 117);
            this.comboDatabase.Name = "comboDatabase";
            this.comboDatabase.Size = new System.Drawing.Size(244, 21);
            this.comboDatabase.TabIndex = 0;
            this.comboDatabase.Text = "Select a database...";
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Bernard MT Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblOptions.Location = new System.Drawing.Point(329, 13);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(163, 57);
            this.lblOptions.TabIndex = 1;
            this.lblOptions.Text = "Options";
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSize = true;
            this.btnSelect.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSelect.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.Transparent;
            this.btnSelect.Location = new System.Drawing.Point(317, 113);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(91, 27);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(56, 175);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(244, 20);
            this.txtCurrentPassword.TabIndex = 3;
            this.txtCurrentPassword.Text = "Enter current password";
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPassword.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblCurrentPassword.Location = new System.Drawing.Point(56, 155);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(114, 17);
            this.lblCurrentPassword.TabIndex = 4;
            this.lblCurrentPassword.Text = "Current Password";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblNewPassword.Location = new System.Drawing.Point(56, 211);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(97, 17);
            this.lblNewPassword.TabIndex = 6;
            this.lblNewPassword.Text = "New Password";
            this.lblNewPassword.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(56, 231);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(244, 20);
            this.txtNewPassword.TabIndex = 5;
            this.txtNewPassword.Text = "Enter new password";
            this.txtNewPassword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblConfirmPassword.Location = new System.Drawing.Point(56, 273);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(117, 17);
            this.lblConfirmPassword.TabIndex = 8;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(56, 293);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(244, 20);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.Text = "Confirm password";
            // 
            // chckAddEncrypt
            // 
            this.chckAddEncrypt.AutoSize = true;
            this.chckAddEncrypt.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckAddEncrypt.ForeColor = System.Drawing.Color.OrangeRed;
            this.chckAddEncrypt.Location = new System.Drawing.Point(56, 343);
            this.chckAddEncrypt.Name = "chckAddEncrypt";
            this.chckAddEncrypt.Size = new System.Drawing.Size(188, 21);
            this.chckAddEncrypt.TabIndex = 9;
            this.chckAddEncrypt.Text = "Add encryption to database";
            this.chckAddEncrypt.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chckAddEncrypt);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblCurrentPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.comboDatabase);
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboDatabase;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.CheckBox chckAddEncrypt;
    }
}