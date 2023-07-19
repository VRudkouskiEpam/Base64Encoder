using WebViews.Models;

namespace WebViews.Extensions
{
    /// <summary>
    /// Extension methods for the services collection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Sets up application settings object based on app configuration.  
        /// </summary>
        /// <param name="services">An services collection instance this method extends.</param>
        /// <param name="config">An instance of the <see cref="IConfiguration"/> object.</param>
        /// <returns>
        /// An instance of extended services collection object.
        /// </returns>
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ApplicationSettings>(
                config.GetSection(ApplicationSettings.SectionName));

            return services;
        }
    }
}
