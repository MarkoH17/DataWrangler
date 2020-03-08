using System.Collections.Generic;
using System.Data;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class AuditEntryRetriever : DataRetriever, IDataRetriever
    {
        private readonly string _username;

        public AuditEntryRetriever(Dictionary<string, string> dbSettings, string username)
        {
            DbSettings = dbSettings;
            _username = username;
            LoadColumns();
        }

        public string[] Columns => ColumnsValue.ToArray();

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

            return DataProcessor.FillAuditEntryDataTable(Columns, auditEntries);
        }

        private void LoadColumns()
        {
            foreach (var col in new[] {"Id", "Object Type", "User Account"})
                ColumnsValue.Add(col);
        }
    }
}