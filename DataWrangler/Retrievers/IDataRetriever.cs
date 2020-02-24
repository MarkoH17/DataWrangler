using System.Data;

namespace DataWrangler.Retrievers
{
    public interface IDataRetriever
    {
        int RowCount { get; }
        DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
    }
}