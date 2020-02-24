namespace DataWrangler
{
    public class StatusObject
    {
        public enum OperationTypes
        {
            Create,
            Read,
            Update,
            Delete,
            FileAdd,
            FileRemove,
            System,
            Login
        }

        public bool Success { get; set; }
        public OperationTypes OperationType { get; set; }
        public object Result { get; set; }
    }
}