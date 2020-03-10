﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.FormControls;
using DataWrangler.Retrievers;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class ManageRecords : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;

        private DataCache _dataCache;
        private IDataRetriever _retriever;

        private RecordType _recordTypeSel;
        private int _rowIdxSel;

        public ManageRecords(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, gridRecords,
                new object[] { true });
            _dbSettings = dbSettings;
            _user = user;
            BringToFront();
        }

        private void LoadRecordTypeBox()
        {
            RecordType[] recordTypes = null;

            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var result = oH.GetRecordTypes();
                if (result.Success) recordTypes = (RecordType[])result.Result;
            }


            foreach (var rT in recordTypes)
            {
                var comboBoxItem = new TextValueItem { Text = rT.Name, Value = rT };
                comboRecType.Items.Add(comboBoxItem);
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
            catch (Exception ex)
            {
                MessageBox.Show("An error was encountered: " + ex.Message);
            }
        }

        private void ManageRecords_Load(object sender, System.EventArgs e)
        {
            LoadRecordTypeBox();
        }

        private void comboRecType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedItem = (TextValueItem)((ComboBox)sender).SelectedItem;
            _recordTypeSel = (RecordType)selectedItem.Value;
            comboField.Items.Clear();
            txtFieldSearch.Text = "";
            txtFieldSearch.Enabled = false;
            foreach (var attr in _recordTypeSel.Attributes)
            {
                var comboBoxItem = new TextValueItem { Text = attr.Value, Value = "Attributes." + attr.Key };
                comboField.Items.Add(comboBoxItem);
            }

            LoadRecordsByType(_recordTypeSel);
            gridRecords.Enabled = true;
            comboField.Enabled = true;
        }

        private void gridRecords_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (comboRecType.SelectedItem == null || _dataCache == null) return;
            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private void comboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFieldSearch.Enabled = true;
        }

        private void txtFieldSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(comboField.SelectedItem.ToString()) || string.IsNullOrEmpty(txtFieldSearch.Text))
                    return;

                var searchField = ((TextValueItem)comboField.SelectedItem).Value.ToString();
                var searchValue = txtFieldSearch.Text;

                LoadRecordsByType(_recordTypeSel, searchField, searchValue);
            }
        }

        private Record GetRecordBySelectedRow(int rowIdx)
        {
            if (rowIdx < 0) return null;
            int rowId = Convert.ToInt32(gridRecords.Rows[rowIdx].Cells[0].Value);
            Record record = null;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var recordFetchStatus = oH.GetRecordById(rowId, _recordTypeSel);
                if (recordFetchStatus.Success)
                {
                    record = (Record)recordFetchStatus.Result;
                }
                else
                {
                    MessageBox.Show("Failed to fetch record!");
                }
            }
            return record;
        }

        private void editRecordMenuItem_Click(object sender, EventArgs e)
        {
            var rec = GetRecordBySelectedRow(_rowIdxSel);
            if (rec != null)
            {
                var editForm = new EditRecord(_dbSettings, _user, rec, _recordTypeSel);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK)
                {
                    RecordGridRefresh();
                }
            }
            
        }

        private void deleteRecordMenuItem_Click(object sender, EventArgs e)
        {
            var rec = GetRecordBySelectedRow(_rowIdxSel);
            if (rec != null)
            {
                var confirm = MessageBox.Show("DataWrangler Confirmation", "Are you sure you wish to delete this record?",
                    MessageBoxButtons.YesNoCancel);

                if (confirm == DialogResult.Yes)
                {
                    using (var oH = new ObjectHelper(_dbSettings, _user))
                    {
                        var deleteStatus = oH.DeleteRecord(rec);
                        if (!deleteStatus.Success)
                        {
                            MessageBox.Show("DataWrangler Error",
                                "An error occured when deleting a record.\n Error: " + deleteStatus.Result);
                        }
                    }
                    RecordGridRefresh();
                }
            }
        }

        private void gridRecords_MouseClick(object sender, MouseEventArgs e)
        {
            if (_recordTypeSel != null && e.Button == MouseButtons.Right)
            {
                var hitTest = gridRecords.HitTest(e.X, e.Y);
                
                if (hitTest.RowIndex < 0)
                    return;
                
                _rowIdxSel = hitTest.RowIndex;

                gridRecords.ClearSelection();
                gridRecords.Rows[_rowIdxSel].Selected = true;

                var cm = new MetroContextMenu(Container);
                cm.Items.Add("Edit Record", null, editRecordMenuItem_Click);
                cm.Items.Add("Delete Record", null, deleteRecordMenuItem_Click);

                cm.Show(gridRecords, gridRecords.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
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
            var lastRowIdx = (firstRowIdx + gridRecords.DisplayedRowCount(true)) - 1;

            _dataCache.RefreshCacheByRange(firstRowIdx, lastRowIdx);
            for (int i = firstRowIdx; i <= lastRowIdx; i++)
            {
                gridRecords.InvalidateRow(i);
            }
        }

        private void gridRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rec = GetRecordBySelectedRow(e.RowIndex);
            if (rec != null)
            {
                var editForm = new EditRecord(_dbSettings, _user, rec, _recordTypeSel);
                var editFormResult = editForm.ShowDialog();
                if (editFormResult == DialogResult.OK)
                {
                    RecordGridRefresh();
                }
            }
            
        }

        private void ManageRecords_Resize(object sender, EventArgs e)
        {
            txtFieldSearch.Refresh();
        }
    }
}