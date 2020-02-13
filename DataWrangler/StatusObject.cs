using System;

namespace DataWrangler
{
    internal class StatusObject
    {
        [Flags]
        public enum OperationTypes
        {
            Create = 0,
            Read = 1,
            Update = 2,
            Delete = 4
        }

        public bool Success { get; set; }
        public OperationTypes OperationType { get; set; }
        public object Result { get; set; }
    }
}