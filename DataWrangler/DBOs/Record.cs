using System;
using System.Collections.Generic;

namespace DataWrangler.DBOs
{
    public class Record
    {
        public bool Active { get; set; }

        public List<string> Attachments { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public int TypeId { get; set; }
    }
}