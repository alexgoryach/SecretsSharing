using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;
using SecretsSharing.Usecases.Common.Dtos.Message;

namespace SecretsSharing.Usecases.Messages.GetAllMessages
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, PagedListMetadataDto<MessageDto>>
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllMessagesQueryHandler(IAppDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        
        public async Task<PagedListMetadataDto<MessageDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var query = mapper
                .ProjectTo<MessageDto>(dbContext.Messages);
            var messages = await EFPagedListFactory
                .FromSourceAsync(query, request.page, request.pageSize, cancellationToken);

            return messages.ToMetadataObject();
        }
    }
}