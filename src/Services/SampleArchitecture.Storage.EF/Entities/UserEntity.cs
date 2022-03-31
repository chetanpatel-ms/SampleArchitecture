namespace SampleArchitecture.Storage.Entities
{
    internal class UserEntity
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
        /// Gets or sets the posts.
        /// </summary>
        public virtual List<PostEntity> Posts { get; set; } = new();

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        public string Suffix { get; set; }
    }
}