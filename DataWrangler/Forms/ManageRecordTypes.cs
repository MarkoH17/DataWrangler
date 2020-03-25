using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Properties;
using DataWrangler.Retrievers;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class ManageRecordTypes : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;
        private DataCache _dataCache; //Needed for caching entries with the data table

        private RecordType _recordTypeSel;

        private IDataRetriever _retriever; //Needed for paging the data table
        private int _rowIdxSel;

        public ManageRecordTypes(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            _dbSettings = dbSettings;
            _user = user;
            BringToFront();
        }

        private void addRecordTypeMenuItem_Click(object sender, EventArgs e)
        {
            var addForm = new EditRecordType(_dbSettings, _user, null);
            var addFormResult = addForm.ShowDialog();
            if (addFormResult == DialogResult.OK) RecordTypeGridRefresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new Landing(_dbSettings, _user));
        }

        private void deleteRecordTypeMenuItem_Click(object sender, EventArgs e)
        {
            var recType = GetRecordTypeBySelectedRow(_rowIdxSel);
            if (recType != null)
            {
                var confirm = MessageBox.Show("DataWrangler Confirmation",
                    "Are you sure you wish to delete this record type? (orphaned records will also be deleted!)",
                    MessageBoxButtons.YesNoCancel);

                if (confirm == DialogResult.Yes)
                {
                    using (var oH = new ObjectHelper(_dbSettings, _user))
                    {
                        var countStatus = oH.GetRecordCountByRecordType(recType);
                        var deleteOrphans = (int) countStatus.Result > 0;

                        var deleteStatus = oH.DeleteRecordType(recType, deleteOrphans);
                        if (!deleteStatus.Success)
                        {
                            NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                                "Failed to delete this record type. Please try again.");
                            return;
                        }
                    }

                    RecordTypeGridRefresh();
                }
            }
        }

        private void editRecordTypeMenuItem_Click(object sender, EventArgs e)
        {
            var recType = GetRecordTypeBySelectedRow(_rowIdxSel);
            if (recType != null)
            {
                var editForm = new EditRecordType(_dbSettings, _user, recType);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK) RecordTypeGridRefresh();
            }
        }

        private RecordType GetRecordTypeBySelectedRow(int rowIdx)
        {
            if (rowIdx < 0) return null;
            var rowId = Convert.ToInt32(gridRecordTypes.Rows[rowIdx].Cells[0].Value);
            RecordType record = null;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var recordFetchStatus = oH.GetRecordTypeById(rowId);
                if (recordFetchStatus.Success)
                    record = (RecordType) recordFetchStatus.Result;
                else
                    NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                        "Failed to fetch this record type. Please try again.");
            }

            return record;
        }

        private void LoadRecordTypes()
        {
            try
            {
                _retriever = new RecordTypeRetriever(_dbSettings);
                _dataCache = new DataCache(_retriever, 500);

                gridRecordTypes.Columns.Clear();
                gridRecordTypes.Rows.Clear();

                foreach (var column in _retriever.Columns)
                    gridRecordTypes.Columns.Add(column, column);

                gridRecordTypes.RowCount = _retriever.RowCount;
                txtRowCnt.Text = _retriever.RowCount.ToString();
            }
            catch (Exception)
            {
                NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                    "Failed to load record types. Please try again.");
            }
        }

        private void ManageRecordTypes_Load(object sender, EventArgs e)
        {
            LoadRecordTypes();
        }

        private void RecordTypeGridRefresh()
        {
            _retriever.ResetRowCount();
            gridRecordTypes.RowCount = _retriever.RowCount;
            txtRowCnt.Text = _retriever.RowCount.ToString();
            RefreshVisibleRows();
        }

        private void RecordTypeGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var recType = GetRecordTypeBySelectedRow(e.RowIndex);
            if (recType != null)
            {
                var editForm = new EditRecordType(_dbSettings, _user, recType);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK) RecordTypeGridRefresh();
            }
        }

        private void RecordTypeGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private void RecordTypeGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = gridRecordTypes.HitTest(e.X, e.Y);

                var cm = new MetroContextMenu(Container);
                if (hitTest.RowIndex > -1)
                {
                    _rowIdxSel = hitTest.RowIndex;

                    gridRecordTypes.ClearSelection();
                    gridRecordTypes.Rows[_rowIdxSel].Selected = true;

                    cm.Items.Add("Edit Type", Resources.edit_dark, editRecordTypeMenuItem_Click);
                    cm.Items.Add("Delete Type", Resources.trash_dark, deleteRecordTypeMenuItem_Click);
                    cm.Items.Add("-");
                }

                cm.Items.Add("Add Type", Resources.plus_dark, addRecordTypeMenuItem_Click);

                cm.Show(gridRecordTypes,
                    gridRecordTypes.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
        }

        private void RefreshVisibleRows()
        {
            if (gridRecordTypes.RowCount < 1) return;
            var firstRowIdx = gridRecordTypes.FirstDisplayedCell.RowIndex;
            var lastRowIdx = firstRowIdx + gridRecordTypes.DisplayedRowCount(true) - 1;

            _dataCache.RefreshCacheByRange(firstRowIdx, lastRowIdx);
            for (var i = firstRowIdx; i <= lastRowIdx; i++) gridRecordTypes.InvalidateRow(i);
        }

        public void SwitchFormStyle()
        {
            btnBack.Image = Theme == MetroThemeStyle.Dark ? Resources.arrow_back_light : Resources.arrow_back_dark;
        }
    }
}