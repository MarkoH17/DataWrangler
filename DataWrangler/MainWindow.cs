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

            var dbFilePath = dbSettings["dbFilePath"];
            var pass = dbSettings["dbPass"];

            var user = new UserAccount
            {
                Username = "markhedrick"
            };

            using (var u = new ObjectHelper(dbFilePath, user, pass))
            {
                var result1 = u.AddRecordType("Person", new List<string> {"First Name", "Last Name", "Age"}, true);
                var recordTypes = (IEnumerable<RecordType>) u.GetRecordTypes().Result;

                var result2 = u.AddRecord(
                    recordTypes.FirstOrDefault(rT => rT.Name.Equals("Person")),
                    new Dictionary<string, string>
                    {
                        {"First Name", "Mark"},
                        {"Last Name", "Hedrick"},
                        {"Age", "21 years"}
                    },
                    true);

                var result3 = (Record) u.GetRecordById(1).Result;

                result3.Active = false;

                u.UpdateRecord(result3);

                var result4 = (Record)u.GetRecordById(1).Result;

                var x = u.GetRecordAuditEntries(1);
                var x0 = u.GetRecordTypeAuditEntries(1);
                var x1 = u.GetAuditEntriesByUsername("markhedrick");
            }
        }
    }
}