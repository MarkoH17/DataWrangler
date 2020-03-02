using DataWrangler.DBOs;
using DataWrangler.Retrievers;
using LiteDB;
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
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;
            if (chckRemember.Checked == true)
            {
                Properties.Settings.Default.Username = txtUserName.Text;
                Properties.Settings.Default.Password = txtPassword.Text;
                Properties.Settings.Default.Save();
            }
             if(chckRemember.Checked == false)
            {
                Properties.Settings.Default.Username ="";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }
               using(var db = new LiteDB.LiteDatabase(connectionString))
            {
                var collection = db.GetCollection<UserAccount>("user");
                var user = collection.Find(txtUserName.Text);
                var password = txtPassword.Text;
                
                if(txtUserName.Text != user.ToString())
                {
                    string wrongUser = "Username is incorrect or does not exist.";
                    MessageBox.Show(wrongUser);
                }
                else
                {
                    if (!user.Equals(password))
                    {
                        MessageBox.Show("Invalid Password.");
                    }
                    else
                    {
                        this.Hide();
                        LandingScreen l = new LandingScreen();
                        l.Show();
                    }
                    {

                    }
                }
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void chckRemember_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chckShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chckShowPass.Checked == true){
                txtPassword.UseSystemPasswordChar =false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.Username != string.Empty)
            {
                txtUserName.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
            }
        }
    }
}