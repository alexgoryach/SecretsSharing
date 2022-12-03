using System;
using System.ComponentModel.DataAnnotations.Schema;
using SecretsSharing.Domain.Users;

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
        [ForeignKey("UserKey")]
        public Guid UserId { get; set; }
        
        /// <summary>
        /// User who upload message.
        /// </summary>
        public User User { get; set; }
    }
}