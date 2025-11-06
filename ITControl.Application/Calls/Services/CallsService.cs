using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Calls.Props;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Props;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Users.Params;
using CallStatus = ITControl.Domain.Calls.Entities.CallStatus;

namespace ITControl.Application.Calls.Services;
public class CallsService(
    IUnitOfWork unitOfWork) : ICallsService
{
    public async Task<Call> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
            .CallsRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
    }

    public async Task<IEnumerable<Call>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.CallsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.CallsRepository
            .CountAsync(parameters.CountProps);
        var pagination = Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Call?> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var user = await unitOfWork.UsersRepository.FindOneAsync(new()
        {
            Id = ((CallProps)parameters.Props).UserId ?? Guid.Empty,
        })
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(Messages.CALLS_OPENED, user.Name, DateTime.Now);
        var callStatus = new CallStatus(new ()
        {
            Status = Domain.Calls.Enums.CallStatus.Open,
            Description = message
        });
        await unitOfWork.CallsStatusesRepository.CreateAsync(callStatus);
        var call = new Call((CallProps)parameters.Props)
        {
            CallStatusId = callStatus.Id
        };
        await unitOfWork.CallsRepository.CreateAsync(call);
        await CreateNotification(call.Id ?? Guid.Empty, Titles.CALLS_NEW, message);
        await unitOfWork.Commit(transaction);

        return call;
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var call = await FindOneAsync(parameters);
        await RemoveNotifications(parameters.Id);
        unitOfWork.CallsStatusesRepository.Delete(call.CallStatus!);
        unitOfWork.CallsRepository.Delete(call);
        await unitOfWork.Commit(transaction);
    }

    private async Task CreateNotification(
        Guid referenceId, string title, string message)
    {
        var findManyRolesParams = new FindManyRolesParams { Name = "MASTER" };
        var rolesMaster = await unitOfWork.RolesRepository
            .FindManyAsync(new () { FindManyProps = findManyRolesParams});
        var roles = rolesMaster.ToList();
        if (roles.Count == 0)
            throw new NotFoundException(Errors.CALL_ROLE_MASTER_NOT_FOUND);
        var findManyParams = new FindManyUsersParams()
        {
            RoleId = roles.ToList()[0].Id
        };
        var users = await unitOfWork.UsersRepository
            .FindManyAsync(new () { FindManyProps = findManyParams});
        foreach (var user in users)
        {
            var notification = new Notification(
                new NotificationProps
                {
                    Title = title,
                    Message = message,
                    Type = NotificationType.Info,
                    Reference = NotificationReference.Call,
                    UserId = user.Id,
                    CallId = referenceId
                });
            await unitOfWork.NotificationsRepository
                .CreateAsync(notification);
        }
    }

    private async Task RemoveNotifications(Guid callId)
    {
        var findManyParams = new FindManyRepositoryParams 
        { 
            FindManyProps = 
            new NotificationProps { CallId = callId } 
        };
        var notifications = await unitOfWork
            .NotificationsRepository
            .FindManyAsync(findManyParams);
        if (notifications.Any())
        {
            unitOfWork.NotificationsRepository.DeleteMany(notifications);
        }
    }
}
