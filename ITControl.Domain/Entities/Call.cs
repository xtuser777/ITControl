using ITControl.Domain.Enums;
using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Call : Entity
{
    private string _title = string.Empty;
    private string _description = string.Empty;
    private Guid _callStatusId;
    private Guid _userId;
    private Guid _locationId;
    private Guid? _systemId;
    private Guid? _equipmentId;

    public string Title
    {
        get => _title;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Title")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 64)
                .Property("Title")
                .LengthMustBeLessThanOrEqualTo(64);
            _title = value;
        }
    }
    public string Description
    {
        get => _description;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Description")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 255)
                .Property("Description")
                .LengthMustBeLessThanOrEqualTo(255);
            _description = value;
        }
    }
    public CallReason Reason { get; set; }
    public Guid CallStatusId
    {
        get => _callStatusId;
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("CallStatusId")
                .MustNotBeEmpty();
            _callStatusId = value;
        }
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
    public Guid LocationId
    {
        get => _locationId;
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("LocationId")
                .MustNotBeEmpty();
            _locationId = value;
        }
    }
    public Guid? SystemId
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
    public Guid? EquipmentId
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

    public CallStatus? CallStatus { get; set; }
    public User? User { get; set; }
    public Location? Location { get; set; }
    public System? System { get; set; }
    public Equipment? Equipment { get; set; }

    public Call(
        string title, 
        string description, 
        CallReason reason,
        Guid callStatusId,
        Guid userId, 
        Guid locationId, 
        Guid? systemId, 
        Guid? equipmentId)
    {
        
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Reason = reason;
        CallStatusId = callStatusId;
        UserId = userId;
        LocationId = locationId;
        SystemId = systemId;
        EquipmentId = equipmentId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}