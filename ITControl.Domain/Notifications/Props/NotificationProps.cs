using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Notifications.Props;

public class NotificationProps : Entity
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public NotificationType? Type { get; set; }
    public NotificationReference? Reference { get; set; }
    public bool? IsRead { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CallId { get; set; }
    public Guid? AppointmentId { get; set; }
    public Guid? TreatmentId { get; set; }
    public User? User { get; set; }
    public Call? Call { get; set; }
    public Appointment? Appointment { get; set; }
    public Treatment? Treatment { get; set; }
}