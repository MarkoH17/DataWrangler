using System;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class WelcomeCreds : MetroForm
    {
        public WelcomeCreds(string username, string password)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            txtUser.Text = username;
            txtPass.Text = password;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}