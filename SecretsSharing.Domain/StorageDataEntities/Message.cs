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
        /// Delete message after reading option.
        /// </summary>
        public bool AutoDelete { get; set; }

        /// <summary>
        /// Id of user who uploaded message.
        /// </summary>
        public Guid UserId { get; set; }
    }
}