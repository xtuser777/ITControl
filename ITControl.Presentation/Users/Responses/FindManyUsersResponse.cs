namespace ITControl.Presentation.Users.Responses;

public class FindManyUsersResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public int Enrollment { get; set; }
    public bool Active { get; set; }
    public Guid PositionId { get; set; }
    public Guid RoleId { get; set; }
    public Guid UnitId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
}