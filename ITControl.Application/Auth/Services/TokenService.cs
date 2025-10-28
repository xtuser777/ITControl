using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using ITControl.Application.Auth.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ITControl.Application.Auth.Services;

public class TokenService : ITokenService
{
    public string GenerateToken(
        string key, string issuer, string audience, LoginPayload payload)
    {
        var claims = new[]
        {
            new Claim("sub", payload.Sub),
            new Claim("user", payload.User),
            new Claim("role", payload.Role),
            new Claim("permissions", JsonSerializer.Serialize(payload.Permissions)),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(securityKey,
                                                SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer: issuer,
                                    audience: audience,
                                    claims: claims,
                                    expires: DateTime.Now.AddDays(7),
                                    signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }
}
