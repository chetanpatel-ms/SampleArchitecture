namespace SampleArchitecture.Storage.Entities
{
    /// <summary>
    /// The post entity.
    /// </summary>
    internal class PostEntity
    {
        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        public DateTimeOffset CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public virtual UserEntity User { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }
    }
}