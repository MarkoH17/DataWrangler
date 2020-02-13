using System;
using System.Collections.Generic;

namespace DataWrangler.DBOs
{
    internal class RecordType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Attributes { get; set; }
        public bool Active { get; set; }
        public DateTime LastUpdated { get; } = DateTime.UtcNow;
    }
}