using System;
using MediatR;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;

namespace SecretsSharing.Usecases.Users.GetCurrentUser
{
    /// <summary>
    /// Get user by id query.
    /// </summary>
    public record GetUserByIdQuery : IRequest<UserDto>
    {
        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; init; }
    }
}