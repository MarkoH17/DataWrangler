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

namespace DataWrangler.Forms
{
    public partial class EditRecord : Form
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;
        private Record _record;
        private RecordType _recordType;

        private List<TextBox> _txtControls = new List<TextBox>();

        private DataCache _dataCache;
        private IDataRetriever _retriever;

        private int _attachmentsRowIdxSel;
        public EditRecord(Dictionary<string, string> dbSettings, UserAccount user, Record record, RecordType recordType)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, gridAuditHistory,
                new object[] { true });

            _dbSettings = dbSettings;
            _user = user;
            _record = record;
            _recordType = recordType;

            LoadFields();
            LoadHistory();
            LoadAttachments();
        }

        public void LoadFields()
        {
            int ctrlCtr = 0;

            txtRecId.Text = _record.Id.ToString();
            txtRecType.Text = _recordType.Name;
            
            foreach (var attr in _recordType.Attributes)
            {
                var attrValue = "";
                _record.Attributes.TryGetValue(attr.Key, out attrValue);

                var newLbl = new Label {Text = _recordType.Attributes[attr.Key]};
                var newTxtBox = new TextBox {Text = attrValue, Tag = attr.Key};

                newLbl.Left = 5;
                newLbl.Top = ctrlCtr * 25 + 10;

                newTxtBox.Left = newLbl.Width + 5;
                newTxtBox.Top = ctrlCtr * 25 + 10;
                newTxtBox.Width = tabControl1.Width - newTxtBox.Left - 25 - 5;

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
            if (_record.Attachments != null && _record.Attachments.Count > 0)
            {
                foreach (var attachment in _record.Attachments)
                {
                    var attachmentName = attachment.Split('/').Last();
                    var listItem = new TextValueItem() {Text = attachmentName, Value = attachment};
                    listAttachments.Items.Add(listItem);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool needsUpdate = false;
            //Update Record Object here, and submit to database
            foreach (var ctrl in _txtControls)
            {
                var attrId = ctrl.Tag.ToString();
                var attrVal = ctrl.Text;

                if (attrVal.Length == 0)
                    attrVal = null;

                if (!_record.Attributes.ContainsKey(attrId))
                {
                    _record.Attributes.Add(attrId, "");
                }

                var currAttrVal = _record.Attributes[attrId];

                if (attrVal != currAttrVal)
                {
                    _record.Attributes[attrId] = attrVal;
                    needsUpdate = true;

                }
            }

            if (needsUpdate)
            {
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    var updateStatus = oH.UpdateRecord(_record);
                    if (updateStatus.Success)
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
            var attachmentPath = ((TextValueItem) listAttachments.Items[_attachmentsRowIdxSel]).Value.ToString();
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
            throw new NotImplementedException();
        }
        private void addAttachmentMenuItem_Click(object sender, EventArgs e)
        {
            string[] filePaths = null;
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.RestoreDirectory = true;
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                    filePaths = dialog.FileNames;
            }

            if (filePaths.Length > 0)
            {
                StatusObject addAttachmentStatus = null;
                using (var oH = new ObjectHelper(_dbSettings, _user))
                {
                    addAttachmentStatus = oH.AddAttachmentsToRecord(_record, filePaths);
                }

                if (addAttachmentStatus != null)
                {
                    RefreshRecord();
                    LoadAttachments();
                    if(!addAttachmentStatus.Success)
                        MessageBox.Show("Failed to add attachment.");
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
        }

        private void listAttachments_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var cm = new ContextMenu();

                int selIdx = listAttachments.IndexFromPoint(e.Location);
                if (selIdx != ListBox.NoMatches)
                {
                    _attachmentsRowIdxSel = selIdx;
                    listAttachments.SelectedIndex = _attachmentsRowIdxSel;
                    cm.MenuItems.Add(new MenuItem("Download Attachment", downloadAttachmentMenuItem_Click));
                    cm.MenuItems.Add(new MenuItem("Delete Attachment", deleteAttachmentMenuItem_Click));
                    cm.MenuItems.Add("-"); //horizontal separator on context menu
                }
                
                cm.MenuItems.Add(new MenuItem("Add Attachment", addAttachmentMenuItem_Click));

                cm.Show(listAttachments, listAttachments.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
        }
    }
}