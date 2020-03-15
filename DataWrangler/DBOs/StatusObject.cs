namespace DataWrangler.DBOs
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
            LoginSuccess,
            LoginFailure
        }

        public OperationTypes OperationType { get; set; }
        public object Result { get; set; }

        public bool Success { get; set; }
    }
}