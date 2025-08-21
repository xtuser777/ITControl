using ITControl.Domain.Enums;
using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Treatment : Entity
{
    private string _description = string.Empty;
    private DateOnly _startedAt;
    private DateOnly? _endedAt;
    private TimeOnly _startedIn;
    private TimeOnly? _endedIn;
    private TreatmentStatus _status;
    private TreatmentType _type;
    private string _observation = string.Empty;
    private string _externalProtocol = string.Empty;
    private Guid _callId;
    private Guid _userId;

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
                .When(value.Length > 100)
                .Property("Description")
                .LengthMustBeLessThanOrEqualTo(100);
            _description = value;
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
                .When(value < _startedAt)
                .Property("EndedAt")
                .DateMustNotBeLessThan(_startedAt);
            _endedAt = value;
        }
    }
    public TimeOnly StartedIn
    {
        get => _startedIn;
        set
        {
            DomainExceptionValidation
                .When(value > TimeOnly.FromDateTime(DateTime.Now))
                .Property("StartedIn")
                .TimeMustNotBeGreaterThanCurrent();
            _startedIn = value;
        }
    }
    public TimeOnly? EndedIn
    {
        get => _endedIn;
        set
        {
            DomainExceptionValidation
                .When(value < _startedIn)
                .Property("EndedIn")
                .TimeMustNotBeLessThan(_startedIn);
            _endedIn = value;
        }
    }
    public TreatmentStatus Status
    {
        get => _status;
        set
        {
            DomainExceptionValidation
                .When(!Enum.IsDefined(typeof(TreatmentStatus), value))
                .Property("Status")
                .MustBeAOneOfFollowingValues(typeof(TreatmentStatus).ToString());
            _status = value;
        }
    }
    public TreatmentType Type
    {
        get => _type;
        set
        {
            DomainExceptionValidation
                .When(!Enum.IsDefined(typeof(TreatmentType), value))
                .Property("Type")
                .MustBeAOneOfFollowingValues(typeof(TreatmentType).ToString());
            _type = value;
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
            DomainExceptionValidation
                .When(value == default)
                .Property("CallId")
                .MustNotBeNull();
            DomainExceptionValidation
                .When(!Guid.TryParse(value.ToString(), out _))
                .Property("CallId")
                .MustBeAUuid();
            _callId = value;
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
            DomainExceptionValidation
                .When(value == default)
                .Property("UserId")
                .MustNotBeNull();
            DomainExceptionValidation
                .When(!Guid.TryParse(value.ToString(), out _))
                .Property("UserId")
                .MustBeAUuid();
            _userId = value;
        }
    }

    public Call? Call { get; set; }
    public User? User { get; set; }

    public Treatment(
        string description,
        DateOnly startedAt, 
        DateOnly? endedAt, 
        TimeOnly startedIn, 
        TimeOnly? endedIn, 
        TreatmentStatus status,
        TreatmentType type,
        Guid callId, 
        Guid userId)
    {
        Description = description;
        StartedAt = startedAt;
        EndedAt = endedAt;
        StartedIn = startedIn;
        EndedIn = endedIn;
        Status = status;
        Type = type;
        CallId = callId;
        UserId = userId;
    }

    public void Update(
        string? description = null,
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null, 
        TimeOnly? startedIn = null, 
        TimeOnly? endedIn = null, 
        TreatmentStatus? status = null,
        TreatmentType? type = null,
        Guid? callId = null, 
        Guid? userId = null)
    {
        Description = description ?? Description;
        StartedAt = startedAt ?? StartedAt;
        EndedAt = endedAt ?? EndedAt;
        StartedIn = startedIn ?? StartedIn;
        EndedIn = endedIn ?? EndedIn;
        Status = status ?? Status;
        Type = type ?? Type;
        CallId = callId ?? CallId;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
    }
}