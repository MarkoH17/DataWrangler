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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.DatabasePathLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.DatabasePathLabelText = new MetroFramework.Controls.MetroLabel();
            this.DatabaseSizeLabel = new MetroFramework.Controls.MetroLabel();
            this.rebuildDatabaseButton = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(34, 79);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(124, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Database Path:";
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
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(34, 121);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(121, 25);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Database Size:";
            // 
            // DatabasePathLabelText
            // 
            this.DatabasePathLabelText.AutoSize = true;
            this.DatabasePathLabelText.Location = new System.Drawing.Point(187, 84);
            this.DatabasePathLabelText.Name = "DatabasePathLabelText";
            this.DatabasePathLabelText.Size = new System.Drawing.Size(83, 19);
            this.DatabasePathLabelText.TabIndex = 4;
            this.DatabasePathLabelText.Text = "metroLabel4";
            // 
            // DatabaseSizeLabel
            // 
            this.DatabaseSizeLabel.AutoSize = true;
            this.DatabaseSizeLabel.Location = new System.Drawing.Point(187, 126);
            this.DatabaseSizeLabel.Name = "DatabaseSizeLabel";
            this.DatabaseSizeLabel.Size = new System.Drawing.Size(83, 19);
            this.DatabaseSizeLabel.TabIndex = 5;
            this.DatabaseSizeLabel.Text = "metroLabel5";
            // 
            // rebuildDatabaseButton
            // 
            this.rebuildDatabaseButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.rebuildDatabaseButton.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.rebuildDatabaseButton.Location = new System.Drawing.Point(232, 291);
            this.rebuildDatabaseButton.Name = "rebuildDatabaseButton";
            this.rebuildDatabaseButton.Size = new System.Drawing.Size(124, 27);
            this.rebuildDatabaseButton.TabIndex = 6;
            this.rebuildDatabaseButton.Text = "Rebuild Database";
            this.rebuildDatabaseButton.UseSelectable = true;
            this.rebuildDatabaseButton.Click += new System.EventHandler(this.rebuildDatabaseButton_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.White;
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton2.Location = new System.Drawing.Point(34, 291);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(124, 27);
            this.metroButton2.TabIndex = 7;
            this.metroButton2.Text = "User Management";
            this.metroButton2.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(34, 161);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(137, 25);
            this.metroLabel6.TabIndex = 8;
            this.metroLabel6.Text = "Default Window:";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(187, 161);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(169, 29);
            this.metroComboBox1.TabIndex = 9;
            this.metroComboBox1.UseSelectable = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 351);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.rebuildDatabaseButton);
            this.Controls.Add(this.DatabaseSizeLabel);
            this.Controls.Add(this.DatabasePathLabelText);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.DatabasePathLabel);
            this.Controls.Add(this.metroLabel1);
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel DatabasePathLabel;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel DatabasePathLabelText;
        private MetroFramework.Controls.MetroLabel DatabaseSizeLabel;
        private MetroFramework.Controls.MetroButton rebuildDatabaseButton;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
    }
}