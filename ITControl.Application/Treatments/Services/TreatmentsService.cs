using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Treatments.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Treatments.Requests;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Treatments.Enums;
using CallStatus = ITControl.Domain.Calls.Enums.CallStatus;

namespace ITControl.Application.Treatments.Services;

public class TreatmentsService(
    IUnitOfWork unitOfWork) : ITreatmentsService
{
    public async Task<Treatment> FindOneAsync(FindOneTreatmentsRequest request)
    {
        return await unitOfWork
            .TreatmentsRepository
            .FindOneAsync(request) 
            ?? throw new NotFoundException(Errors.TREATMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Treatment>> FindManyAsync(FindManyTreatmentsRequest request)
    {
        return await unitOfWork.TreatmentsRepository.FindManyAsync(request);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyTreatmentsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.TreatmentsRepository.CountAsync(request);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<Treatment?> CreateAsync(CreateTreatmentsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = new Treatment(request);
        var call = await unitOfWork.CallsRepository.FindOneAsync(
                       new FindOneRepositoryParams { Id = request.CallId }) 
                   ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var callStatus = call.CallStatus!;
        var user = await unitOfWork.UsersRepository.FindOneAsync(new()
        {
            Id = request.UserId,
        }) 
                   ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(Messages.TREATMENTS_STARTED, treatment.Protocol, call.Title, user.Name);
        callStatus.Update(
            status: CallStatus.InProgress,
            description: message);
        await unitOfWork.TreatmentsRepository.CreateAsync(treatment);
        unitOfWork.CallsStatusesRepository.Update(callStatus);
        await CreateNotification(treatment.Id, request.UserId, Titles.TREATMENTS_STARTED, message, NotificationType.Info);
        await unitOfWork.Commit(transaction);

        return treatment;
    }

    public async Task UpdateAsync(Guid id, UpdateTreatmentsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = await FindOneAsync(new () { Id = id });
        var call = treatment.Call
                   ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var callStatus = call.CallStatus!;
        var user = treatment.User
                   ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = "";
        var type = NotificationType.Info;
        if (treatment.Status == TreatmentStatus.Started)
        {
            message = string.Format(Messages.TREATMENTS_STARTED, treatment.Protocol, call.Title, user.Name);
            callStatus.Update(
                status: CallStatus.InProgress,
                description: message);
        }

        if (treatment.Status == TreatmentStatus.PartialFinished)
        {
            message = string.Format(Messages.TREATMENTS_PARTIAL_FINISHED, treatment.Protocol, call.Title, user.Name);
            callStatus.Update(
                status: CallStatus.InProgress,
                description: message);
        }

        if (treatment.Status == TreatmentStatus.Finished)
        {
            message = string.Format(Messages.TREATMENTS_FINISHED, call.Title, user.Name);
            type = NotificationType.Success;
            callStatus.Update(
                status: CallStatus.Closed,
                description: message);
        }
        treatment.Update(request);
        unitOfWork.TreatmentsRepository.Update(treatment);
        unitOfWork.CallsStatusesRepository.Update(callStatus);
        await CreateNotification(treatment.Id, call.UserId, Titles.TREATMENTS_UPDATED, message, type);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = await FindOneAsync(new() { Id = id });
        unitOfWork.TreatmentsRepository.Delete(treatment);
        await unitOfWork.Commit(transaction);
    }

    private async Task CreateNotification(
        Guid referenceId, 
        Guid userId, 
        string title, 
        string message,
        NotificationType type)
    {
        var notification = new Notification(
            new NotificationParams
            {
                Title = title,
                Message = message,
                Type = type,
                Reference = NotificationReference.Treatment,
                UserId = userId,
                TreatmentId = referenceId
            });
        await unitOfWork.NotificationsRepository.CreateAsync(notification);
    }
}
