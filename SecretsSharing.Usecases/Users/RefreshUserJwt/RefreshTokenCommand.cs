using System.ComponentModel.DataAnnotations;
using MediatR;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;

namespace SecretsSharing.Usecases.Users.RefreshUserJwt
{
    /// <summary>
    /// Refresh token command.
    /// </summary>
    public record RefreshTokenCommand : IRequest<TokenModel>
    {
        /// <summary>
        /// User token.
        /// </summary>
        [Required]
        public string Token { get; init; }
    }
}