using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;
using SecretsSharing.Usecases.Users.Login;

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
    }
}