using SampleArchitecture.Api.Controllers.Users.Requests;
using SampleArchitecture.Commands;
using SampleArchitecture.Models;
using SampleArchitecture.Storage;

namespace SampleArchitecture.Api.Controllers.Users.CommandHandlers
{
    /// <summary>
    /// The search users by first name request command handler.
    /// </summary>
    /// <seealso cref="ICommandHandler{TCommand, TResult}" />
    internal sealed class SearchUsersByFirstNameRequestCommandHandler : ICommandHandler<SearchUsersByFirstNameRequest, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="SearchUsersByFirstNameRequestCommandHandler" />.
        /// </summary>
        /// <param name="userRepository">The <see cref="IUserRepository" />.</param>
        public SearchUsersByFirstNameRequestCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async ValueTask<IEnumerable<User>> HandleAsync(SearchUsersByFirstNameRequest command,
            CancellationToken cancellationToken)
        {
            return await _userRepository.GetByFirstNameAsync(command.FirstName, cancellationToken);
        }
    }
}