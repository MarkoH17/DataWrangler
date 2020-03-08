using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Retrievers;
using DataWrangler.UI_Controls;

namespace DataWrangler
{
    public partial class MainWindow : Form
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;

        private RecordType _recordTypeSel;


        private IDataRetriever _retriever; //Needed for paging the data table
        private DataCache _dataCache; //Needed for caching entries with the data table

        public MainWindow()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridView1,
                new object[] {true});

            var initResult = ObjectHelper.InitializeSystem(@"C:\Users\Mark Hedrick\Desktop\big-test.db", false, true);

            if (initResult.Success)
                _dbSettings = (Dictionary<string, string>) initResult.Result;
            else
                _dbSettings = ConfigurationHelper.GetDbSettings();

            using (var oH = new ObjectHelper(_dbSettings))
            {
                var loginResult = oH.LoginUserAccount("sysadmin", "P@ssw0rd");
                if (loginResult.Success)
                    _user = (UserAccount) loginResult.Result;
            }


            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var dP = new DataProcessor();

                var clientDataFolder = @"C:\Users\Mark Hedrick\Desktop\Client Data\";

                var testFiles = Directory.GetFiles(clientDataFolder, "*.xlsx");

                foreach (var file in testFiles)
                {
                    
                    var fileName = new FileInfo(file).Name;
                    var headers = dP.GetSpreadsheetHeaders(file);
                    var resultAddRT = oH.AddRecordType(fileName.Replace(".xlsx", ""), headers.Values.ToList(), true);
                    if (resultAddRT.Success)
                    {
                        var objRT = (RecordType) oH.GetRecordTypeById((int) resultAddRT.Result).Result;

                        for (var i = 0; i < 350; i++)
                        {
                            var recs = dP.GetRecordsFromSheet(objRT, headers, file);
                            oH.AddRecords(recs, objRT);
                        }
                    }
                }
            }


            //populate record type box
            RecordType[] recordTypes = null;

            using (var oH = new ObjectHelper(_dbSettings, _user))
            {
                var result = oH.GetRecordTypes();
                if (result.Success) recordTypes = (RecordType[]) result.Result;
            }


            foreach (var rT in recordTypes)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = rT.Name;
                comboBoxItem.Value = rT;
                comboRecordType.Items.Add(comboBoxItem);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            dataGridView1.VirtualMode = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellValueNeeded += dataGridView1_CellValueNeeded;
            dataGridView1.RowCount = 0;

            comboField.MaxDropDownItems = 100;
            comboRecordType.MaxDropDownItems = 100;

            //Demo code for populating datatable of UserAccounts
            /*try
            {
                //Change 'UserAccountRetriever' below to proper retriever. E.g. for showing Records, use RecordRetriever, for showing RecordType use RecordTypeRetriever. Update constructor parameters if required.
                _retriever = new UserAccountRetriever(_dbSettings); 
                _dataCache = new DataCache(_retriever, 500);


                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                foreach (var column in _retriever.Columns)
                    dataGridView1.Columns.Add(column, column);

                dataGridView1.RowCount = _retriever.RowCount;
                textBox1.Text = _retriever.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was encountered: " + ex.Message);
            }*/

            base.OnLoad(e);
        }

        private void btnFieldSearchGo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboField.SelectedItem.ToString()) || string.IsNullOrEmpty(txtFieldSearch.Text))
                return;

            var searchField = ((ComboBoxItem) comboField.SelectedItem).Value.ToString();
            var searchValue = txtFieldSearch.Text;

            LoadRecordsByType(_recordTypeSel, searchField, searchValue);
        }

        private void btnGlobalGo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGlobal.Text))
                return;
            var searchValue = txtGlobal.Text;

            LoadRecordsByType(_recordTypeSel, "*", searchValue);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (ComboBoxItem) ((ComboBox) sender).SelectedItem;
            _recordTypeSel = (RecordType) selectedItem.Value;
            comboField.Items.Clear();

            foreach (var attr in _recordTypeSel.Attributes)
            {
                var comboBoxItem = new ComboBoxItem {Text = attr.Value, Value = "Attributes." + attr.Key};
                comboField.Items.Add(comboBoxItem);
            }

            LoadRecordsByType(_recordTypeSel);
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            //if (comboRecordType.SelectedItem == null || _dataCache == null/* ||
               // DataProcessor.IsColumnVisible(dataGridView1, e)*/)
                //return;
            e.Value = _dataCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private void LoadRecordsByType(RecordType rT, string searchField = null, string searchValue = null)
        {
            try
            {
                _retriever = new RecordRetriever(_dbSettings, rT, searchField, searchValue);
                _dataCache = new DataCache(_retriever, 500, searchField, searchValue);


                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                foreach (var column in _retriever.Columns)
                    dataGridView1.Columns.Add(column, column);

                dataGridView1.RowCount = _retriever.RowCount;
                textBox1.Text = _retriever.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was encountered: " + ex.Message);
            }
        }
    }
}