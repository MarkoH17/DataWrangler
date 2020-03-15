using System.Windows.Forms;
using MetroFramework.Controls;
namespace DataWrangler.Forms
{
    partial class Landing
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tileRecords = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.tileRecTypes = new MetroFramework.Controls.MetroTile();
            this.lblRecTypes = new System.Windows.Forms.Label();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tileUserAccts = new MetroFramework.Controls.MetroTile();
            this.lblUserAcc = new System.Windows.Forms.Label();
            this.btnManage = new MetroFramework.Controls.MetroButton();
            this.contextManage = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.btnManageRec = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManageRecType = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManageUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImport = new MetroFramework.Controls.MetroButton();
            this.btnOptions = new MetroFramework.Controls.MetroButton();
            this.tileRecords.SuspendLayout();
            this.tileRecTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            this.tileUserAccts.SuspendLayout();
            this.contextManage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileRecords
            // 
            this.tileRecords.ActiveControl = null;
            this.tileRecords.Controls.Add(this.metroLabel1);
            this.tileRecords.Controls.Add(this.lblRecCount);
            this.tileRecords.Location = new System.Drawing.Point(43, 134);
            this.tileRecords.Name = "tileRecords";
            this.tileRecords.Size = new System.Drawing.Size(139, 121);
            this.tileRecords.TabIndex = 0;
            this.tileRecords.Text = "Records";
            this.tileRecords.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tileRecords.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tileRecords.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileRecords.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileRecords.UseSelectable = true;
            this.tileRecords.Click += new System.EventHandler(this.tileRecords_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(28, 31);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(0, 0);
            this.metroLabel1.TabIndex = 1;
            // 
            // lblRecCount
            // 
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCount.ForeColor = System.Drawing.Color.White;
            this.lblRecCount.Location = new System.Drawing.Point(40, 26);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(0, 24);
            this.lblRecCount.TabIndex = 0;
            // 
            // tileRecTypes
            // 
            this.tileRecTypes.ActiveControl = null;
            this.tileRecTypes.Controls.Add(this.lblRecTypes);
            this.tileRecTypes.Location = new System.Drawing.Point(304, 134);
            this.tileRecTypes.Name = "tileRecTypes";
            this.tileRecTypes.Size = new System.Drawing.Size(139, 121);
            this.tileRecTypes.TabIndex = 1;
            this.tileRecTypes.Text = "Record Types";
            this.tileRecTypes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tileRecTypes.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileRecTypes.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileRecTypes.UseSelectable = true;
            this.tileRecTypes.Click += new System.EventHandler(this.tileRecTypes_Click);
            // 
            // lblRecTypes
            // 
            this.lblRecTypes.AutoSize = true;
            this.lblRecTypes.BackColor = System.Drawing.Color.Transparent;
            this.lblRecTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecTypes.ForeColor = System.Drawing.Color.White;
            this.lblRecTypes.Location = new System.Drawing.Point(56, 36);
            this.lblRecTypes.Name = "lblRecTypes";
            this.lblRecTypes.Size = new System.Drawing.Size(0, 24);
            this.lblRecTypes.TabIndex = 0;
            // 
            // chartData
            // 
            this.chartData.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea1);
            this.chartData.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "Legend1";
            this.chartData.Legends.Add(legend1);
            this.chartData.Location = new System.Drawing.Point(12, 270);
            this.chartData.Name = "chartData";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Records By Type";
            this.chartData.Series.Add(series1);
            this.chartData.Size = new System.Drawing.Size(778, 178);
            this.chartData.TabIndex = 3;
            this.chartData.Text = "Records Per Record Type";
            // 
            // tileUserAccts
            // 
            this.tileUserAccts.ActiveControl = null;
            this.tileUserAccts.Controls.Add(this.lblUserAcc);
            this.tileUserAccts.Location = new System.Drawing.Point(570, 134);
            this.tileUserAccts.Name = "tileUserAccts";
            this.tileUserAccts.Size = new System.Drawing.Size(139, 121);
            this.tileUserAccts.TabIndex = 4;
            this.tileUserAccts.Text = "User Accounts";
            this.tileUserAccts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tileUserAccts.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileUserAccts.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileUserAccts.UseSelectable = true;
            this.tileUserAccts.Click += new System.EventHandler(this.tileUserAccts_Click);
            // 
            // lblUserAcc
            // 
            this.lblUserAcc.AutoSize = true;
            this.lblUserAcc.BackColor = System.Drawing.Color.Transparent;
            this.lblUserAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAcc.ForeColor = System.Drawing.Color.White;
            this.lblUserAcc.Location = new System.Drawing.Point(54, 36);
            this.lblUserAcc.Name = "lblUserAcc";
            this.lblUserAcc.Size = new System.Drawing.Size(0, 24);
            this.lblUserAcc.TabIndex = 0;
            // 
            // btnManage
            // 
            this.btnManage.Location = new System.Drawing.Point(127, 54);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(104, 20);
            this.btnManage.TabIndex = 5;
            this.btnManage.Text = "Manage";
            this.btnManage.UseSelectable = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // contextManage
            // 
            this.contextManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnManageRec,
            this.btnManageRecType,
            this.btnManageUsers});
            this.contextManage.Name = "contextManage";
            this.contextManage.Size = new System.Drawing.Size(190, 70);
            // 
            // btnManageRec
            // 
            this.btnManageRec.Name = "btnManageRec";
            this.btnManageRec.Size = new System.Drawing.Size(189, 22);
            this.btnManageRec.Text = "Manage Records";
            this.btnManageRec.Click += new System.EventHandler(this.btnManageRec_Click);
            // 
            // btnManageRecType
            // 
            this.btnManageRecType.Name = "btnManageRecType";
            this.btnManageRecType.Size = new System.Drawing.Size(189, 22);
            this.btnManageRecType.Text = "Manage Record Types";
            this.btnManageRecType.Click += new System.EventHandler(this.btnManageRecType_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(189, 22);
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(23, 54);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(104, 20);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.UseSelectable = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(223, 54);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(104, 20);
            this.btnOptions.TabIndex = 9;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseSelectable = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // Landing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.tileUserAccts);
            this.Controls.Add(this.chartData);
            this.Controls.Add(this.tileRecTypes);
            this.Controls.Add(this.tileRecords);
            this.Name = "Landing";
            this.Text = "Data Wrangler Main";
            this.Load += new System.EventHandler(this.LandingScreen_Load);
            this.tileRecords.ResumeLayout(false);
            this.tileRecords.PerformLayout();
            this.tileRecTypes.ResumeLayout(false);
            this.tileRecTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            this.tileUserAccts.ResumeLayout(false);
            this.tileUserAccts.PerformLayout();
            this.contextManage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroTile tileRecords;
        private MetroTile tileRecTypes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartData;
        private Label lblRecCount;
        private MetroTile tileUserAccts;
        private Label lblRecTypes;
        private Label lblUserAcc;
        private MetroButton btnManage;
        private MetroContextMenu contextManage;
        private ToolStripMenuItem btnManageRec;
        private ToolStripMenuItem btnManageRecType;
        private ToolStripMenuItem btnManageUsers;
        private MetroButton btnImport;
        private MetroButton btnOptions;
        private MetroLabel metroLabel1;
    }
}