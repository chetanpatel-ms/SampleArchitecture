using Microsoft.EntityFrameworkCore;
using SampleArchitecture.Models;
using SampleArchitecture.Storage.Contexts;
using SampleArchitecture.Storage.Entities;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The post repository.
    /// </summary>
    /// <seealso cref="BaseRepository{TKey, TEntity, TModel}"/>
    /// <seealso cref="IPostRepository"/>
    internal sealed class PostRepository : BaseRepository<Guid, PostEntity, Post>, IPostRepository
    {
        private readonly BlogContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="PostRepository" />.
        /// </summary>
        /// <param name="blogContext">The <see cref="BlogContext" />.</param>
        public PostRepository(BlogContext blogContext)
            : base(blogContext)
        {
            _context = blogContext;
        }

        /// <inheritdoc />
        public override async ValueTask<bool> DeleteAsync(Guid key, CancellationToken cancellationToken)
        {
            _context.Remove(_context.Posts.SingleAsync(e => e.Id == key, cancellationToken));
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <inheritdoc />
        public override async ValueTask<Post> GetAsync(Guid key, CancellationToken cancellationToken)
        {
            PostEntity entity = await _context.Posts
                .SingleAsync(e => e.Id == key, cancellationToken);

            return ToModel(entity);
        }

        /// <inheritdoc />
        public async ValueTask<IEnumerable<Post>> GetByUserIdAsync(Guid userId,
            CancellationToken cancellationToken) =>
            await _context.Posts
                .Where(e => e.UserId == userId)
                .Select(x => ToModel(x))
                .ToListAsync(cancellationToken);

        /// <inheritdoc />
        protected override PostEntity ToEntity(Post model) =>
            new()
            {
                CreatedDateTime = model.CreatedDateTime,
                Id = model.Id,
                UserId = model.UserId,
                Value = model.Value
            };

        /// <inheritdoc />
        protected override Post ToModel(PostEntity entity) =>
            new()
            {
                CreatedDateTime = entity.CreatedDateTime,
                Id = entity.Id,
                UserId = entity.UserId,
                Value = entity.Value
            };
    }
}