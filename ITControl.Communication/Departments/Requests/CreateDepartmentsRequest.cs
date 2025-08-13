namespace ITControl.Communication.Departments.Requests;

public class CreateDepartmentsRequest
{
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}