namespace ITControl.Presentation.Users.Responses;

public class FindOneUsersDepartmentResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Alias { get; set; } = string.Empty;
}
