﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;

namespace SecretsSharing.Usecases.Users.Services
{
    /// <summary>
    /// Token model generator.
    /// </summary>
    internal static class TokenModelGenerator
    {
        /// <summary>
        /// Common code to generate token and fill with claims.
        /// </summary>
        /// <param name="authenticationTokenService">Authentication token service.</param>
        /// <param name="claims">User claims.</param>
        /// <returns>Token model.</returns>
        public static TokenModel Generate(
            IAuthenticationTokenService authenticationTokenService,
            IEnumerable<Claim> claims)
        {
            var iatClaim = new Claim(AuthenticationConstants.IatClaimType, DateTime.UtcNow.Ticks.ToString(),
                ClaimValueTypes.Integer64);
            return new TokenModel
            {
                Token = authenticationTokenService.GenerateToken(
                    claims.Union(new[] { iatClaim }),
                    AuthenticationConstants.AccessTokenExpirationTime),
                ExpiresIn = (int)AuthenticationConstants.AccessTokenExpirationTime.TotalSeconds
            };
        }
    }
}