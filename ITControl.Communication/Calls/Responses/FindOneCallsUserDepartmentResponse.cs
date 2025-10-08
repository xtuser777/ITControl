namespace ITControl.Communication.Calls.Responses;

public class FindOneCallsUserDepartmentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
}
