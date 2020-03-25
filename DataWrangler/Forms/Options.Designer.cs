namespace DataWrangler.Forms
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
            this.lblDatabasePath = new MetroFramework.Controls.MetroLabel();
            this.DatabasePathLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblDatabaseSize = new MetroFramework.Controls.MetroLabel();
            this.lblDatabasePathValue = new MetroFramework.Controls.MetroLabel();
            this.lblDatabaseSizeValue = new MetroFramework.Controls.MetroLabel();
            this.rebuildDatabaseButton = new MetroFramework.Controls.MetroButton();
            this.tglDarkMode = new MetroFramework.Controls.MetroToggle();
            this.lblDarkMode = new MetroFramework.Controls.MetroLabel();
            this.comboStyle = new MetroFramework.Controls.MetroComboBox();
            this.lblStyle = new MetroFramework.Controls.MetroLabel();
            this.lblHorSep1 = new MetroFramework.Controls.MetroLabel();
            this.btnClose = new MetroFramework.Controls.MetroButton();
            this.btnResetAll = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lblDatabasePath
            // 
            this.lblDatabasePath.AutoSize = true;
            this.lblDatabasePath.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDatabasePath.Location = new System.Drawing.Point(12, 84);
            this.lblDatabasePath.Name = "lblDatabasePath";
            this.lblDatabasePath.Size = new System.Drawing.Size(120, 25);
            this.lblDatabasePath.TabIndex = 0;
            this.lblDatabasePath.Text = "Database Path";
            // 
            // DatabasePathLabel
            // 
            this.DatabasePathLabel.AutoSize = true;
            this.DatabasePathLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.DatabasePathLabel.Location = new System.Drawing.Point(164, 79);
            this.DatabasePathLabel.Name = "DatabasePathLabel";
            this.DatabasePathLabel.Size = new System.Drawing.Size(0, 0);
            this.DatabasePathLabel.TabIndex = 1;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(164, 121);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(0, 0);
            this.metroLabel2.TabIndex = 3;
            // 
            // lblDatabaseSize
            // 
            this.lblDatabaseSize.AutoSize = true;
            this.lblDatabaseSize.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDatabaseSize.Location = new System.Drawing.Point(12, 121);
            this.lblDatabaseSize.Name = "lblDatabaseSize";
            this.lblDatabaseSize.Size = new System.Drawing.Size(117, 25);
            this.lblDatabaseSize.TabIndex = 2;
            this.lblDatabaseSize.Text = "Database Size";
            // 
            // lblDatabasePathValue
            // 
            this.lblDatabasePathValue.Location = new System.Drawing.Point(142, 90);
            this.lblDatabasePathValue.Name = "lblDatabasePathValue";
            this.lblDatabasePathValue.Size = new System.Drawing.Size(247, 19);
            this.lblDatabasePathValue.TabIndex = 4;
            this.lblDatabasePathValue.Text = "metroLabel4";
            // 
            // lblDatabaseSizeValue
            // 
            this.lblDatabaseSizeValue.AutoSize = true;
            this.lblDatabaseSizeValue.Location = new System.Drawing.Point(139, 127);
            this.lblDatabaseSizeValue.Name = "lblDatabaseSizeValue";
            this.lblDatabaseSizeValue.Size = new System.Drawing.Size(83, 19);
            this.lblDatabaseSizeValue.TabIndex = 5;
            this.lblDatabaseSizeValue.Text = "metroLabel5";
            // 
            // rebuildDatabaseButton
            // 
            this.rebuildDatabaseButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.rebuildDatabaseButton.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.rebuildDatabaseButton.Location = new System.Drawing.Point(15, 229);
            this.rebuildDatabaseButton.Name = "rebuildDatabaseButton";
            this.rebuildDatabaseButton.Size = new System.Drawing.Size(120, 27);
            this.rebuildDatabaseButton.TabIndex = 6;
            this.rebuildDatabaseButton.Text = "Rebuild Database";
            this.rebuildDatabaseButton.UseSelectable = true;
            this.rebuildDatabaseButton.Click += new System.EventHandler(this.rebuildDatabaseButton_Click);
            // 
            // tglDarkMode
            // 
            this.tglDarkMode.AutoSize = true;
            this.tglDarkMode.Location = new System.Drawing.Point(114, 175);
            this.tglDarkMode.Name = "tglDarkMode";
            this.tglDarkMode.Size = new System.Drawing.Size(80, 17);
            this.tglDarkMode.TabIndex = 12;
            this.tglDarkMode.Text = "Off";
            this.tglDarkMode.UseSelectable = true;
            this.tglDarkMode.CheckedChanged += new System.EventHandler(this.tglDarkMode_CheckedChanged);
            // 
            // lblDarkMode
            // 
            this.lblDarkMode.AutoSize = true;
            this.lblDarkMode.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDarkMode.Location = new System.Drawing.Point(12, 169);
            this.lblDarkMode.Name = "lblDarkMode";
            this.lblDarkMode.Size = new System.Drawing.Size(96, 25);
            this.lblDarkMode.TabIndex = 13;
            this.lblDarkMode.Text = "Dark Mode";
            // 
            // comboStyle
            // 
            this.comboStyle.FormattingEnabled = true;
            this.comboStyle.ItemHeight = 23;
            this.comboStyle.Location = new System.Drawing.Point(292, 169);
            this.comboStyle.Name = "comboStyle";
            this.comboStyle.Size = new System.Drawing.Size(106, 29);
            this.comboStyle.TabIndex = 14;
            this.comboStyle.UseSelectable = true;
            this.comboStyle.SelectedValueChanged += new System.EventHandler(this.comboStyle_SelectedValueChanged);
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblStyle.Location = new System.Drawing.Point(218, 169);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(68, 25);
            this.lblStyle.TabIndex = 15;
            this.lblStyle.Text = "UI Style";
            // 
            // lblHorSep1
            // 
            this.lblHorSep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHorSep1.Location = new System.Drawing.Point(15, 155);
            this.lblHorSep1.Margin = new System.Windows.Forms.Padding(0);
            this.lblHorSep1.Name = "lblHorSep1";
            this.lblHorSep1.Size = new System.Drawing.Size(383, 2);
            this.lblHorSep1.TabIndex = 17;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnClose.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnClose.Location = new System.Drawing.Point(341, 229);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 27);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnResetAll
            // 
            this.btnResetAll.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnResetAll.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnResetAll.Location = new System.Drawing.Point(142, 229);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(80, 27);
            this.btnResetAll.TabIndex = 19;
            this.btnResetAll.Text = "Reset All...";
            this.btnResetAll.UseSelectable = true;
            this.btnResetAll.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 267);
            this.Controls.Add(this.btnResetAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblHorSep1);
            this.Controls.Add(this.lblStyle);
            this.Controls.Add(this.comboStyle);
            this.Controls.Add(this.lblDarkMode);
            this.Controls.Add(this.tglDarkMode);
            this.Controls.Add(this.rebuildDatabaseButton);
            this.Controls.Add(this.lblDatabaseSizeValue);
            this.Controls.Add(this.lblDatabasePathValue);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.lblDatabaseSize);
            this.Controls.Add(this.DatabasePathLabel);
            this.Controls.Add(this.lblDatabasePath);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblDatabasePath;
        private MetroFramework.Controls.MetroLabel DatabasePathLabel;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblDatabaseSize;
        private MetroFramework.Controls.MetroLabel lblDatabasePathValue;
        private MetroFramework.Controls.MetroLabel lblDatabaseSizeValue;
        private MetroFramework.Controls.MetroButton rebuildDatabaseButton;
        private MetroFramework.Controls.MetroToggle tglDarkMode;
        private MetroFramework.Controls.MetroLabel lblDarkMode;
        private MetroFramework.Controls.MetroComboBox comboStyle;
        private MetroFramework.Controls.MetroLabel lblStyle;
        private MetroFramework.Controls.MetroLabel lblHorSep1;
        private MetroFramework.Controls.MetroButton btnClose;
        private MetroFramework.Controls.MetroButton btnResetAll;
    }
}