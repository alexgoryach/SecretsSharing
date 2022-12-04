using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using SecretsSharing.Domain.Users;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;
using SecretsSharing.Usecases.Users.Services;

namespace SecretsSharing.Usecases.Users.RefreshUserJwt
{
    /// <summary>
    /// Refresh token command handler.
    /// </summary>
    internal class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenModel>
    {
        private readonly IAuthenticationTokenService tokenService;
        private readonly SignInManager<User> signInManager;
        private readonly IAppDbContext dbContext;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RefreshTokenCommandHandler(IAuthenticationTokenService tokenService,
            SignInManager<User> signInManager, IAppDbContext dbContext)
        {
            this.tokenService = tokenService;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }

        /// <inheritdoc />>
        public async Task<TokenModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // Get user.
            var userId = GetTokenUserId(request.Token);
            var user = await signInManager.UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new DomainException($"User with identifier {userId} not found.");
            }

            // Validate token.
            var tokenCreationDate = GetTokenCreationDate(request.Token);
            if (tokenCreationDate + AuthenticationConstants.RefreshTokenExpire <= DateTime.UtcNow ||
                tokenCreationDate < user.LastTokenResetAt)
            {
                throw new DomainException("Token has been expired.");
            }

            var principal = await signInManager.CreateUserPrincipalAsync(user);
            return TokenModelGenerator.Generate(tokenService, principal.Claims);
        }
        
        /// <summary>
        /// Get token creation date.
        /// </summary>
        /// <param name="token">Token.</param>
        /// <returns>Token creation date.</returns>
        private DateTime GetTokenCreationDate(string token)
        {
            var tokenClaims = GetTokenClaims(token);
            var iatClaim = tokenClaims.FirstOrDefault(c => c.Type == AuthenticationConstants.IatClaimType);
            if (iatClaim == null)
            {
                throw new DomainException("Iat claim cannot be found. Invalid token.");
            }
            return new DateTime(long.Parse(iatClaim.Value), DateTimeKind.Utc);
        }

        /// <summary>
        /// Get token user id.
        /// </summary>
        /// <param name="token">Token.</param>
        /// <returns>User id.</returns>
        private string GetTokenUserId(string token)
        {
            var tokenClaims = GetTokenClaims(token);
            var userIdClaim = tokenClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new DomainException(
                    "User identifier claim cannot be found. Invalid token.");
            }
            return userIdClaim.Value;
        }

        /// <summary>
        /// Get token claims.
        /// </summary>
        /// <param name="token">Token.</param>
        /// <returns>Token claims.</returns>
        private IEnumerable<Claim> GetTokenClaims(string token)
        {
            try
            {
                return tokenService.GetTokenClaims(token);
            }
            catch (Exception)
            {
                throw new DomainException("Invalid token.");
            }
        }
    }
}