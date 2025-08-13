namespace ITControl.Communication.Divisions.Requests;

public class CreateDivisionsRequest
{
    public string Name { get; set; } = string.Empty;
    public string DepartmentId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}