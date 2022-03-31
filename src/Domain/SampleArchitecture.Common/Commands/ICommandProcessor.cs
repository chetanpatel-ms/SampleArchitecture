namespace SampleArchitecture.Commands
{
    /// <summary>
    /// The command processor.
    /// </summary>
    public interface ICommandProcessor
    {
        /// <summary>
        /// Handles the command asynchronously.
        /// </summary>
        /// <typeparam name="TCommand">The type of command.</typeparam>
        /// <typeparam name="TResult">The type of result.</typeparam>
        /// <param name="command">The <typeparamref name="TCommand" />.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns a <typeparamref name="TResult" />.
        /// </returns>
        ValueTask<TResult> HandleAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken)
            where TCommand : class;
    }
}