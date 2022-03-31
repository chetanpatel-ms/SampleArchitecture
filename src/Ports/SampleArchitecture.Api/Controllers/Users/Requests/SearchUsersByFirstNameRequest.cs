namespace SampleArchitecture.Api.Controllers.Users.Requests
{
    /// <summary>
    /// The search users by first name request.
    /// </summary>
    internal sealed class SearchUsersByFirstNameRequest
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }
    }
}