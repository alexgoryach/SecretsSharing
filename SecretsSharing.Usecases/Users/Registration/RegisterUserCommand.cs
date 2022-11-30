using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SecretsSharing.Usecases.Users.Registration
{
    /// <summary>
    /// User registration command.
    /// </summary>
    public record RegisterUserCommand : IRequest<Guid>
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