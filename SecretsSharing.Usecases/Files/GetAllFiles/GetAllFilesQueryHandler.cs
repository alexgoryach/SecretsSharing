using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;
using SecretsSharing.Usecases.Common.Dtos.File;

namespace SecretsSharing.Usecases.Files.GetAllFiles
{
    public class GetAllFilesQueryHandler : IRequestHandler<GetAllFilesQuery, PagedListMetadataDto<FileSummaryDto>>
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllFilesQueryHandler(IAppDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<PagedListMetadataDto<FileSummaryDto>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
        {
            var query = mapper
                .ProjectTo<FileSummaryDto>(dbContext.Files);
            var files = await EFPagedListFactory
                .FromSourceAsync(query, request.page, request.pageSize, cancellationToken);

            return files.ToMetadataObject();
        }
    }
}