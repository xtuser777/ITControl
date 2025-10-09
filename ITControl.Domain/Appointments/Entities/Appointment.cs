using ITControl.Domain.Appointments.Params;
using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Appointments.Entities;

public sealed class Appointment : Entity
{
    public string Description { get; set; } = string.Empty;
    public DateOnly ScheduledAt { get; set; }
    public TimeOnly ScheduledIn { get; set; }
    public string Observation { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid CallId { get; set; }
    public User? User { get; set; }
    public Call? Call { get; set; }

    public Appointment() { }

    public Appointment(AppointmentsParams @params)
    {
        Id = Guid.NewGuid();
        Description = @params.Description;
        ScheduledAt = @params.ScheduledAt;
        ScheduledIn = @params.ScheduledIn;
        Observation = @params.Observation;
        UserId = @params.UserId;
        CallId = @params.CallId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdateAppointmentParams @params)
    {
        Description = @params.Description ?? Description;
        ScheduledAt = @params.ScheduledAt ?? ScheduledAt;
        ScheduledIn = @params.ScheduledIn ?? ScheduledIn;
        Observation = @params.Observation ?? Observation;
        UserId = @params.UserId ?? UserId;
        CallId = @params.CallId ?? CallId;
        UpdatedAt = DateTime.Now;
    }
}