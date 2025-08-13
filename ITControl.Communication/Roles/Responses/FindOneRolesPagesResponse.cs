namespace ITControl.Communication.Roles.Responses;

public class FindOneRolesPagesResponse
{
    public string Id { get; set; } = string.Empty;
    public string PageId { get; set; } = string.Empty;
    public FindOneRolesPagesPageResponse? Page { get; set; }
}