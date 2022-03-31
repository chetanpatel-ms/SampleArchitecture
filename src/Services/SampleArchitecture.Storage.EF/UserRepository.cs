using Microsoft.EntityFrameworkCore;
using SampleArchitecture.Models;
using SampleArchitecture.Storage.Contexts;
using SampleArchitecture.Storage.Entities;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The user repository.
    /// </summary>
    /// <seealso cref="BaseRepository{TKey, TEntity, TModel}"/>
    /// <seealso cref="IUserRepository"/>
    internal sealed class UserRepository : BaseRepository<Guid, UserEntity, User>, IUserRepository
    {
        private readonly BlogContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="UserRepository" />.
        /// </summary>
        /// <param name="blogContext">The <see cref="BlogContext" />.</param>
        public UserRepository(BlogContext blogContext)
            : base(blogContext)
        {
            _context = blogContext;
        }

        /// <inheritdoc />
        public override async ValueTask<bool> DeleteAsync(Guid key, CancellationToken cancellationToken)
        {
            _context.Remove(_context.Users.SingleAsync(e => e.Id == key, cancellationToken));
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <inheritdoc />
        public override async ValueTask<User> GetAsync(Guid key, CancellationToken cancellationToken)
        {
            UserEntity entity = await _context.Users
                .SingleAsync(e => e.Id == key, cancellationToken);

            return ToModel(entity);
        }

        /// <inheritdoc />
        public async ValueTask<IEnumerable<User>> GetByFirstNameAsync(string firstName,
            CancellationToken cancellationToken) =>
            await _context.Users
                .Where(e => e.FirstName == firstName)
                .Select(e => ToModel(e))
                .ToListAsync(cancellationToken);

        /// <inheritdoc />
        protected override UserEntity ToEntity(User model) =>
            new()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Suffix = model.Suffix
            };

        /// <inheritdoc />
        protected override User ToModel(UserEntity entity) =>
            new()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                Suffix = entity.Suffix
            };
    }
}