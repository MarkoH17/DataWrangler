using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataWrangler.DBOs;
using MetroFramework;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class Options : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly MetroForm _parentForm;
        private readonly UserAccount _user;

        public Options(MetroForm parentForm, Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            _dbSettings = dbSettings;
            _user = user;
            _parentForm = parentForm;
            BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var useDarkMode = tglDarkMode.Checked;
            var themeStyle = useDarkMode ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            var colorStyle = (MetroColorStyle) comboStyle.SelectedItem;

            ConfigurationHelper.SaveStyleSettings(themeStyle, colorStyle);
            StyleHelper.LoadFormSavedStyle(this);
            StyleHelper.LoadFormSavedStyle(_parentForm);
            Close();
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            ConfigurationHelper.ResetAllPreferences();
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void comboStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            var colorStyle = (MetroColorStyle) comboStyle.SelectedItem;
            StyleHelper.PreviewFormStyle(this, Theme, colorStyle);
            StyleHelper.PreviewFormStyle(_parentForm, Theme, colorStyle);
        }

        private string DbSizeConverter(long dbSize)
        {
            string[] sizeSuffixes = {"bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"};

            string SizeSuffix(long value, int decimalPlaces = 1)
            {
                if (value < 0) return "-" + SizeSuffix(-value);

                var i = 0;
                decimal dValue = value;
                while (Math.Round(dValue, decimalPlaces) >= 1000)
                {
                    dValue /= 1024;
                    i++;
                }

                return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, sizeSuffixes[i]);
            }

            return SizeSuffix(dbSize);
        }

        private void LoadDatabaseValues()
        {
            var dbFilePath = "";
            _dbSettings?.TryGetValue("dbFilePath", out dbFilePath);

            lblDatabasePathValue.Text = dbFilePath;

            var dbSize = 0;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var fetchSizeStatus = oH.GetDbSize();
                if (fetchSizeStatus.Success) dbSize = (int) fetchSizeStatus.Result;
            }

            lblDatabaseSizeValue.Text = DbSizeConverter(dbSize);
            //lblDatabaseSizeValue.Text = dbSize.ToString();
        }

        private void LoadStyles()
        {
            foreach (var color in Enum.GetValues(typeof(MetroColorStyle)))
            {
                if (color.ToString().Equals("White") || color.ToString().Equals("Black") ||
                    color.ToString().Equals("Default")) continue;
                comboStyle.Items.Add(color);
            }

            var currThemeStyle = Theme;
            var currColorStyle = Style;

            if (currThemeStyle == MetroThemeStyle.Dark)
                tglDarkMode.Checked = true;

            comboStyle.SelectedItem = currColorStyle;
        }

        private void Options_Load(object sender, EventArgs e)
        {
            LoadDatabaseValues();
            LoadStyles();
        }

        private void rebuildDatabaseButton_Click(object sender, EventArgs e)
        {
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var rebuildStatus = oH.RebuildDb(_dbSettings);
                if (rebuildStatus.Success)
                    NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Information,
                        "Successfully rebuilt database!");
                else
                    NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                        "Failed to rebuild database. Please try again.");
            }
        }

        private void tglDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            var useDarkMode = tglDarkMode.Checked;
            var themeStyle = useDarkMode ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            StyleHelper.PreviewFormStyle(this, themeStyle, Style);
            StyleHelper.PreviewFormStyle(_parentForm, themeStyle, Style);
        }
    }
}