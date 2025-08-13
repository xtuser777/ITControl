namespace ITControl.Communication.Divisions.Responses;

public class FindOneDivisionsResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string DepartmentId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public FindOneDivisionsDepartmentResponse? Department { get; set; }
    public FindOneDivisionsUserResponse? User { get; set; }
}