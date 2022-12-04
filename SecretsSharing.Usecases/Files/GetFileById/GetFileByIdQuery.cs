using System;
using MediatR;
using SecretsSharing.Usecases.Common.Dtos.File;

namespace SecretsSharing.Usecases.Files.GetFileById
{
    /// <summary>
    /// Get file by id query.
    /// </summary>
    public record GetFileByIdQuery : IRequest<FileDto>
    {
        /// <summary>
        /// File id.
        /// </summary>
        public Guid FileId { get; init; }
    }
}