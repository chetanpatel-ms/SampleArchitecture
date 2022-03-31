using SampleArchitecture.Models;
using SampleArchitecture.Storage.Documents;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The user repository.
    /// </summary>
    /// <seealso cref="BaseRepository{TModel, TDocument}"/>
    /// <seealso cref="IUserRepository"/>
    internal sealed class UserRepository : BaseRepository<User, UserDocument>, IUserRepository
    {
        private readonly IDocumentRepository<UserDocument> _repository;

        /// <summary>
        /// Initializes a new instance of <see cref="UserRepository" />.
        /// </summary>
        /// <param name="repository"></param>
        public UserRepository(IDocumentRepository<UserDocument> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public async ValueTask<User> AddAsync(User model,
            CancellationToken cancellationToken)
        {
            UserDocument document = ToDocument(model);
            UserDocument upsertedDocument = await _repository.UpsertAsync(document, cancellationToken);
            return ToModel(upsertedDocument);
        }

        /// <inheritdoc />
        public async ValueTask<bool> DeleteAsync(Guid key, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(key, cancellationToken);
            return true;
        }

        /// <inheritdoc />
        public async ValueTask<User> GetAsync(Guid key, CancellationToken cancellationToken)
        {
            UserDocument document = await _repository.GetAsync(key, cancellationToken);
            return ToModel(document);
        }

        /// <inheritdoc />
        public async ValueTask<IEnumerable<User>> GetByFirstNameAsync(string firstName,
            CancellationToken cancellationToken)
        {
            IEnumerable<UserDocument> results = await _repository.GetByFilterAsync(
                (x) => x.FirstName == firstName,
                cancellationToken);

            return results
                .Select(x => ToModel(x))
                .ToList();
        }

        /// <inheritdoc />
        public async ValueTask<User> UpdateAsync(User model, CancellationToken cancellationToken)
        {
            UserDocument document = ToDocument(model);
            UserDocument upsertedDocument = await _repository.UpsertAsync(document, cancellationToken);
            return ToModel(upsertedDocument);
        }

        /// <inheritdoc />
        protected override UserDocument ToDocument(User model) =>
            new()
            {
                FirstName = model.FirstName,
                Id = model.Id,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Suffix = model.Suffix
            };

        /// <inheritdoc />
        protected override User ToModel(UserDocument document) =>
            new()
            {
                FirstName = document.FirstName,
                Id = document.Id,
                LastName = document.LastName,
                MiddleName = document.MiddleName,
                Suffix = document.Suffix
            };
    }
}