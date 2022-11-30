using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecretsSharing.Usecases.Users.Registration;

namespace SecretsSharing.Api.Controllers
{
    /// <summary>
    /// User registration controller.
    /// </summary>
    [ApiController]
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private IMediator mediator;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public RegisterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// User registration.
        /// </summary>
        /// <param name="command">Register command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task RegisterUser(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
        }
    }
}