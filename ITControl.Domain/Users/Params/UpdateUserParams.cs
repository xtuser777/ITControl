using ITControl.Domain.Shared.Params;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Users.Params;

public record UpdateUserParams : UpdateEntityParams
{
    public string? Username { get; init; }
    public string? Password { get; init; }
    public string? Email { get; init; }
    public string? Name { get; init; }
    public string? Document { get; init; }
    public bool? Active { get; init; }
    public int? Enrollment { get; init; }
    public Guid? PositionId { get; init; }
    public Guid? RoleId { get; init; }
    public Guid? UnitId { get; init; }
    public Guid? DepartmentId { get; init; }
    public Guid? DivisionId { get; init; }
    public ICollection<UserEquipment>? UsersEquipments { get; set; }
    public ICollection<UserSystem>? UsersSystems { get; set; }
}
