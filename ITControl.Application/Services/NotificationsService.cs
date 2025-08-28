using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Notifications.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Enums;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

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
            ?? throw new NotFoundException("Notification not found");
    }

    public async Task<IEnumerable<Notification>> FindManyAsync(FindManyNotificationsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.NotificationsRepository.FindManyAsync(
            request.Title,
            request.Message,
            null,
            null,
            request.IsRead,
            request.UserId,
            request.OrderByTitle,
            request.OrderByMessage,
            request.OrderByType,
            request.OrderByReference,
            request.OrderByIsRead,
            request.OrderByUser,
            page,
            size);
    }

    public async Task UpdateAsync(Guid id, UpdateNotificationsRequest request)
    {
        using var transaction = unitOfWork.BeginTransaction;
        var notification = await FindOneAsync(id);
        if (request.IsRead != null && request.IsRead == true)
        {
            notification.MarkAsRead();
        }
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
            request.UserId);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }
}
