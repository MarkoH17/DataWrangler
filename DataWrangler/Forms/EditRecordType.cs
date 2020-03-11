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

namespace DataWrangler.Forms
{
    public partial class EditRecordType : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;
        private RecordType _recordType;

        private List<MetroTextBox> _txtControls = new List<MetroTextBox>();

        private DataCache _dataCache;
        private IDataRetriever _retriever;

        private int _attachmentsSelIdx;
        private MetroToolTip hintToolTip = new MetroToolTip();
        private string[] recordAttachments;
        public EditRecordType(Dictionary<string, string> dbSettings, UserAccount user, RecordType recordType)
        {
            InitializeComponent();

            _dbSettings = dbSettings;
            _user = user;
            _recordType = recordType;

            LoadAttributes();
            if (recordType == null)
            {
                Text = "Add Record";
                
            }
            tabControl1.SelectedTab = tabAttributes;
        }

        public void LoadAttributes()
        {
            int ctrlCtr = 0;

            txtRecId.Text = _recordType != null ? _recordType.Id.ToString() : "---";
            txtRecType.Text = _recordType.Name;

            foreach (var attr in _recordType.Attributes)
            {
                var attrValue = "";
                if(_recordType != null)
                {
                    _recordType.Attributes.TryGetValue(attr.Key, out attrValue);
                }

                var newLbl = new MetroLabel { Text = "Attribute " + (ctrlCtr + 1) };
                var newTxtBox = new MetroTextBox { Text = attrValue, Tag = attr.Key };

                newLbl.Left = 5;
                newLbl.Top = ctrlCtr * 30 + 15;

                newTxtBox.Left = newLbl.Width + 5;
                newTxtBox.Top = ctrlCtr * 30 + 15;
                newTxtBox.Width = tabControl1.Width - newTxtBox.Left - 20;

                _txtControls.Add(newTxtBox);

                tabAttributes.Controls.Add(newLbl);
                tabAttributes.Controls.Add(newTxtBox);
                ctrlCtr++;
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool needsDbAction = false;

            if (_recordType == null)
            {
                _recordType = new RecordType();
                _recordType.Attributes = new Dictionary<string, string>();
                _recordType.Active = true;
            }

            foreach (var ctrl in _txtControls)
            {
                var attrId = ctrl.Tag.ToString();
                var attrVal = ctrl.Text;

                if (attrVal.Length == 0)
                    attrVal = null;

                var currAttrVal = _recordType.Attributes[attrId];

                if (attrVal != currAttrVal)
                {
                    _recordType.Attributes[attrId] = attrVal;
                    needsDbAction = true;
                }
            }

            if (needsDbAction)
            {
                StatusObject dbActionStatus;
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    if (_recordType.Id == 0)
                    {
                        dbActionStatus = oH.AddRecordType(txtRecType.Text, _recordType.Attributes.Select(x => x.Value).ToList(), true);
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