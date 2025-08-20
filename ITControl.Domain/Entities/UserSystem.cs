using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class UserSystem : Entity
{
    private Guid _userId;
    private Guid _systemId;

    public UserSystem(Guid userId, Guid systemId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        SystemId = systemId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid UserId
    {
        get => _userId;
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("UserId")
                .MustNotBeEmpty();
            _userId = value;
        }
    }
    public Guid SystemId
    {
        get => _systemId;
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("SystemId")
                .MustNotBeEmpty();
            _systemId = value;
        }
    }
    public User? User { get; set; }
    public System? System { get; set; }

    public void Update(Guid? userId = null, Guid? systemId = null)
    {
        UserId = userId ?? UserId;
        SystemId = systemId ?? SystemId;
        UpdatedAt = DateTime.Now;
    }
}