using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Notifications.Props;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Notifications.Services;

public class NotificationsService(
    IUnitOfWork unitOfWork) : INotificationsService
{
    public async Task<Notification> FindOneAsync(
        FindOneServiceParams @params)
    {
        return await unitOfWork
                   .NotificationsRepository
                   .FindOneAsync(@params) 
            ?? throw new NotFoundException(Errors.NOTIFICATION_NOT_FOUND);
    }

    public async Task<IEnumerable<Notification>> FindManyAsync(
        FindManyServiceParams @params)
    {
        return await unitOfWork.NotificationsRepository
            .FindManyAsync(@params);
    }

    public async Task UpdateAsync(
        UpdateServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var notification = await FindOneAsync(@params);
        notification.Update((NotificationProps)@params.Props);
        unitOfWork.NotificationsRepository.Update(notification);
        await unitOfWork.Commit(transaction);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams @params)
    {
        var count = await unitOfWork
            .NotificationsRepository.CountAsync(@params.CountProps);
        var pagination = Pagination.Build(@params.PaginationParams, count);
        return pagination;
    }

    public async Task<int> CountUnreadAsync(Guid userId)
    {
        return await unitOfWork.NotificationsRepository.CountAsync(
            new FindManyNotificationsParams
            { 
                IsRead = false, 
                UserId = userId 
            });
    }
}
