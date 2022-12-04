using System;

namespace SecretsSharing.Usecases.Common.Dtos.Message
{
    /// <summary>
    /// Message Dto.
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// Message id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Message text.
        /// </summary>
        public string MessageText { get; set; }
    }
}