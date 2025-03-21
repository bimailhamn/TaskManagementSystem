using System;

namespace TaskManagement.Domain.DomainExceptions
{
    /// <summary>
    /// Represents errors that occur due to invalid domain logic or validation failures.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Gets the error code associated with the validation exception.
        /// </summary>
        public string ErrorCode { get; set; } = string.Empty;


        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class with a specified error message and an error code.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errorCode">The error code associated with the validation exception.</param>
        public ValidationException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class with a specified error message and a reference to the inner exception that caused this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
