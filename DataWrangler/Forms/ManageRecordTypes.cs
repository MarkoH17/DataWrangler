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
            _dbSettings = dbSettings;
            _user = user;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                //Change 'UserAccountRetriever' below to proper retriever. E.g. for showing Records, use RecordRetriever, for showing RecordType use RecordTypeRetriever. Update constructor parameters if required.
                _retriever = new RecordTypeRetriever(_dbSettings);
                _dataCache = new DataCache(_retriever, 500);

                RecordTypeGridView.Columns.Clear();
                RecordTypeGridView.Rows.Clear();

                foreach (var column in _retriever.Columns)
                    RecordTypeGridView.Columns.Add(column, column);

                RecordTypeGridView.RowCount = _retriever.RowCount;
                //textBox1.Text = _retriever.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was encountered: " + ex.Message);
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
            int rowId = Convert.ToInt32(RecordTypeGridView.Rows[rowIdx].Cells[0].Value);
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
                    MessageBox.Show("Failed to fetch record!");
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
                            MessageBox.Show("DataWrangler Error",
                                "An error occured when deleting a record type.\n Error: " + deleteStatus.Result);
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
            RecordTypeGridView.RowCount = _retriever.RowCount;
            //txtRowCnt.Text = _retriever.RowCount.ToString();
            RefreshVisibleRows();
        }

        private void RefreshVisibleRows()
        {
            if (RecordTypeGridView.RowCount < 1) return;
            var firstRowIdx = RecordTypeGridView.FirstDisplayedCell.RowIndex;
            var lastRowIdx = (firstRowIdx + RecordTypeGridView.DisplayedRowCount(true)) - 1;

            _dataCache.RefreshCacheByRange(firstRowIdx, lastRowIdx);
            for (int i = firstRowIdx; i <= lastRowIdx; i++)
            {
                RecordTypeGridView.InvalidateRow(i);
            }
        }

        private void RecordTypeGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = RecordTypeGridView.HitTest(e.X, e.Y);

                var cm = new MetroContextMenu(Container);
                if (hitTest.RowIndex > -1)
                {
                    _rowIdxSel = hitTest.RowIndex;

                    RecordTypeGridView.ClearSelection();
                    RecordTypeGridView.Rows[_rowIdxSel].Selected = true;

                    cm.Items.Add("Edit Type", Properties.Resources.edit, editRecordTypeMenuItem_Click);
                    cm.Items.Add("Delete Type", Properties.Resources.trash, deleteRecordTypeMenuItem_Click);
                    cm.Items.Add("-");
                }

                cm.Items.Add("Add Type", Properties.Resources.plus, addRecordTypeMenuItem_Click);

                cm.Show(RecordTypeGridView, RecordTypeGridView.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
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
    }
}
