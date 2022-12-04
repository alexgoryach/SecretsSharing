using MediatR;
using Saritasa.Tools.Common.Pagination;
using SecretsSharing.Usecases.Common.Dtos.File;

namespace SecretsSharing.Usecases.Files.GetAllFiles
{
    /// <summary>
    /// Get all files query.
    /// </summary>
    /// <param name="page">Pagination number of pages.</param>
    /// <param name="pageSize">Pagination page size.</param>
    public record GetAllFilesQuery(int page = 1, int pageSize = 20) : IRequest<PagedListMetadataDto<FileSummaryDto>>
    {
    }
}