using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using SecretsSharing.Domain.StorageDataEntities;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;

namespace SecretsSharing.Usecases.Files.UploadFile
{
    /// <summary>
    /// Upload file command handler.
    /// </summary>
    internal class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Guid>
    {
        private readonly IFileService fileService;
        private readonly IMapper mapper;
        private readonly IAppDbContext dbContext;
        private readonly ILoggedUserAccessor loggedUserAccessor;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public UploadFileCommandHandler(IFileService fileService, IMapper mapper,
            IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
        {
            this.fileService = fileService;
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.loggedUserAccessor = loggedUserAccessor;
        }

        /// <inheritdoc cref=""/>
        public async Task<Guid> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            if (loggedUserAccessor.GetCurrentUserId() != request.UserId)
            {
                throw new ForbiddenException("You have no rights to upload file.");
            }

            var fileToDb = mapper.Map<File>(request);
            var fileUrl = await fileService.UploadFile(request.File, request.UserId);
            fileToDb.Url = fileUrl;

            dbContext.Files.Add(fileToDb);
            await dbContext.SaveChangesAsync(cancellationToken);

            return fileToDb.Id;
        }
    }
}