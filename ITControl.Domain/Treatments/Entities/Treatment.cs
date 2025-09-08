using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Treatments.Entities;

public sealed class Treatment : Entity
{
    public string Description { get; set; } = string.Empty;
    public string Protocol { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly StartedIn { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public TreatmentStatus Status { get; set; }
    public TreatmentType Type { get; set; }
    public string Observation { get; set; } = string.Empty;
    public string ExternalProtocol { get; set; } = string.Empty;
    public Guid CallId { get; set; }
    public Guid UserId { get; set; }

    public Call? Call { get; set; }
    public User? User { get; set; }

    public Treatment(
        string description,
        string protocol,
        DateOnly startedAt, 
        DateOnly? endedAt, 
        TimeOnly startedIn, 
        TimeOnly? endedIn, 
        TreatmentStatus status,
        TreatmentType type,
        string observation,
        string externalProtocol,
        Guid callId, 
        Guid userId)
    {
        Description = description;
        Protocol = protocol;
        StartedAt = startedAt;
        EndedAt = endedAt;
        StartedIn = startedIn;
        EndedIn = endedIn;
        Status = status;
        Type = type;
        Observation = observation;
        ExternalProtocol = externalProtocol;
        CallId = callId;
        UserId = userId;
    }

    public void Update(
        string? description = null,
        string? protocol = null,
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null, 
        TimeOnly? startedIn = null, 
        TimeOnly? endedIn = null, 
        TreatmentStatus? status = null,
        TreatmentType? type = null,
        string? observation = null,
        string? externalProtocol = null,
        Guid? callId = null, 
        Guid? userId = null)
    {
        Description = description ?? Description;
        Protocol = protocol ?? Protocol;
        StartedAt = startedAt ?? StartedAt;
        EndedAt = endedAt ?? EndedAt;
        StartedIn = startedIn ?? StartedIn;
        EndedIn = endedIn ?? EndedIn;
        Status = status ?? Status;
        Type = type ?? Type;
        Observation = observation ?? Observation;
        ExternalProtocol = externalProtocol ?? ExternalProtocol;
        CallId = callId ?? CallId;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
    }
}