namespace SampleArchitecture.Models
{
    /// <summary>
    /// The user.
    /// </summary>
    /// <seealso cref="IModel{TKey}"/>
    public class User : IModel<Guid>
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        public string Suffix { get; set; }
    }
}