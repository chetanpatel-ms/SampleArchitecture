using Newtonsoft.Json;

namespace SampleArchitecture.Storage.Documents
{
    /// <summary>
    /// The user document.
    /// </summary>
    /// <seealso cref="BaseDocument"/>
    internal class UserDocument : BaseDocument
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        [JsonProperty(PropertyName = "middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        [JsonProperty(PropertyName = "suffix")]
        public string Suffix { get; set; }
    }
}