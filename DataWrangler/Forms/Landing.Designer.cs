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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tileRecords = new MetroFramework.Controls.MetroTile();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.tileRecTypes = new MetroFramework.Controls.MetroTile();
            this.label2 = new System.Windows.Forms.Label();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tileUserAccts = new MetroFramework.Controls.MetroTile();
            this.label3 = new System.Windows.Forms.Label();
            this.tileRecords.SuspendLayout();
            this.tileRecTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tileUserAccts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileRecords
            // 
            this.tileRecords.ActiveControl = null;
            this.tileRecords.Controls.Add(this.lblRecCount);
            this.tileRecords.Location = new System.Drawing.Point(69, 98);
            this.tileRecords.Name = "tileRecords";
            this.tileRecords.Size = new System.Drawing.Size(139, 121);
            this.tileRecords.TabIndex = 0;
            this.tileRecords.Text = "Records";
            this.tileRecords.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tileRecords.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tileRecords.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileRecords.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileRecords.UseSelectable = true;
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
            this.tileRecTypes.Controls.Add(this.label2);
            this.tileRecTypes.Location = new System.Drawing.Point(309, 98);
            this.tileRecTypes.Name = "tileRecTypes";
            this.tileRecTypes.Size = new System.Drawing.Size(139, 121);
            this.tileRecTypes.TabIndex = 1;
            this.tileRecTypes.Text = "Record Types";
            this.tileRecTypes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tileRecTypes.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileRecTypes.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileRecTypes.UseSelectable = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(56, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "100";
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(12, 270);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Maps";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(778, 178);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // tileUserAccts
            // 
            this.tileUserAccts.ActiveControl = null;
            this.tileUserAccts.Controls.Add(this.label3);
            this.tileUserAccts.Location = new System.Drawing.Point(549, 98);
            this.tileUserAccts.Name = "tileUserAccts";
            this.tileUserAccts.Size = new System.Drawing.Size(139, 121);
            this.tileUserAccts.TabIndex = 4;
            this.tileUserAccts.Text = "User Accounts";
            this.tileUserAccts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tileUserAccts.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileUserAccts.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileUserAccts.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(54, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "100";
         
            // 
            // Landing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tileUserAccts);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.tileRecTypes);
            this.Controls.Add(this.tileRecords);
            this.Name = "Landing";
            this.Text = "Data Wrangler Main";
            this.Load += new System.EventHandler(this.LandingScreen_Load);
            this.tileRecords.ResumeLayout(false);
            this.tileRecords.PerformLayout();
            this.tileRecTypes.ResumeLayout(false);
            this.tileRecTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tileUserAccts.ResumeLayout(false);
            this.tileUserAccts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroTile tileRecords;
        private MetroTile tileRecTypes;
        private MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label lblRecCount;
        private MetroTile tileUserAccts;
        private Label label2;
        private Label label3;
    }
}