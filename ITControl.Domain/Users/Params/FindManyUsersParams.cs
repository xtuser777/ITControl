using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Users.Params;

public record FindManyUsersParams : FindManyParams
{
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Document { get; set; }
    public int? Enrollment { get; set; }
    public bool? Active { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? RoleId { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
}