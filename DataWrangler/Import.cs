using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataWrangler.DBOs;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using DataRow = System.Data.DataRow;

namespace DataWrangler
{
    public partial class Import : Form
    {
        private readonly DataProcessor _dP = new DataProcessor();
        private readonly DataTable _fieldsTable = new DataTable();

        private string fileImportPath;
        private RecordType[] recordTypes = null;

        /*
             * UPDATE DBSETTINGS AND USER TO REFLECT REAL VALUES PASSED FROM OTHER WINDOWS. CHANGE THIS LATER!
             */
        Dictionary<string, string> _dbSettings = ConfigurationHelper.GetDbSettings();
        UserAccount _user = new UserAccount()
        {
            Id = 1,
            Username = "sysadmin"
        };

        /*
         * UPDATE DBSETTINGS AND USER TO REFLECT REAL VALUES PASSED FROM OTHER WINDOWS. CHANGE THIS LATER!
         */

        public Import()
        {
            InitializeComponent();

            _fieldsTable.Columns.Add(new DataColumn() { ColumnName = "FieldName" });
            _fieldsTable.Columns.Add(new DataColumn() { ColumnName = "SheetColumnIndex" });

            var fieldNameCol = new DataGridViewTextBoxColumn();
            fieldNameCol.Name = "Attribute Name";

            var fieldValueCol = new DataGridViewComboBoxColumn();
            fieldValueCol.Name = "Mapped Field";
            fieldValueCol.DataSource = _fieldsTable;
            fieldValueCol.DisplayMember = "FieldName";
            fieldValueCol.ValueMember = "SheetColumnIndex";


            gridFieldAssignment.Columns.Add(fieldValueCol);
            gridFieldAssignment.Columns.Add(fieldNameCol);
            gridFieldAssignment.ContextMenuStrip = contextMenuStrip1;
            //gridFieldAssignment.RowTemplate.ContextMenuStrip = contextMenuStrip1;
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileImportPath = dialog.FileName;
                }
                else
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(fileImportPath))
            {
                comboImportOptions.Enabled = true;
            }
            txtPathAddr.Text = fileImportPath;

            comboImportOptions.SelectedIndex = -1;
            comboRecordTypeSelector.Items.Clear();
            gridFieldAssignment.Rows.Clear();

