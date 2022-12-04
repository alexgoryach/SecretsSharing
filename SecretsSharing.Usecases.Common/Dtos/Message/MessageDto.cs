using System;

namespace SecretsSharing.Usecases.Common.Dtos.Message
{
    public class MessageDto
    {
        public Guid Id { get; set; }

        public string MessageText { get; set; }
    }
}