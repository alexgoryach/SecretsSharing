using System;

namespace SecretsSharing.Usecases.Common.Dtos.UserAuthentication
{
    /// <summary>
    /// Login User.
    /// </summary>
    public class LoginUserCommandResult
    {
        /// <summary>
        /// Logged user id.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// New refresh token.
        /// </summary>
        public TokenModel TokenModel { get; set; }
    }
}