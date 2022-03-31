namespace SampleArchitecture.Api.Exceptions
{
    /// <summary>
    /// The request validation exception.
    /// </summary>
    internal class RequestValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RequestValidationException" />.
        /// </summary>
        public RequestValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="RequestValidationException" />.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public RequestValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="RequestValidationException"/>. 
        /// </summary>
        /// <param name="message">The error message that explains the reason for the
        /// exception.</param> <param name="innerException">The exception that is the cause of the
        /// current exception, or a null reference
        // (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RequestValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="RequestValidationException" />.
        /// </summary>
        /// <param name="validationErrors">The validation errors.</param>
        public RequestValidationException(IEnumerable<KeyValuePair<string, string>> validationErrors)
        {
            if (validationErrors == null)
            {
                return;
            }

            foreach (KeyValuePair<string, string> validationError in validationErrors)
            {
                Data.Add(validationError.Key, validationError.Value);
            }
        }
    }
}