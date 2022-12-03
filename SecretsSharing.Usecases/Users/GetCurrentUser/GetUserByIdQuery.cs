using System;
using MediatR;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;

namespace SecretsSharing.Usecases.Users.GetCurrentUser
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; set; }
    }
}