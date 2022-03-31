using SampleArchitecture.Api.Controllers.Users.Requests;
using SampleArchitecture.Audit;
using SampleArchitecture.Commands;

namespace SampleArchitecture.Api.Controllers.Users.CommandHandlers.Audit
{
    /// <summary>
    /// The audit delete user by identifier request command handler.
    /// </summary>
    /// <seealso cref="ICommandHandler{TCommand, TResult}" />
    internal sealed class AuditDeleteUserByIdRequestCommandHandler : ICommandHandler<DeleteUserByIdRequest, bool>
    {
        private readonly IAuditLogger _auditLogger;
        private readonly ICommandHandler<DeleteUserByIdRequest, bool> _commandHandler;

        /// <summary>
        /// Initializes a new instance of <see cref="AuditDeleteUserByIdRequestCommandHandler" />
        /// </summary>
        /// <param name="auditLogger">The <see cref="IAuditLogger" />.</param>
        public AuditDeleteUserByIdRequestCommandHandler(
            IAuditLogger auditLogger,
            ICommandHandler<DeleteUserByIdRequest, bool> commandHandler)
        {
            _auditLogger = auditLogger;
            _commandHandler = commandHandler;
        }

        /// <inheritdoc />
        public async ValueTask<bool> HandleAsync(DeleteUserByIdRequest command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _commandHandler.HandleAsync(command, cancellationToken);

                _auditLogger.Log(new AuditRecord
                {
                    IsSuccessful = true,
                    Operation = "DeleteUserById"
                });

                return result;
            }
            catch
            {
                _auditLogger.Log(new AuditRecord
                {
                    Operation = "DeleteUserById"
                });

                throw;
            }
        }
    }
}