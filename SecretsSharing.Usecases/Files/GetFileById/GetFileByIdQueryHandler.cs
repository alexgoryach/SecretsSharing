using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Saritasa.Tools.EFCore;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;
using SecretsSharing.Usecases.Common.Dtos.File;

namespace SecretsSharing.Usecases.Files.GetFileById
{
    /// <summary>
    /// Get file by id query handler.
    /// </summary>
    internal class GetFileByIdQueryHandler : IRequestHandler<GetFileByIdQuery, FileDto>
    {
        private readonly IAppDbContext dbContext;
        private readonly ILoggedUserAccessor loggedUserAccessor;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GetFileByIdQueryHandler(IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.loggedUserAccessor = loggedUserAccessor;
            this.mapper = mapper;
        }
        
        /// <inheritdoc />
        public async Task<FileDto> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
        {
            var file = await dbContext.Files.GetAsync(file => file.Id == request.FileId);
            
            if (loggedUserAccessor.IsAuthenticated() && loggedUserAccessor.GetCurrentUserId() == file.UserId &&
                file.AutoDelete)
            {
                dbContext.Files.Remove(file);
                await dbContext.SaveChangesAsync(cancellationToken);
                File.Delete(file.Url);
            }

            return mapper.Map<FileDto>(file);
        }
    }
}