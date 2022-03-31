using SampleArchitecture.Api.Controllers.Users.Requests;
using SampleArchitecture.Commands;
using SampleArchitecture.Storage;

namespace SampleArchitecture.Api.Controllers.Users.CommandHandlers
{
    /// <summary>
    /// The delete user by identifier request command handler.
    /// </summary>
    /// <seealso cref="ICommandHandler{TCommand, TResult}" />
    internal sealed class DeleteUserByIdRequestCommandHandler : ICommandHandler<DeleteUserByIdRequest, bool>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="DeleteUserByIdRequestCommandHandler" />.
        /// </summary>
        /// <param name="userRepository">The <see cref="IUserRepository" />.</param>
        public DeleteUserByIdRequestCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async ValueTask<bool> HandleAsync(DeleteUserByIdRequest command,
            CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteAsync(command.Id, cancellationToken);
        }
    }
}