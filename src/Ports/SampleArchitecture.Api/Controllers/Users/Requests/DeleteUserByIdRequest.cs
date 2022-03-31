namespace SampleArchitecture.Api.Controllers.Users.Requests
{
    /// <summary>
    /// The delete user by identifier request.
    /// </summary>
    internal sealed class DeleteUserByIdRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }
    }
}