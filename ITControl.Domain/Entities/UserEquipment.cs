using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class UserEquipment : Entity
{
    private Guid _userId;
    private Guid _equipmentId;
    private DateOnly _startedAt;
    private DateOnly? _endedAt;

    public UserEquipment(
        Guid userId, 
        Guid equipmentId, 
        DateOnly startedAt, 
        DateOnly? endedAt)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        EquipmentId = equipmentId;
        StartedAt = startedAt;
        EndedAt = endedAt;
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
    public Guid EquipmentId
    {
        get => _equipmentId;
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("EquipmentId")
                .MustNotBeEmpty();
            _equipmentId = value;
        }
    }
    public DateOnly StartedAt
    {
        get => _startedAt;
        set
        {
            DomainExceptionValidation
                .When(value > DateOnly.FromDateTime(DateTime.Now))
                .Property("StartedAt")
                .DateMustNotBeGreaterThanCurrent();
            _startedAt = value;
        }
    }
    public DateOnly? EndedAt
    {
        get => _endedAt;
        set
        {
            DomainExceptionValidation
                .When(value != null && value < _startedAt)
                .Property("EndedAt")
                .DateMustNotBeLessThan(_startedAt);
            _endedAt = value;
        }
    }

    public User? User { get; set; }
    public Equipment? Equipment { get; set; }

    public void Update(
        Guid? userId = null, 
        Guid? equipmentId = null, 
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null)
    {
        UserId = userId ?? UserId;
        EquipmentId = equipmentId ?? EquipmentId;
        StartedAt = startedAt ?? StartedAt;
        EndedAt = endedAt ?? EndedAt;
        UpdatedAt = DateTime.Now;
    }
}