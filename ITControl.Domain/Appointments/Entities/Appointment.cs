using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Entities;
using ITControl.Domain.Locations.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Appointments.Entities;

public sealed class Appointment : Entity
{
    public string Description { get; set; } 
    public DateOnly ScheduledAt { get; set; }
    public TimeOnly ScheduledIn { get; set; }
    public string Observation { get; set; }
    public Guid UserId { get; set; }
    public Guid CallId { get; set; }
    public Guid LocationId { get; set; }
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