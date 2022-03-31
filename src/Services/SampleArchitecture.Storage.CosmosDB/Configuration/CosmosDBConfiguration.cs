namespace SampleArchitecture.Storage.Configuration
{
    /// <summary>
    /// The cosmos DB configuration.
    /// </summary>
    internal class CosmosDBConfiguration
    {
        /// <summary>
        /// Gets or sets the authorizatio token.
        /// </summary>
        public string AuthorizationToken { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the service endpoint.
        /// </summary>
        public string ServiceEndpoint { get; set; }
    }
}