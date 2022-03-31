using DotNext.Threading;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;
using SampleArchitecture.Storage.Configuration;
using SampleArchitecture.Storage.Documents;
using System.Linq.Expressions;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The document repository.
    /// </summary>
    /// <typeparam name="TDocument">The type of document.</typeparam>
    /// <seealso cref="IDocumentRepository{TDocument}"/>
    internal sealed class DocumentRepository<TDocument> : IDocumentRepository<TDocument>
        where TDocument : BaseDocument
    {
        /// <inheritdoc />
        private readonly AsyncLazy<Container> _container;

        /// <summary>
        /// Initializes a new instance of <see cref="DocumentRepository{TDocument}" />
        /// </summary>
        /// <param name="options"></param>
        public DocumentRepository(IOptions<CosmosDBConfiguration> options)
        {
            var configuration = options.Value;

            _container = new AsyncLazy<Container>(async () =>
            {
                CosmosClient client = new CosmosClientBuilder(
                    configuration.ServiceEndpoint,
                    configuration.AuthorizationToken)
                .WithConsistencyLevel(ConsistencyLevel.Strong)
                .Build();

                Database database = await client.CreateDatabaseIfNotExistsAsync(configuration.DatabaseName);

                ContainerProperties properties = new(
                    typeof(TDocument).Name,
                    "/partitionKey");

                ContainerResponse containerResponse = await database.CreateContainerIfNotExistsAsync(
                    properties,
                    1000);

                return containerResponse.Container;
            });
        }

        /// <inheritdoc />
        public async ValueTask DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var container = await _container;

            await container.DeleteItemAsync<TDocument>(
                id.ToString(),
                new PartitionKey(id.ToString()),
                cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public async ValueTask<TDocument> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var container = await _container;

            ItemResponse<TDocument> response = await container.ReadItemAsync<TDocument>(
                id.ToString(),
                new PartitionKey(id.ToString()),
                cancellationToken: cancellationToken);

            return response.Resource;
        }

        /// <inheritdoc />
        public async ValueTask<IEnumerable<TDocument>> GetByFilterAsync(
            Expression<Func<TDocument, bool>> filter,
            CancellationToken cancellationToken)
        {
            List<TDocument> documents = new();

            var container = await _container;

            IQueryable<TDocument> query = container.GetItemLinqQueryable<TDocument>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            using FeedIterator<TDocument> iterator = query.ToFeedIterator();

            while (iterator.HasMoreResults)
            {
                foreach (var document in await iterator.ReadNextAsync(cancellationToken))
                {
                    documents.Add(document);
                }
            }

            return documents;
        }

        /// <inheritdoc />
        public async ValueTask<TDocument> UpsertAsync(TDocument document, CancellationToken cancellationToken)
        {
            var container = await _container;

            ItemResponse<TDocument> response = await container.UpsertItemAsync<TDocument>(
                document,
                null,
                requestOptions: new ItemRequestOptions
                {
                    IfMatchEtag = document.ETag
                },
                cancellationToken: cancellationToken);

            return response.Resource;
        }
    }
}