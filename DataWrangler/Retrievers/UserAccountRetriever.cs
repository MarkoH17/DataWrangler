using System.Collections.Generic;
using System.Data;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class UserAccountRetriever : DataRetriever, IDataRetriever
    {
        public UserAccountRetriever(Dictionary<string, string> dbSettings)
        {
            DbSettings = dbSettings;
            LoadColumns();
        }

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage, string searchField = null,
            string searchTerm = null)
        {
            UserAccount[] userAccounts = null;
            using (var oH = new ObjectHelper(DbSettings))
            {
                var fetchStatus = oH.GetUserAccounts(lowerPageBoundary, rowsPerPage);
                if (fetchStatus.Success)
                    userAccounts = (UserAccount[]) fetchStatus.Result;
            }

            return DataProcessor.FillUserAccountDataTable(Columns, userAccounts);
        }

        public string[] Columns => ColumnsValue.ToArray();

        public int RowCount
        {
            get
            {
                if (RowCountValue != -1) return RowCountValue;

                using (var oH = new ObjectHelper(DbSettings))
                {
                    var countStatus = oH.GetUserAccountCount();
                    if (countStatus.Success) RowCountValue = (int) countStatus.Result;
                }

                return RowCountValue;
            }
        }

        private void LoadColumns()
        {
            foreach (var col in new[] {"Id", "Username", "Active", "LastUpdated"})
                ColumnsValue.Add(col);
        }
    }
}