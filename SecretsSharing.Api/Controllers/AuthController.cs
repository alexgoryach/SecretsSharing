using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecretsSharing.Api.Infrastructure.LoggedUserAccessorServices;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;
using SecretsSharing.Usecases.Users.GetCurrentUser;
using SecretsSharing.Usecases.Users.Login;
using SecretsSharing.Usecases.Users.RefreshUserJwt;

namespace SecretsSharing.Api.Controllers
{
    /// <summary>
    /// User authentication controller.
    /// </summary>
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="command">Login command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<TokenModel> AuthenticateUser(LoginUserCommand command, CancellationToken cancellationToken)
        {
            return (await mediator.Send(command, cancellationToken)).TokenModel;
        }
        
        /// <summary>
        /// Get current logged user info.
        /// </summary>
        /// <returns>Current logged user info.</returns>
        /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
        [HttpGet]
        [Authorize]
        public async Task<UserDto> GetMe(CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery
            {
                UserId = User.GetCurrentUserId()
            };
            return await mediator.Send(query, cancellationToken);
        }
        
        /// <summary>
        /// Get new token by refresh token.
        /// </summary>
        /// <param name="command">Refresh token command.</param>
        /// <returns>New authentication and refresh tokens.</returns>
        /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
        [HttpPut]
        public Task<TokenModel> RefreshToken(RefreshTokenCommand command, CancellationToken cancellationToken)
            => mediator.Send(command, cancellationToken);
    }
}