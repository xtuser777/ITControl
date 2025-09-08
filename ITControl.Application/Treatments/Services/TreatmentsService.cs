using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Shared.Utils;
using ITControl.Application.Treatments.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Treatments.Requests;
using ITControl.Domain.Exceptions;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Treatments.Enums;
using CallStatus = ITControl.Domain.Calls.Enums.CallStatus;

namespace ITControl.Application.Treatments.Services;

public class TreatmentsService(
    IUnitOfWork unitOfWork) : ITreatmentsService
{
    public async Task<Treatment> FindOneAsync(
        Guid id, 
        bool? includeCall = null, 
        bool? includeUser = null)
    {
        return await unitOfWork
            .TreatmentsRepository
            .FindOneAsync(id, includeCall, includeUser) 
            ?? throw new NotFoundException(Errors.TREATMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Treatment>> FindManyAsync(FindManyTreatmentsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.TreatmentsRepository.FindManyAsync(
            request.Description,
            request.Protocol,
            request.StartedAt,
            request.EndedAt,
            request.StartedIn,
            request.EndedIn,
            Parser.ToEnumOptional<TreatmentStatus>(request.Status),
            Parser.ToEnumOptional<TreatmentType>(request.Type),
            request.Observation,
            request.ExternalProtocol,
            request.CallId,
            request.UserId,
            request.OrderByDescription,
            request.OrderByProtocol,
            request.OrderByStartedAt,
            request.OrderByEndedAt,
            request.OrderByStartedIn,
            request.OrderByEndedIn,
            request.OrderByStatus,
            request.OrderByType,
            request.OrderByObservation,
            request.OrderByExternalProtocol,
            request.OrderByCall,
            request.OrderByUser,
            page,
            size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyTreatmentsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.TreatmentsRepository.CountAsync(
            null,
            request.Description,
            request.Protocol,
            request.StartedAt,
            request.EndedAt,
            request.StartedIn,
            request.EndedIn,
            Parser.ToEnumOptional<TreatmentStatus>(request.Status),
            Parser.ToEnumOptional<TreatmentType>(request.Type),
            request.Observation,
            request.ExternalProtocol,
            request.CallId,
            request.UserId);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<Treatment?> CreateAsync(CreateTreatmentsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        await CheckExistenceAsync(request.CallId, request.UserId);
        var treatment = new Treatment(
            request.Description,
            Guid.NewGuid().ToString().ToUpper().Replace("-", ""),
            request.StartedAt,
            request.EndedAt,
            request.StartedIn,
            request.EndedIn,
            TreatmentStatus.Started,
            Parser.ToEnum<TreatmentType>(request.Type),
            request.Observation,
            request.ExternalProtocol,
            request.CallId,
            request.UserId);
        var call = await unitOfWork.CallsRepository.FindOneAsync(request.CallId) 
                   ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var callStatus = call.CallStatus!;
        var user = await unitOfWork.UsersRepository.FindOneAsync(
            request.UserId, null, null, null, null) 
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
        await CheckExistenceAsync(request.CallId, request.UserId);
        var treatment = await FindOneAsync(id, true, true);
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
        treatment.Update(
            request.Description,
            null,
            request.StartedAt,
            request.EndedAt,
            request.StartedIn,
            request.EndedIn,
            Parser.ToEnumOptional<TreatmentStatus>(request.Status),
            Parser.ToEnumOptional<TreatmentType>(request.Type),
            request.Observation,
            request.ExternalProtocol,
            request.CallId,
            request.UserId);
        unitOfWork.TreatmentsRepository.Update(treatment);
        unitOfWork.CallsStatusesRepository.Update(callStatus);
        await CreateNotification(treatment.Id, call.UserId, Titles.TREATMENTS_UPDATED, message, type);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = await FindOneAsync(id);
        unitOfWork.TreatmentsRepository.Delete(treatment);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckExistenceAsync(Guid? callId = null, Guid? userId = null)
    {
        var messages = new List<string>();
        if (callId != null)
        {
            await CheckCallExistenceAsync(callId.Value, messages);
        }

        if (userId != null)
        {
            await CheckUserExistenceAsync(userId.Value, messages);
        }

        if (messages.Count > 0)
        {
            throw new NotFoundException(string.Join(Environment.NewLine, messages.ToArray()));
        }
    }

    private async Task CheckCallExistenceAsync(
        Guid callId,
        List<string> messages)
    {
        var exists = await unitOfWork.CallsRepository.ExistsAsync(id: callId);
        if (exists == false)
        {
            messages.Add(Errors.CALL_NOT_FOUND);
        }
    }

    private async Task CheckUserExistenceAsync(Guid userId, List<string> messages)
    {
        var user = await unitOfWork.UsersRepository.ExistsAsync(id: userId);
        if (user == false)
        {
            messages.Add(Errors.USER_NOT_FOUND);
        }
    }

    private async Task CreateNotification(
        Guid referenceId, 
        Guid userId, 
        string title, 
        string message,
        NotificationType type)
    {
        var notification = new Notification(
            title,
            message,
            type,
            NotificationReference.Treatment,
            userId,
            null,
            null,
            referenceId);
        await unitOfWork.NotificationsRepository.CreateAsync(notification);
    }
}
