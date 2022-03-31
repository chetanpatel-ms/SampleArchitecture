using SampleArchitecture.Api.Controllers.Users.Requests;
using SampleArchitecture.Commands;
using SampleArchitecture.Models;
using SampleArchitecture.Storage;

namespace SampleArchitecture.Api.Controllers.Users.CommandHandlers
{
    /// <summary>
    /// The get user by identifier request command handler.
    /// </summary>
    /// <seealso cref="ICommandHandler{TCommand, TResult}" />
    internal sealed class GetUserByIdRequestCommandHandler : ICommandHandler<GetUserByIdRequest, User>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="GetUserByIdRequestCommandHandler" />.
        /// </summary>
        /// <param name="userRepository">The <see cref="IUserRepository" />.</param>
        public GetUserByIdRequestCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async ValueTask<User> HandleAsync(GetUserByIdRequest command,
            CancellationToken cancellationToken)
        {
            return await _userRepository.GetAsync(command.Id, cancellationToken);
        }
    }
}