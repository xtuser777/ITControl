namespace ITControl.Communication.Auth.Responses;

public class PermissionsResponse
{
    public int ExpiresIn { get; set; }
    public string AccessToken { get; set; } = string.Empty;
}