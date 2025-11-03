namespace ITControl.Presentation.Departments.Responses;

public record FindManyDepartmentsResponse
{
    public Guid? Id { get; set; }
    public string? Alias { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
}