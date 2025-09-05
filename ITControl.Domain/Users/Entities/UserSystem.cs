using ITControl.Domain.Entities;

namespace ITControl.Domain.Users.Entities;

public sealed class UserSystem : Entity
{
    public UserSystem(Guid userId, Guid systemId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        SystemId = systemId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid UserId { get; set; }
    public Guid SystemId { get; set; }
    public User? User { get; set; }
    public System? System { get; set; }

    public void Update(Guid? userId = null, Guid? systemId = null)
    {
        UserId = userId ?? UserId;
        SystemId = systemId ?? SystemId;
        UpdatedAt = DateTime.Now;
    }
}