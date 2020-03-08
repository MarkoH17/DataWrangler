using System.Data;

namespace DataWrangler.Retrievers
{
    public interface IDataRetriever
    {
        int RowCount { get; }
        string[] Columns { get; }

        DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage, string searchField = null,
            string searchTerm = null);
    }
}