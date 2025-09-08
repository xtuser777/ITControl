using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Validation;

namespace ITControl.Domain.Calls.Entities;

public sealed class CallStatus : Entity
{
    private Enums.CallStatus _status;
    private string _description = string.Empty;

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

    public CallStatus(
        Enums.CallStatus status, 
        string description)
    {
        Id = Guid.NewGuid();
        Status = status;
        Description = description;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(
        Enums.CallStatus? status = null, 
        string? description = null)
    {
        Status = status ?? Status;
        Description = description ?? Description;
        UpdatedAt = DateTime.Now;
    }
}
