using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public DataColumnCollection Columns
        {
            get
            {
                if (ColumnsValue != null)
                    return ColumnsValue;
                return ColumnsValue;
            }
        }

        public int RowCount
        {
            get
            {
                if (RowCountValue != -1) return RowCountValue;

                using (var oH = new ObjectHelper(DbSettings))
                {
                    var countStatus = oH.GetRecordTypeCount();
                    if (countStatus.Success) RowCountValue = (int) countStatus.Result;
                }

                return RowCountValue;
            }
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

            return DataProcessor.FillUserAccountDataTable(ColumnNames, userAccounts);
        }

        private void LoadColumns()
        {
            DataTable.Columns.Add("Id");
            DataTable.Columns.Add("Username");
            ColumnNames = DataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            ColumnsValue = DataTable.Columns;
        }
    }
}