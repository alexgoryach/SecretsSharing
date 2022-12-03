using System;
using Microsoft.AspNetCore.Http;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;

namespace SecretsSharing.Api.Infrastructure.LoggedUserAccessorServices
{
    /// <summary>
    /// Logged user accessor.
    /// </summary>
    internal class LoggedUserAccessor : ILoggedUserAccessor
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Constructor.
        /// </summary>
        public LoggedUserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc />
        public Guid GetCurrentUserId()
        {
            if (httpContextAccessor.HttpContext == null)
            {
                throw new InvalidOperationException("There is no active HTTP context specified.");
            }

            return httpContextAccessor.HttpContext.User.GetCurrentUserId();
        }

        /// <inheritdoc />
        public bool IsAuthenticated()
        {
            if (httpContextAccessor.HttpContext == null)
            {
                return false;
            }
            return httpContextAccessor.HttpContext.User.TryGetCurrentUserId(out _);
        }
    }
}