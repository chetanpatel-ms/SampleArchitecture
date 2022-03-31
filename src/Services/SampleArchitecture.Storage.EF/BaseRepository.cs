using Microsoft.EntityFrameworkCore;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="TKey">The type of key.</typeparam>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    /// <typeparam name="TModel">The type of model.</typeparam>
    internal abstract class BaseRepository<TKey, TEntity, TModel> : IRepository<TKey, TModel>
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="BaseRepository{TKey, TEntity, TModel}" />
        /// </summary>
        /// <param name="dbContext">The <see cref="DbContext" />.</param>
        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
        }

        /// <inheritdoc />
        public async ValueTask<TModel> AddAsync(TModel model, CancellationToken cancellationToken)
        {
            TEntity entity = ToEntity(model);

            _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return ToModel(entity);
        }

        /// <inheritdoc />
        public abstract ValueTask<bool> DeleteAsync(TKey key, CancellationToken cancellationToken);

        /// <inheritdoc />
        public abstract ValueTask<TModel> GetAsync(TKey key, CancellationToken cancellationToken);

        /// <inheritdoc />
        public async ValueTask<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken)
        {
            TEntity entity = ToEntity(model);

            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return ToModel(entity);
        }

        /// <summary>
        /// Converts the specified <typeparamref name="TModel" /> to a <see cref="TEntity" />.
        /// </summary>
        /// <param name="model">The <typeparamref name="TModel" />.</param>
        /// <returns>A <typeparamref name="TEntity" />.</returns>
        protected abstract TEntity ToEntity(TModel model);

        /// <summary>
        /// Converts the specified <typeparamref name="TEntity" /> to a <see cref="TModel" />.
        /// </summary>
        /// <param name="model">The <typeparamref name="TEntity" />.</param>
        /// <returns>A <typeparamref name="TModel" />.</returns>
        protected abstract TModel ToModel(TEntity entity);
    }
}