namespace Exceptions.Job
{
    /// <summary> Represents exceptions that occur during job sheet processing. </summary>
    public class JobSheetException : Exception
    {
        /// <summary> The error code associated with the job sheet exception. Defaults to "002". </summary>
        public readonly string ERROR_CODE = "002";

        /// <summary> Initializes a new instance of the <see cref="JobSheetException"/> class. </summary>
        public JobSheetException() { }

        /// <summary> Initializes a new instance of the <see cref="JobSheetException"/> class with a specified error message. </summary>
        public JobSheetException(string message) : base(message) { }

        /// <summary> Initializes a new instance of the <see cref="JobSheetException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception. </summary>
        public JobSheetException(string message, Exception innerException) : base(message, innerException) { }
    }
}
