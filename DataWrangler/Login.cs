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

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUserName.Text;
            var password = txtPassword.Text;
        }
    }
}