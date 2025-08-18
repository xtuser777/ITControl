namespace ITControl.Communication.Auth.Responses;

public class PermissionsPayload
{
    public string Sub { get; set; } = string.Empty;
    public IEnumerable<string> Permissions { get; set; } = [];
}