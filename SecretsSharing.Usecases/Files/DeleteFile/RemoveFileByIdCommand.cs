using System;
using MediatR;

namespace SecretsSharing.Usecases.Files.DeleteFile
{
    /// <summary>
    /// Remove file by id command.
    /// </summary>
    /// <param name="FileId">File id.</param>
    public record RemoveFileByIdCommand(Guid FileId) : IRequest
    {
    }
}