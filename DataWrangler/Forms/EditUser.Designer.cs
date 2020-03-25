namespace DataWrangler.Forms
{
    partial class EditUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabUser = new MetroFramework.Controls.MetroTabPage();
            this.togActiveStat = new MetroFramework.Controls.MetroToggle();
            this.txtPasswordVerify = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.lblUsername = new MetroFramework.Controls.MetroLabel();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tabHistory = new MetroFramework.Controls.MetroTabPage();
            this.gridHistory = new MetroFramework.Controls.MetroGrid();
            this.tabAuditHistory = new MetroFramework.Controls.MetroTabPage();
            this.gridAuditHistory = new MetroFramework.Controls.MetroGrid();
            this.btnClose = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.lbUpdated = new MetroFramework.Controls.MetroLabel();
            this.txtUpdated = new MetroFramework.Controls.MetroTextBox();
            this.txtUserId = new MetroFramework.Controls.MetroTextBox();
            this.lblId = new MetroFramework.Controls.MetroLabel();
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.tabAuditHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabUser);
            this.tabControl.Controls.Add(this.tabHistory);
            this.tabControl.Controls.Add(this.tabAuditHistory);
            this.tabControl.Location = new System.Drawing.Point(12, 99);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(416, 326);
            this.tabControl.TabIndex = 10;
            this.tabControl.TabStop = false;
            this.tabControl.UseSelectable = true;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabUser
            // 
            this.tabUser.AutoScroll = true;
            this.tabUser.BackColor = System.Drawing.Color.Transparent;
            this.tabUser.Controls.Add(this.togActiveStat);
            this.tabUser.Controls.Add(this.txtPasswordVerify);
            this.tabUser.Controls.Add(this.metroLabel2);
            this.tabUser.Controls.Add(this.txtUsername);
            this.tabUser.Controls.Add(this.lblUsername);
            this.tabUser.Controls.Add(this.txtPassword);
            this.tabUser.Controls.Add(this.lblPassword);
            this.tabUser.Controls.Add(this.metroLabel1);
            this.tabUser.HorizontalScrollbar = true;
            this.tabUser.HorizontalScrollbarBarColor = true;
            this.tabUser.HorizontalScrollbarHighlightOnWheel = false;
            this.tabUser.HorizontalScrollbarSize = 10;
            this.tabUser.Location = new System.Drawing.Point(4, 41);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(408, 281);
            this.tabUser.TabIndex = 0;
            this.tabUser.Text = "User Information";
            this.tabUser.UseVisualStyleBackColor = true;
            this.tabUser.VerticalScrollbar = true;
            this.tabUser.VerticalScrollbarBarColor = true;
            this.tabUser.VerticalScrollbarHighlightOnWheel = false;
            this.tabUser.VerticalScrollbarSize = 10;
            // 
            // togActiveStat
            // 
            this.togActiveStat.AutoSize = true;
            this.togActiveStat.Location = new System.Drawing.Point(0, 193);
            this.togActiveStat.Name = "togActiveStat";
            this.togActiveStat.Size = new System.Drawing.Size(80, 17);
            this.togActiveStat.TabIndex = 4;
            this.togActiveStat.Text = "Off";
            this.togActiveStat.UseSelectable = true;
            // 
            // txtPasswordVerify
            // 
            // 
            // 
            // 
            this.txtPasswordVerify.CustomButton.Image = null;
            this.txtPasswordVerify.CustomButton.Location = new System.Drawing.Point(195, 1);
            this.txtPasswordVerify.CustomButton.Name = "";
            this.txtPasswordVerify.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPasswordVerify.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPasswordVerify.CustomButton.TabIndex = 1;
            this.txtPasswordVerify.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPasswordVerify.CustomButton.UseSelectable = true;
            this.txtPasswordVerify.CustomButton.Visible = false;
            this.txtPasswordVerify.Enabled = false;
            this.txtPasswordVerify.Lines = new string[0];
            this.txtPasswordVerify.Location = new System.Drawing.Point(3, 141);
            this.txtPasswordVerify.MaxLength = 32767;
            this.txtPasswordVerify.Name = "txtPasswordVerify";
            this.txtPasswordVerify.PasswordChar = '●';
            this.txtPasswordVerify.PromptText = "********";
            this.txtPasswordVerify.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPasswordVerify.SelectedText = "";
            this.txtPasswordVerify.SelectionLength = 0;
            this.txtPasswordVerify.SelectionStart = 0;
            this.txtPasswordVerify.ShortcutsEnabled = true;
            this.txtPasswordVerify.Size = new System.Drawing.Size(217, 23);
            this.txtPasswordVerify.TabIndex = 3;
            this.txtPasswordVerify.UseSelectable = true;
            this.txtPasswordVerify.UseSystemPasswordChar = true;
            this.txtPasswordVerify.WaterMark = "********";
            this.txtPasswordVerify.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPasswordVerify.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPasswordVerify.TextChanged += new System.EventHandler(this.txtPasswordVerify_TextChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(0, 119);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(107, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Password (Verify)";
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.CustomButton.Image = null;
            this.txtUsername.CustomButton.Location = new System.Drawing.Point(195, 1);
            this.txtUsername.CustomButton.Name = "";
            this.txtUsername.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsername.CustomButton.TabIndex = 1;
            this.txtUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsername.CustomButton.UseSelectable = true;
            this.txtUsername.CustomButton.Visible = false;
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(3, 37);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(217, 23);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.UseSelectable = true;
            this.txtUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(0, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(68, 19);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(195, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(3, 89);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PromptText = "********";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(217, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMark = "********";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(0, 67);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(63, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(0, 171);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Active Status";
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.gridHistory);
            this.tabHistory.HorizontalScrollbarBarColor = true;
            this.tabHistory.HorizontalScrollbarHighlightOnWheel = false;
            this.tabHistory.HorizontalScrollbarSize = 10;
            this.tabHistory.Location = new System.Drawing.Point(4, 41);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(408, 281);
            this.tabHistory.TabIndex = 2;
            this.tabHistory.Text = "History";
            this.tabHistory.VerticalScrollbarBarColor = true;
            this.tabHistory.VerticalScrollbarHighlightOnWheel = false;
            this.tabHistory.VerticalScrollbarSize = 10;
            // 
            // gridHistory
            // 
            this.gridHistory.AllowUserToAddRows = false;
            this.gridHistory.AllowUserToDeleteRows = false;
            this.gridHistory.AllowUserToResizeRows = false;
            this.gridHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHistory.EnableHeadersVisualStyles = false;
            this.gridHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridHistory.Location = new System.Drawing.Point(3, 3);
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.ReadOnly = true;
            this.gridHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(402, 275);
            this.gridHistory.TabIndex = 2;
            this.gridHistory.TabStop = false;
            this.gridHistory.VirtualMode = true;
            this.gridHistory.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridHistory_CellValueNeeded);
            // 
            // tabAuditHistory
            // 
            this.tabAuditHistory.BackColor = System.Drawing.Color.Transparent;
            this.tabAuditHistory.Controls.Add(this.gridAuditHistory);
            this.tabAuditHistory.HorizontalScrollbarBarColor = true;
            this.tabAuditHistory.HorizontalScrollbarHighlightOnWheel = false;
            this.tabAuditHistory.HorizontalScrollbarSize = 10;
            this.tabAuditHistory.Location = new System.Drawing.Point(4, 41);
            this.tabAuditHistory.Name = "tabAuditHistory";
            this.tabAuditHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabAuditHistory.Size = new System.Drawing.Size(408, 281);
            this.tabAuditHistory.TabIndex = 1;
            this.tabAuditHistory.Text = "User Audit";
            this.tabAuditHistory.VerticalScrollbarBarColor = true;
            this.tabAuditHistory.VerticalScrollbarHighlightOnWheel = false;
            this.tabAuditHistory.VerticalScrollbarSize = 10;
            // 
            // gridAuditHistory
            // 
            this.gridAuditHistory.AllowUserToAddRows = false;
            this.gridAuditHistory.AllowUserToDeleteRows = false;
            this.gridAuditHistory.AllowUserToResizeRows = false;
            this.gridAuditHistory.BackgroundColor = System.Drawing.Color.White;
            this.gridAuditHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridAuditHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridAuditHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAuditHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridAuditHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAuditHistory.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridAuditHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAuditHistory.EnableHeadersVisualStyles = false;
            this.gridAuditHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridAuditHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridAuditHistory.Location = new System.Drawing.Point(3, 3);
            this.gridAuditHistory.MultiSelect = false;
            this.gridAuditHistory.Name = "gridAuditHistory";
            this.gridAuditHistory.ReadOnly = true;
            this.gridAuditHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAuditHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridAuditHistory.RowHeadersVisible = false;
            this.gridAuditHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridAuditHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAuditHistory.Size = new System.Drawing.Size(402, 275);
            this.gridAuditHistory.TabIndex = 2;
            this.gridAuditHistory.TabStop = false;
            this.gridAuditHistory.UseCustomBackColor = true;
            this.gridAuditHistory.UseCustomForeColor = true;
            this.gridAuditHistory.UseStyleColors = true;
            this.gridAuditHistory.VirtualMode = true;
            this.gridAuditHistory.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridAuditHistory_CellValueNeeded);
            // 
            // btnClose
            // 
            this.btnClose.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnClose.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnClose.Location = new System.Drawing.Point(361, 431);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCancel.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnCancel.Location = new System.Drawing.Point(290, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbUpdated
            // 
            this.lbUpdated.AutoSize = true;
            this.lbUpdated.Location = new System.Drawing.Point(162, 62);
            this.lbUpdated.Name = "lbUpdated";
            this.lbUpdated.Size = new System.Drawing.Size(90, 19);
            this.lbUpdated.TabIndex = 9;
            this.lbUpdated.Text = "User Updated";
            this.lbUpdated.UseMnemonic = false;
            // 
            // txtUpdated
            // 
            // 
            // 
            // 
            this.txtUpdated.CustomButton.Image = null;
            this.txtUpdated.CustomButton.Location = new System.Drawing.Point(148, 1);
            this.txtUpdated.CustomButton.Name = "";
            this.txtUpdated.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUpdated.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUpdated.CustomButton.TabIndex = 1;
            this.txtUpdated.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUpdated.CustomButton.UseSelectable = true;
            this.txtUpdated.CustomButton.Visible = false;
            this.txtUpdated.Enabled = false;
            this.txtUpdated.Lines = new string[0];
            this.txtUpdated.Location = new System.Drawing.Point(258, 61);
            this.txtUpdated.MaxLength = 32767;
            this.txtUpdated.Name = "txtUpdated";
            this.txtUpdated.PasswordChar = '\0';
            this.txtUpdated.ReadOnly = true;
            this.txtUpdated.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUpdated.SelectedText = "";
            this.txtUpdated.SelectionLength = 0;
            this.txtUpdated.SelectionStart = 0;
            this.txtUpdated.ShortcutsEnabled = true;
            this.txtUpdated.Size = new System.Drawing.Size(170, 23);
            this.txtUpdated.TabIndex = 0;
            this.txtUpdated.TabStop = false;
            this.txtUpdated.UseSelectable = true;
            this.txtUpdated.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUpdated.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtUserId
            // 
            // 
            // 
            // 
            this.txtUserId.CustomButton.Image = null;
            this.txtUserId.CustomButton.Location = new System.Drawing.Point(65, 1);
            this.txtUserId.CustomButton.Name = "";
            this.txtUserId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUserId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUserId.CustomButton.TabIndex = 1;
            this.txtUserId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUserId.CustomButton.UseSelectable = true;
            this.txtUserId.CustomButton.Visible = false;
            this.txtUserId.Enabled = false;
            this.txtUserId.Lines = new string[0];
            this.txtUserId.Location = new System.Drawing.Point(69, 61);
            this.txtUserId.MaxLength = 32767;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.PasswordChar = '\0';
            this.txtUserId.ReadOnly = true;
            this.txtUserId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUserId.SelectedText = "";
            this.txtUserId.SelectionLength = 0;
            this.txtUserId.SelectionStart = 0;
            this.txtUserId.ShortcutsEnabled = true;
            this.txtUserId.Size = new System.Drawing.Size(87, 23);
            this.txtUserId.TabIndex = 0;
            this.txtUserId.TabStop = false;
            this.txtUserId.UseSelectable = true;
            this.txtUserId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUserId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 62);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(51, 19);
            this.lblId.TabIndex = 6;
            this.lblId.Text = "User ID";
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 464);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lbUpdated);
            this.Controls.Add(this.txtUpdated);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditUser";
            this.Resizable = false;
            this.Text = "Edit User";
            this.tabControl.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.tabAuditHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabControl;
        private MetroFramework.Controls.MetroTabPage tabUser;
        private MetroFramework.Controls.MetroLabel lbUpdated;
        private MetroFramework.Controls.MetroTextBox txtUpdated;
        private MetroFramework.Controls.MetroTextBox txtUserId;
        private MetroFramework.Controls.MetroLabel lblId;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroLabel lblUsername;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtPasswordVerify;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnClose;
        private MetroFramework.Controls.MetroToggle togActiveStat;
        private MetroFramework.Controls.MetroTabPage tabAuditHistory;
        private MetroFramework.Controls.MetroGrid gridAuditHistory;
        private MetroFramework.Controls.MetroTabPage tabHistory;
        private MetroFramework.Controls.MetroGrid gridHistory;
    }
}