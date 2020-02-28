using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class RecordRetriever : DataRetriever, IDataRetriever
    {
        private readonly RecordType _recordType;
        private readonly string _searchField;
        private readonly string _searchValue;

        private readonly string _sortColumnId;
        private readonly ListSortDirection _sortDirection;

        public RecordRetriever(Dictionary<string, string> dbSettings, RecordType recordType, string searchField = null,
            string searchValue = null, string sortColumnId = null, ListSortDirection sortDirection = ListSortDirection.Descending)
        {
            DbSettings = dbSettings;
            _recordType = recordType;
            _searchField = searchField;
            _searchValue = searchValue;
            _sortColumnId = sortColumnId;
            _sortDirection = sortDirection;

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

        public List<string> ColumnIds { get; set; } = new List<string>();


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
            string searchTerm = null, string sortColumnId = null, ListSortDirection sortDirection = ListSortDirection.Descending)
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
            DataTable.Columns.Add("Id");
            ColumnIds.Add("Id");
            foreach (var attr in _recordType.Attributes)
            {
                DataTable.Columns.Add(attr.Value);
                ColumnIds.Add("Attributes." + attr.Key);
            }
                

            ColumnNames = DataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            ColumnsValue = DataTable.Columns;
        }
    }
}