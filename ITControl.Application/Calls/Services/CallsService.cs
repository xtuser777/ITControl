using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Calls.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Users.Params;
using CallStatus = ITControl.Domain.Calls.Entities.CallStatus;

namespace ITControl.Application.Calls.Services;
public class CallsService(
    IUnitOfWork unitOfWork) : ICallsService
{
    public async Task<Call> FindOneAsync(FindOneCallsServiceParams @params)
    {
        return await unitOfWork
            .CallsRepository
            .FindOneAsync(@params)
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
    }

    public async Task<IEnumerable<Call>> FindManyAsync(FindManyCallsServiceParams @params)
    {
        return await unitOfWork.CallsRepository.FindManyAsync(
            @params.FindManyParams,
            @params.OrderByParams,
            @params.PaginationParams);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationCallsServiceParams @params)
    {
        if (@params.Page == null || @params.Size == null) return null;

        var count = await unitOfWork.CallsRepository
            .CountAsync(@params.CountParams);

        var pagination = Pagination.Build(@params.Page, @params.Size, count);

        return pagination;
    }

    public async Task<Call?> CreateAsync(CreateCallsServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var user = await unitOfWork.UsersRepository.FindOneAsync(new()
        {
            Id = @params.Params.UserId,
        })
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(Messages.CALLS_OPENED, user.Name, DateTime.Now);
        var callStatus = new CallStatus(
            Domain.Calls.Enums.CallStatus.Open,
            message);
        await unitOfWork.CallsStatusesRepository.CreateAsync(callStatus);
        var call = new Call(@params.Params)
        {
            CallStatusId = callStatus.Id
        };
        await unitOfWork.CallsRepository.CreateAsync(call);
        await CreateNotification(call.Id, Titles.CALLS_NEW, message);
        await unitOfWork.Commit(transaction);

        return call;
    }

    public async Task DeleteAsync(DeleteCallsServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var call = await FindOneAsync(@params);
        unitOfWork.CallsStatusesRepository.Delete(call.CallStatus!);
        unitOfWork.CallsRepository.Delete(call);
        await unitOfWork.Commit(transaction);
    }

    private async Task CreateNotification(Guid referenceId, string title, string message)
    {
        var rolesMaster = await unitOfWork.RolesRepository
            .FindManyAsync(new () { Name = "MASTER" });
        var roles = rolesMaster.ToList();
        if (roles.Count == 0)
            throw new NotFoundException(Errors.CALL_ROLE_MASTER_NOT_FOUND);
        var findManyParams = new FindManyUsersParams()
        {
            RoleId = roles.ToList()[0].Id
        };
        var users = await unitOfWork.UsersRepository
            .FindManyAsync(new () { FindMany = findManyParams});
        foreach (var user in users)
        {
            var notification = new Notification(
                new NotificationParams
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
}