            LoadDataSource(fileImportPath);
        }

        private void LoadDataSource(string filePath)
        {
            _fieldsTable.Rows.Clear();
            gridFieldAssignment.Rows.Clear();

            

            var headers = _dP.GetSpreadsheetHeaders(filePath);

            DataRow row;

            foreach (var header in headers)
            {
                row = _fieldsTable.NewRow();
                row["FieldName"] = header.Value;
                row["SheetColumnIndex"] = header.Key;
                _fieldsTable.Rows.Add(row);
            }
        }

        private bool ValidRow(DataGridViewRow r)
        {
            foreach (DataGridViewCell cell in r.Cells)
            {
                if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                    return false;
            }
            return true;
        }

        private bool CheckDuplicateFields()
        {
            bool hasError = false;


            var selectedItems = new Dictionary<int, int>();

            foreach(DataGridViewRow row in gridFieldAssignment.Rows)
            {
                var c = (DataGridViewComboBoxCell)row.Cells[0];
                selectedItems.Add(row.Index, Convert.ToInt32(c.Value));
            }

            var duplicateRowsByField = selectedItems
                .Where(x => x.Value != 0)
                .GroupBy(x => x.Value)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key - 1)
                .ToList();

            if (duplicateRowsByField.Count > 0)
                hasError = true;

            foreach (DataGridViewRow row in gridFieldAssignment.Rows)
            {
                if (duplicateRowsByField.Contains(row.Index))
                {
                    row.ErrorText = "BAD";
                }
                else
                {
                    row.ErrorText = "";
                }
            }

            btnImport.Enabled = !hasError;
            return hasError;
        }

        private void AddLastRow()
        {
            if(comboImportOptions.SelectedIndex != 1 && ValidRow(gridFieldAssignment.Rows[gridFieldAssignment.RowCount - 1]))
                gridFieldAssignment.Rows.Add();
        }

        private void gridFieldAssignment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var r = gridFieldAssignment.Rows[e.RowIndex];
            if (!CheckDuplicateFields())
            {
                if (ValidRow(r)/* && ValidRow(gridFieldAssignment.Rows[gridFieldAssignment.RowCount - 1])*/)
                {
                    AddLastRow();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gridFieldAssignment.RowCount <= 1)
                e.Cancel = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var selectedRows = gridFieldAssignment.SelectedRows;
            foreach (DataGridViewRow row in selectedRows)
            {
                gridFieldAssignment.Rows.RemoveAt(row.Index);
            }

            if (!CheckDuplicateFields())
            {
                AddLastRow();
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string recordTypeName = null;

            if (comboImportOptions.SelectedIndex == 0)
            {
                recordTypeName = comboRecordTypeSelector.Text;
            }else if (comboImportOptions.SelectedIndex == 1)
            {
                recordTypeName = comboRecordTypeSelector.SelectedText;
            }

            var selectedHeaders = new Dictionary<int, string>();

            foreach (DataGridViewRow row in gridFieldAssignment.Rows)
            {
                if (row.Cells[0].Value != null && ValidRow(row))
                {
                    var colIndex = Convert.ToInt32(row.Cells[0].Value);
                    var attrName = row.Cells[1].Value.ToString();
                    selectedHeaders.Add(colIndex, attrName);
                }
                   
            }

            if (comboImportOptions.SelectedIndex == 0)
            {
                RecordType rT = null;
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var addRecordTypeStatus = oH.AddRecordType(recordTypeName, selectedHeaders.Values.ToList(), true);
                    if (addRecordTypeStatus.Success)
                    {
                        var fetchRecordType = oH.GetRecordTypeById((int)addRecordTypeStatus.Result);
                        if (fetchRecordType.Success)
                        {
                            rT = (RecordType)fetchRecordType.Result;
                        }
                    }
                }

                if (rT != null)
                {
                    var records = _dP.GetRecordsFromSheet(rT, selectedHeaders, fileImportPath);
                    if (records.Length > 0)
                    {
                        using (var oH = new ObjectHelper(_dbSettings, _user))
                        {
                            var importStatus = oH.AddRecords(records, rT);
                            if (importStatus.Success)
                            {
                                MessageBox.Show("Successfully imported " + (int)importStatus.Result + " records!");
                            }
                            else
                            {
                                MessageBox.Show("Failed to import records!");
                            }
                        }
                    }
                }
            }
            else
            {
                RecordType rT = recordTypes[comboRecordTypeSelector.SelectedIndex];
                var records = _dP.GetRecordsFromSheet(rT, selectedHeaders, fileImportPath);
                if (records.Length > 0)
                {
                    using (var oH = new ObjectHelper(_dbSettings, _user))
                    {
                        var importStatus = oH.AddRecords(records, rT);
                        if (importStatus.Success)
                        {
                            MessageBox.Show("Successfully imported " + (int)importStatus.Result + " records!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to import records!");
                        }
                    }
                }
            }

            
        }

        private void comboImportOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboRecordTypeSelector.Items.Clear();
            gridFieldAssignment.Rows.Clear();
            if(comboImportOptions.SelectedIndex == 0) //Import to new record type
            {
                comboRecordTypeSelector.DropDownStyle = ComboBoxStyle.DropDown;
                comboRecordTypeSelector.Enabled = true;

                //Autoload table
                foreach (DataRow row in _fieldsTable.Rows)
                {
                    var newGridViewRow = new DataGridViewRow();
                    newGridViewRow.CreateCells(gridFieldAssignment);

                    newGridViewRow.Cells[1].Value = row["FieldName"];
                    newGridViewRow.Cells[0].Value = row["SheetColumnIndex"];
                    gridFieldAssignment.Rows.Add(newGridViewRow);
                }
                gridFieldAssignment.Enabled = true;
                btnImport.Enabled = true;
                gridFieldAssignment.Rows.Add();

            }
            else if (comboImportOptions.SelectedIndex == 1) //Import to existing record type
            {
                comboRecordTypeSelector.DropDownStyle = ComboBoxStyle.DropDownList;
                
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var fetchRecordTypesStatus = oH.GetRecordTypes();
                    if (fetchRecordTypesStatus.Success)
                    {
                        recordTypes = (RecordType[]) fetchRecordTypesStatus.Result;
                        comboRecordTypeSelector.Items.AddRange(recordTypes.Select(x => x.Name).ToArray());
                    }
                }

                comboRecordTypeSelector.Enabled = true;
            }
        }

        private void comboRecordTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRecordType = recordTypes[comboRecordTypeSelector.SelectedIndex];
            foreach (var attr in selectedRecordType.Attributes)
            {
                var newGridViewRow = new DataGridViewRow();
                newGridViewRow.CreateCells(gridFieldAssignment);

                newGridViewRow.Cells[1].Value = attr.Value;
                newGridViewRow.Cells[1].ReadOnly = true;
                //newGridViewRow.Cells[0].Value = row["SheetColumnIndex"];
                gridFieldAssignment.Rows.Add(newGridViewRow);
            }

            gridFieldAssignment.Enabled = true;
        }
    }
}