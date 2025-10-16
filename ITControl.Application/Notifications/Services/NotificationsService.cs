using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Notifications.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Notifications.Services;

public class NotificationsService(
    IUnitOfWork unitOfWork) : INotificationsService
{
    public async Task<Notification> FindOneAsync(FindOneNotificationsRequest request)
    {
        return await unitOfWork.NotificationsRepository.FindOneAsync(request) 
            ?? throw new NotFoundException(Errors.NOTIFICATION_NOT_FOUND);
    }

    public async Task<IEnumerable<Notification>> FindManyAsync(
        FindManyNotificationsRequest request,
        OrderByNotificationsRequest orderByNotificationsRequest)
    {
        return await unitOfWork.NotificationsRepository.FindManyAsync(
            request, orderByNotificationsRequest, request);
    }

    public async Task UpdateAsync(Guid id, UpdateNotificationsRequest request)
    {
        using var transaction = unitOfWork.BeginTransaction;
        var notification = await FindOneAsync(new () { Id = id });
        notification.Update(request);
        unitOfWork.NotificationsRepository.Update(notification);
        await unitOfWork.Commit(transaction);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyNotificationsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.NotificationsRepository.CountAsync(request);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<int> CountUnreadAsync(Guid userId)
    {
        return await unitOfWork.NotificationsRepository.CountAsync(new () 
            { 
                IsRead = false, 
                UserId = userId 
            });
    }
}
