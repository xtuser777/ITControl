using ITControl.Domain.Entities;
using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Roles.Entities;

namespace ITControl.Domain.Users.Entities;

public sealed class User : Entity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
    public int Enrollment { get; set; }
    public Guid PositionId { get; set; }
    public Guid RoleId { get; set; }
    public Position? Position { get; set; }
    public Role? Role { get; set; }
    public ICollection<UserEquipment>? UsersEquipments { get; set; }
    public ICollection<UserSystem>? UsersSystems { get; set; }

    public User(
        string username, 
        string password, 
        string email, 
        string name, 
        int enrollment,
        Guid positionId,
        Guid roleId
    )
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        Active = true; // Default to active
        Enrollment = enrollment;
        PositionId = positionId;
        RoleId = roleId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(
        string? username = null,
        string? password = null,
        string? email = null,
        string? name = null,
        bool? active = null,
        int? enrollment = null,
        Guid? positionId = null,
        Guid? roleId = null
    )
    {
        Username = username ?? Username;
        Password = password ?? Password;
        Email = email ?? Email;
        Name = name ?? Name;
        Active = active ?? Active;
        Enrollment = enrollment ?? Enrollment;
        PositionId = positionId ?? PositionId;
        RoleId = roleId ?? RoleId;
        
        UpdatedAt = DateTime.Now;
    }
}