using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Properties;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class Landing : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;
        public Landing(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            _dbSettings = dbSettings;
            _user = user;
        }

        private void LandingScreen_Load(object sender, EventArgs e)
        {
        }

        private void lblRecord_OnLoad(object sender, EventArgs e)
        {
            using(var oH = new ObjectHelper(_dbSettings))
            {
                RecordType[] recordTypes = null;
                var recordTotal = 0;

                var recCount = oH.GetRecordTypes();
                if (recCount.Success) recordTypes = (RecordType[])recCount.Result;

                foreach( var rT in recordTypes)
                {
                    var recordType = new 
                    recordTotal += 1;
                }
                lblRecCount.Text = recordTotal.ToString();
            }
        }
    }
}