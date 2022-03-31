namespace SampleArchitecture.Commands
{
    /// <summary>
    /// The command handler.
    /// </summary>
    /// <typeparam name="TCommand">The type of command.</typeparam>
    /// <typeparam name="TResult">The type of result.</typeparam>
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand : class
    {
        /// <summary>
        /// Handles the command asynchronously.
        /// </summary>
        /// <param name="command">The <typeparamref name="TCommand" />.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns a <typeparamref name="TResult" />.
        /// </returns>
        ValueTask<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}