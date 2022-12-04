using MediatR;
using Saritasa.Tools.Common.Pagination;
using SecretsSharing.Usecases.Common.Dtos.Message;

namespace SecretsSharing.Usecases.Messages.GetAllMessages
{
    public record GetAllMessagesQuery(int page = 1, int pageSize = 20): IRequest<PagedListMetadataDto<MessageDto>>
    {
    }
}