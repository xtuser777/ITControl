using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Notifications.Responses;

public class FindOneNotificationsResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public TranslatableField Type { get; set; } = null!;
    public TranslatableField Reference { get; set; } = null!;
    public bool IsRead { get; set; }
    public Guid UserId { get; set; }
    public Guid? CallId { get; set; }
    public Guid? AppointmentId { get; set; }
    public Guid? TreatmentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ReadAt { get; set; }
}
