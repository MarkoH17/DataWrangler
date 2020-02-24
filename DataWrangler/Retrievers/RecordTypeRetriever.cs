using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class RecordTypeRetriever : DataRetriever, IDataRetriever
    {
        public RecordTypeRetriever(Dictionary<string, string> dbSettings)
        {
            base.DbSettings = dbSettings;
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

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
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