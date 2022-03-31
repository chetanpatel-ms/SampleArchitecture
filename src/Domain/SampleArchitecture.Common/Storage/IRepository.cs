namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="TKey">The type of key.</typeparam>
    /// <typeparam name="TModel">The type of model.</typeparam>
    public interface IRepository<in TKey, TModel>
    {
        /// <summary>
        /// Adds the model asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns the added <paramref name="model" />.
        /// </returns>
        ValueTask<TModel> AddAsync(TModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the model by the specified key asynchronously.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="ValueTask{TResult}" /> that returns if the model was deleted.</returns>
        ValueTask<bool> DeleteAsync(TKey key, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the model by the specified key asynchronously.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns a <typeparamref name="TModel" />.
        /// </returns>
        ValueTask<TModel> GetAsync(TKey key, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the model asynchronously.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" />.</param>
        /// <returns>
        /// A <see cref="ValueTask{TResult}" /> that returns the updated <paramref name="model" />.
        /// </returns>
        ValueTask<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken);
    }
}