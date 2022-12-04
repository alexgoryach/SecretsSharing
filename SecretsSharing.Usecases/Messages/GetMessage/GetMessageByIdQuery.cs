using System;
using MediatR;
using SecretsSharing.Usecases.Common.Dtos.Message;

namespace SecretsSharing.Usecases.Messages.GetMessage
{
    /// <summary>
    /// Get message by id query.
    /// </summary>
    public record GetMessageByIdQuery : IRequest<MessageDto>
    {
        /// <summary>
        /// Message id.
        /// </summary>
        public Guid MessageId { get; init; }
    }
}