namespace ITControl.Presentation.Roles.Responses;

public record FindOneRolesPageResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? DisplayValue { get; set; } = string.Empty;
}