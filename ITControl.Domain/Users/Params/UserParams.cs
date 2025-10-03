using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Users.Params;

public class UserParams
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public int Enrollment { get; set; }
    public Guid PositionId { get; set; }
    public Guid RoleId { get; set; }
    public Guid UnitId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
    public ICollection<UserEquipment>? UsersEquipments { get; set; }
    public ICollection<UserSystem>? UsersSystems { get; set; }
}