using SampleArchitecture.Api.Controllers.Users.Requests;
using SampleArchitecture.Commands;
using SampleArchitecture.Models;
using SampleArchitecture.Storage;

namespace SampleArchitecture.Api.Controllers.Users.CommandHandlers
{
    /// <summary>
    /// The update user request command handler.
    /// </summary>
    /// <seealso cref="ICommandHandler{TCommand, TResult}" />
    internal sealed class UpdateUserRequestCommandHandler : ICommandHandler<UpdateUserRequest, User>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="UpdateUserRequestCommandHandler" />.
        /// </summary>
        /// <param name="userRepository">The <see cref="IUserRepository" />.</param>
        public UpdateUserRequestCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async ValueTask<User> HandleAsync(UpdateUserRequest command,
            CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateAsync(command.User, cancellationToken);
        }
    }
}