using System;
using System.Collections.Generic;

namespace DataWrangler.DBOs
{
    internal class Record
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public Dictionary<string, string> Attributes { get; set; }

        public List<string> Attachments { get; set; }

        public bool Active { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}