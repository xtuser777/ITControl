using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Appointment : Entity
{
    private string _description = string.Empty;
    private DateOnly _scheduledAt;
    private TimeOnly _scheduledIn;
    private string _observation = string.Empty;
    private Guid _userId;
    private Guid _callId;
    private Guid _locationId;

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
    public DateOnly ScheduledAt
    {
        get => _scheduledAt;
        set
        {
            DomainExceptionValidation
                .When(value > DateOnly.FromDateTime(DateTime.Now))
                .Property("ScheduledAt")
                .DateMustNotBeGreaterThanCurrent();
            _scheduledAt = value;
        }
    }
    public TimeOnly ScheduledIn
    {
        get => _scheduledIn;
        set
        {
            DomainExceptionValidation
                .When(value > TimeOnly.FromDateTime(DateTime.Now))
                .Property("ScheduledIn")
                .TimeMustNotBeGreaterThanCurrent();
            _scheduledIn = value;
        }
    }
    public string Observation
    {
        get => _observation;
        set
        {
            DomainExceptionValidation
                .When(value.Length > 255)
                .Property("Observation")
                .LengthMustBeLessThanOrEqualTo(255);
            _observation = value;
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
    public Guid LocationId
    {
        get => _locationId;
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("LocationId")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value == default)
                .Property("LocationId")
                .MustNotBeNull();
            DomainExceptionValidation
                .When(!Guid.TryParse(value.ToString(), out _))
                .Property("LocationId")
                .MustBeAUuid();
            _locationId = value;
        }
    }

    public User? User { get; set; }
    public Call? Call { get; set; }
    public Location? Location { get; set; }

    public Appointment(
        string description,
        DateOnly scheduledAt,
        TimeOnly scheduledIn,
        string observation,
        Guid userId,
        Guid callId,
        Guid locationId)
    {
        Id = Guid.NewGuid();
        Description = description;
        ScheduledAt = scheduledAt;
        ScheduledIn = scheduledIn;
        Observation = observation;
        UserId = userId;
        CallId = callId;
        LocationId = locationId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(
        string? description = null,
        DateOnly? scheduledAt = null,
        TimeOnly? scheduledIn = null,
        string? observation = null,
        Guid? userId = null,
        Guid? callId = null,
        Guid? locationId = null)
    {
        Description = description ?? Description;
        ScheduledAt = scheduledAt ?? ScheduledAt;
        ScheduledIn = scheduledIn ?? ScheduledIn;
        Observation = observation ?? Observation;
        UserId = userId ?? UserId;
        CallId = callId ?? CallId;
        LocationId = locationId ?? LocationId;
        UpdatedAt = DateTime.Now;
    }
}