using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Properties;
using DataWrangler.Retrievers;
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
            BringToFront();
        }

        private void LandingScreen_Load(object sender, EventArgs e)
        {
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
    }
}