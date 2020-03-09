namespace DataWrangler.Forms
{
    partial class ManageUserAccounts
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
            this.dataUserInfo = new System.Windows.Forms.DataGridView();
            this.lblUserManage = new System.Windows.Forms.Label();
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.comboSelectUser = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataUserInfo
            // 
            this.dataUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUserInfo.Location = new System.Drawing.Point(41, 177);
            this.dataUserInfo.Name = "dataUserInfo";
            this.dataUserInfo.Size = new System.Drawing.Size(467, 251);
            this.dataUserInfo.TabIndex = 7;
            // 
            // lblUserManage
            // 
            this.lblUserManage.AutoSize = true;
            this.lblUserManage.Font = new System.Drawing.Font("Bernard MT Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserManage.Location = new System.Drawing.Point(105, 9);
            this.lblUserManage.Name = "lblUserManage";
            this.lblUserManage.Size = new System.Drawing.Size(347, 57);
            this.lblUserManage.TabIndex = 6;
            this.lblUserManage.Text = "User Management";
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.BackColor = System.Drawing.Color.Gray;
            this.btnSelectUser.Font = new System.Drawing.Font("Book Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectUser.ForeColor = System.Drawing.Color.Transparent;
            this.btnSelectUser.Location = new System.Drawing.Point(433, 114);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(75, 23);
            this.btnSelectUser.TabIndex = 5;
            this.btnSelectUser.Text = "Select User";
            this.btnSelectUser.UseVisualStyleBackColor = false;
            // 
            // comboSelectUser
            // 
            this.comboSelectUser.Font = new System.Drawing.Font("Book Antiqua", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSelectUser.FormattingEnabled = true;
            this.comboSelectUser.Location = new System.Drawing.Point(41, 114);
            this.comboSelectUser.Name = "comboSelectUser";
            this.comboSelectUser.Size = new System.Drawing.Size(371, 23);
            this.comboSelectUser.TabIndex = 4;
            this.comboSelectUser.Text = "Select a user...";
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(566, 448);
            this.Controls.Add(this.dataUserInfo);
            this.Controls.Add(this.lblUserManage);
            this.Controls.Add(this.btnSelectUser);
            this.Controls.Add(this.comboSelectUser);
            this.Name = "UserManage";
            this.Text = "UserManage";
            ((System.ComponentModel.ISupportInitialize)(this.dataUserInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataUserInfo;
        private System.Windows.Forms.Label lblUserManage;
        private System.Windows.Forms.Button btnSelectUser;
        private System.Windows.Forms.ComboBox comboSelectUser;
    }
}