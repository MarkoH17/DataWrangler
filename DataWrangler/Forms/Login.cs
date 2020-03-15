using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Properties;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class Login : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;

        public Login(Dictionary<string, string> dbSettings)
        {
            InitializeComponent();
            _dbSettings = dbSettings;
            BringToFront();
        }

        private void LoadSavedFields()
        {
            var savedLoginConfig = ConfigurationHelper.GetLoginSettings();
            var username = "";
            if (savedLoginConfig.Keys.Count > 0)
            {
                savedLoginConfig.TryGetValue("Username", out username);
            }

            if (!string.IsNullOrEmpty(username))
            {
                txtUserName.Text = username;
                chckRemember.Checked = true;
            }
            
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var oH = new ObjectHelper(_dbSettings))
            {
                var username = txtUserName.Text;
                var password = txtPassword.Text;

                var loginStatus = oH.LoginUserAccount(username, password);

                if (loginStatus.Success && loginStatus.Result != null)
                {
                    var user = (UserAccount) loginStatus.Result;
                    try
                    {
                        if(chckRemember.Checked)
                            ConfigurationHelper.SaveLoginSettings(username);
                        else
                            ConfigurationHelper.SaveLoginSettings(null);
                        

                        if (user.Active)
                            Program.SwitchForm(new Landing(_dbSettings, user));
                        else
                            MessageBox.Show("Account disabled! Please contact administrator.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong. Please retry.");
                    }
                }
                else
                {
                    MessageBox.Show("Authentication Failure");
                    
                }
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

        private void Login_Shown(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0)
                txtPassword.Focus();
            else
                txtUserName.Focus();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoadSavedFields();
        }
    }
}