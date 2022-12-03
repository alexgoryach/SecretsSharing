using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;

namespace SecretsSharing.Api.Infrastructure.Jwt
{
    /// <summary>
    /// Jwt token service.
    /// </summary>
    internal class JwtTokenService : IAuthenticationTokenService
    {
        private readonly TokenValidationParameters tokenValidationParameters;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="jwtOptionsMonitor">JWT options.</param>
        public JwtTokenService(IOptionsMonitor<JwtBearerOptions> jwtOptionsMonitor)
        {
            tokenValidationParameters = jwtOptionsMonitor.Get(JwtBearerDefaults.AuthenticationScheme)
                .TokenValidationParameters.Clone();
            // For this we don't need to validate lifetime because we don't use validation here at all.
            tokenValidationParameters.ValidateLifetime = false;
        }

        /// <inheritdoc />
        public string GenerateToken(IEnumerable<Claim> claims, TimeSpan expirationTime)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.Add(expirationTime),
                issuer: tokenValidationParameters.ValidIssuer,
                audience: tokenValidationParameters.ValidAudience,
                signingCredentials:
                new SigningCredentials(tokenValidationParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        /// <inheritdoc />
        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token, tokenValidationParameters, out SecurityToken _);
            return principal.Claims;
        }
    }
}