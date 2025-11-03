namespace ITControl.Presentation.Divisions.Responses;

public class FindOneDivisionsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public Guid? DepartmentId { get; set; }
    public FindOneDivisionsDepartmentResponse? Department { get; set; }
}