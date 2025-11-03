namespace ITControl.Presentation.Divisions.Responses;

public class FindManyDivisionsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public Guid? DepartmentId { get; set; }
}