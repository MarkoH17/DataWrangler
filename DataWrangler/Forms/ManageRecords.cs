using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class ManageRecords : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;

        private DataCache _dataCache;

        private RecordType _recordTypeSel;
        private IDataRetriever _retriever;
        private int _rowIdxSel;
        private bool _gridIsFiltered;

        public ManageRecords(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, gridRecords,
                new object[] {true});
            _dbSettings = dbSettings;
            _user = user;
            BringToFront();
        }

        private void addRecordMenuItem_Click(object sender, EventArgs e)
        {
            var addForm = new EditRecord(_dbSettings, _user, null, _recordTypeSel);
            var addFormResult = addForm.ShowDialog();
            if (addFormResult == DialogResult.OK) RecordGridRefresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new Landing(_dbSettings, _user));
        }

        private void comboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFieldSearch.Enabled = true;
        }

        private void comboRecType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (TextValueItem) ((ComboBox) sender).SelectedItem;
            _recordTypeSel = (RecordType) selectedItem.Value;
            comboField.Items.Clear();
            txtFieldSearch.Text = "";
            txtFieldSearch.Enabled = false;
            foreach (var attr in _recordTypeSel.Attributes)
            {
                var comboBoxItem = new TextValueItem {Text = attr.Value, Value = "Attributes." + attr.Key};
                comboField.Items.Add(comboBoxItem);
            }

            if(comboField.Items.Count > 0)
            {
                var comboBoxItem = new TextValueItem { Text = "(all fields)", Value = "*" };
                comboField.Items.Add(comboBoxItem);
            }

            LoadRecordsByType(_recordTypeSel);
            gridRecords.Enabled = true;
            comboField.Enabled = true;
        }

        private void deleteRecordMenuItem_Click(object sender, EventArgs e)
        {
            var rec = GetRecordBySelectedRow(_rowIdxSel);
            if (rec != null)
            {
                var confirm = NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Warning, "Are you sure you wish to delete this record?", MessageBoxButtons.YesNoCancel);

                if (confirm == DialogResult.Yes)
                {
                    using (var oH = new ObjectHelper(_dbSettings, _user))
                    {
                        var deleteStatus = oH.DeleteRecord(rec);
                        if (!deleteStatus.Success)
                            NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                                "Failed to delete this record. Please try again.");
                    }

                    RecordGridRefresh();
                }
            }
        }

        private void editRecordMenuItem_Click(object sender, EventArgs e)
        {
            var rec = GetRecordBySelectedRow(_rowIdxSel);
            if (rec != null)
            {
                var editForm = new EditRecord(_dbSettings, _user, rec, _recordTypeSel);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK) RecordGridRefresh();
            }
        }

        private Record GetRecordBySelectedRow(int rowIdx)
        {
            if (rowIdx < 0) return null;
            var rowId = Convert.ToInt32(gridRecords.Rows[rowIdx].Cells[0].Value);
            Record record = null;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var recordFetchStatus = oH.GetRecordById(rowId, _recordTypeSel);
                if (recordFetchStatus.Success)
                    record = (Record) recordFetchStatus.Result;
                else
                    NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                        "Failed to fetch this record. Please try again.");
            }

            return record;
        }

        private void gridRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rec = GetRecordBySelectedRow(e.RowIndex);
            if (rec != null)
            {
                var editForm = new EditRecord(_dbSettings, _user, rec, _recordTypeSel);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK) RecordGridRefresh();
            }
        }

        private void gridRecords_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (comboRecType.SelectedItem == null || _dataCache == null) return;
            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private void gridRecords_MouseClick(object sender, MouseEventArgs e)
        {
            if (_recordTypeSel != null && e.Button == MouseButtons.Right)
            {
                var hitTest = gridRecords.HitTest(e.X, e.Y);

                var cm = new MetroContextMenu(Container);
                if (hitTest.RowIndex > -1)
                {
                    _rowIdxSel = hitTest.RowIndex;

                    gridRecords.ClearSelection();
                    gridRecords.Rows[_rowIdxSel].Selected = true;

                    cm.Items.Add("Edit Record", Resources.edit_dark, editRecordMenuItem_Click);
                    cm.Items.Add("Delete Record", Resources.trash_dark, deleteRecordMenuItem_Click);
                    cm.Items.Add("-");
                }

                cm.Items.Add("Add Record", Resources.plus_dark, addRecordMenuItem_Click);

                cm.Show(gridRecords, gridRecords.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
        }

        private void LoadRecordsByType(RecordType rT, string searchField = null, string searchValue = null)
        {
            try
            {
                _retriever = new RecordRetriever(_dbSettings, rT, searchField, searchValue);
                _dataCache = new DataCache(_retriever, 500, searchField, searchValue);

                gridRecords.Columns.Clear();
                gridRecords.Rows.Clear();


                foreach (var column in _retriever.Columns)
                    gridRecords.Columns.Add(column, column);

                gridRecords.RowCount = _retriever.RowCount;
                txtRowCnt.Text = _retriever.RowCount.ToString();
            }
            catch (Exception)
            {
                NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                    "Failed to load records. Please try again.");
            }
        }

        private void LoadRecordTypeBox()
        {
            RecordType[] recordTypes = null;

            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var result = oH.GetRecordTypes();
                if (result.Success) recordTypes = (RecordType[]) result.Result;
            }


            foreach (var rT in recordTypes)
            {
                var comboBoxItem = new TextValueItem {Text = rT.Name, Value = rT};
                comboRecType.Items.Add(comboBoxItem);
            }
        }

        private void ManageRecords_Load(object sender, EventArgs e)
        {
            LoadRecordTypeBox();
        }

        private void ManageRecords_Resize(object sender, EventArgs e)
        {
            txtFieldSearch.Refresh();
        }

        private void RecordGridRefresh()
        {
            _retriever.ResetRowCount();
            gridRecords.RowCount = _retriever.RowCount;
            txtRowCnt.Text = _retriever.RowCount.ToString();
            RefreshVisibleRows();
        }

        private void RefreshVisibleRows()
        {
            var firstRowIdx = gridRecords.FirstDisplayedCell.RowIndex;
            var lastRowIdx = firstRowIdx + gridRecords.DisplayedRowCount(true) - 1;

            _dataCache.RefreshCacheByRange(firstRowIdx, lastRowIdx);
            for (var i = firstRowIdx; i <= lastRowIdx; i++) gridRecords.InvalidateRow(i);
        }

        public void SwitchFormStyle()
        {
            btnBack.Image = Theme == MetroThemeStyle.Dark ? Resources.arrow_back_light : Resources.arrow_back_dark;
        }

        private void txtFieldSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                if (!_gridIsFiltered && comboField.SelectedItem != null && (string.IsNullOrEmpty(comboField.SelectedItem.ToString()) ||
                    string.IsNullOrEmpty(txtFieldSearch.Text)))
                    return;

                if(_gridIsFiltered && string.IsNullOrEmpty(txtFieldSearch.Text))
                {
                    comboField.SelectedIndex = -1;
                    txtFieldSearch.Text = "";
                    txtFieldSearch.Enabled = false;
                    LoadRecordsByType(_recordTypeSel);
                    _gridIsFiltered = false;
                    return;
                }

                var searchField = ((TextValueItem) comboField.SelectedItem).Value.ToString();
                var searchValue = txtFieldSearch.Text;
                var searchValueLen = txtFieldSearch.Text.Replace(" ", "").Length;

                if (searchValueLen < 1) return;

                LoadRecordsByType(_recordTypeSel, searchField, searchValue);
                _gridIsFiltered = true;
            }
        }
    }
}