using DataWrangler.DBOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWrangler.Forms
{
    public partial class Options : MetroFramework.Forms.MetroForm
    {
        private Dictionary<string, string> _dbSettings;
        private UserAccount _user;

        public Options(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            _dbSettings = dbSettings;
            _user = user;
           
            //this.DatabaseSizeLabel = _dbSettings
            DatabasePathLabelText.Text = _dbSettings["dbFilePath"].ToString();
        }

        private void rebuildDatabaseButton_Click(object sender, EventArgs e)
        {
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var rebuildStatus = oH.RebuildDb(_dbSettings);
                if (rebuildStatus.Success)
                {
                    MessageBox.Show("Rebuild Sucessful");
                }
            }
        }
    }
}
