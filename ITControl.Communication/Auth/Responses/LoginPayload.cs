namespace ITControl.Communication.Auth.Responses;

public class LoginPayload
{
    public string Sub { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public IEnumerable<string> Permissions { get; set; } = [];
}