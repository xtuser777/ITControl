using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Notifications.Entities;

public sealed class Notification : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public NotificationReference Reference { get; set; }
    public bool IsRead { get; set; } = false;
    public Guid UserId { get; set; }
    public Guid? CallId { get; set; }
    public Guid? AppointmentId { get; set; }
    public Guid? TreatmentId { get; set; }
    public User? User { get; set; }
    public Call? Call { get; set; }
    public Appointment? Appointment { get; set; }
    public Treatment? Treatment { get; set; }

    public Notification() { }

    public Notification(NotificationParams @params)
    {
        Id = Guid.NewGuid();
        UserId = @params.UserId;
        Title = @params.Title;
        Message = @params.Message;
        Type = @params.Type;
        Reference = @params.Reference;
        CallId = @params.CallId;
        AppointmentId = @params.AppointmentId;
        TreatmentId = @params.TreatmentId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void MarkAsRead()
    {
        IsRead = true;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdateNotificationParams @params)
    {
        Title = @params.Title ?? Title;
        Message = @params.Message ?? Message;
        Type = @params.Type ?? Type;
        Reference = @params.Reference ?? Reference;
        IsRead = @params.IsRead ?? IsRead;
        UserId = @params.UserId ?? UserId;
        CallId = @params.CallId ?? CallId;
        AppointmentId = @params.AppointmentId ?? AppointmentId;
        TreatmentId = @params.TreatmentId ?? TreatmentId;
        UpdatedAt = DateTime.Now;
    }
}
