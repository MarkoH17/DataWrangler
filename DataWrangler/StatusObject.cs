using System;

namespace DataWrangler
{
    internal class StatusObject
    {
        public enum OperationTypes
        {
            Create,
            Read,
            Update,
            Delete,
            FileAdd,
            FileRemove,
            Maintenance
        }

        public bool Success { get; set; }
        public OperationTypes OperationType { get; set; }
        public object Result { get; set; }
    }
}