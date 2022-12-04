using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace SecretsSharing.Usecases.Files.UploadFile
{
    /// <summary>
    /// Upload file command.
    /// </summary>
    public record UploadFileCommand : IRequest<Guid>
    {
        /// <summary>
        /// File.
        /// </summary>
        public IFormFile File { get; init; }
        
        /// <summary>
        /// Id of user who uploaded file.
        /// </summary>
        public Guid UserId { get; init; }

        /// <summary>
        /// Delete file after access option.
        /// </summary>
        public bool AutoDelete { get; init; }
    }
}