using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecretsSharing.Usecases.Common.Dtos.Message;
using SecretsSharing.Usecases.Messages.GetMessage;
using SecretsSharing.Usecases.Messages.RemoveMessage;
using SecretsSharing.Usecases.Messages.UploadMessage;

namespace SecretsSharing.Api.Controllers
{
    /// <summary>
    /// Message controller.
    /// </summary>
    [ApiController]
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MessageController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        /// <summary>
        /// Create message.
        /// </summary>
        /// <param name="command">Create message command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [Authorize]
        public async Task<Guid> CreateMessage(CreateMessageCommand command, CancellationToken cancellationToken)
        {
            return await mediator.Send(command, cancellationToken);
        }
        
        /// <summary>
        /// Get message by id.
        /// </summary>
        [HttpGet("{messageId}")]
        public async Task<MessageDto> GetMessageById(Guid messageId, CancellationToken cancellationToken)
        {
            var query = new GetMessageByIdQuery()
            {
                MessageId = messageId
            };
            return await mediator.Send(query, cancellationToken);
        }
        
        /// <summary>
        /// Remove message by id.
        /// </summary>
        [HttpDelete("{messageId}")]
        [Authorize]
        public async Task RemoveMessageById(Guid messageId, CancellationToken cancellationToken) =>
            await mediator.Send(new RemoveMessageByIdCommand(messageId), cancellationToken);
    }
}