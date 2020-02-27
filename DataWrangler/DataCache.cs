using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using DataWrangler.Retrievers;

namespace DataWrangler
{
    public class DataCache
    {
        private const int MaxPages = 8;
        private static int _rowsPerPage;
        private readonly IDataRetriever _dataSupply;

        private DataPage[] _cachePages;

        private readonly string _searchField;
        private readonly string _searchValue;
        private int _usedPages;


        public DataCache(IDataRetriever dataSupplier, int rowsPerPage, string searchField = null,
            string searchValue = null)
        {
            _dataSupply = dataSupplier;
            _rowsPerPage = rowsPerPage;

            _searchField = searchField;
            _searchValue = searchValue;

            LoadInitialData();
        }

        // Sets the value of the element parameter if the value is in the cache.
        private bool IfPageCached_ThenSetElement(int rowIndex, int columnIndex, ref string element)
        {
            for (var i = 0; i < _usedPages; i++)
                if (IsRowCachedInPage(i, rowIndex))
                {
                    element = _cachePages[i].Table.Rows[rowIndex % _rowsPerPage][columnIndex].ToString();
                    return true;
                }

            return false;
        }

        public string RetrieveElement(int rowIndex, int columnIndex)
        {
            string element = null;

            if (IfPageCached_ThenSetElement(rowIndex, columnIndex, ref element))
                return element;


            return RetrieveData_CacheIt_ThenReturnElement(rowIndex, columnIndex);
        }

        private void LoadInitialData()
        {
            _cachePages = new DataPage[MaxPages];
            if (_dataSupply.RowCount >= _rowsPerPage * 2)
            {
                _cachePages[0] = new DataPage(
                    _dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0), _rowsPerPage, _searchField,
                        _searchValue),
                    0);
                _cachePages[1] =
                    new DataPage(
                        _dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(_rowsPerPage), _rowsPerPage,
                            _searchField, _searchValue),
                        _rowsPerPage);
                _usedPages = 2;
            }
            else
            {
                _cachePages[0] = new DataPage(
                    _dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0), _rowsPerPage, _searchField,
                        _searchValue),
                    0);
                _usedPages = 1;
            }
        }

        private string RetrieveData_CacheIt_ThenReturnElement(
            int rowIndex, int columnIndex)
        {
            // Retrieve a page worth of data containing the requested value.
            var table = _dataSupply.SupplyPageOfData(
                DataPage.MapToLowerBoundary(rowIndex), _rowsPerPage);

            if (_usedPages < MaxPages)
            {
                //Room left in cache, lets add it to our cache pages
                var nextPageIdx = GetIndexToNextPage();
                _cachePages[nextPageIdx] = new DataPage(table, rowIndex);
                _usedPages++;
            }
            else
            {
                //No room left in cache, lets replace one of our cache pages
                //int replacementIdx = GetIndexOfOldestPage();
                var replacementIdx = GetIndexToUnusedPage(rowIndex);
                _cachePages[replacementIdx] = new DataPage(table, rowIndex);
            }


            return RetrieveElement(rowIndex, columnIndex);
        }

        // Returns the index of the cached page most distant from the given index
        // and therefore least likely to be reused.
        private int GetIndexToUnusedPage(int rowIndex)
        {
            var pageDistances = new Dictionary<int, double>();
            for (var i = 0; i < _usedPages; i++)
            {
                var newLowestIndex = DataPage.MapToLowerBoundary(rowIndex);
                var newHighestIndex = DataPage.MapToUpperBoundary(rowIndex);

                var currLowestIndex = _cachePages[i].LowestIndex;
                var currHighestIndex = _cachePages[i].HighestIndex;

                //Sqrt( (x2 - x1) ^ 2 + (y2 - y1) ^ 2)

                var distance =
                    Math.Sqrt(
                        (newHighestIndex - currHighestIndex) * (newHighestIndex - currHighestIndex) +
                        (newLowestIndex - currHighestIndex) * (newLowestIndex - currHighestIndex));

                pageDistances.Add(i, distance);
            }

            var maxDistIdx = pageDistances.Aggregate((k, d) => k.Value > d.Value ? k : d).Key;
            return maxDistIdx;
        }

        private int GetIndexToNextPage()
        {
            return _usedPages;
        }

        // Returns a value indicating whether the given row index is contained
        // in the given DataPage. 
        private bool IsRowCachedInPage(int pageNumber, int rowIndex)
        {
            return rowIndex <= _cachePages[pageNumber].HighestIndex &&
                   rowIndex >= _cachePages[pageNumber].LowestIndex;
        }

        // Represents one page of data.  
        public struct DataPage
        {
            public DataTable Table;

            public DataPage(DataTable table, int rowIndex)
            {
                Table = table;
                LowestIndex = MapToLowerBoundary(rowIndex);
                HighestIndex = MapToUpperBoundary(rowIndex);
                Debug.Assert(LowestIndex >= 0);
                Debug.Assert(HighestIndex >= 0);
            }

            public int LowestIndex { get; }

            public int HighestIndex { get; }

            public static int MapToLowerBoundary(int rowIndex)
            {
                // Return the lowest index of a page containing the given index.
                return rowIndex / _rowsPerPage * _rowsPerPage;
            }

            public static int MapToUpperBoundary(int rowIndex)
            {
                // Return the highest index of a page containing the given index.
                return MapToLowerBoundary(rowIndex) + _rowsPerPage - 1;
            }
        }
    }
}