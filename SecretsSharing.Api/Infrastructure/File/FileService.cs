using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;

namespace SecretsSharing.Api.Infrastructure.File
{
    internal class FileService : IFileService
    {
        private readonly IWebHostEnvironment environment;
        private const int EmptyFileSize = 0;

        public FileService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        
        public async Task<string> UploadFile(IFormFile file, Guid userId)
        {
            var uploadFilesPath = environment.ContentRootPath + "\\UploadFiles\\" + $"{userId}\\";

            if (file.Length != EmptyFileSize)
            {
                if (!Directory.Exists(uploadFilesPath))
                {
                    Directory.CreateDirectory(uploadFilesPath);
                }

                var fileUrl = uploadFilesPath + file.FileName;

                using (FileStream fileStream =
                       System.IO.File.Create(fileUrl))
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Flush();
                }
                return fileUrl;
            }
            return "Empty file";
        }
    }
}