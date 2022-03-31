using SampleArchitecture.Storage.Documents;
using System.Linq.Expressions;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The document repository.
    /// </summary>
    /// <typeparam name="TDocument">The type of document.</typeparam>
    internal interface IDocumentRepository<TDocument>
        where TDocument : BaseDocument
    {
        /// <summary>
        /// Deletes the document by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="ValueTask" />.</returns>
        ValueTask DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the document by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns a <typeparamref name="TDocument" />.
        /// </returns>
        ValueTask<TDocument> GetAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the document by the specified filter asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns an <see cref="IEnumerable{T}" />
        /// collection of <typeparamref name="TDocument" />.
        /// </returns>
        ValueTask<IEnumerable<TDocument>> GetByFilterAsync(Expression<Func<TDocument, bool>> filter,
            CancellationToken cancellationToken);

        /// <summary>
        /// Inserts or updates the specified document asynchronously.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns the inserted or updated <typeparamref
        /// name="TDocument" />.
        /// </returns>
        ValueTask<TDocument> UpsertAsync(TDocument document, CancellationToken cancellationToken);
    }
}