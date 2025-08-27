using ITControl.Domain.Enums;

namespace ITControl.Domain.Entities;

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

    public Notification(
        string title, 
        string message, 
        NotificationType type, 
        NotificationReference reference,
        Guid userId,
        Guid? callId,
        Guid? appointmentId,
        Guid? treatmentId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Title = title;
        Message = message;
        Type = type;
        Reference = reference;
        CallId = callId;
        AppointmentId = appointmentId;
        TreatmentId = treatmentId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void MarkAsRead()
    {
        IsRead = true;
        UpdatedAt = DateTime.Now;
    }
}
