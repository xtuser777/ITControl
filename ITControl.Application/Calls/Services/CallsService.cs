using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Calls.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;
using CallStatus = ITControl.Domain.Calls.Entities.CallStatus;

namespace ITControl.Application.Calls.Services;
public class CallsService(
    IUnitOfWork unitOfWork) : ICallsService
{
    public async Task<Call> FindOneAsync(FindOneCallsRequest request)
    {
        return await unitOfWork
            .CallsRepository
            .FindOneAsync(request)
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
    }

    public async Task<IEnumerable<Call>> FindManyAsync(FindManyCallsRequest request)
    {
        return await unitOfWork.CallsRepository.FindManyAsync(request);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyCallsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.CallsRepository.CountAsync(request);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<Call?> CreateAsync(CreateCallsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var user = await unitOfWork.UsersRepository.FindOneAsync(new()
        {
            Id = request.UserId,
        })
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(Messages.CALLS_OPENED, user.Name, DateTime.Now);
        var callStatus = new CallStatus(
            Domain.Calls.Enums.CallStatus.Open,
            message);
        await unitOfWork.CallsStatusesRepository.CreateAsync(callStatus);
        var call = (Call)request;
        call.CallStatusId = callStatus.Id;
        await unitOfWork.CallsRepository.CreateAsync(call);
        await CreateNotification(call.Id, Titles.CALLS_NEW, message);
        await unitOfWork.Commit(transaction);

        return call;
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var call = await FindOneAsync(new () { Id = id });
        unitOfWork.CallsStatusesRepository.Delete(call.CallStatus!);
        unitOfWork.CallsRepository.Delete(call);
        await unitOfWork.Commit(transaction);
    }

    private async Task CreateNotification(Guid referenceId, string title, string message)
    {
        var rolesMaster = await unitOfWork.RolesRepository.FindManyAsync(new () { Name = "MASTER" });
        var roles = rolesMaster.ToList();
        if (roles.Count == 0)
            throw new NotFoundException(Errors.CALL_ROLE_MASTER_NOT_FOUND);
        var users = await unitOfWork.UsersRepository.FindManyAsync(new () { RoleId = roles.ToList()[0].Id });
        foreach (var user in users)
        {
            var notification = new Notification(
                title: title,
                message: message,
                type: NotificationType.Info,
                reference: NotificationReference.Call,
                userId: user.Id,
                callId: referenceId,
                appointmentId: null,
                treatmentId: null);
            await unitOfWork.NotificationsRepository.CreateAsync(notification);
        }
    }
}
