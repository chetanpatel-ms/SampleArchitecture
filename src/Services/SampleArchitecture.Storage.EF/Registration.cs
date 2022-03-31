using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleArchitecture.Storage.Contexts;

namespace SampleArchitecture.Storage
{
    /// <summary>
    /// The registration.
    /// </summary>
    public static class Registration
    {
        /// <summary>
        /// Adds the entity framework storage.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="configuration">The <see cref="IConfiguration" />.</param>
        /// <returns>
        /// The <paramref name="services" /> with the storage added.
        /// </returns>
        public static IServiceCollection AddEFStorage(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BlogContextConnectionString")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}