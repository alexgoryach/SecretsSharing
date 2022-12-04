using MediatR;
using Saritasa.Tools.Common.Pagination;
using SecretsSharing.Usecases.Common.Dtos.Message;

namespace SecretsSharing.Usecases.Messages.GetAllMessages
{
    /// <summary>
    /// Get all messages query.
    /// </summary>
    /// <param name="page">Pagination pages number.</param>
    /// <param name="pageSize">Pagination page size.</param>
    public record GetAllMessagesQuery(int page = 1, int pageSize = 20): IRequest<PagedListMetadataDto<MessageDto>>
    {
    }
}