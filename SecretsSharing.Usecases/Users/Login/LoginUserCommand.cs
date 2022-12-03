using System.ComponentModel.DataAnnotations;
using MediatR;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;

namespace SecretsSharing.Usecases.Users.Login
{
    /// <summary>
    /// Login user command.
    /// </summary>
    public record LoginUserCommand : IRequest<LoginUserCommandResult>
    {
        /// <summary>
        /// User email.
        /// </summary>
        [DataType(DataType.EmailAddress)]
        public string Email { get; init; }
        
        /// <summary>
        /// User password.
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; init; }
    }
}