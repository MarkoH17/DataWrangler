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
using DataWrangler.Properties;
using LiteDB;
using MetroFramework;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class Options : MetroFramework.Forms.MetroForm
    {
        private Dictionary<string, string> _dbSettings;
        private UserAccount _user;
        private MetroForm _parentForm;

        public Options(MetroForm parentForm, Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            _dbSettings = dbSettings;
            _user = user;
            _parentForm = parentForm;
            LoadDatabaseValues();
            LoadStyles();
            BringToFront();
        }

        private void LoadDatabaseValues()
        {
            var dbFilePath = "";
            if (_dbSettings != null)
            {
                _dbSettings.TryGetValue("dbFilePath", out dbFilePath);
            }

            lblDatabasePathValue.Text = dbFilePath;

            var dbSize = 0;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var fetchSizeStatus = oH.GetDbSize();
                if (fetchSizeStatus.Success)
                {
                    dbSize = (int)fetchSizeStatus.Result;
                }
            }

            lblDatabaseSizeValue.Text = dbSize.ToString();
        }

        private void LoadStyles()
        {
            foreach (var color in Enum.GetValues(typeof(MetroColorStyle)))
            {
                if (color.ToString().Equals("White") || color.ToString().Equals("Black") || color.ToString().Equals("Default")) continue;
                comboStyle.Items.Add(color);
            }

            var currThemeStyle = Theme;
            var currColorStyle = Style;

            if (currThemeStyle == MetroThemeStyle.Dark)
                tglDarkMode.Checked = true;

            comboStyle.SelectedItem = currColorStyle;
        }

        private void rebuildDatabaseButton_Click(object sender, EventArgs e)
        {
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var rebuildStatus = oH.RebuildDb(_dbSettings);
                if (rebuildStatus.Success)
                {
                    MessageBox.Show("Rebuild Successful");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var useDarkMode = tglDarkMode.Checked;
            var themeStyle = useDarkMode ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            var colorStyle = (MetroColorStyle)comboStyle.SelectedItem;

            ConfigurationHelper.SaveStyleSettings(themeStyle, colorStyle);
            StyleHelper.LoadFormSavedStyle(this);
            StyleHelper.LoadFormSavedStyle(_parentForm);
            Close();
        }

        private void comboStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            var colorStyle = (MetroColorStyle)comboStyle.SelectedItem;
            StyleHelper.PreviewFormStyle(this, Theme, colorStyle);
        }

        private void tglDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            var useDarkMode = tglDarkMode.Checked;
            var themeStyle = useDarkMode ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            StyleHelper.PreviewFormStyle(this, themeStyle, Style);
        }
    }
}
