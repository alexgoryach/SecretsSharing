using System;

namespace SecretsSharing.Usecases.Common.Dtos.File
{
    /// <summary>
    /// File Dto.
    /// </summary>
    public class FileDto
    {
        /// <summary>
        /// File id.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// File url.
        /// </summary>
        public string Url { get; set; }
    }
}