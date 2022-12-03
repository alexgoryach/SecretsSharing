using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using SecretsSharing.Domain.StorageDataEntities;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;

namespace SecretsSharing.Usecases.Messages.UploadMessage
{
    /// <summary>
    /// Create message command handler.
    /// </summary>
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext dbContext;
        private readonly ILoggedUserAccessor loggedUserAccessor;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CreateMessageCommandHandler(IMapper mapper, IAppDbContext dbContext,
            ILoggedUserAccessor loggedUserAccessor)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.loggedUserAccessor = loggedUserAccessor;
        }
        
        /// <inheritdoc />
        public async Task<Guid> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            if (loggedUserAccessor.GetCurrentUserId() != request.UserId)
            {
                throw new ForbiddenException("You have no rights to create user characteristic");
            }

            var message = mapper.Map<Message>(request);

            dbContext.Messages.Add(message);
            await dbContext.SaveChangesAsync(cancellationToken);

            return message.Id;
        }
    }
}