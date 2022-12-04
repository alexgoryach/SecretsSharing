using MediatR;
using Saritasa.Tools.Common.Pagination;
using SecretsSharing.Usecases.Common.Dtos.File;

namespace SecretsSharing.Usecases.Files.GetAllFiles
{
    public record GetAllFilesQuery(int page = 1, int pageSize = 20) : IRequest<PagedListMetadataDto<FileDto>>
    {
    }
}