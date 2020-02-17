using System;

namespace DataWrangler.DBOs
{
    internal class AuditEntry
    {
        public int Id { get; set; }
        public string ObjectLookupCol { get; set; }
        public int ObjectId { get; set; }
        public string Username { get; set; }
        public StatusObject.OperationTypes Operation { get; set; }

        public DateTime Date { get; set; }
    }
}