using Microsoft.Extensions.DependencyInjection;

namespace SampleArchitecture.Commands
{
    /// <summary>
    /// The command processor.
    /// </summary>
    /// <seealso cref="ICommandProcessor"/>
    public sealed class CommandProcessor : ICommandProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of <see cref="CommandProcessor" />.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider" />.</param>
        public CommandProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public async ValueTask<TResult> HandleAsync<TCommand, TResult>(TCommand command,
            CancellationToken cancellationToken) where TCommand : class
        {
            ICommandHandler<TCommand, TResult> handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            return await handler.HandleAsync(command, cancellationToken);
        }
    }
}