using SampleArchitecture.Models;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The user repository.
    /// </summary>
    /// <seealso cref="IRepository{TKey, TModel}"/>
    public interface IUserRepository : IRepository<Guid, User>
    {
        /// <summary>
        /// Gets the users by the specified first name asynchronously.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns an <see cref="IEnumerable{T}" />
        /// collection of <see cref="User" />.
        /// </returns>
        ValueTask<IEnumerable<User>> GetByFirstNameAsync(string firstName, CancellationToken cancellationToken);
    }
}