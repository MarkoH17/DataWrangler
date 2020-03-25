using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Properties;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class Landing : MetroForm
    {
        private readonly MetroContextMenu _ctxMenuManage;
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;

        public Landing(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            _ctxMenuManage = new MetroContextMenu(Container);
            StyleHelper.LoadFormSavedStyle(this);
            _dbSettings = dbSettings;
            _user = user;
            SetupClickListeners();
            BringToFront();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new Login(_dbSettings));
        }

        private void Landing_FormClosing(object sender, FormClosingEventArgs e)
        {
            statsBackgroundWorker.CancelAsync();
            statsBackgroundWorker.DoWork -= StatsBackgroundWorker_DoWork;
            statsBackgroundWorker.ProgressChanged -= StatsBackgroundWorkerOnProgressChanged;
        }

        private void Landing_Shown(object sender, EventArgs e)
        {
            statsBackgroundWorker.RunWorkerAsync();
        }

        private void LandingScreen_Load(object sender, EventArgs e)
        {
            btnBack.Image = Theme == MetroThemeStyle.Dark ? Resources.logout_light : Resources.logout_dark;
        }


        private void LoadChartData(Dictionary<string, int> recordCounts)
        {
            if (lblRecTypes.IsDisposed || !IsHandleCreated || statsBackgroundWorker.CancellationPending) return;
            foreach (var recCnt in recordCounts)
            {
                void AddPoint()
                {
                    chartData.Series["Records By Type"].Points.AddXY(recCnt.Key, Convert.ToInt32(recCnt.Value));
                }

                if (statsBackgroundWorker != null && !statsBackgroundWorker.CancellationPending &&
                    !chartData.IsDisposed)
                    try
                    {
                        chartData.Invoke((Action) AddPoint);
                    }
                    catch
                    {
                        //ignored
                    }
            }
        }

        private void Records_Total()
        {
            if (lblRecTypes.IsDisposed || !IsHandleCreated || statsBackgroundWorker.CancellationPending) return;
            Dictionary<string, int> recordCounts = null;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var cntStatus = oH.GetRecordCounts();
                if (cntStatus.Success) recordCounts = (Dictionary<string, int>) cntStatus.Result;
            }

            if (recordCounts != null)
            {
                void SetSum()
                {
                    lblRecCount.Text = recordCounts.Sum(x => x.Value).ToString();
                }

                if (statsBackgroundWorker != null && !statsBackgroundWorker.CancellationPending &&
                    !lblRecCount.IsDisposed)
                    try
                    {
                        lblRecCount.Invoke((Action) SetSum);
                        LoadChartData(recordCounts);
                        statsBackgroundWorker.ReportProgress(100);
                    }
                    catch
                    {
                        //ignored
                    }
            }
        }

        private void RecordType_Total()
        {
            if (lblRecTypes.IsDisposed || !IsHandleCreated || statsBackgroundWorker.CancellationPending) return;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var fetchTotal = oH.GetRecordTypeCount();
                if (fetchTotal.Success)
                {
                    void SetTotal()
                    {
                        lblRecTypes.Text = fetchTotal.Result.ToString();
                    }

                    if (statsBackgroundWorker != null && !statsBackgroundWorker.CancellationPending &&
                        !lblRecTypes.IsDisposed)
                        try
                        {
                            lblRecTypes.Invoke((Action) SetTotal);
                            statsBackgroundWorker.ReportProgress(40);
                        }
                        catch
                        {
                            //ignored
                        }
                }
            }
        }

        private void SetupClickListeners()
        {
            void ManageRecordsHandler(object sender, EventArgs args)
            {
                Program.SwitchPrimaryForm(new ManageRecords(_dbSettings, _user));
            }

            void ManageRecordTypesHandler(object sender, EventArgs args)
            {
                Program.SwitchPrimaryForm(new ManageRecordTypes(_dbSettings, _user));
            }

            void ManageUserAccountsHandler(object sender, EventArgs args)
            {
                Program.SwitchPrimaryForm(new ManageUserAccounts(_dbSettings, _user));
            }

            btnImport.Click += (sender, args) => Program.SwitchPrimaryForm(new ImportRecords(_dbSettings, _user));
            btnOptions.Click += (sender, args) => new Options(this, _dbSettings, _user).ShowDialog();
            btnManage.Click += (sender, args) => _ctxMenuManage.Show(btnManage, new Point(0, btnManage.Height));
            tileRecords.Click += ManageRecordsHandler;
            tileRecTypes.Click += ManageRecordTypesHandler;
            tileUserAccts.Click += ManageUserAccountsHandler;

            _ctxMenuManage.Items.Add("Manage Records", null, ManageRecordsHandler);
            _ctxMenuManage.Items.Add("Manage Record Types", null, ManageRecordTypesHandler);
            _ctxMenuManage.Items.Add("Manage User Accounts", null, ManageUserAccountsHandler);
        }

        private void StatsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (statsBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            UserAccount_Total();
            if (statsBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            RecordType_Total();
            if (statsBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            Records_Total();
        }

        private void StatsBackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 20)
                spinner3.Visible = false;
            else if (e.ProgressPercentage == 40)
                spinner2.Visible = false;
            else if (e.ProgressPercentage == 100) spinner1.Visible = false;
        }

        private void SwitchChartStyle()
        {
            var foreColor = Theme == MetroThemeStyle.Dark ? Color.White : Color.Black;
            chartData.Legends[0].ForeColor = foreColor;
            chartData.ChartAreas[0].AxisX.LineColor = foreColor;
            chartData.ChartAreas[0].AxisX.MajorGrid.LineColor = foreColor;
            chartData.ChartAreas[0].AxisX.LabelStyle.ForeColor = foreColor;
            chartData.ChartAreas[0].AxisX.MajorTickMark.LineColor = foreColor;
            chartData.ChartAreas[0].AxisY.LineColor = foreColor;
            chartData.ChartAreas[0].AxisY.MajorGrid.LineColor = foreColor;
            chartData.ChartAreas[0].AxisY.LabelStyle.ForeColor = foreColor;
            chartData.ChartAreas[0].AxisY.MajorTickMark.LineColor = foreColor;
        }

        public void SwitchFormStyle()
        {
            btnBack.Image = Theme == MetroThemeStyle.Dark ? Resources.logout_light : Resources.logout_dark;
            SwitchChartStyle();
        }

        private void UserAccount_Total()
        {
            if (lblRecTypes.IsDisposed || !IsHandleCreated || statsBackgroundWorker.CancellationPending) return;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var fetchTotal = oH.GetUserAccountCount();
                if (fetchTotal.Success)
                {
                    void SetTotal()
                    {
                        lblUserAcc.Text = fetchTotal.Result.ToString();
                    }

                    if (statsBackgroundWorker != null && !statsBackgroundWorker.CancellationPending &&
                        !lblUserAcc.IsDisposed)
                        try
                        {
                            lblUserAcc.Invoke((Action) SetTotal);
                            statsBackgroundWorker.ReportProgress(20);
                        }
                        catch
                        {
                            //ignored
                        }
                }
            }
        }
    }
}