namespace SampleArchitecture.Api.Controllers.Users.Requests
{
    /// <summary>
    /// The get user by identifier request.
    /// </summary>
    internal sealed class GetUserByIdRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }
    }
}