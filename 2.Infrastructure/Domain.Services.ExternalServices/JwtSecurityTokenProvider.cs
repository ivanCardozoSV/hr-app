﻿using Core;
using Domain.Services.ExternalServices.Config;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Services.ExternalServices
{
    public class JwtSecurityTokenProvider : ISecurityTokenProvider
    {

        JwtSettings _settings;
        public JwtSecurityTokenProvider(JwtSettings settings)
        {
            _settings = settings;
        }

        
        public string BuildSecurityToken(string userName, List<(string claimType, bool authValue)> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var jwtClaims = new List<Claim>();
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, userName));
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            jwtClaims.Add(new Claim("isAuthenticated", "true"));

            foreach ((string claimType, bool authValue) in claims)
            {
                jwtClaims.Add(new Claim(claimType, authValue.ToString()));
            }

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: jwtClaims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_settings.MinutesToExpiration),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
