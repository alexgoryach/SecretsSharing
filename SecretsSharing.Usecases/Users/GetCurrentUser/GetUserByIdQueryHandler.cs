using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Saritasa.Tools.EFCore;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;

namespace SecretsSharing.Usecases.Users.GetCurrentUser
{
    /// <summary>
    /// Get user by id query handler.
    /// </summary>
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GetUserByIdQueryHandler(IMapper mapper, IAppDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users.GetAsync(user => user.Id == request.UserId.ToString(), cancellationToken: cancellationToken);
            return mapper.Map<UserDto>(user);
        }
    }
}