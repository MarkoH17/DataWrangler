using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DataWrangler.DBOs;
using DataWrangler.Retrievers;

namespace DataWrangler
{
    public partial class MainWindow : Form
    {
        private readonly Dictionary<string, string> _dbSettings;
        private readonly UserAccount _user;

        private DataCache _memoryCache;

        public MainWindow()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridView1, new object[] {true});

            var initResult = ObjectHelper.InitializeSystem(@"V:\DataWrangler Project\test.db", false, true);

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

                var testPath1 = @"C:\Users\Mark Hedrick\Desktop\Client Data\publication headlines.xlsx";

                var headers1 = dP.GetSpreadsheetHeaders(testPath1);

                var rt1 = oH.AddRecordType("Publication Headlines", headers1.Values.ToList(), true);
                var rT1 = oH.GetRecordTypeById((int) rt1.Result);
                if (rt1.Success && rT1.Success)
                    for (var i = 0; i < 75; i++) //generating duplicate data to test performance
                    {
                        var recs = dP.GetRecordsFromSheet((RecordType) rT1.Result, headers1, testPath1);
                        oH.AddRecords(recs);
                    }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            // Complete the initialization of the DataGridView.
            dataGridView1.Size = new Size(800, 250);
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.VirtualMode = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellValueNeeded += dataGridView1_CellValueNeeded;
            try
            {
                var rT = new RecordType
                {
                    Id = 1,
                    Name = "Publication Headlines",
                    Attributes = new List<string>
                    {
                        "Headline",
                        "Date",
                        "Publication",
                        "Volume",
                        "Number",
                        "Page No.",
                        "Type"
                    },
                    Active = true
                };

                var retriever = new RecordRetriever(_dbSettings, rT);
                _memoryCache = new DataCache(retriever, 500);

                foreach (DataColumn column in retriever.Columns)
                    dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);

                dataGridView1.RowCount = retriever.RowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was encountered: " + ex.Message);
                Application.Exit();
            }

            // Adjust the column widths based on the displayed values.
            dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.DisplayedCells);

            base.OnLoad(e);
        }
        

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (DataProcessor.IsColumnVisible(dataGridView1, e))
                return;

            e.Value = _memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}