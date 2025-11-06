using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Users.Props;

public class UserProps : Entity
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
    public bool? Active { get; set; }
    public int? Enrollment { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? RoleId { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
    public Position? Position { get; set; }
    public Role? Role { get; set; }
    public Unit? Unit { get; set; }
    public Department? Department { get; set; }
    public Division? Division { get; set; }
    public ICollection<UserEquipment>? UsersEquipments { get; set; }
    public ICollection<UserSystem>? UsersSystems { get; set; }    
}