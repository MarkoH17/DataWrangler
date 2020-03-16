using System;
using System.Drawing;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.FormControls;
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

        private UserAccount _users;
        private DataCache _dataCache;
        private IDataRetriever _retriever;

        private int rowIdUsers;

        public ManageUserAccounts(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, gridUsers,
                new object[] { true });
            _dbSettings = dbSettings;
            _user = user;
            LoadUsers();
            BringToFront();
        }

        private void LoadUsers()
        {
            try
            {
                _retriever = new UserAccountRetriever(_dbSettings);
                _dataCache = new DataCache(_retriever, 500, null, null);

                foreach (var column in _retriever.Columns)
                    gridUsers.Columns.Add(column, column);

                gridUsers.RowCount = _retriever.RowCount;
                txtRowCnt.Text = _retriever.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was encountered: " + ex.Message);
            }
        }
        private void gridUsers_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (_dataCache == null) return;

            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private UserAccount GetUserBySelectedRow(int rowIdUsers)
        {
            if (rowIdUsers < 0) return null;
            int rowId = Convert.ToInt32(gridUsers.Rows[rowIdUsers].Cells[0].Value);
           UserAccount users = null;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var userFetchStatus = oH.GetUserAccountById(rowId);
                if (userFetchStatus.Success)
                {
                    users = (UserAccount)userFetchStatus.Result;
                }
                else
                {
                    MessageBox.Show("Failed to fetch record!");
                }
            }
            return users;
        }

        private void addUserMenuItem_Click(object sender, EventArgs e)
        {
            var addForm = new EditUsers(_dbSettings, _user, _users);
            var addFormResult = addForm.ShowDialog();
            if (addFormResult == DialogResult.OK)
            {
                RecordGridRefresh();
            }
        }

        private void editUsersMenuItem_Click(object sender, EventArgs e)
        {
            var rec = GetUserBySelectedRow(rowIdUsers);
            if (rec != null)
            {
                var editForm = new EditUsers(_dbSettings, _user, rec);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK)
                {
                    RecordGridRefresh();
                }
            }

        }

        private void gridUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (_users!= null && e.Button == MouseButtons.Right)
            {
                var hitTest = gridUsers.HitTest(e.X, e.Y);

                var cm = new MetroContextMenu(Container);
                if (hitTest.RowIndex > 0)
                {
                    rowIdUsers = hitTest.RowIndex;

                    gridUsers.ClearSelection();
                    gridUsers.Rows[rowIdUsers].Selected = true;

                    cm.Items.Add("Edit Record", Properties.Resources.edit_dark, editUsersMenuItem_Click);
                    cm.Items.Add("-");
                }

                cm.Items.Add("Add Record", Properties.Resources.plus_dark, addUserMenuItem_Click);

                cm.Show(gridUsers, gridUsers.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
        }

        private void RecordGridRefresh()
        {
            _retriever.ResetRowCount();
            gridUsers.RowCount = _retriever.RowCount;
            txtRowCnt.Text = _retriever.RowCount.ToString();
            RefreshVisibleRows();
        }

        private void RefreshVisibleRows()
        {
            var firstRowIdx = gridUsers.FirstDisplayedCell.RowIndex;
            var lastRowIdx = (firstRowIdx + gridUsers.DisplayedRowCount(true)) - 1;

            _dataCache.RefreshCacheByRange(firstRowIdx, lastRowIdx);
            for (int i = firstRowIdx; i <= lastRowIdx; i++)
            {
                gridUsers.InvalidateRow(i);
            }
        }

        private void gridRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rec = GetUserBySelectedRow(e.RowIndex);
            if (rec != null)
            {
                var editForm = new EditUsers(_dbSettings, _user, rec);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK)
                {
                    RecordGridRefresh();
                }
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var editForm = new EditUsers(_dbSettings, _user, null);
            var editFormResult = editForm.ShowDialog();
            if (editFormResult == DialogResult.OK)
            {
                RecordGridRefresh();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new Landing(_dbSettings, _user));
        }

        public void SwitchIconStyle()
        {
            if (Theme == MetroThemeStyle.Dark)
            {
                btnBack.Image = Resources.arrow_back_light;
            }
            else
            {
                btnBack.Image = Resources.arrow_back_dark;
            }
        }
    }
}