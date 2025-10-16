using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Utils;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Users.Params;

namespace ITControl.Domain.Users.Entities;

public sealed class User : Entity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public bool Active { get; set; }
    public int Enrollment { get; set; }
    public Guid PositionId { get; set; }
    public Guid RoleId { get; set; }
    public Guid UnitId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
    public Position? Position { get; set; }
    public Role? Role { get; set; }
    public Unit? Unit { get; set; }
    public Department? Department { get; set; }
    public Division? Division { get; set; }
    public ICollection<UserEquipment>? UsersEquipments { get; set; }
    public ICollection<UserSystem>? UsersSystems { get; set; }

    public User() { }

    [Obsolete]
    public User(UserParams @params)
    {
        Id = Guid.NewGuid();
        Username = @params.Username;
        Password = Crypt.HashPassword(@params.Password);
        Email = @params.Email;
        Name = @params.Name;
        Document = @params.Document;
        Active = true; // Default to active
        Enrollment = @params.Enrollment;
        PositionId = @params.PositionId;
        RoleId = @params.RoleId;
        UnitId = @params.UnitId;
        DepartmentId = @params.DepartmentId;
        DivisionId = @params.DivisionId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        UsersSystems = @params.UsersSystems;
        UsersEquipments = @params.UsersEquipments;
    }

    [Obsolete]
    public void Update(UpdateUserParams @params)
    {
        Username = @params.Username ?? Username;
        Password = Crypt.HashPassword(@params.Password ?? Password);
        Email = @params.Email ?? Email;
        Name = @params.Name ?? Name;
        Document = @params.Document ?? Document;
        Active = @params.Active ?? Active;
        Enrollment = @params.Enrollment ?? Enrollment;
        PositionId = @params.PositionId ?? PositionId;
        RoleId = @params.RoleId ?? RoleId;
        UnitId = @params.UnitId ?? UnitId;
        DepartmentId = @params.DepartmentId ?? DepartmentId;
        DivisionId = @params.DivisionId ?? DivisionId;
        UsersSystems = @params.UsersSystems;
        UsersEquipments = @params.UsersEquipments;
        
        UpdatedAt = DateTime.Now;
    }
}