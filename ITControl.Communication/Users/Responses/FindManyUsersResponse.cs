namespace ITControl.Communication.Users.Responses;

public class FindManyUsersResponse
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Enrollment { get; set; }
    public bool Active { get; set; }
    public string PositionId { get; set; } = string.Empty;
    public string RoleId { get; set; } = string.Empty;  
}