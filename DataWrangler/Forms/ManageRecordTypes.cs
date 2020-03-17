using DataWrangler.DBOs;
using DataWrangler.Retrievers;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWrangler.Properties;
using MetroFramework;

namespace DataWrangler.Forms
{

    public partial class ManageRecordTypes : MetroFramework.Forms.MetroForm
    {

        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;
        private DataCache _dataCache; //Needed for caching entries with the data table

        private RecordType _recordTypeSel;
        private int _rowIdxSel;

        private IDataRetriever _retriever; //Needed for paging the data table
        
        public ManageRecordTypes(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            _dbSettings = dbSettings;
            _user = user;
            BringToFront();
        }

        protected override void OnLoad(EventArgs e)
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
                
            }
            catch (Exception ex)
            {
                NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error, "Failed to load record types. Please try again.");
            }
            base.OnLoad(e);
        }

        private void RecordTypeGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private RecordType GetRecordTypeBySelectedRow(int rowIdx)
        {
            if (rowIdx < 0) return null;
            int rowId = Convert.ToInt32(gridRecordTypes.Rows[rowIdx].Cells[0].Value);
            RecordType record = null;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var recordFetchStatus = oH.GetRecordTypeById(rowId);
                if (recordFetchStatus.Success)
                {
                    record = (RecordType)recordFetchStatus.Result;
                }
                else
                {
                    NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error, "Failed to fetch this record type. Please try again.");
                }
            }
            return record;
        }

        private void addRecordTypeMenuItem_Click(object sender, EventArgs e)
        {
            var addForm = new EditRecordType(_dbSettings, _user, null);
            var addFormResult = addForm.ShowDialog();
            if (addFormResult == DialogResult.OK)
            {
                RecordTypeGridRefresh();
            }
        }

        private void editRecordTypeMenuItem_Click(object sender, EventArgs e)
        {
            var recType = GetRecordTypeBySelectedRow(_rowIdxSel);
            if(recType != null)
            {
                var editForm = new EditRecordType(_dbSettings, _user, recType);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK)
                {
                    RecordTypeGridRefresh();
                }
            }
        }

        private void deleteRecordTypeMenuItem_Click(object sender, EventArgs e)
        {
            var recType = GetRecordTypeBySelectedRow(_rowIdxSel);
            if (recType != null)
            {
                var confirm = MessageBox.Show("DataWrangler Confirmation", "Are you sure you wish to delete this record type? (orphaned records will also be deleted!)",
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
                            NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error, "Failed to delete this record type. Please try again.");
                            return;
                        }
                    }
                    RecordTypeGridRefresh();
                }
            }
        }

        private void RecordTypeGridRefresh()
        {
            _retriever.ResetRowCount();
            gridRecordTypes.RowCount = _retriever.RowCount;
            //txtRowCnt.Text = _retriever.RowCount.ToString();
            RefreshVisibleRows();
        }

        private void RefreshVisibleRows()
        {
            if (gridRecordTypes.RowCount < 1) return;
            var firstRowIdx = gridRecordTypes.FirstDisplayedCell.RowIndex;
            var lastRowIdx = (firstRowIdx + gridRecordTypes.DisplayedRowCount(true)) - 1;

            _dataCache.RefreshCacheByRange(firstRowIdx, lastRowIdx);
            for (int i = firstRowIdx; i <= lastRowIdx; i++)
            {
                gridRecordTypes.InvalidateRow(i);
            }
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

                cm.Show(gridRecordTypes, gridRecordTypes.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
        }

        private void RecordTypeGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var recType = GetRecordTypeBySelectedRow(e.RowIndex);
            if (recType != null)
            {
                var editForm = new EditRecordType(_dbSettings, _user, recType);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK)
                {
                    RecordTypeGridRefresh();
                }
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
