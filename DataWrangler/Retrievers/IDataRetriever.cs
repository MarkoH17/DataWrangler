using System.Collections.Generic;
using System.Data;

namespace DataWrangler.Retrievers
{
    public interface IDataRetriever
    {
        int RowCount { get; }
        DataColumnCollection Columns { get; }
        List<string> ColumnIds { get; set; }
        DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage, string searchField = null,
            string searchTerm = null);
    }
}