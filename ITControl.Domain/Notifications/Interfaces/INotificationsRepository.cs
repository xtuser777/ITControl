using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;

namespace ITControl.Domain.Notifications.Interfaces;

public interface INotificationsRepository
{
    Task<Notification?> FindOneAsync(
        Guid id, 
        bool? includeUser = null,
        bool? includeCall = null,
        bool? includeAppointment = null,
        bool? includeTreatment = null);
    Task<IEnumerable<Notification>> FindManyAsync(
        string? title = null,
        string? message = null,
        NotificationType? type = null,
        NotificationReference? reference = null,
        bool? isRead = null,
        Guid? userId = null,
        DateTime? createdAt = null,
        string? orderByTitle = null,
        string? orderByMessage = null,
        string? orderByType = null,
        string? orderByReference = null,
        string? orderByIsRead = null,
        string? orderByUser = null,
        string? orderByCreatedAt = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Notification notification);
    void Update(Notification notification);
    Task<int> CountAsync(
        string? title = null,
        string? message = null,
        NotificationType? type = null,
        NotificationReference? reference = null,
        bool? isRead = null,
        Guid? userId = null,
        DateTime? createdAt = null);
}
