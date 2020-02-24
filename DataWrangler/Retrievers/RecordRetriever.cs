using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class RecordRetriever : DataRetriever, IDataRetriever
    {
        private readonly RecordType _recordType;

        public RecordRetriever(Dictionary<string, string> dbSettings, RecordType recordType)
        {
            base.DbSettings = dbSettings;
            _recordType = recordType;
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
                    var countStatus = oH.GetRecordCount();
                    if (countStatus.Success) RowCountValue = (int) countStatus.Result;
                }

                return RowCountValue;
            }
        }

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            Record[] records = null;
            using (var oH = new ObjectHelper(DbSettings))
            {
                var fetchStatus = oH.GetRecordsByType(_recordType, lowerPageBoundary, rowsPerPage);
                if (fetchStatus.Success)
                    records = (Record[]) fetchStatus.Result;
            }

            return DataProcessor.FillRecordDataTable(ColumnNames, _recordType, records);
        }

        private void LoadColumns()
        {
            DataTable.Columns.Add("Id");
            foreach (var attr in _recordType.Attributes)
                DataTable.Columns.Add(attr);

            ColumnNames = DataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            ColumnsValue = DataTable.Columns;
        }
    }
}