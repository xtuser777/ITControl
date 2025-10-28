namespace ITControl.Presentation.Roles.Responses;

public record FindOneRolesPagesResponse
{
    public Guid Id { get; set; }
    public Guid PageId { get; set; }
}