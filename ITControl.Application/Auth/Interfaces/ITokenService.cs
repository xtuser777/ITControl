using ITControl.Communication.Auth.Responses;

namespace ITControl.Application.Auth.Interfaces;

public interface ITokenService
{
    string GenerateToken(string key, string issuer, string audience, LoginPayload payload);
    string GenerateToken(string key, string issuer, string audience, PermissionsPayload payload);
}