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
using LiteDB;

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
           
            
            LoadValues();
            
        }

        private void LoadValues()
        {
            var dbFilePath = "";
            if (_dbSettings != null)
            {
                _dbSettings.TryGetValue("dbFilePath", out dbFilePath);
            }

            DatabasePathLabelText.Text = dbFilePath;

            var dbSize = 0;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var fetchSizeStatus = oH.GetDbSize();
                if (fetchSizeStatus.Success)
                {
                    var fetchResult = (BsonDocument) fetchSizeStatus.Result;
                    fetchResult.TryGetValue("dataFileSize", out var dbSizeVal);
                    if (dbSizeVal != null)
                        dbSize = dbSizeVal.AsInt32;
                }
            }

            DatabaseSizeLabel.Text = dbSize.ToString();
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
