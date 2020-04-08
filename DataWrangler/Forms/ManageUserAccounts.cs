using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Properties;
using DataWrangler.Retrievers;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class ManageUserAccounts : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;
        private DataCache _dataCache;
        private IDataRetriever _retriever;

        private int _rowIdUsers;

        private UserAccount _users;

        public ManageUserAccounts(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, gridUsers,
                new object[] {true});
            _dbSettings = dbSettings;
            _user = user;
            BringToFront();
        }

        private void addUserMenuItem_Click(object sender, EventArgs e)
        {
            _users = null;
            var dialogResult = Program.ShowDialog(this, new EditUser(_dbSettings, _user, _users));
            if (dialogResult == DialogResult.OK) UserGridRefresh();
            BringToFront();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new Landing(_dbSettings, _user));
        }

        private void editUsersMenuItem_Click(object sender, EventArgs e)
        {
            var rec = GetUserBySelectedRow(_rowIdUsers);
            if (rec != null)
            {
                var dialogResult = Program.ShowDialog(this, new EditUser(_dbSettings, _user, rec));
                if (dialogResult == DialogResult.OK) UserGridRefresh();
                BringToFront();
            }
        }

        private UserAccount GetUserBySelectedRow(int rowIdUsers)
        {
            if (rowIdUsers < 0) return null;
            var rowId = Convert.ToInt32(gridUsers.Rows[rowIdUsers].Cells[0].Value);
            UserAccount users = null;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var userFetchStatus = oH.GetUserAccountById(rowId);
                if (userFetchStatus.Success)
                    users = (UserAccount) userFetchStatus.Result;
                else
                    NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                        "Failed to fetch this user account. Please try again.");
            }

            return users;
        }

        private void gridRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rec = GetUserBySelectedRow(e.RowIndex);
            if (rec != null)
            {
                var dialogResult = Program.ShowDialog(this, new EditUser(_dbSettings, _user, rec));
                if (dialogResult == DialogResult.OK) UserGridRefresh();
                BringToFront();
            }
        }

        private void gridUsers_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (_dataCache == null) return;

            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private void gridUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (_user != null && e.Button == MouseButtons.Right)
            {
                var hitTest = gridUsers.HitTest(e.X, e.Y);

                var cm = new MetroContextMenu(Container);
                if (hitTest.RowIndex >= 0)
                {
                    _rowIdUsers = hitTest.RowIndex;

                    gridUsers.ClearSelection();
                    gridUsers.Rows[_rowIdUsers].Selected = true;

                    cm.Items.Add("Edit User", Resources.edit_dark, editUsersMenuItem_Click);
                    cm.Items.Add("-");
                }

                cm.Items.Add("Add User", Resources.plus_dark, addUserMenuItem_Click);

                cm.Show(gridUsers, gridUsers.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
        }

        private void LoadUsers()
        {
            try
            {
                _retriever = new UserAccountRetriever(_dbSettings);
                _dataCache = new DataCache(_retriever, 500);

                foreach (var column in _retriever.Columns)
                    gridUsers.Columns.Add(column, column);

                gridUsers.RowCount = _retriever.RowCount;
                txtRowCnt.Text = _retriever.RowCount.ToString();
            }
            catch (Exception)
            {
                NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                    "Failed to load user accounts. Please try again.");
            }
        }

        private void ManageUserAccounts_Load_1(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void UserGridRefresh()
        {
            _retriever.ResetRowCount();
            gridUsers.RowCount = _retriever.RowCount;
            txtRowCnt.Text = _retriever.RowCount.ToString();
            RefreshVisibleRows();
        }

        private void RefreshVisibleRows()
        {
            var firstRowIdx = gridUsers.FirstDisplayedCell.RowIndex;
            var lastRowIdx = firstRowIdx + gridUsers.DisplayedRowCount(true) - 1;

            _dataCache.RefreshCacheByRange(firstRowIdx, lastRowIdx);
            for (var i = firstRowIdx; i <= lastRowIdx; i++) gridUsers.InvalidateRow(i);
        }

        public void SwitchFormStyle()
        {
            btnBack.Image = Theme == MetroThemeStyle.Dark ? Resources.arrow_back_light : Resources.arrow_back_dark;
        }
    }
}