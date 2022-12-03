using System;
using MediatR;
using SecretsSharing.Usecases.Common.Dtos.Message;

namespace SecretsSharing.Usecases.Messages.GetMessage
{
    public record GetMessageByIdQuery : IRequest<MessageDto>
    {
        public Guid MessageId { get; init; }
    }
}