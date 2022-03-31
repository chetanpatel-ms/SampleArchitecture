using FluentValidation;
using FluentValidation.Results;
using SampleArchitecture.Api.Exceptions;
using SampleArchitecture.Commands;

namespace SampleArchitecture.Api.Validation
{
    /// <summary>
    /// The validation command handler.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <seealso cref="ICommandHandler{TCommand, TResult}"/>
    internal sealed class ValidationCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : class
    {
        private readonly IValidator<TCommand> _validator;
        private readonly ICommandHandler<TCommand, TResult> _commandHandler;

        public ValidationCommandHandler(
            ICommandHandler<TCommand, TResult> commandHandler,
            IValidator<TCommand> validator)
        {
            _commandHandler = commandHandler;
            _validator = validator;
        }

        /// <inheritdoc />
        public async ValueTask<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken)
        {
            ValidationResult result = await _validator.ValidateAsync(command, cancellationToken);

            if (!result.IsValid)
            {
                throw new RequestValidationException(result.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage));
            }

            return await _commandHandler.HandleAsync(command, cancellationToken);
        }
    }
}
