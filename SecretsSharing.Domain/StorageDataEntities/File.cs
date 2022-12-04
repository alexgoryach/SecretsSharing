using System;

namespace SecretsSharing.Domain.StorageDataEntities
{
    /// <summary>
    /// File entity.
    /// </summary>
    public class File
    {
        /// <summary>
        /// File id.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// File url.
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// Delete after access option.
        /// </summary>
        public bool AutoDelete { get; set; }

        /// <summary>
        /// Id of user who uploaded file.
        /// </summary>
        public Guid UserId { get; set; }
    }
}