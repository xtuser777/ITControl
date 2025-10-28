using ITControl.Domain.Shared.Params;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Users.Params;

public record UserParams : EntityParams
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Document { get; init; } = string.Empty;
    public int Enrollment { get; init; }
    public Guid PositionId { get; init; }
    public Guid RoleId { get; init; }
    public Guid UnitId { get; init; }
    public Guid DepartmentId { get; init; }
    public Guid? DivisionId { get; init; }
    public ICollection<UserEquipment>? UsersEquipments { get; set; }
    public ICollection<UserSystem>? UsersSystems { get; set; }
}