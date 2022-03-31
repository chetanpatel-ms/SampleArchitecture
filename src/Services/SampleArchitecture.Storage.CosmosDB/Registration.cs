using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleArchitecture.Storage.Configuration;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The registration.
    /// </summary>
    public static class Registration
    {
        /// <summary>
        /// Adds the cosmos DB storage.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="configuration">The <see cref="IConfiguration" />.</param>
        /// <returns>
        /// The <paramref name="services" /> with the storage added.
        /// </returns>
        public static IServiceCollection AddCosmosDBStorage(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions<CosmosDBConfiguration>(nameof(CosmosDBConfiguration));
            services.AddSingleton(typeof(IDocumentRepository<>), typeof(DocumentRepository<>));

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IPostRepository, PostRepository>();

            return services;
        }
    }
}