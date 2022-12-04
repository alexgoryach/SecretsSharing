using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Saritasa.Tools.EFCore;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;
using SecretsSharing.Usecases.Common.Dtos.Message;

namespace SecretsSharing.Usecases.Messages.GetMessage
{
    /// <summary>
    /// Get message by id query handler.
    /// </summary>
    internal class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, MessageDto>
    {
        private readonly IMapper mapper;
        private readonly ILoggedUserAccessor loggedUserAccessor;
        private readonly IAppDbContext dbContext;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GetMessageByIdQueryHandler(IMapper mapper, IAppDbContext dbContext,
            ILoggedUserAccessor loggedUserAccessor)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.loggedUserAccessor = loggedUserAccessor;
        }

        /// <inheritdoc />
        public async Task<MessageDto> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await dbContext.Messages.GetAsync(message => message.Id == request.MessageId);
            
            if (loggedUserAccessor.IsAuthenticated() && loggedUserAccessor.GetCurrentUserId() == message.UserId &&
                message.AutoDelete)
            {
                dbContext.Messages.Remove(message);
                await dbContext.SaveChangesAsync(cancellationToken);
            }

            return mapper.Map<MessageDto>(message);
        }
    }
}