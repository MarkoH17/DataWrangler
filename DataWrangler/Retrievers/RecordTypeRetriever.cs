using System.Collections.Generic;
using System.Data;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class RecordTypeRetriever : DataRetriever, IDataRetriever
    {
        public RecordTypeRetriever(Dictionary<string, string> dbSettings)
        {
            DbSettings = dbSettings;
            LoadColumns();
        }

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage, string searchField = null,
            string searchTerm = null)
        {
            RecordType[] recordTypes = null;
            using (var oH = new ObjectHelper(DbSettings))
            {
                var fetchStatus = oH.GetRecordTypes(lowerPageBoundary, rowsPerPage);
                if (fetchStatus.Success)
                    recordTypes = (RecordType[]) fetchStatus.Result;
            }

            return DataProcessor.FillRecordTypeDataTable(Columns, recordTypes);
        }

        public string[] Columns => ColumnsValue.ToArray();

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

        private void LoadColumns()
        {
            foreach (var col in new[] {"Id", "Name", "Attributes"})
                ColumnsValue.Add(col);
        }
    }
}