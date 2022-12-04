using System;
using MediatR;

namespace SecretsSharing.Usecases.Files.DeleteFile
{
    public record RemoveFileByIdCommand(Guid FileId) : IRequest
    {
    }
}