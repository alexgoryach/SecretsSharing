using System;
using MediatR;

namespace SecretsSharing.Usecases.Messages.UploadMessage
{
    /// <summary>
    /// Create message command.
    /// </summary>
    public record CreateMessageCommand : IRequest<Guid>
    {
        /// <inheritdoc cref="SecretsSharing.Domain.StorageDataEntities.Message.UserId"/>
        public Guid UserId { get; init; }
        
        /// <inheritdoc cref="SecretsSharing.Domain.StorageDataEntities.Message.MessageText"/>
        public string MessageText { get; init; }
        
        /// <inheritdoc cref="SecretsSharing.Domain.StorageDataEntities.Message.AutoDelete"/>
        public bool AutoDelete { get; init; }
    }
}