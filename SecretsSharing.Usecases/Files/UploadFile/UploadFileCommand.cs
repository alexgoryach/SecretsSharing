using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace SecretsSharing.Usecases.Files.UploadFile
{
    public record UploadFileCommand : IRequest<Guid>
    {
        public IFormFile File { get; init; }
        
        public Guid UserId { get; init; }

        public bool AutoDelete { get; init; }
    }
}