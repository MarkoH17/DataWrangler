using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataWrangler.DBOs;

namespace DataWrangler
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            var cF = new ConfigurationHelper();

            var res1 = cF.SaveDbSettings(@"C:\Users\Mark Hedrick\Desktop\test.db", true, "test");
            var dbSettings = cF.GetDbSettings();

            using (var oH = new ObjectHelper(dbSettings, null))
            {
                oH.AddUserAccount("markhedrick", "password", true);
            }

            var user = UserAccount.Login(dbSettings, "markhedrick", "password");

            using (var oH = new ObjectHelper(dbSettings, user))
            {
                var dP = new DataProcessor();

                var testPath1 = @"C:\Users\Mark Hedrick\Desktop\Client Data\personnel.xlsx";
                var testPath2 = @"C:\Users\Mark Hedrick\Desktop\Client Data\publication headlines.xlsx";

                var headers1 = dP.GetSpreadsheetHeaders(testPath1);

                var rt1 = oH.AddRecordType("Personnel", headers1.Values.ToList(), true);
                var rT1 = oH.GetRecordTypeById((int) rt1.Result);
                if (rt1.Success && rT1.Success)
                {
                    var rec1 = dP.GetRecordsFromSheet((RecordType)rT1.Result, headers1, testPath1);
                    oH.AddRecords(rec1);
                }


                var rt2 = oH.AddRecordType("Publication Headlines", new List<string>()
                {
                    "Headline Name",
                    "Date",
                    "Publication",
                    "Volume",
                    "Number",
                    "Page No.",
                    "Type"
                }, true);

                var rT2 = oH.GetRecordTypeById((int) rt2.Result);

                

                if (rt2.Success && rT2.Success)
                {
                    var headers2 = dP.GetSpreadsheetHeaders(testPath2);

                    headers2 = dP.RemapHeaders(headers2, (RecordType) rT2.Result, new[]
                    {
                        new KeyValuePair<int, int>(1, 0)
                    });


                    var rec2 = dP.GetRecordsFromSheet((RecordType)rT2.Result, headers2, testPath2);
                    oH.AddRecords(rec2);
                }


                var recordsA = oH.GetRecordsByType((RecordType) rT1.Result);
                var recordsB = oH.GetRecordsByType((RecordType)rT2.Result);


                dataGridView1.DataSource = dP.GetDataTableForRecords((RecordType)rT2.Result, (Record[])recordsB.Result);
            }
            
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}