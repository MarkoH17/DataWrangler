using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class RecordTypeRetriever : IDataRetriever
    {
        
        public RecordTypeRetriever(Dictionary<string, string> dbSettings)
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
            RecordType[] recordTypes = null;
            using (var oH = new ObjectHelper(DbSettings))
            {
                var fetchStatus = oH.GetRecordTypes(lowerPageBoundary, rowsPerPage);
                if (fetchStatus.Success)
                    recordTypes = (RecordType[]) fetchStatus.Result;
            }

            return DataProcessor.FillRecordTypeDataTable(ColumnNames, recordTypes);
        }

        public string[] ColumnNames { get; set; }
        public DataColumnCollection ColumnsValue { get; set; }
        public List<string> ColumnIds { get; set; } = new List<string>();
        public DataProcessor DataProcessor { get; set; } = new DataProcessor();
        public DataTable DataTable { get; set; } = new DataTable();
        public Dictionary<string, string> DbSettings { get; set; }
        public int RowCountValue { get; set; } = -1;

        private void LoadColumns()
        {
            DataTable.Columns.Add("Id");
            DataTable.Columns.Add("Name");
            DataTable.Columns.Add("Attributes");
            ColumnNames = DataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            ColumnsValue = DataTable.Columns;
        }
    }
}