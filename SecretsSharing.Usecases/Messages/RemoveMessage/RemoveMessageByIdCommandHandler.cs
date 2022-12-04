using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;

namespace SecretsSharing.Usecases.Messages.RemoveMessage
{
    /// <summary>
    /// Remove message by id command handler.
    /// </summary>
    internal class RemoveMessageByIdCommandHandler : IRequestHandler<RemoveMessageByIdCommand>
    {
        private readonly IAppDbContext dbContext;
        private readonly ILoggedUserAccessor loggedUserAccessor;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RemoveMessageByIdCommandHandler(IAppDbContext dbContext,
            ILoggedUserAccessor loggedUserAccessor)
        {
            this.dbContext = dbContext;
            this.loggedUserAccessor = loggedUserAccessor;
        }

        /// <inheritdoc />>
        public async Task<Unit> Handle(RemoveMessageByIdCommand request, CancellationToken cancellationToken)
        {
            var message = await dbContext.Messages.GetAsync(message => message.Id == request.messageId);

            if (loggedUserAccessor.GetCurrentUserId() != message.UserId)
            {
                throw new ForbiddenException("You have no rights to delete this message");
            }

            dbContext.Messages.Remove(message);
            await dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}