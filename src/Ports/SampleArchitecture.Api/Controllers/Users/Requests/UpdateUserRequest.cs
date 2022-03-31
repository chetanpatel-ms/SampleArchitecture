using SampleArchitecture.Models;

namespace SampleArchitecture.Api.Controllers.Users.Requests
{
    /// <summary>
    /// The update user request.
    /// </summary>
    internal sealed class UpdateUserRequest
    {
        /// <summary>
        /// Get or sets the user.
        /// </summary>
        public User User { get; set; }
    }
}