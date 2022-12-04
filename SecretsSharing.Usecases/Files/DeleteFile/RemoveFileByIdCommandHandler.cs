using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;

namespace SecretsSharing.Usecases.Files.DeleteFile
{
    /// <summary>
    /// Remove file by id command handler.
    /// </summary>
    internal class RemoveFileByIdCommandHandler : IRequestHandler<RemoveFileByIdCommand>
    {
        private readonly IAppDbContext dbContext;
        private readonly ILoggedUserAccessor loggedUserAccessor;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RemoveFileByIdCommandHandler(IAppDbContext dbContext,
            ILoggedUserAccessor loggedUserAccessor)
        {
            this.dbContext = dbContext;
            this.loggedUserAccessor = loggedUserAccessor;
        }
        
        /// <inheritdoc />>
        public async Task<Unit> Handle(RemoveFileByIdCommand request, CancellationToken cancellationToken)
        {
            var file = await dbContext.Files.GetAsync(file => file.Id == request.FileId);
            if (loggedUserAccessor.GetCurrentUserId() != file.UserId)
            {
                throw new ForbiddenException("You have no rights to delete this message");
            }
            dbContext.Files.Remove(file);
            await dbContext.SaveChangesAsync(cancellationToken);
            File.Delete(file.Url);
            
            return Unit.Value;
        }
    }
}