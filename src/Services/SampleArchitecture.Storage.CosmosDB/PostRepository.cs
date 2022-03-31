using SampleArchitecture.Models;
using SampleArchitecture.Storage.Documents;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The post repository.
    /// </summary>
    /// <seealso cref="BaseRepository{TModel, TDocument}"/>
    /// <seealso cref="IPostRepository"/>
    internal sealed class PostRepository : BaseRepository<Post, PostDocument>, IPostRepository
    {
        private readonly IDocumentRepository<PostDocument> _repository;

        /// <summary>
        /// Initializes a new instance of <see cref="PostRepository" />.
        /// </summary>
        /// <param name="repository"></param>
        public PostRepository(IDocumentRepository<PostDocument> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public async ValueTask<Post> AddAsync(Post model, CancellationToken cancellationToken)
        {
            PostDocument document = ToDocument(model);
            PostDocument upsertedDocument = await _repository.UpsertAsync(document, cancellationToken);
            return ToModel(upsertedDocument);
        }

        /// <inheritdoc />
        public async ValueTask<bool> DeleteAsync(Guid key, CancellationToken cancellationToken)
        { 
            await _repository.DeleteAsync(key, cancellationToken);
            return true;
        }

        /// <inheritdoc />
        public async ValueTask<Post> GetAsync(Guid key, CancellationToken cancellationToken)
        {
            PostDocument document = await _repository.GetAsync(key, cancellationToken);
            return ToModel(document);
        }

        /// <inheritdoc />
        public async ValueTask<IEnumerable<Post>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            IEnumerable<PostDocument> results = await _repository.GetByFilterAsync(
                (x) => x.UserId == userId,
                cancellationToken);

            return results
                .Select(x => ToModel(x))
                .ToList();
        }

        /// <inheritdoc />
        public async ValueTask<Post> UpdateAsync(Post model, CancellationToken cancellationToken)
        {
            PostDocument document = ToDocument(model);
            PostDocument upsertedDocument = await _repository.UpsertAsync(document, cancellationToken);
            return ToModel(upsertedDocument);
        }

        /// <inheritdoc />
        protected override PostDocument ToDocument(Post model) =>
            new()
            {
                CreatedDateTime = model.CreatedDateTime,
                Id = model.Id,
                UserId = model.UserId,
                Value = model.Value
            };

        /// <inheritdoc />
        protected override Post ToModel(PostDocument document) =>
            new()
            {
                CreatedDateTime = document.CreatedDateTime,
                Id = document.Id,
                UserId = document.UserId,
                Value = document.Value
            };
    }
}