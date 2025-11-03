using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Systems.Entities;

namespace ITControl.Domain.Users.Entities;

public sealed class UserSystem : Entity
{
    public UserSystem(Guid? userId, Guid? systemId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        SystemId = systemId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid? UserId { get; set; }
    public Guid? SystemId { get; set; }
    public User? User { get; set; }
    public SystemEntity? System { get; set; }
}