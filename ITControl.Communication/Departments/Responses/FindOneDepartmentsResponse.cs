namespace ITControl.Communication.Departments.Responses;

public class FindOneDepartmentsResponse
{
    public string Id { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public FindOneDepartmentsUserResponse? User { get; set; }
}