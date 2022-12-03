using System;

namespace SecretsSharing.Usecases.Common.Dtos.UserAuthentication
{
    /// <summary>
    /// User Dto.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// User id.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Username.
        /// </summary>
        public string Username { get; set; }
    }
}