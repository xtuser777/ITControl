using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class CallStatus : Entity
{
    private Enums.CallStatus _status;
    private string _description = string.Empty;
    private Guid _callId;

    public Enums.CallStatus Status 
    { 
        get => _status; 
        set
        {
            DomainExceptionValidation
                .When(!Enum.IsDefined(typeof(Enums.CallStatus), value))
                .Property("Status")
                .MustBeAOneOfFollowingValues(typeof(Enums.CallStatus).ToString());
            _status = value;
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
    public Guid CallId
    {
        get => _callId;
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("CallId")
                .MustNotBeEmpty();
            _callId = value;
        }
    }
    public Call? Call { get; set; }

    public CallStatus(
        Enums.CallStatus status, 
        string description, 
        Guid callId)
    {
        Id = Guid.NewGuid();
        Status = status;
        Description = description;
        CallId = callId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(
        Enums.CallStatus? status = null, 
        string? description = null, 
        Guid? callId = null)
    {
        Status = status ?? Status;
        Description = description ?? Description;
        CallId = callId ?? CallId;
        UpdatedAt = DateTime.Now;
    }
}
