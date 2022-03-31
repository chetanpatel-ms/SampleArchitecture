namespace SampleArchitecture.Audit
{
    /// <summary>
    /// The audit logger.
    /// </summary>
    public interface IAuditLogger
    {
        /// <summary>
        /// Logs the specified <see cref="AuditRecord" />.
        /// </summary>
        /// <param name="record">The audit record.</param>
        void Log(AuditRecord record);
    }
}