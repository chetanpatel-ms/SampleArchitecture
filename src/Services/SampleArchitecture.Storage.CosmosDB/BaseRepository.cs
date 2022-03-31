using SampleArchitecture.Storage.Documents;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="TModel">The type of model.</typeparam>
    /// <typeparam name="TDocument">The type of document.</typeparam>
    internal abstract class BaseRepository<TModel, TDocument>
        where TModel : class
        where TDocument : BaseDocument
    {
        /// <summary>
        /// Converts the specified <typeparamref name="TModel" /> to a <see cref="TDocument" />.
        /// </summary>
        /// <param name="model">The <typeparamref name="TModel" />.</param>
        /// <returns>A <typeparamref name="TDocument" />.</returns>
        protected abstract TDocument ToDocument(TModel model);

        /// <summary>
        /// Converts the specified <typeparamref name="TDocument" /> to a <see cref="TModel" />.
        /// </summary>
        /// <param name="model">The <typeparamref name="TDocument" />.</param>
        /// <returns>A <typeparamref name="TModel" />.</returns>
        protected abstract TModel ToModel(TDocument document);
    }
}