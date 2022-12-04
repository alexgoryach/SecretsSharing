using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecretsSharing.Usecases.Files.GetFileById;
using SecretsSharing.Usecases.Files.UploadFile;
using Saritasa.Tools.Common.Pagination;
using SecretsSharing.Usecases.Common.Dtos.File;
using SecretsSharing.Usecases.Files.DeleteFile;
using SecretsSharing.Usecases.Files.GetAllFiles;

namespace SecretsSharing.Api.Controllers
{
    /// <summary>
    /// File controller.
    /// </summary>
    [ApiController]
    [Route("api/files")]
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
        /// <param name="command">Upload file command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Uploaded file url.</returns>
        [HttpPost]
        [Authorize]
        public async Task<Guid> UploadFile([FromForm]UploadFileCommand command, CancellationToken cancellationToken)
        {
            return await mediator.Send(command, cancellationToken);
        }
        
        /// <summary>
        /// Get file by id.
        /// </summary>
        /// <param name="fileId">File id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>File.</returns>
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
        /// <param name="fileId">File id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpDelete("{fileId}")]
        [Authorize]
        public async Task RemoveFileById(Guid fileId, CancellationToken cancellationToken) =>
            await mediator.Send(new RemoveFileByIdCommand(fileId), cancellationToken);
        
        /// <summary>
        /// Get all files.
        /// </summary>
        /// <param name="page">Pagination pages number.</param>
        /// <param name="pageSize">Pagination page size.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>List of files.</returns>
        [HttpGet]
        public async Task<PagedListMetadataDto<FileSummaryDto>> GetAllFiles(CancellationToken cancellationToken,
            int page = 1, int pageSize = 20)
        {
            var query = new GetAllFilesQuery(page, pageSize);
            return await mediator.Send(query, cancellationToken);
        }
    }
}