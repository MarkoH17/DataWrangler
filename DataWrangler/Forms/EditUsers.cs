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
        private  UserAccount _users;

        private DataCache _dataCache;
        private IDataRetriever _retriever;
   
        public EditUsers(Dictionary<string, string> dbSettings, UserAccount user, UserAccount users)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
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
            StyleHelper.LoadFormSavedStyle(this);
            BringToFront();
        }

        private void LoadUser()
        {
            var id = _users.Id;
            txtUserId.Text = id.ToString();

            var updated = _users.LastUpdated;
            txtUpdated.Text = updated.ToString();

            var status = _users.Active;
            togActiveStat.Checked = status;

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

        private void btnUpdate_Click()
        {
            bool needsDbAction = false;

            var txtUser = txtUsername.Text;
            var currTxtUser = _users.Username;
            bool stat = togActiveStat.Checked;
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

        private void btnAddUser_Click()
        {
            tabControl.TabPages.Remove(tabHistory);
            var username = txtUsername.Text;
            var password = txtOldPassword.Text;
            var passVerify = txtNewPassword.Text;
            bool active = togActiveStat.Checked;

            if (password == passVerify)
            {
                using (var oH = new ObjectHelper(_dbSettings, _users))
                {
                    var success = oH.AddUserAccount(username, password, active);
                    if (success.Success)
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
            else
            {
                MessageBox.Show("The passwords do not match!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_users == null)
            {
                btnAddUser_Click();
            }
            else
            {
                btnUpdate_Click();
                LoadHistory();
            }
        }

        private void gridAuditHistory_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        public void LoadHistory()
        {
            try
            {
                _retriever = new AuditEntryRetriever(_dbSettings, _users);
                _dataCache = new DataCache(_retriever, 500);

                gridAuditHistory.Columns.Clear();
                gridAuditHistory.Rows.Clear();

                foreach (var column in _retriever.Columns)
                    gridAuditHistory.Columns.Add(column, column);

                gridAuditHistory.RowCount = _retriever.RowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was encountered: " + ex.Message);
            }
        }
    }
}