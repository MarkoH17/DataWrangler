using System.Data;

namespace DataWrangler.Retrievers
{
    public interface IDataRetriever
    {
        string[] Columns { get; }
        int RowCount { get; }

        DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage, string searchField = null,
            string searchTerm = null);
    }
}