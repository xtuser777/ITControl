using ITControl.Domain.Entities;
using ITControl.Domain.Enums;

namespace ITControl.Domain.Interfaces;

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
        string? orderByTitle = null,
        string? orderByMessage = null,
        string? orderByType = null,
        string? orderByReference = null,
        string? orderByIsRead = null,
        string? orderByUser = null,
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
        Guid? userId = null);
}
