using System;
using MediatR;

namespace SecretsSharing.Usecases.Messages.RemoveMessage
{
    public record RemoveMessageByIdCommand (Guid messageId) : IRequest
    {
    }
}