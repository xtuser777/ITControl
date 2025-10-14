using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Shared.Utils;
using ITControl.Communication.Notifications.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;

namespace ITControl.Application.Notifications.Services;

public class NotificationsService(
    IUnitOfWork unitOfWork) : INotificationsService
{
    public async Task<Notification> FindOneAsync(
        Guid id,
        bool? includeUser = null,
        bool? includeCall = null,
        bool? includeAppointment = null,
        bool? includeTreatment = null)
    {
        return await unitOfWork.NotificationsRepository.FindOneAsync(
            id, includeUser, includeCall, includeAppointment, includeTreatment) 
            ?? throw new NotFoundException(Errors.NOTIFICATION_NOT_FOUND);
    }

    public async Task<IEnumerable<Notification>> FindManyAsync(FindManyNotificationsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.NotificationsRepository.FindManyAsync(
            request.Title,
            request.Message,
            Parser.ToEnumOptional<NotificationType>(request.Type),
            Parser.ToEnumOptional<NotificationReference>(request.Reference),
            request.IsRead,
            request.UserId,
            request.CreatedAt,
            request.OrderByTitle,
            request.OrderByMessage,
            request.OrderByType,
            request.OrderByReference,
            request.OrderByIsRead,
            request.OrderByUser,
            request.OrderByCreatedAt,
            page,
            size);
    }

    public async Task UpdateAsync(Guid id, UpdateNotificationsRequest request)
    {
        using var transaction = unitOfWork.BeginTransaction;
        var notification = await FindOneAsync(id);
        notification.Update(isRead: request.IsRead);
        unitOfWork.NotificationsRepository.Update(notification);
        await unitOfWork.Commit(transaction);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyNotificationsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.NotificationsRepository.CountAsync(
            request.Title,
            request.Message,
            Parser.ToEnumOptional<NotificationType>(request.Type),
            Parser.ToEnumOptional<NotificationReference>(request.Reference),
            request.IsRead,
            request.UserId,
            request.CreatedAt);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<int> CountUnreadAsync(Guid userId)
    {
        return await unitOfWork.NotificationsRepository.CountAsync(
            isRead: false,
            userId: userId);
    }
}
