using System;

namespace DataWrangler.DBOs
{
    public class AuditEntry
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string Note { get; set; }
        public int ObjectId { get; set; }
        public string ObjectLookupCol { get; set; }
        public StatusObject.OperationTypes Operation { get; set; }
        public UserAccount User { get; set; }
    }
}