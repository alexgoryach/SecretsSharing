using System;
using MediatR;

namespace SecretsSharing.Usecases.Messages.RemoveMessage
{
    /// <summary>
    /// Remove message by id command.
    /// </summary>
    /// <param name="messageId">Message id.</param>
    public record RemoveMessageByIdCommand (Guid messageId) : IRequest
    {
    }
}