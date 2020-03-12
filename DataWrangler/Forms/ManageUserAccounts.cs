using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.FormControls;
using DataWrangler.Retrievers;
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

        private UserAccountRetriever userAccount;
        private UserAccount _users;
        private int _rowIdxSel;

        public ManageUserAccounts(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, gridUsers,
                new object[] { true });
            _dbSettings = dbSettings;
            BringToFront();
        }

        private void PopulateGrid(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _retriever = new UserAccountRetriever(_dbSettings);
            _dataCache = new DataCache(_retriever, 500, null, null);

            gridUsers.Columns.Clear();
            gridUsers.Rows.Clear();


            foreach (var column in _retriever.Columns)
                gridUsers.Columns.Add(column, column);

            
        }
    }
}