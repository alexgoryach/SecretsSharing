using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SecretsSharing.Infrastructure.Abstractions.Interfaces
{
    /// <summary>
    /// File service.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Upload file.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="userId">User who uploaded file.</param>
        /// <returns>File url.</returns>
        Task<string> UploadFile(IFormFile file, Guid userId);
    }
}