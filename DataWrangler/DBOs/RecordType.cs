using System;
using System.Collections.Generic;

namespace DataWrangler.DBOs
{
    public class RecordType
    {
        public bool Active { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }
    }
}