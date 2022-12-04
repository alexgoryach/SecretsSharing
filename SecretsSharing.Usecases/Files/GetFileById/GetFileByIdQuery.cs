using System;
using System.IO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecretsSharing.Usecases.Common.Dtos.File;

namespace SecretsSharing.Usecases.Files.GetFileById
{
    public record GetFileByIdQuery : IRequest<FileDto>
    {
        public Guid FileId { get; init; }
    }
}