using System;

namespace SecretsSharing.Domain.StorageDataEntities
{
    /// <summary>
    /// Message entity.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Message id.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Message text.
        /// </summary>
        public string MessageText { get; set; }
        
        /// <summary>
        /// Automatic deletion of message after reading.
        /// </summary>
        public bool AutoDelete { get; set; }

        /// <summary>
        /// User id.
        /// </summary>
        public Guid UserId { get; set; }
    }
}