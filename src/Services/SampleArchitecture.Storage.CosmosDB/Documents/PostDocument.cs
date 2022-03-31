using Newtonsoft.Json;

namespace SampleArchitecture.Storage.Documents
{
    /// <summary>
    /// The post document.
    /// </summary>
    /// <seealso cref="BaseDocument"/>
    internal class PostDocument : BaseDocument
    {
        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTime")]
        public DateTimeOffset CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}