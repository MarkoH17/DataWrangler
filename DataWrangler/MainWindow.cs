using DataWrangler.DBOs;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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



            using (ObjectHelper u = new ObjectHelper(dbFilePath, pass))
            {
                var result1 = u.AddRecordType("Person", new List<string>() { "First Name", "Last Name", "Age" }, true);
                var recordTypes = (IEnumerable<RecordType>)u.GetRecordTypes().Result;

                var result2 = u.AddRecord(
                    recordTypes.FirstOrDefault(rT => rT.Name.Equals("Person")),
                    new Dictionary<string, string>()
                    {
                        {"First Name", "Mark"},
                        {"Last Name", "Hedrick"},
                        {"Age", "21 years"}
                    },
                    true);
            }
        }
    }
}
