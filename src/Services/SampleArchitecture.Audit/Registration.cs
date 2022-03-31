using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleArchitecture.Audit
{
    /// <summary>
    /// The registration.
    /// </summary>
    public static class Registration
    {
        /// <summary>
        /// Adds the audit services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="configuration">The <see cref="IConfiguration" />.</param>
        /// <returns>The <paramref name="services" /> with the audit services.</returns>
        public static IServiceCollection AddAuditServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IAuditLogger, AuditLogger>();

            return services;
        }
    }
}