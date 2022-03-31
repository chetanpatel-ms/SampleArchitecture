using Newtonsoft.Json;

namespace SampleArchitecture.Storage.Documents
{
    /// <summary>
    /// The base document.
    /// </summary>
    internal abstract class BaseDocument
    {
        /// <summary>
        /// Gets or sets the entity tag.
        /// </summary>
        [JsonProperty(PropertyName = "_etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}