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
        /// User id.
        /// </summary>
        public Guid Id { get; private set; }
    }
}