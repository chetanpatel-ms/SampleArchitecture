using SampleArchitecture.Models;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The post repository.
    /// </summary>
    /// <seealso cref="IRepository{TKey, TModel}"/>
    public interface IPostRepository : IRepository<Guid, Post>
    {
        /// <summary>
        /// Gets the posts by the specified user identifier asynchronously.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns an <see cref="IEnumerable{T}" />
        /// collection of <see cref="Post" />.
        /// </returns>
        ValueTask<IEnumerable<Post>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    }
}