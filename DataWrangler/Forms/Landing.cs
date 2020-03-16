using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataWrangler.DBOs;
using DataWrangler.FormControls;
using DataWrangler.Properties;
using DataWrangler.Retrievers;
using MetroFramework;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class Landing : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;

        private DataCache _dataCache;
        private IDataRetriever _retriever;
        private RecordType _recordtype;
        public Landing(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            _dbSettings = dbSettings;
            _user = user;
            BringToFront();
        }

        private void LandingScreen_Load(object sender, EventArgs e)
        {
            ChartData_Load();
            Records_Total();
            UserAccount_Total();
            RecordType_Total();
            btnBack.Image = Theme == MetroThemeStyle.Dark ? Resources.logout_light : Resources.logout_dark;
        }

        private void Records_Total()
        {
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {

                var cnt = oH.GetRecordCounts();
                var overallSum = ((Dictionary<string, int>)cnt.Result).Sum(x => x.Value);

                lblRecCount.Text = overallSum.ToString();
            }
        }
        private void RecordType_Total()
        {
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var fetchTotal = oH.GetRecordTypeCount();
                if (fetchTotal.Success)
                    lblRecTypes.Text = (fetchTotal.Result).ToString();
            }
        }

        private void UserAccount_Total()
        {
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var fetchTotal = oH.GetUserAccountCount();
                if (fetchTotal.Success)
                    lblUserAcc.Text = (fetchTotal.Result).ToString();
            }
        }
        private void tileRecords_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new ManageRecords(_dbSettings, _user));
        }

        private void tileRecTypes_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new ManageRecordTypes(_dbSettings, _user));
        }

        private void tileUserAccts_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new ManageUserAccounts(_dbSettings, _user));
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            contextManage.Show(btnManage, 0, btnManage.Height);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new ImportRecords(_dbSettings, _user));
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            var optionsForm = new Options(this, _dbSettings, _user);
            optionsForm.ShowDialog();
        }

        private void btnManageRec_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new ManageRecords(_dbSettings, _user));
        }

        private void btnManageRecType_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new ManageRecordTypes(_dbSettings, _user));
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new ManageUserAccounts(_dbSettings, _user));
        }

        private void ChartData_Load()
        {
            RecordType[] recordTypes = null;
            Dictionary<string, int> recordVals = null;
            //var keyArray = new List<string>();
            //var cntArray = new List<int>();
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var result = oH.GetRecordTypes();
                if (result.Success) recordTypes = (RecordType[])result.Result;
                var cnt = oH.GetRecordCounts();
                if (cnt.Success) recordVals = (Dictionary<string, int>)cnt.Result;
                string[] keyArray = recordVals.Keys.ToArray();
                int[] cntArray = recordVals.Values.ToArray();
                for (int i = 0; i < recordTypes.Length; i++)
                {
                    chartData.Series["Records By Type"].Points.AddXY(keyArray[i].ToString(), Convert.ToInt32(cntArray[i]));
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new Login(_dbSettings));
        }

        public void SwitchIconStyle()
        {
            if (Theme == MetroThemeStyle.Dark)
            {
                btnBack.Image = Resources.logout_light;
            }
            else
            {
                btnBack.Image = Resources.logout_dark;
            }
        }
    }
}