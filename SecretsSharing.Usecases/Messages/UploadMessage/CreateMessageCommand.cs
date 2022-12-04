using System;
using MediatR;

namespace SecretsSharing.Usecases.Messages.UploadMessage
{
    /// <summary>
    /// Create message command.
    /// </summary>
    public record CreateMessageCommand : IRequest<Guid>
    {
        /// <summary>
        /// Id of user who uploaded message.
        /// </summary>
        public Guid UserId { get; init; }
        
        /// <summary>
        /// Message text.
        /// </summary>
        public string MessageText { get; init; }
        
        /// <summary>
        /// Delete message after access option.
        /// </summary>
        public bool AutoDelete { get; init; }
    }
}