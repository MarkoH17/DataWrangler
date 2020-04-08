using System;
using System.Collections.Generic;
using DataWrangler.DBOs;
using DataWrangler.Properties;
using MetroFramework;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class Login : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;

        public Login(Dictionary<string, string> dbSettings)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            _dbSettings = dbSettings;
            BringToFront();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserAccount user = null;
            try
            {
                using (var oH = new ObjectHelper(_dbSettings))
                {
                    var username = txtUserName.Text;
                    var password = txtPassword.Text;

                    var loginStatus = oH.LoginUserAccount(username, password);

                    if (loginStatus.Success && loginStatus.Result != null)
                    {
                        user = (UserAccount) loginStatus.Result;

                        ConfigurationHelper.SaveLoginSettings(chckRemember.Checked ? username : null);

                        if (!user.Active)
                        {
                            NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                                "Your account is disabled. Please contact your administrator.");
                            txtUserName.Focus();
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                    "An error occured while trying to access the database. Try again.");
            }


            if (user != null)
            {
                Program.SwitchPrimaryForm(new Landing(_dbSettings, user), false);
            }
            else
            {
                NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                    "Authentication failure. Please try again.");
                txtUserName.Focus();
            }
        }

        private void chckShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chckShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        public void ChckUserPassTxt_OnChange(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0)
                btnLogin.Enabled = true;
            else
                btnLogin.Enabled = false;
        }

        private void LoadSavedFields()
        {
            var savedLoginConfig = ConfigurationHelper.GetLoginSettings();
            var username = "";
            if (savedLoginConfig.Keys.Count > 0) savedLoginConfig.TryGetValue("Username", out username);

            if (!string.IsNullOrEmpty(username))
            {
                txtUserName.Text = username;
                chckRemember.Checked = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoadSavedFields();

            txtUserName.Icon = Theme == MetroThemeStyle.Dark ? Resources.user_light : Resources.user_dark;
            txtPassword.Icon = Theme == MetroThemeStyle.Dark ? Resources.key_light : Resources.key_dark;
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0)
                txtPassword.Focus();
            else
                txtUserName.Focus();
        }
    }
}