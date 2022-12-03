using System;
using Microsoft.AspNetCore.Identity;

namespace SecretsSharing.Domain.Users
{
    /// <summary>
    /// Identity user entity.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// The date when user last logged in.
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Last token reset date. Before the date all generate login tokens are considered
        /// not valid. Must be in UTC format.
        /// </summary>
        public DateTime LastTokenResetAt { get; set; } = DateTime.UtcNow;
    }
}