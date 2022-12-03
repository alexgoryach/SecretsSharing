using Microsoft.Extensions.DependencyInjection;
using SecretsSharing.Usecases.Users;

namespace SecretsSharing.Api.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Auto mapper module.
    /// </summary>
    internal static class AutoMapperModule
    {
        /// <summary>
        /// Register auto mapper dependency model.
        /// </summary>
        /// <param name="services">Services collection.</param>
        public static void Register(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(UsersMappingProfile).Assembly);
        }
    }
}