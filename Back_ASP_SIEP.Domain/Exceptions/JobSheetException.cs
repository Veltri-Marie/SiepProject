namespace Exceptions.Job
{
    public class JobSheetException : Exception
    {
        public readonly string ERROR_CODE = "002";
        public JobSheetException() {}
        public JobSheetException(string message) : base(message) {}
        public JobSheetException(string message, Exception innerException) : base(message, innerException) {}
    }
}