using System.Collections.Generic;

namespace DataWrangler.Retrievers
{
    public class DataRetriever
    {
        public List<string> ColumnsValue = new List<string>();
        public DataProcessor DataProcessor = new DataProcessor();
        public Dictionary<string, string> DbSettings;
        public int RowCountValue = -1;
    }
}