using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class AuditEntryRetriever : DataRetriever
    {
        private readonly string _username;

        public AuditEntryRetriever(Dictionary<string, string> dbSettings, string username)
        {
            DbSettings = dbSettings;
            _username = username;
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
                    var countStatus = oH.GetAuditEntryCount();
                    if (countStatus.Success) RowCountValue = (int) countStatus.Result;
                }

                return RowCountValue;
            }
        }

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage, string searchField = null,
            string searchTerm = null)
        {
            AuditEntry[] auditEntries = null;
            using (var oH = new ObjectHelper(DbSettings))
            {
                var fetchStatus = oH.GetAuditEntriesByUsername(_username, lowerPageBoundary, rowsPerPage);
                if (fetchStatus.Success)
                    auditEntries = (AuditEntry[]) fetchStatus.Result;
            }

            return DataProcessor.FillAuditEntryDataTable(ColumnNames, auditEntries);
        }

        private void LoadColumns()
        {
            DataTable.Columns.Add("Id");
            DataTable.Columns.Add("Object Type");
            DataTable.Columns.Add("User Account");
            ColumnNames = DataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            ColumnsValue = DataTable.Columns;
        }
    }
}