namespace ITControl.Communication.Roles.Responses;

public class FindManyRolesResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
}