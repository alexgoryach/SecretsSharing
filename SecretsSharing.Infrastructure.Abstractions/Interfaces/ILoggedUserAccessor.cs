using System;

namespace SecretsSharing.Infrastructure.Abstractions.Interfaces
{
    /// <summary>
    /// Logged user accessor abstraction.
    /// </summary>
    public interface ILoggedUserAccessor
    {
        /// <summary>
        /// Get current user id.
        /// </summary>
        /// <returns>Current user identifier.</returns>
        Guid GetCurrentUserId();

        /// <summary>
        /// Return true if there is any user authenticated.
        /// </summary>
        /// <returns>Returns <c>true</c> if there is authenticated user.</returns>
        bool IsAuthenticated();
    }
}