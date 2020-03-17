using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Properties;
using DataWrangler.Retrievers;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class EditRecordType : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;
        private RecordType _recordType;

        private List<MetroTextBox> _txtControls = new List<MetroTextBox>();
        private List<int> _topPoints = new List<int>();
        private MetroTextBox _addRowTextBox;
        private MetroLabel _addRowLabel;
        private Button _addRowButton;

        private DataCache _dataCache;
        private IDataRetriever _retriever;

        private List<string> _removedAttrs = new List<string>();

        public EditRecordType(Dictionary<string, string> dbSettings, UserAccount user, RecordType recordType)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            _dbSettings = dbSettings;
            _user = user;
            _recordType = recordType;

            if (recordType == null)
            {
                Text = "Add Record Type";
                tabControl1.TabPages.Remove(tabHistory);
                LoadAddRow(0);
            }
            else
            {
                LoadAttributes();
                LoadHistory();
            }

            txtRecId.Text = _recordType != null ? _recordType.Id.ToString() : "---";
            txtRecTypeName.Text = _recordType != null ? _recordType.Name : "";

            tabControl1.SelectedTab = tabAttributes;
            tableLayoutPanel1.RowStyles[0].Height = 30F;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.VerticalScroll.Visible = true;
            tableLayoutPanel1.AutoSize = true;
            BringToFront();
        }

        public void LoadAttributes()
        {
            int ctrlCtr = 0;

            if (_recordType != null)
            {
                tabAttributes.SuspendLayout();
                tableLayoutPanel1.SuspendLayout();
                foreach (var attr in _recordType.Attributes)
                {
                    var attrValue = "";
                    if (_recordType != null)
                    {
                        _recordType.Attributes.TryGetValue(attr.Key, out attrValue);
                    }

                    var newLbl = new MetroLabel
                    {
                        Text = "Attribute " + (ctrlCtr + 1),
                        Name = "Row" + ctrlCtr,
                        Theme = Theme,
                        Style = Style
                    };
                    var newTxtBox = new MetroTextBox
                    {
                        Text = attrValue,
                        Tag = attr.Key,
                        Name = "Row" + ctrlCtr,
                        Width = 250,
                        Theme = Theme,
                        Style = Style
                    };
                    var deleteButton = new Button
                    {
                        Width = 25,
                        BackgroundImage = Theme == MetroThemeStyle.Dark ? Resources.trash_light : Resources.trash_dark,
                        BackColor = Color.Transparent,
                        Name = "Row" + ctrlCtr,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance =
                        {
                            BorderSize = 0,
                            MouseDownBackColor = Color.Transparent,
                            MouseOverBackColor = Color.Transparent
                        }
                    };

                    deleteButton.Click += (sender, args) => RemoveRow(sender);

                    _txtControls.Add(newTxtBox);
                    _topPoints.Add(newTxtBox.Top);

                    tabAttributes.Controls.Add(newLbl);
                    tabAttributes.Controls.Add(newTxtBox);
                    tabAttributes.Controls.Add(deleteButton);

                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));

                    tableLayoutPanel1.Controls.Add(newLbl, 0, tableLayoutPanel1.RowCount);
                    tableLayoutPanel1.Controls.Add(newTxtBox, 1, tableLayoutPanel1.RowCount);
                    tableLayoutPanel1.Controls.Add(deleteButton, 2, tableLayoutPanel1.RowCount);

                    tableLayoutPanel1.RowCount++;

                    ctrlCtr++;
                }
                LoadAddRow(tableLayoutPanel1.RowCount + 1);
                tableLayoutPanel1.ResumeLayout();
                tabAttributes.ResumeLayout();
            }
        }

        public void LoadHistory()
        {
            try
            {
                _retriever = new AuditEntryRetriever(_dbSettings, _recordType);
                _dataCache = new DataCache(_retriever, 500);

                gridAuditHistory.Columns.Clear();
                gridAuditHistory.Rows.Clear();

                foreach (var column in _retriever.Columns)
                    gridAuditHistory.Columns.Add(column, column);

                gridAuditHistory.RowCount = _retriever.RowCount;
            }
            catch (Exception ex)
            {
                NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error, "Failed to load history for this record type. Please try again.");
            }
        }

        private void gridAuditHistory_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        public void LoadAddRow(int row)
        {
            _addRowLabel = new MetroLabel
            {
                Text = "New Attribute",
                Tag = "NEW",
                Theme = Theme,
                Style = Style
            };
            _addRowTextBox = new MetroTextBox
            {
                Tag = "NEW", 
                Width = 250,
                Theme = Theme,
                Style = Style
            };
            _addRowButton = new Button
            {
                Width = 25,
                BackgroundImage = Theme == MetroThemeStyle.Dark ? Resources.plus_light : Resources.plus_dark,
                BackColor = Color.Transparent,
                Tag = "NEW",
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0, 
                    MouseDownBackColor = Color.Transparent, 
                    MouseOverBackColor = Color.Transparent
                }
            };

            _addRowButton.Click += (sender, args) => AddRow();

            if (row != 0)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));
                tableLayoutPanel1.RowCount++;
            }
            
            tableLayoutPanel1.Controls.Add(_addRowLabel, 0, row);
            tableLayoutPanel1.Controls.Add(_addRowTextBox, 1, row);
            tableLayoutPanel1.Controls.Add(_addRowButton, 2, row);
        }

        private void AddRow()
        {
            tabAttributes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            var addValue = _addRowTextBox.Text;

            if (string.IsNullOrEmpty(addValue)) return;

            var ctrlCnt = _txtControls.Count;

            var newLbl = new MetroLabel
            {
                Text = "Attribute " + (_txtControls.Count + 1),
                Name = "Row" + (ctrlCnt + 1),
                Theme = Theme,
                Style = Style
            };
            var newTxtBox = new MetroTextBox
            {
                Text = addValue, Tag = "ADDED",
                Name = "Row" + (ctrlCnt + 1),
                Width = 250,
                Theme = Theme,
                Style = Style
            };
            var deleteButton = new Button
            {
                Width = 25, 
                BackgroundImage = Theme == MetroThemeStyle.Dark ? Resources.trash_light : Resources.trash_dark, 
                BackColor = Color.Transparent, 
                Name = "Row" + (ctrlCnt + 1), 
                FlatStyle = FlatStyle.Flat, 
                FlatAppearance = 
                { 
                    BorderSize = 0, 
                    MouseDownBackColor = Color.Transparent, 
                    MouseOverBackColor = Color.Transparent
                }
            };

            deleteButton.Click += (sender, args) => RemoveRow(sender);

            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));

            tableLayoutPanel1.Controls.Add(newLbl, 0, tableLayoutPanel1.RowCount + 1);
            tableLayoutPanel1.Controls.Add(newTxtBox, 1, tableLayoutPanel1.RowCount + 1);
            tableLayoutPanel1.Controls.Add(deleteButton, 2, tableLayoutPanel1.RowCount + 1);

            _txtControls.Add(newTxtBox);

            _addRowTextBox.Text = "";

            var addRowsCtrls = tableLayoutPanel1.Controls.Cast<Control>()
                .Where(x => x.Tag != null && x.Tag.Equals("NEW")).ToArray();

            foreach(var ctrl in addRowsCtrls)
                tableLayoutPanel1.Controls.Remove(ctrl);

            LoadAddRow(tableLayoutPanel1.RowCount + 2);
            tableLayoutPanel1.ResumeLayout();
            tabAttributes.ResumeLayout();
        }

        private void RemoveRow(object sender)
        {
            tabAttributes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            var senderBtn = (Button) sender;

            var rowName = senderBtn.Name;
            var rowNum = tableLayoutPanel1.GetRow(senderBtn);

            var rowCtrls = tableLayoutPanel1.Controls.Cast<Control>()
                .Where(x => x.Name != null && x.Name.Equals(rowName)).ToArray();

            foreach (var ctrl in rowCtrls)
            {
                tableLayoutPanel1.Controls.Remove(ctrl);
                if (ctrl.GetType() == typeof(MetroTextBox))
                {
                    _removedAttrs.Add(ctrl.Tag.ToString());
                    _txtControls.Remove((MetroTextBox) ctrl);
                }
                    
            }
                

            tableLayoutPanel1.RowStyles.RemoveAt(rowNum);
            tableLayoutPanel1.RowCount--;
            // move up row controls that comes after row we want to remove
            for (int i = rowNum + 1; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    var control = tableLayoutPanel1.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        tableLayoutPanel1.SetRow(control, i - 1);
                    }
                }
            }

            
            
            var attributeLabels = tableLayoutPanel1.Controls.OfType<MetroLabel>().Where(x => x.Name.Contains("Row")).OrderBy(x => x.Text);
            var newLabelCtr = 1;
            foreach (var label in attributeLabels)
            {
                label.Text = "Attribute " + newLabelCtr;
                newLabelCtr++;
            }
            tableLayoutPanel1.ResumeLayout();
            tabAttributes.ResumeLayout();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool needsDbAction = false;
            var newAttrs = new List<string>();

            //Remove removed attributes in existing records
            if (_recordType != null && _removedAttrs.Count > 0)
            {
                foreach (var rAttr in _removedAttrs)
                    _recordType.Attributes.Remove(rAttr);
                needsDbAction = true;
            }

            if (_recordType != null && !_recordType.Name.Equals(txtRecTypeName.Text))
            {
                _recordType.Name = txtRecTypeName.Text;
                needsDbAction = true;
            }
                

            foreach (var ctrl in _txtControls)
            {
                var attrVal = ctrl.Text;
                if (ctrl.Tag.Equals("ADDED"))
                {
                    //This is a new attribute, add its value to the new attr list
                    newAttrs.Add(ctrl.Text);
                    needsDbAction = true;
                }else
                {
                    //This is an existing attribute, retrieve its id and value
                    var attrId = ctrl.Tag.ToString();
                    _recordType.Attributes.TryGetValue(attrId, out var currAttrVal);
                    if (!attrVal.Equals(currAttrVal) && _recordType.Attributes.ContainsKey(attrId))
                    {
                        //new value doesn't match current value, update it
                        _recordType.Attributes[attrId] = attrVal;
                        needsDbAction = true;
                    }
                }
            }

            if (_recordType == null && needsDbAction)
            {
                //Adding a new one
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var addStatus = oH.AddRecordType(txtRecTypeName.Text, newAttrs, true);
                    if (addStatus.Success)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error, "Failed to add this new record type. Please try again.");
                    }
                }
            }
            else if (needsDbAction)
            {
                foreach (var attr in newAttrs)
                {
                    var newId = DataProcessor.GetStrId();
                    while (_recordType.Attributes.ContainsKey(newId))
                    {
                        newId = DataProcessor.GetStrId(); //Keep generating a new strId until it's unique
                    }
                    _recordType.Attributes.Add(newId, attr);
                }
                    

                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var updateStatus = oH.UpdateRecordType(_recordType);
                    if (updateStatus.Success)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        NotificationHelper.ShowNotification(this, NotificationHelper.NotificationType.Error, "Failed to update this record type. Please try again.");
                    }
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void RefreshRecordType()
        {
            if (_recordType != null)
            {
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var recordTypeFetch = oH.GetRecordTypeById(_recordType.Id);
                    if (recordTypeFetch.Success)
                    {
                        _recordType = (RecordType)recordTypeFetch.Result;
                    }
                }
            }
            LoadAttributes();
        }

        private void txtRecType_TextChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = txtRecTypeName.Text.Replace(" ", "").Length > 0;
        }
    }
}