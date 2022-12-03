using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SecretsSharing.Usecases.Users.Registration;

namespace SecretsSharing.Api.Infrastructure.DependencyInjection
{
    /// <summary>
    /// MediatR module.
    /// </summary>
    internal static class MediatRModule
    {
        /// <summary>
        /// MediatR dependency registration.
        /// </summary>
        /// <param name="services">Services to register collection.</param>
        public static void Register(IServiceCollection services)
        {
            services.AddMediatR(typeof(RegisterUserCommand).Assembly);
        }
    }
}