namespace SampleArchitecture.Audit
{
    /// <summary>
    /// The audit record.
    /// </summary>
    public class AuditRecord
    {
        /// <summary>
        /// Gets or sets if successful.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the operation.
        /// </summary>
        public string Operation { get; set; }
    }
}