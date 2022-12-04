using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SecretsSharing.Infrastructure.Abstractions.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file, Guid userId);
    }
}