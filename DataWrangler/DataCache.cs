using System;
using System.Data;
using System.Diagnostics;
using DataWrangler.Retrievers;

namespace DataWrangler
{
    public class DataCache
    {
        private const int MaxPages = 8;
        private static int _rowsPerPage;
        private readonly IDataRetriever _dataSupply;

        private DataPage[] _cachePages;
        private int _usedPages;


        public DataCache(IDataRetriever dataSupplier, int rowsPerPage)
        {
            _dataSupply = dataSupplier;
            _rowsPerPage = rowsPerPage;

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

            if (IfPageCached_ThenSetElement(rowIndex, columnIndex, ref element)) return element;

            var x = RetrieveData_CacheIt_ThenReturnElement(
                rowIndex, columnIndex);
            return x;
        }

        private void LoadInitialData()
        {
            _cachePages = new DataPage[MaxPages];
            if (_dataSupply.RowCount >= _rowsPerPage * 2)
            {
                _cachePages[0] = new DataPage(_dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0), _rowsPerPage),
                    0);
                _cachePages[1] =
                    new DataPage(_dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(_rowsPerPage), _rowsPerPage),
                        _rowsPerPage);
                _usedPages = 2;
            }
            else
            {
                _cachePages[0] = new DataPage(_dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0), _rowsPerPage),
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
            var furthestMidDiff = Math.Abs((_cachePages[0].HighestIndex + _cachePages[0].LowestIndex + 1) / 2 - rowIndex);
            var furthestPageIdx = 0;

            //Need to find datapage furthest from upcoming data page.
            for (var i = 0; i < _usedPages; i++)
            {
                var pageMidDiff = Math.Abs((_cachePages[i].HighestIndex + _cachePages[i].LowestIndex + 1) / 2 - rowIndex);

                if (pageMidDiff > furthestMidDiff)
                    furthestPageIdx = i;
            }

            return furthestPageIdx;
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
                this.Table = table;
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

            private static int MapToUpperBoundary(int rowIndex)
            {
                // Return the highest index of a page containing the given index.
                return MapToLowerBoundary(rowIndex) + _rowsPerPage - 1;
            }
        }
    }
}