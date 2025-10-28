namespace ITControl.Presentation.Auth.Responses;

public class LoginResponse
{
    public int ExpiresIn { get; set; }
    public string AccessToken { get; set; } = string.Empty;
}