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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUserAccounts));
            this.columnsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userAccountRetrieverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridUsers = new MetroFramework.Controls.MetroGrid();
            this.txtRowCnt = new MetroFramework.Controls.MetroTextBox();
            this.userAccountBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.userAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddNew = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.columnsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountRetrieverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // columnsBindingSource
            // 
            this.columnsBindingSource.DataMember = "Columns";
            this.columnsBindingSource.DataSource = this.userAccountRetrieverBindingSource;
            // 
            // userAccountRetrieverBindingSource
            // 
            this.userAccountRetrieverBindingSource.DataSource = typeof(DataWrangler.Retrievers.UserAccountRetriever);
            // 
            // gridUsers
            // 
            this.gridUsers.AllowUserToAddRows = false;
            this.gridUsers.AllowUserToDeleteRows = false;
            this.gridUsers.AllowUserToResizeRows = false;
            this.gridUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridUsers.EnableHeadersVisualStyles = false;
            this.gridUsers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridUsers.Location = new System.Drawing.Point(23, 163);
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.ReadOnly = true;
            this.gridUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(520, 233);
            this.gridUsers.TabIndex = 5;
            this.gridUsers.VirtualMode = true;
            this.gridUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRecords_CellDoubleClick);
            this.gridUsers.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridUsers_CellValueNeeded);
            this.gridUsers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridUsers_MouseClick);
            // 
            // txtRowCnt
            // 
            // 
            // 
            // 
            this.txtRowCnt.CustomButton.Image = null;
            this.txtRowCnt.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtRowCnt.CustomButton.Name = "";
            this.txtRowCnt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRowCnt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRowCnt.CustomButton.TabIndex = 1;
            this.txtRowCnt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRowCnt.CustomButton.UseSelectable = true;
            this.txtRowCnt.CustomButton.Visible = false;
            this.txtRowCnt.Lines = new string[0];
            this.txtRowCnt.Location = new System.Drawing.Point(468, 402);
            this.txtRowCnt.MaxLength = 32767;
            this.txtRowCnt.Name = "txtRowCnt";
            this.txtRowCnt.PasswordChar = '\0';
            this.txtRowCnt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRowCnt.SelectedText = "";
            this.txtRowCnt.SelectionLength = 0;
            this.txtRowCnt.SelectionStart = 0;
            this.txtRowCnt.ShortcutsEnabled = true;
            this.txtRowCnt.Size = new System.Drawing.Size(75, 23);
            this.txtRowCnt.TabIndex = 6;
            this.txtRowCnt.UseSelectable = true;
            this.txtRowCnt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRowCnt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // userAccountBindingSource1
            // 
            this.userAccountBindingSource1.DataSource = typeof(DataWrangler.DBOs.UserAccount);
            // 
            // userAccountBindingSource
            // 
            this.userAccountBindingSource.DataSource = typeof(DataWrangler.DBOs.UserAccount);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(371, 401);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(91, 23);
            this.btnAddNew.TabIndex = 7;
            this.btnAddNew.Text = "Add New User";
            this.btnAddNew.UseSelectable = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(205, 116);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(165, 19);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Users of Current Database.";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(23, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(24, 24);
            this.btnBack.TabIndex = 11;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ManageUserAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 448);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.txtRowCnt);
            this.Controls.Add(this.gridUsers);
            this.Name = "ManageUserAccounts";
            this.Text = "     User Management";
            ((System.ComponentModel.ISupportInitialize)(this.columnsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountRetrieverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ManageUserAccounts_Load(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.BindingSource userAccountBindingSource1;
        private System.Windows.Forms.BindingSource userAccountRetrieverBindingSource;
        private System.Windows.Forms.BindingSource columnsBindingSource;
        private System.Windows.Forms.BindingSource userAccountBindingSource;
        private MetroFramework.Controls.MetroGrid gridUsers;
        private MetroFramework.Controls.MetroTextBox txtRowCnt;
        private MetroFramework.Controls.MetroButton btnAddNew;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Button btnBack;
    }
}