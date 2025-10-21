using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Notifications.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Notifications.Services;

public class NotificationsService(
    IUnitOfWork unitOfWork) : INotificationsService
{
    public async Task<Notification> FindOneAsync(
        FindOneNotificationsServiceParams @params)
    {
        return await unitOfWork
                   .NotificationsRepository
                   .FindOneAsync(@params) 
            ?? throw new NotFoundException(Errors.NOTIFICATION_NOT_FOUND);
    }

    public async Task<IEnumerable<Notification>> FindManyAsync(
        FindManyNotificationsServiceParams @params)
    {
        return await unitOfWork.NotificationsRepository.FindManyAsync(
            @params.FindManyParams,
            @params.OrderByParams,
            @params.PaginationParams);
    }

    public async Task UpdateAsync(UpdateNotificationsServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var notification = await FindOneAsync(@params);
        notification.Update(@params.Params);
        unitOfWork.NotificationsRepository.Update(notification);
        await unitOfWork.Commit(transaction);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationNotificationsServiceParams @params)
    {
        var (page, size) = @params;
        if (page == null || size == null) return null;
        var count = await unitOfWork
            .NotificationsRepository.CountAsync(@params.CountParams);
        var pagination = Pagination.Build(page, size, count);
        return pagination;
    }

    public async Task<int> CountUnreadAsync(Guid userId)
    {
        return await unitOfWork.NotificationsRepository.CountAsync(
            new FindManyNotificationsRepositoryParams
            { 
                IsRead = false, 
                UserId = userId 
            });
    }
}
