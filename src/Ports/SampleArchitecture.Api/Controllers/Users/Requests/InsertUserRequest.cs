using SampleArchitecture.Models;

namespace SampleArchitecture.Api.Controllers.Users.Requests
{
    /// <summary>
    /// The insert user request.
    /// </summary>
    internal sealed class InsertUserRequest
    {
        /// <summary>
        /// Get or sets the user.
        /// </summary>
        public User User { get; set; }
    }
}