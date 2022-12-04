using System;
using System.ComponentModel.DataAnnotations.Schema;
using SecretsSharing.Domain.Users;

namespace SecretsSharing.Domain.StorageDataEntities
{
    public class File
    {
        public Guid Id { get; set; }
        
        public string Url { get; set; }
        
        public bool AutoDelete { get; set; }

        public Guid UserId { get; set; }
    }
}