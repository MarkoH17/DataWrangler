using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.FormControls;
using DataWrangler.Retrievers;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class EditUsers : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;
        private UserAccount _users;

        private List<MetroTextBox> _txtControls = new List<MetroTextBox>();

        private DataCache _dataCache;
        private IDataRetriever _retriever;

        private MetroToolTip hintToolTip = new MetroToolTip();
   
        public EditUsers(Dictionary<string, string> dbSettings, UserAccount user, UserAccount users)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, tabUser,
                new object[] { true });

            _dbSettings = dbSettings;
            _user = user;
            _users = users;

            if (_users == null)
            {
                
            }
            else
            {
                LoadUser();
            }
        }

        private void LoadUser()
        {
            var id = _users.Id;
            txtUserId.Text = id.ToString();

            var updated = _users.LastUpdated;
            txtUpdated.Text = updated.ToString();

            var status = _users.Active;
            txtActiveStat.Text = status.ToString();

            var username = _users.Username;
            txtUsername.Text = username;

            txtOldPassword.Text = "";
        }
        private void RefreshRecord()
        {
            if (_users != null)
            {
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var userFetch = oH.GetUserAccountById(_users.Id);
                    if (userFetch.Success)
                    {
                        _users = (UserAccount)userFetch.Result;
                    }
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool needsDbAction = false;

            var txtUser = txtUsername.Text;
            var currTxtUser = _users.Username;
            bool stat = Boolean.Parse(txtActiveStat.Text);
            bool currStat = _users.Active;
            var txtPass = txtOldPassword.Text;
            var newPass = txtNewPassword.Text;
            var hashedPass = UserAccount.GetPasswordHash(txtPass);
            var hashedNew = UserAccount.GetPasswordHash(newPass);

            if ( txtUser !=  currTxtUser)
            {
                _users.Username = txtUser;
                needsDbAction = true;
            }
            if (hashedNew != hashedPass)
            {
                
                _users.Password = hashedNew;
                needsDbAction = true;
            }
            if(stat != currStat)
            {
                _users.Active = stat;
                needsDbAction = true;
            }

            if (needsDbAction)
            {
                StatusObject dbActionStatus;
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    dbActionStatus = oH.UpdateUserAccount(_users);
                    if (dbActionStatus.Success)
                    {
                        DialogResult = DialogResult.OK;
                        MessageBox.Show("You successfully updated the user account.");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update record!");
                    }
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (var oH = new ObjectHelper(_dbSettings, _users))
            {
                var username = txtUsername.Text;
                var password = txtNewPassword.Text;
                bool active = Boolean.Parse(txtActiveStat.Text);
                var success = oH.AddUserAccount(username, password, active);

                if(success.Success)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("You successfully added a new account.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to add new account!");
                }
            }
        }
    }
}