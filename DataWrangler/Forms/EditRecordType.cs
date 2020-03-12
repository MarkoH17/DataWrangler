using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.FormControls;
using DataWrangler.Retrievers;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MetroFramework.Interfaces;

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
        private MetroButton _addRowButton;

        private List<string> _removedAttrs = new List<string>();

        public EditRecordType(Dictionary<string, string> dbSettings, UserAccount user, RecordType recordType)
        {
            InitializeComponent();

            _dbSettings = dbSettings;
            _user = user;
            _recordType = recordType;

            if (recordType == null)
            {
                Text = "Add Record Type";
                LoadAddRow(0);
            }
            else
            {
                LoadAttributes();
            }
            tabControl1.SelectedTab = tabAttributes;
        }

        public void LoadAttributes()
        {
            int ctrlCtr = 0;

            txtRecId.Text = _recordType != null ? _recordType.Id.ToString() : "---";
            txtRecType.Text = _recordType != null ? _recordType.Name : "";

            if (_recordType != null)
            {
                foreach (var attr in _recordType.Attributes)

                {
                    var attrValue = "";
                    if (_recordType != null)
                    {
                        _recordType.Attributes.TryGetValue(attr.Key, out attrValue);
                    }

                    var newLbl = new MetroLabel {Text = "Attribute " + (ctrlCtr + 1), Name = "Row" + ctrlCtr};
                    var newTxtBox = new MetroTextBox {Text = attrValue, Tag = attr.Key, Name = "Row" + ctrlCtr };
                    var deleteButton = new MetroButton {Width = 25, BackgroundImage = Properties.Resources.trash, BackColor = Color.Transparent, Name = "Row" + ctrlCtr };

                    newLbl.Left = 5;
                    newLbl.Top = ctrlCtr * 30 + 15;

                    newTxtBox.Left = newLbl.Width + 5;
                    newTxtBox.Top = ctrlCtr * 30 + 15;
                    newTxtBox.Width = tabControl1.Width - newTxtBox.Left - 30 - 5 - 15;

                    deleteButton.Left = newLbl.Width + 5 + newTxtBox.Width + 5;
                    deleteButton.Top = ctrlCtr * 30 + 15;
                    deleteButton.Click += (sender, args) => RemoveRow(sender);

                    _txtControls.Add(newTxtBox);
                    _topPoints.Add(newTxtBox.Top);

                    tabAttributes.Controls.Add(newLbl);
                    tabAttributes.Controls.Add(newTxtBox);
                    tabAttributes.Controls.Add(deleteButton);
                    
                    ctrlCtr++;
                }
                LoadAddRow(ctrlCtr);
            }
        }

        public void LoadAddRow(int offset)
        {
            _addRowLabel = new MetroLabel { Text = "New Attribute", Tag = "NEW"};
            _addRowTextBox = new MetroTextBox { Tag = "NEW" };
            _addRowButton = new MetroButton { Width = 25, BackgroundImage = Properties.Resources.plus, BackColor = Color.Transparent, Tag = "NEW" };

            _addRowLabel.Left = 5;
            _addRowLabel.Top = offset * 30 + 15;

            _addRowTextBox.Left = _addRowLabel.Width + 5;
            _addRowTextBox.Top = offset * 30 + 15;
            _addRowTextBox.Width = tabControl1.Width - _addRowTextBox.Left - 30 - 5 - 15;

            _addRowButton.Left = _addRowLabel.Width + 5 + _addRowTextBox.Width + 5;
            _addRowButton.Top = offset * 30 + 15;
            _addRowButton.Click += (sender, args) => AddRow();

            tabAttributes.Controls.Add(_addRowLabel);
            tabAttributes.Controls.Add(_addRowTextBox);
            tabAttributes.Controls.Add(_addRowButton);
        }

        private void AddRow()
        {
            var addValue = _addRowTextBox.Text;

            if (string.IsNullOrEmpty(addValue)) return;

            var ctrlCnt = _txtControls.Count;

            var newLbl = new MetroLabel { Text = "Attribute " + (_txtControls.Count + 1), Name = "Row" + (ctrlCnt + 1) };
            var newTxtBox = new MetroTextBox { Text = addValue, Tag = "ADDED", Name = "Row" + (ctrlCnt + 1) };
            var deleteButton = new MetroButton { Width = 25, BackgroundImage = Properties.Resources.trash, BackColor = Color.Transparent, Name = "Row" + (ctrlCnt + 1) };

            newLbl.Left = 5;
            newLbl.Top = ctrlCnt * 30 + 15;

            newTxtBox.Left = newLbl.Width + 5;
            newTxtBox.Top = ctrlCnt * 30 + 15;
            newTxtBox.Width = tabControl1.Width - newTxtBox.Left - 30 - 5 - 15;

            deleteButton.Left = newLbl.Width + 5 + newTxtBox.Width + 5;
            deleteButton.Top = ctrlCnt * 30 + 15;
            deleteButton.Click += (sender, args) => RemoveRow(sender);

            _txtControls.Add(newTxtBox);

            tabAttributes.Controls.Add(newLbl);
            tabAttributes.Controls.Add(newTxtBox);
            tabAttributes.Controls.Add(deleteButton);
            
            _addRowLabel.Top = (ctrlCnt + 1) * 30 + 15;
            _addRowTextBox.Top = (ctrlCnt + 1) * 30 + 15;
            _addRowButton.Top = (ctrlCnt + 1) * 30 + 15;

            _addRowTextBox.Text = "";

            try
            {
                /*var vscroll = tabAttributes.Controls.OfType<MetroScrollBar>()
                    .Where(x => x.Orientation == MetroScrollOrientation.Vertical).ToArray()[0];
                if (vscroll.Visible)
                    vscroll.Value = vscroll.Maximum - vscroll.Height - 1;*/
            }
            catch { }

        }

        private void RemoveRow(object sender)
        {
            tabAttributes.SuspendLayout();
            var senderBtn = (MetroButton) sender;

            int rowNum = Convert.ToInt32(senderBtn.Name.Replace("Row", ""));

            var rowControls = tabAttributes.Controls.Find(senderBtn.Name, false);
            foreach (var ctrl in rowControls)
            {
                if (ctrl.GetType() == typeof(MetroTextBox))
                {
                    _txtControls.Remove((MetroTextBox)ctrl);
                    _removedAttrs.Add(ctrl.Tag.ToString());
                }
                    
                tabAttributes.Controls.Remove(ctrl);
            }
                

            var otherControls = tabAttributes.Controls;
            foreach (Control ctrl in otherControls)
            {
                if (ctrl.Name.Contains("Row"))
                {
                    var ctrlNum = Convert.ToInt32(ctrl.Name.Replace("Row", ""));
                    if(ctrlNum > rowNum)
                        ctrl.Top -= 30;
                }
                else if (ctrl.Tag != null && ctrl.Tag.Equals("NEW"))
                {
                    ctrl.Top -= 30;
                }
            }

            var attributeLabels = tabAttributes.Controls.OfType<MetroLabel>().Where(x => x.Name.Contains("Row")).OrderBy(x => x.Text);
            var newLabelCtr = 1;
            foreach (var label in attributeLabels)
            {
                label.Text = "Attribute " + newLabelCtr;
                newLabelCtr++;
            }

            tabAttributes.ResumeLayout();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool needsDbAction = false;
            var addValues = new List<string>();
            foreach (var ctrl in _txtControls)
            {
                var attrId = ctrl.Tag.ToString();

                var attrVal = ctrl.Text;

                if (attrVal.Length == 0)
                    attrVal = null;

                var currAttrVal = "";
                if (_recordType != null)
                {
                    _recordType.Attributes.TryGetValue(attrId, out currAttrVal);
                    if (attrVal != currAttrVal)
                    {
                        _recordType.Attributes[attrId] = attrVal;
                        needsDbAction = true;
                    }
                }
                else
                {
                    addValues.Add(attrVal);
                    needsDbAction = true;
                }
            }

            var currName = _recordType?.Name ?? "";
            var newName = txtRecType.Text;

            if (_recordType != null && currName != newName)
            {
                _recordType.Name = newName;
                needsDbAction = true;
            }

            if (_recordType != null && _removedAttrs.Count > 0)
            {
                foreach (var attr in _removedAttrs)
                    _recordType.Attributes.Remove(attr);
                needsDbAction = true;
            }

            if (needsDbAction)
            {
                StatusObject dbActionStatus;
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    if (_recordType == null)
                    {
                        dbActionStatus = oH.AddRecordType(newName, addValues, true);
                        if (dbActionStatus.Success)
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add new record type!");
                        }
                    }
                    else
                    {
                        dbActionStatus = oH.UpdateRecordType(_recordType);
                        if (dbActionStatus.Success)
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update record type!");
                        }
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

    }
}