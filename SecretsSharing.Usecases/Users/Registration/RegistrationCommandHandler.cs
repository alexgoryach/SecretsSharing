using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using SecretsSharing.Domain.Users;

namespace SecretsSharing.Usecases.Users.Registration
{
    /// <summary>
    /// Registration command handler.
    /// </summary>
    internal class RegistrationCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly UserManager<User> userManager;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userManager"></param>
        public RegistrationCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        /// <inheritdoc />
        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User()
            {
                Email = request.Email,
                UserName = request.Email
            };

            var result = await userManager.CreateAsync(newUser, request.Password);
            
            if (!result.Succeeded)
            {
                throw new DomainException("Error in login or password");
            }

            return Guid.Parse(newUser.Id);
        }
    }
}