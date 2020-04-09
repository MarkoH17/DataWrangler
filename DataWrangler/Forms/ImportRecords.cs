using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Properties;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class ImportRecords : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly DataProcessor _dP = new DataProcessor();
        private readonly DataTable _fieldsTable = new DataTable();
        private readonly UserAccount _user;

        private string _fileImportPath;
        private RecordType[] _recordTypes;

        public ImportRecords(Dictionary<string, string> dbSettings, UserAccount user)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, gridFieldAssignment,
                new object[] { true });
            _dbSettings = dbSettings;
            _user = user;

            _fieldsTable.Columns.Add(new DataColumn {ColumnName = "FieldName"});
            _fieldsTable.Columns.Add(new DataColumn {ColumnName = "SheetColumnIndex"});

            var fieldNameCol = new DataGridViewTextBoxColumn {Name = "Attribute Name"};

            var fieldValueCol = new DataGridViewComboBoxColumn
            {
                Name = "Mapped Field",
                DataSource = _fieldsTable,
                DisplayMember = "FieldName",
                ValueMember = "SheetColumnIndex"
            };


            gridFieldAssignment.Columns.Add(fieldValueCol);
            gridFieldAssignment.Columns.Add(fieldNameCol);

            BringToFront();
        }

        private void AddLastRow()
        {
            if (comboImportOptions.SelectedIndex != 1 &&
                ValidRow(gridFieldAssignment.Rows[gridFieldAssignment.RowCount - 1]))
                gridFieldAssignment.Rows.Add();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.SwitchPrimaryForm(new Landing(_dbSettings, _user));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Program.SwitchPrimaryForm(new Landing(_dbSettings, _user));
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                    _fileImportPath = dialog.FileName;
                else
                    return;
            }

            if (!string.IsNullOrEmpty(_fileImportPath)) comboImportOptions.Enabled = true;
            txtPathAddr.Text = _fileImportPath;

            comboImportOptions.SelectedIndex = -1;
            comboRecordTypeSelector.Items.Clear();
            txtRecordTypeName.Text = "";
            gridFieldAssignment.Rows.Clear();

            foreach (var scroll in gridFieldAssignment.Controls.OfType<MetroScrollBar>())
                scroll.Visible = false; //Fixes ghosted scrollbars in MetroGrid after a data source refresh

            LoadDataSource(_fileImportPath);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string recordTypeName = null;

            if (comboImportOptions.SelectedIndex == 0)
                recordTypeName = txtRecordTypeName.Text;
            else if (comboImportOptions.SelectedIndex == 1)
                recordTypeName = comboRecordTypeSelector.SelectedText;

            var selectedHeaders = new Dictionary<int, string>();

            foreach (DataGridViewRow row in gridFieldAssignment.Rows)
                if (row.Cells[0].Value != null && ValidRow(row))
                {
                    var colIndex = Convert.ToInt32(row.Cells[0].Value);
                    var attrName = row.Cells[1].Value.ToString();
                    selectedHeaders.Add(colIndex, attrName);
                }

            StatusObject importStatus = null;
            if (comboImportOptions.SelectedIndex == 0)
            {
                RecordType rT = null;
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var addRecordTypeStatus = oH.AddRecordType(recordTypeName, selectedHeaders.Values.ToList(), true);
                    if (addRecordTypeStatus.Success)
                    {
                        var fetchRecordType = oH.GetRecordTypeById((int) addRecordTypeStatus.Result);
                        if (fetchRecordType.Success) rT = (RecordType) fetchRecordType.Result;
                    }
                }

                if (rT != null)
                {
                    var records = _dP.GetRecordsFromSheet(rT, selectedHeaders, _fileImportPath);
                    if (records.Length > 0)
                        using (var oH = new ObjectHelper(_dbSettings, _user))
                        {
                            importStatus = oH.AddRecords(records, rT);
                        }
                }
            }
            else
            {
                var rT = _recordTypes.First(x => x.Name.Equals(comboRecordTypeSelector.SelectedItem));
                var records = _dP.GetRecordsFromSheet(rT, selectedHeaders, _fileImportPath);
                if (records.Length > 0)
                    using (var oH = new ObjectHelper(_dbSettings, _user))
                    {
                        importStatus = oH.AddRecords(records, rT);
                    }
            }

            if (importStatus != null && importStatus.Success)
                NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Information,
                    "Successfully imported " + (int) importStatus.Result + " records!");
            else
                NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error,
                    "Failed to import records. Please try again.");
        }

        private void comboImportOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboRecordTypeSelector.Items.Clear();
            gridFieldAssignment.Rows.Clear();
            if (comboImportOptions.SelectedIndex == 0) //Import to new record type
            {
                //Change Combobox to a text box
                txtRecordTypeName.Location = new Point(comboRecordTypeSelector.Location.X,
                    comboRecordTypeSelector.Location.Y +
                    (comboRecordTypeSelector.Height - txtRecordTypeName.Height) / 2);
                txtRecordTypeName.Width = comboRecordTypeSelector.Width;
                txtRecordTypeName.Enabled = true;
                comboRecordTypeSelector.Enabled = false;
                comboRecordTypeSelector.Visible = false;
                txtRecordTypeName.Visible = true;
                lblRecordType.Text = "Type Name";
                txtRecordTypeName.Text = Path.GetFileNameWithoutExtension(_fileImportPath);
                ValidateForm();
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
                gridFieldAssignment.Rows.Add();
            }
            else if (comboImportOptions.SelectedIndex == 1) //Import to existing record type
            {
                txtRecordTypeName.Location = comboRecordTypeSelector.Location;
                txtRecordTypeName.Enabled = false;
                comboRecordTypeSelector.Enabled = true;
                txtRecordTypeName.Visible = false;
                comboRecordTypeSelector.Visible = true;
                lblRecordType.Text = "Record Type";

                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var fetchRecordTypesStatus = oH.GetRecordTypes();
                    if (fetchRecordTypesStatus.Success)
                    {
                        _recordTypes = (RecordType[]) fetchRecordTypesStatus.Result;
                        if (_recordTypes.Length > 0)
                            comboRecordTypeSelector.Items.AddRange(_recordTypes.OrderBy(x => x.Name).Select(x => x.Name)
                                .ToArray());
                    }
                }

                comboRecordTypeSelector.Enabled = true;
            }
        }

        private void comboRecordTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridFieldAssignment.Rows.Clear();
            var selectedRecordType = _recordTypes.First(x => x.Name.Equals(comboRecordTypeSelector.SelectedItem));
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

        private void deleteToolStrip_Click(object sender, EventArgs e)
        {
            var selectedRows = gridFieldAssignment.SelectedRows;
            foreach (DataGridViewRow row in selectedRows) gridFieldAssignment.Rows.RemoveAt(row.Index);

            if (!ValidateForm()) AddLastRow();
        }

        private void gridFieldAssignment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var r = gridFieldAssignment.Rows[e.RowIndex];
            if (!ValidateForm())
                if (ValidRow(r) /* && ValidRow(gridFieldAssignment.Rows[gridFieldAssignment.RowCount - 1])*/)
                    AddLastRow();
        }

        private void gridFieldAssignment_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = gridFieldAssignment.HitTest(e.X, e.Y);

                gridFieldAssignment.ClearSelection();
                gridFieldAssignment.Rows[hitTest.RowIndex].Selected = true;

                var cm = new MetroContextMenu(Container);
                cm.Items.Add("Delete Row", Resources.trash_dark, deleteToolStrip_Click);

                cm.Show(gridFieldAssignment,
                    gridFieldAssignment.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
        }

        private void ImportRecords_Resize(object sender, EventArgs e)
        {
            txtPathAddr.Refresh();
        }

        private void LoadDataSource(string filePath)
        {
            _fieldsTable.Rows.Clear();
            gridFieldAssignment.Rows.Clear();

            var headers = _dP.GetSpreadsheetHeaders(filePath);

            foreach (var header in headers)
            {
                var row = _fieldsTable.NewRow();
                row["FieldName"] = header.Value;
                row["SheetColumnIndex"] = header.Key;
                _fieldsTable.Rows.Add(row);
            }
        }

        public void SwitchFormStyle()
        {
            btnBack.Image = Theme == MetroThemeStyle.Dark ? Resources.arrow_back_light : Resources.arrow_back_dark;
        }

        private void txtRecordTypeName_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateForm();
        }

        private bool ValidateForm()
        {
            var hasError = false;
            var selectedItems = new Dictionary<int, int>();

            foreach (DataGridViewRow row in gridFieldAssignment.Rows)
            {
                var c = (DataGridViewComboBoxCell) row.Cells[0];
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
                row.ErrorText = duplicateRowsByField.Contains(row.Index) ? "Duplicate Field Assignment" : "";

            if (_recordTypes == null)
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var fetchRecordTypesStatus = oH.GetRecordTypes();
                    if (fetchRecordTypesStatus.Success) _recordTypes = (RecordType[]) fetchRecordTypesStatus.Result;
                }

            if (comboImportOptions.SelectedIndex == 0 &&
                (_recordTypes.Select(x => x.Name).ToList().Contains(txtRecordTypeName.Text.Trim()) ||
                 txtRecordTypeName.Text.Length < 1))
            {
                hasError = true;
                txtRecordTypeName.UseCustomBackColor = true;
                txtRecordTypeName.BackColor = MetroColors.Yellow;
                txtRecordTypeName.Refresh();
            }
            else
            {
                txtRecordTypeName.UseCustomBackColor = false;
                txtRecordTypeName.Refresh();
            }


            btnImport.Enabled = !hasError;
            return hasError;
        }

        private bool ValidRow(DataGridViewRow r)
        {
            foreach (DataGridViewCell cell in r.Cells)
                if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                    return false;
            return true;
        }
    }
}