namespace SampleArchitecture.Models
{
    /// <summary>
    /// The post.
    /// </summary>
    /// <seealso cref="IModel{TKey}"/>
    public class Post : IModel<Guid>
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
        /// Gets or sets the user identifier.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }
    }
}