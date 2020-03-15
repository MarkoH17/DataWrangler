using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataWrangler.DBOs;
using DataWrangler.FormControls;
using DataWrangler.Properties;
using DataWrangler.Retrievers;
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
        }

        private void Records_Total()
        {
            using(var oH = new ObjectHelper(_dbSettings, _user))
            {
                var cnt = oH.GetRecordCounts();
                var overallSum = ((Dictionary<string, int>)cnt.Result).Sum(x => x.Value);

                lblRecCount.Text = overallSum.ToString();
            }
        }
        private void RecordType_Total()
        {
            using(var oH =  new ObjectHelper(_dbSettings, _user))
            {
                _retriever = new RecordTypeRetriever(_dbSettings);
                _dataCache = new DataCache(_retriever, 500);

                int sum = _retriever.RowCount;

                lblRecTypes.Text = sum.ToString();
            }
        }

        private void UserAccount_Total()
        {
            using(var oH = new ObjectHelper(_dbSettings, _user))
            {
                _retriever = new UserAccountRetriever(_dbSettings);
                _dataCache = new DataCache(_retriever, 500);

                int sum = _retriever.RowCount;

                lblUserAcc.Text = sum.ToString();
            }
        }
        private void tileRecords_Click(object sender, EventArgs e)
        {
            Program.SwitchForm(new ManageRecords(_dbSettings, _user));
        }

        private void tileRecTypes_Click(object sender, EventArgs e)
        {
            Program.SwitchForm(new ManageRecordTypes(_dbSettings, _user));
        }

        private void tileUserAccts_Click(object sender, EventArgs e)
        {
            Program.SwitchForm(new ManageUserAccounts(_dbSettings, _user));
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            contextManage.Show(btnManage, 0, btnManage.Height);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Program.SwitchForm(new ImportRecords(_dbSettings, _user));
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            Program.SwitchForm(new Options(_dbSettings, _user));

        }

        private void btnManageRec_Click(object sender, EventArgs e)
        {
            Program.SwitchForm(new ManageRecords(_dbSettings, _user));
        }

        private void btnManageRecType_Click(object sender, EventArgs e)
        {
            Program.SwitchForm(new ManageRecordTypes(_dbSettings, _user));
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            Program.SwitchForm(new ManageUserAccounts(_dbSettings, _user));
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
    }
}