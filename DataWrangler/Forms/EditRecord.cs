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
using DataWrangler.Properties;
using DataWrangler.Retrievers;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace DataWrangler.Forms
{
    public partial class EditRecord : MetroForm
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;
        private Record _record;
        private RecordType _recordType;

        private List<MetroTextBox> _txtControls = new List<MetroTextBox>();

        private DataCache _dataCache;
        private IDataRetriever _retriever;

        private int _attachmentsSelIdx;
        private MetroToolTip hintToolTip = new MetroToolTip();
        private string[] recordAttachments;
        public EditRecord(Dictionary<string, string> dbSettings, UserAccount user, Record record, RecordType recordType)
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, gridAuditHistory,
                new object[] { true });

            _dbSettings = dbSettings;
            _user = user;
            _record = record;
            _recordType = recordType;

            LoadAttributes();
            if (record == null)
            {
                Text = "Add Record";
                tabControl.TabPages.Remove(tabHistory);
                tabControl.TabPages.Remove(tabAttachments);
            }
            else
            {
                LoadHistory();
                LoadAttachments();
            }
            tabControl.SelectedTab = tabAttributes;
            BringToFront();
        }

        public void LoadAttributes()
        {
            int ctrlCtr = 0;

            txtRecId.Text = _record != null ? _record.Id.ToString() : "---";
            txtRecType.Text = _recordType.Name;
            
            foreach (var attr in _recordType.Attributes)
            {
                var attrValue = "";
                if (_record != null)
                {
                    _record.Attributes.TryGetValue(attr.Key, out attrValue);
                }
                

                var newLbl = new MetroLabel
                {
                    Text = _recordType.Attributes[attr.Key],
                    Theme = Theme,
                    Style = Style
                };
                var newTxtBox = new MetroTextBox
                {
                    Text = attrValue,
                    Tag = attr.Key,
                    Theme = Theme,
                    Style = Style
                };

                newLbl.Left = 5;
                newLbl.Top = ctrlCtr * 30 + 15;
                newLbl.MouseHover += label_Hover;

                newTxtBox.Left = newLbl.Width + 5;
                newTxtBox.Top = ctrlCtr * 30 + 15;
                newTxtBox.Width = tabControl.Width - newTxtBox.Left - 20;

                _txtControls.Add(newTxtBox);

                tabAttributes.Controls.Add(newLbl);
                tabAttributes.Controls.Add(newTxtBox);
                ctrlCtr++;
            }
        }

        public void LoadHistory()
        {
            try
            {
                _retriever = new AuditEntryRetriever(_dbSettings, _recordType, _record.Id);
                _dataCache = new DataCache(_retriever, 500);

                gridAuditHistory.Columns.Clear();
                gridAuditHistory.Rows.Clear();

                foreach (var column in _retriever.Columns)
                    gridAuditHistory.Columns.Add(column, column);

                gridAuditHistory.RowCount = _retriever.RowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was encountered: " + ex.Message);
            }
        }

        public void LoadAttachments()
        {
            listAttachments.Clear();
            listAttachments.Columns.Add("File Name");
            if (_record.Attachments != null && _record.Attachments.Count > 0)
            {
                foreach (var attachment in _record.Attachments)
                {
                    var attachmentName = attachment.Split('/').Last();
                    var lvi = new ListViewItem(new string[] { attachmentName });
                    listAttachments.Items.Add(lvi);
                }

                recordAttachments = _record.Attachments.ToArray();
            }
            listAttachments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listAttachments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listAttachments.AllowSorting = true;

        }

        private void label_Hover(object sender, EventArgs e)
        {
            var labelSender = (MetroLabel) sender;
            int origSize = labelSender.Width;
            labelSender.AutoSize = true;
            int newSize = labelSender.Width;
            labelSender.AutoSize = false;

            if (newSize >= origSize)
            {
                hintToolTip.SetToolTip(labelSender, labelSender.Text);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool needsDbAction = false;

            if (_record == null)
            {
                _record = new Record();
                _record.Attributes = new Dictionary<string, string>();
                _record.Active = true;
            }
            
            foreach (var ctrl in _txtControls)
            {
                var attrId = ctrl.Tag.ToString();
                var attrVal = ctrl.Text;

                if (attrVal.Length == 0)
                    attrVal = null;

                if (!_record.Attributes.ContainsKey(attrId))
                {
                    _record.Attributes.Add(attrId, null);
                }

                var currAttrVal = _record.Attributes[attrId];

                if (attrVal != currAttrVal)
                {
                    _record.Attributes[attrId] = attrVal;
                    needsDbAction = true;
                }
            }

            if (needsDbAction)
            {
                StatusObject dbActionStatus;
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    if (_record.Id == 0)
                    {
                        dbActionStatus = oH.AddRecord(_recordType, _record.Attributes, true);
                        if (dbActionStatus.Success)
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add new record!");
                        }
                    }
                    else
                    {
                        dbActionStatus = oH.UpdateRecord(_record);
                        if (dbActionStatus.Success)
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update record!");
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

        private void gridAuditHistory_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private void downloadAttachmentMenuItem_Click(object sender, EventArgs e)
        {
            var attachmentPath = recordAttachments[_attachmentsSelIdx];
            var attachmentName = attachmentPath.Split('/').Last();
            
            string filePath = null;
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = attachmentName;
                saveFileDialog.DefaultExt = attachmentPath.Substring(attachmentPath.LastIndexOf(".") + 1);
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                }
            }

            if (filePath != null)
            {
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var saveStatus = oH.SaveFileFromRecord(attachmentPath, filePath);
                    if (!saveStatus.Success || !new FileInfo(filePath).Exists)
                    {
                        MessageBox.Show("An error occured while saving the file!");
                    }
                    else
                    {
                        string cmd = "explorer.exe";
                        string arg = "/select, " + filePath;
                        Process.Start(cmd, arg);
                    }
                }
            }
        }
        private void deleteAttachmentMenuItem_Click(object sender, EventArgs e)
        {
            var attachmentPath = recordAttachments[_attachmentsSelIdx];
            StatusObject deleteAttachmentStatus;
            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                deleteAttachmentStatus = oH.DeleteAttachmentFromRecord(_record, attachmentPath);
            }
            if (deleteAttachmentStatus != null)
            {
                RefreshRecord();
                if (!deleteAttachmentStatus.Success)
                    MessageBox.Show("Failed to delete attachment.");
            }
        }
        private void addAttachmentMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.RestoreDirectory = true;
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    StatusObject addAttachmentStatus;
                    using (var oH = new ObjectHelper(_dbSettings, _user))
                    {
                        addAttachmentStatus = oH.AddAttachmentsToRecord(_record, dialog.FileNames);
                    }

                    if (addAttachmentStatus != null)
                    {
                        RefreshRecord();
                        if (!addAttachmentStatus.Success)
                            MessageBox.Show("Failed to add attachment.");
                    }
                }
                    
            }
        }

        private void RefreshRecord()
        {
            if (_record != null)
            {
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var recordFetch = oH.GetRecordById(_record.Id, _recordType);
                    if (recordFetch.Success)
                    {
                        _record = (Record) recordFetch.Result;
                    }
                }
            }
            LoadAttributes();
            LoadHistory();
            LoadAttachments();
        }

        private void listAttachments_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var cm = new MetroContextMenu(Container);
                var hitTest = listAttachments.HitTest(e.X, e.Y);
                
                _attachmentsSelIdx = -1;

                if (hitTest.Item != null) _attachmentsSelIdx = hitTest.Item.Index;
                
                if (_attachmentsSelIdx > -1)
                {
                    cm.Items.Add("Download Attachment", Theme == MetroThemeStyle.Dark ? Resources.download_light : Resources.download_dark, downloadAttachmentMenuItem_Click);
                    cm.Items.Add("Delete Attachment", Theme == MetroThemeStyle.Dark ? Resources.trash_light : Resources.trash_dark, deleteAttachmentMenuItem_Click);
                    cm.Items.Add("-"); //horizontal separator on context menu
                }
                
                cm.Items.Add("Add Attachment", Theme == MetroThemeStyle.Dark ? Resources.plus_light : Resources.plus_dark, addAttachmentMenuItem_Click);

                cm.Show(listAttachments, listAttachments.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
        }
    }
}