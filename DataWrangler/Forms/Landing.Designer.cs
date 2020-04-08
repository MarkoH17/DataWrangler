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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tileRecords = new MetroFramework.Controls.MetroTile();
            this.spinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.tileRecTypes = new MetroFramework.Controls.MetroTile();
            this.spinner2 = new MetroFramework.Controls.MetroProgressSpinner();
            this.lblRecTypes = new System.Windows.Forms.Label();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tileUserAccts = new MetroFramework.Controls.MetroTile();
            this.spinner3 = new MetroFramework.Controls.MetroProgressSpinner();
            this.lblUserAcc = new System.Windows.Forms.Label();
            this.btnManage = new MetroFramework.Controls.MetroButton();
            this.btnImport = new MetroFramework.Controls.MetroButton();
            this.btnOptions = new MetroFramework.Controls.MetroButton();
            this.btnBack = new System.Windows.Forms.Button();
            this.statsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tileRecords.SuspendLayout();
            this.tileRecTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            this.tileUserAccts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileRecords
            // 
            this.tileRecords.ActiveControl = null;
            this.tileRecords.Controls.Add(this.spinner1);
            this.tileRecords.Controls.Add(this.metroLabel1);
            this.tileRecords.Controls.Add(this.lblRecCount);
            this.tileRecords.Location = new System.Drawing.Point(43, 134);
            this.tileRecords.Name = "tileRecords";
            this.tileRecords.Size = new System.Drawing.Size(139, 121);
            this.tileRecords.TabIndex = 1;
            this.tileRecords.Text = "Records";
            this.tileRecords.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tileRecords.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tileRecords.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileRecords.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileRecords.UseSelectable = true;
            // 
            // spinner1
            // 
            this.spinner1.Location = new System.Drawing.Point(44, 26);
            this.spinner1.Maximum = 100;
            this.spinner1.Name = "spinner1";
            this.spinner1.Size = new System.Drawing.Size(50, 50);
            this.spinner1.TabIndex = 7;
            this.spinner1.UseSelectable = true;
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
            this.lblRecCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCount.ForeColor = System.Drawing.Color.White;
            this.lblRecCount.Location = new System.Drawing.Point(3, 39);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(133, 24);
            this.lblRecCount.TabIndex = 0;
            this.lblRecCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tileRecTypes
            // 
            this.tileRecTypes.ActiveControl = null;
            this.tileRecTypes.Controls.Add(this.spinner2);
            this.tileRecTypes.Controls.Add(this.lblRecTypes);
            this.tileRecTypes.Location = new System.Drawing.Point(329, 134);
            this.tileRecTypes.Name = "tileRecTypes";
            this.tileRecTypes.Size = new System.Drawing.Size(139, 121);
            this.tileRecTypes.TabIndex = 2;
            this.tileRecTypes.Text = "Record Types";
            this.tileRecTypes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tileRecTypes.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileRecTypes.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileRecTypes.UseSelectable = true;
            // 
            // spinner2
            // 
            this.spinner2.Location = new System.Drawing.Point(44, 26);
            this.spinner2.Maximum = 100;
            this.spinner2.Name = "spinner2";
            this.spinner2.Size = new System.Drawing.Size(50, 50);
            this.spinner2.TabIndex = 8;
            this.spinner2.UseSelectable = true;
            // 
            // lblRecTypes
            // 
            this.lblRecTypes.BackColor = System.Drawing.Color.Transparent;
            this.lblRecTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecTypes.ForeColor = System.Drawing.Color.White;
            this.lblRecTypes.Location = new System.Drawing.Point(3, 39);
            this.lblRecTypes.Name = "lblRecTypes";
            this.lblRecTypes.Size = new System.Drawing.Size(133, 24);
            this.lblRecTypes.TabIndex = 0;
            this.lblRecTypes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartData
            // 
            this.chartData.BackColor = System.Drawing.Color.Transparent;
            this.chartData.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            this.chartData.BorderlineWidth = 0;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea1);
            this.chartData.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            this.chartData.Legends.Add(legend1);
            this.chartData.Location = new System.Drawing.Point(12, 270);
            this.chartData.Name = "chartData";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Records By Type";
            this.chartData.Series.Add(series1);
            this.chartData.Size = new System.Drawing.Size(778, 178);
            this.chartData.TabIndex = 0;
            this.chartData.TabStop = false;
            this.chartData.Text = "Records Per Record Type";
            this.chartData.Visible = false;
            // 
            // tileUserAccts
            // 
            this.tileUserAccts.ActiveControl = null;
            this.tileUserAccts.Controls.Add(this.spinner3);
            this.tileUserAccts.Controls.Add(this.lblUserAcc);
            this.tileUserAccts.Location = new System.Drawing.Point(610, 134);
            this.tileUserAccts.Name = "tileUserAccts";
            this.tileUserAccts.Size = new System.Drawing.Size(139, 121);
            this.tileUserAccts.TabIndex = 3;
            this.tileUserAccts.Text = "User Accounts";
            this.tileUserAccts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tileUserAccts.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileUserAccts.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileUserAccts.UseSelectable = true;
            // 
            // spinner3
            // 
            this.spinner3.Location = new System.Drawing.Point(44, 26);
            this.spinner3.Maximum = 100;
            this.spinner3.Name = "spinner3";
            this.spinner3.Size = new System.Drawing.Size(50, 50);
            this.spinner3.TabIndex = 9;
            this.spinner3.UseSelectable = true;
            // 
            // lblUserAcc
            // 
            this.lblUserAcc.BackColor = System.Drawing.Color.Transparent;
            this.lblUserAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAcc.ForeColor = System.Drawing.Color.White;
            this.lblUserAcc.Location = new System.Drawing.Point(3, 39);
            this.lblUserAcc.Name = "lblUserAcc";
            this.lblUserAcc.Size = new System.Drawing.Size(133, 24);
            this.lblUserAcc.TabIndex = 0;
            this.lblUserAcc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnManage
            // 
            this.btnManage.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnManage.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnManage.Location = new System.Drawing.Point(126, 58);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(104, 24);
            this.btnManage.TabIndex = 5;
            this.btnManage.Text = "Manage";
            this.btnManage.UseSelectable = true;
            // 
            // btnImport
            // 
            this.btnImport.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnImport.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnImport.Location = new System.Drawing.Point(23, 58);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(104, 24);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseSelectable = true;
            // 
            // btnOptions
            // 
            this.btnOptions.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnOptions.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnOptions.Location = new System.Drawing.Point(229, 58);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(104, 24);
            this.btnOptions.TabIndex = 6;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseSelectable = true;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::DataWrangler.Properties.Resources.logout_dark;
            this.btnBack.Location = new System.Drawing.Point(23, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(24, 24);
            this.btnBack.TabIndex = 0;
            this.btnBack.TabStop = false;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // statsBackgroundWorker
            // 
            this.statsBackgroundWorker.WorkerReportsProgress = true;
            this.statsBackgroundWorker.WorkerSupportsCancellation = true;
            this.statsBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.StatsBackgroundWorker_DoWork);
            this.statsBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.StatsBackgroundWorkerOnProgressChanged);
            // 
            // Landing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.tileUserAccts);
            this.Controls.Add(this.chartData);
            this.Controls.Add(this.tileRecTypes);
            this.Controls.Add(this.tileRecords);
            this.MaximizeBox = false;
            this.Name = "Landing";
            this.Resizable = false;
            this.Text = "     Data Wrangler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Landing_FormClosing);
            this.Load += new System.EventHandler(this.LandingScreen_Load);
            this.Shown += new System.EventHandler(this.Landing_Shown);
            this.tileRecords.ResumeLayout(false);
            this.tileRecords.PerformLayout();
            this.tileRecTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            this.tileUserAccts.ResumeLayout(false);
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
        private MetroButton btnImport;
        private MetroButton btnOptions;
        private MetroLabel metroLabel1;
        private Button btnBack;
        private MetroProgressSpinner spinner1;
        private MetroProgressSpinner spinner3;
        private MetroProgressSpinner spinner2;
        private System.ComponentModel.BackgroundWorker statsBackgroundWorker;
    }
}