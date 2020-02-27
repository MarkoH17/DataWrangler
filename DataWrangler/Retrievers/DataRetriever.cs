using System.Collections.Generic;
using System.Data;

namespace DataWrangler.Retrievers
{
    public class DataRetriever
    {
        public string[] ColumnNames;
        public DataColumnCollection ColumnsValue;
        public DataProcessor DataProcessor = new DataProcessor();
        public DataTable DataTable = new DataTable();
        public Dictionary<string, string> DbSettings;
        public int RowCountValue = -1;
    }
}