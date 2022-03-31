using SampleArchitecture.Api.Controllers.Users.Requests;
using SampleArchitecture.Commands;
using SampleArchitecture.Models;
using SampleArchitecture.Storage;

namespace SampleArchitecture.Api.Controllers.Users.CommandHandlers
{
    /// <summary>
    /// The insert user request command handler.
    /// </summary>
    /// <seealso cref="ICommandHandler{TCommand, TResult}" />
    internal sealed class InsertUserRequestCommandHandler : ICommandHandler<InsertUserRequest, User>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="InsertUserRequestCommandHandler" />.
        /// </summary>
        /// <param name="userRepository">The <see cref="IUserRepository" />.</param>
        public InsertUserRequestCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async ValueTask<User> HandleAsync(InsertUserRequest command,
            CancellationToken cancellationToken)
        {
            return await _userRepository.AddAsync(command.User, cancellationToken);
        }
    }
}