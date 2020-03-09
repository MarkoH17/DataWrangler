using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Properties;

namespace DataWrangler.Forms
{
    public partial class Login : Form
    {
        private readonly Dictionary<string, string> _dbSettings;

        public Login(Dictionary<string, string> dbSettings)
        {
            InitializeComponent();
            _dbSettings = dbSettings;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var oH = new ObjectHelper(_dbSettings))
            {
                var username = txtUserName.Text;
                var password = txtPassword.Text;

                var loginStatus = oH.LoginUserAccount(username, password);

                if (loginStatus.Success)
                {
                    var user = (UserAccount) loginStatus.Result;
                    try
                    {
                        Settings.Default.Username = chckRemember.Checked ? txtUserName.Text : "";

                        Settings.Default.Save();

                        if (user.Active)
                            Program.SwitchForm(new ManageRecords(_dbSettings, user));
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
            txtPassword.UseSystemPasswordChar = !chckShowPass.Checked;
        }

        public void ChckUserPassTxt_OnChange(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0)
                btnLogin.Enabled = true;
            else
                btnLogin.Enabled = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Username != string.Empty) txtUserName.Text = Settings.Default.Username;
        }

        private void txtPassword_Focus(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void txtUserName_Focus(object sender, EventArgs e)
        {
            txtUserName.Text = "";
        }
    }
}