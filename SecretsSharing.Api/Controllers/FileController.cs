using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecretsSharing.Domain.StorageDataEntities;
using SecretsSharing.Usecases.Files.GetFileById;
using SecretsSharing.Usecases.Files.UploadFile;
using System.IO;
using SecretsSharing.Usecases.Common.Dtos.File;
using File = System.IO.File;

namespace SecretsSharing.Api.Controllers
{
    [ApiController]
    [Route("api/file")]
    public class FileController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FileController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        /// <summary>
        /// Upload file.
        /// </summary>
        /// <param name="command">Create message command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [Authorize]
        public async Task<Guid> UploadFile([FromForm]UploadFileCommand command, CancellationToken cancellationToken)
        {
            return await mediator.Send(command, cancellationToken);
        }
        
        /// <summary>
        /// Get file by id.
        /// </summary>
        [HttpGet("{fileId}")]
        public async Task<FileDto> GetFileById(Guid fileId, CancellationToken cancellationToken)
        {
            var query = new GetFileByIdQuery()
            {
                FileId = fileId
            };
            return await mediator.Send(query, cancellationToken);
        }
        
        /// <summary>
        /// Remove file by id.
        /// </summary>
        /*[HttpDelete("{fileId}")]
        [Authorize]
        public async Task RemoveFileById(Guid fileId, CancellationToken cancellationToken) =>
            await mediator.Send(new RemoveFileByIdCommand(fileId), cancellationToken);*/
    }
}