namespace ITControl.Application.Auth.Interfaces;

public interface ITokenService
{
    string GenerateToken(string key, string issuer, string audience, LoginPayload payload);
}


public class LoginPayload
{
    public string Sub { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public IEnumerable<string> Permissions { get; set; } = [];
}