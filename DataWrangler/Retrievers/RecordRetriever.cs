using System.Collections.Generic;
using System.Data;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class RecordRetriever : DataRetriever, IDataRetriever
    {
        private readonly RecordType _recordType;
        private readonly string _searchField;
        private readonly string _searchValue;

        public RecordRetriever(Dictionary<string, string> dbSettings, RecordType recordType, string searchField = null,
            string searchValue = null)
        {
            DbSettings = dbSettings;
            _recordType = recordType;
            _searchField = searchField;
            _searchValue = searchValue;

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
                    int count;

                    if (string.IsNullOrEmpty(_searchField) || string.IsNullOrEmpty(_searchValue))
                    {
                        count = (int) oH.GetRecordCountByRecordType(_recordType).Result;
                    }
                    else
                    {
                        if (_searchField.Equals("*"))
                            count = (int) oH.GetRecordCountByRecordTypeAndGlobalSearch(_recordType, _searchValue)
                                .Result;
                        else
                            count = (int) oH
                                .GetRecordCountByRecordTypeAndSearch(_recordType, _searchField, _searchValue).Result;
                    }

                    RowCountValue = count;
                }

                return RowCountValue;
            }
        }

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage, string searchField = null,
            string searchTerm = null)
        {
            Record[] records = null;
            using (var oH = new ObjectHelper(DbSettings))
            {
                StatusObject fetchStatus = null;
                if (searchField != null || searchTerm != null)
                {
                    if (searchField.Equals("*"))
                        fetchStatus =
                            oH.GetRecordsByGlobalSearch(_recordType, _searchValue, lowerPageBoundary, rowsPerPage);
                    else
                        fetchStatus = oH.GetRecordsByTypeSearch(_recordType, searchField, searchTerm, lowerPageBoundary,
                            rowsPerPage);
                    if (fetchStatus.Success)
                        records = (Record[]) fetchStatus.Result;
                }
                else
                {
                    fetchStatus = oH.GetRecordsByType(_recordType, lowerPageBoundary, rowsPerPage);
                    if (fetchStatus.Success)
                        records = (Record[]) fetchStatus.Result;
                }
            }

            return DataProcessor.FillRecordDataTable(_recordType, records);
        }

        private void LoadColumns()
        {
            ColumnsValue.Add("Id");
            foreach (var attr in _recordType.Attributes) ColumnsValue.Add(attr.Value);
        }
    }
}