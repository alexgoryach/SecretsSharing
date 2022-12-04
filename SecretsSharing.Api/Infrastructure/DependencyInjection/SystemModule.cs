using Microsoft.Extensions.DependencyInjection;
using SecretsSharing.Api.Infrastructure.File;
using SecretsSharing.Api.Infrastructure.Jwt;
using SecretsSharing.Api.Infrastructure.LoggedUserAccessorServices;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;
using SecretsSharing.Infrastructure.DataAccess;

namespace SecretsSharing.Api.Infrastructure.DependencyInjection
{
    /// <summary>
    /// System dependencies module.
    /// </summary>
    internal static class SystemModule
    {
        /// <summary>
        /// System dependencies registration.
        /// </summary>
        /// <param name="services">Services to register collection.</param>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IAppDbContext, ApplicationDbContext>();
            services.AddScoped<IAuthenticationTokenService, JwtTokenService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ILoggedUserAccessor, LoggedUserAccessor>();
        }
    }
}