using DataWrangler.DBOs;
using System;
using System.Windows.Forms;

namespace DataWrangler
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.Dictionary<string, string> settings = ConfigurationHelper.GetDbSettings();

            using (var oH = new ObjectHelper(settings, null))
            {
                var loginStatus = oH.LoginUserAccount(txtUserName.Text, txtPassword.Text);
                /***********I used the commented out code to add my user account. I'm sure there is a better way to do this*************/
                //var createAccount = oH.AddUserAccount(txtUserName.Text, txtPassword.Text, true);
                //if (createAccount.Success)
                //{
                //    MessageBox.Show("Success");
                //    createAccount.Result = new UserAccount();
                //}
                //else
                //{
                //    MessageBox.Show("Something failed");
                //}
                if (loginStatus.Success)
                {
                    UserAccount user = (UserAccount)loginStatus.Result;
                    try
                    {
                        if (chckRemember.Checked == true)
                        {
                            Properties.Settings.Default.Username = txtUserName.Text;
                            Properties.Settings.Default.Password = txtPassword.Text;
                            Properties.Settings.Default.Save();
                        }
                        if (chckRemember.Checked == false)
                        {
                            Properties.Settings.Default.Username = "";
                            Properties.Settings.Default.Password = "";
                            Properties.Settings.Default.Save();
                        }
                        if (user.Active == true)
                        {
                            LandingScreen land = new LandingScreen();
                            land.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to login. Please retry");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong. Please retry.");
                    }
                }
            }
        }

        private void chckShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chckShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                txtUserName.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
            }
        }
        private void txtUserName_Focus(object sender, EventArgs e)
        {
            txtUserName.Text = "";
        }
        private void txtPassword_Focus(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }
    }
}