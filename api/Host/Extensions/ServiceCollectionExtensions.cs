using Host.Components;
using Host.Interfaces;

namespace Host.Extensions
{
    /// <summary>
    /// Service collection related extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers services dependensies.
        /// </summary>
        public static IServiceCollection AddServices(
             this IServiceCollection services)
        {
            services.AddScoped<IEncoder, Base64Encoder>();
            services.AddScoped<IProcessingSimulator, ProcessingSimulator>();
            services.AddScoped<IEncodingProcessor, ChunkedEncodingProcessor>();

            return services;
        }
    }
}
