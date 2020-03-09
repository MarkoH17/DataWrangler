using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
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
                newLbl.Top = ctrlCtr * 25;

                newTxtBox.Left = newLbl.Width + 5;
                newTxtBox.Top = ctrlCtr * 25;
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
    }
}