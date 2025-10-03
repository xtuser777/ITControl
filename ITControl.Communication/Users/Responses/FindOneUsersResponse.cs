namespace ITControl.Communication.Users.Responses;

public class FindOneUsersResponse
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
    public FindOneUsersPositionResponse? Position { get; set; }
    public FindOneUsersRoleResponse? Role { get; set; }
    public FindOneUsersUnitResponse? Unit { get; set; }
    public FindOneUsersDepartmentResponse? Department { get; set; }
    public FindOneUsersDivisionResponse? Division { get; set; }
    public IEnumerable<FindOneUsersEquipmentsResponse>? UsersEquipments { get; set; }
    public IEnumerable<FindOneUsersSystemsResponse>? UsersSystems { get; set; }
}