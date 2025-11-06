using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Treatments.Interfaces;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Props;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Treatments.Params;
using ITControl.Domain.Treatments.Props;
using CallStatus = ITControl.Domain.Calls.Enums.CallStatus;

namespace ITControl.Application.Treatments.Services;

public class TreatmentsService(
    IUnitOfWork unitOfWork) : ITreatmentsService
{
    public async Task<Treatment> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
            .TreatmentsRepository
            .FindOneAsync(parameters) 
            ?? throw new NotFoundException(Errors.TREATMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Treatment>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.TreatmentsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.TreatmentsRepository
            .CountAsync(parameters.CountProps);
        var pagination = Pagination.Build(parameters.PaginationParams, count);

        return pagination;
    }

    public async Task<Treatment?> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = new Treatment((TreatmentProps)parameters.Props);
        var findOneCallParams = new FindOneRepositoryParams
        {
            Id = ((TreatmentProps)parameters.Props).CallId ?? Guid.Empty
        };
        var call = await unitOfWork.CallsRepository
                       .FindOneAsync(findOneCallParams) 
                   ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        treatment.Call = call;
        var callStatus = call.CallStatus!;
        var user = await unitOfWork.UsersRepository
                       .FindOneAsync(
            new FindOneRepositoryParams
            {
                Id = ((TreatmentProps)parameters.Props).UserId ?? Guid.Empty,
            }) 
                   ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(
            Messages.TREATMENTS_STARTED, 
            treatment.Protocol, call.Title, user.Name);
        callStatus.Update(new ()
        {
            Status = CallStatus.InProgress,
            Description = message
        });
        await unitOfWork.TreatmentsRepository.CreateAsync(treatment);
        unitOfWork.CallsStatusesRepository.Update(callStatus);
        await CreateNotification(
            treatment.Id ?? Guid.Empty, 
            call.UserId ?? Guid.Empty, 
            Titles.TREATMENTS_STARTED, 
            message, 
            NotificationType.Info);
        await unitOfWork.Commit(transaction);

        return treatment;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var props = (TreatmentProps)parameters.Props;
        var findOneParams = new FindOneServiceParams
        {
            Id = parameters.Id,
            Includes = new IncludesTreatmentsParams
            {
                Call = new IncludesTreatmentsCallParams
                {
                    CallStatus = true
                },
                User = true,
            }
        };
        var treatment = await FindOneAsync(findOneParams);
        var call = treatment.Call
                   ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var callStatus = call.CallStatus!;
        var user = treatment.User
                   ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = "";
        var type = NotificationType.Info;
        switch (props.Status)
        {
            case TreatmentStatus.Started:
                message = string.Format(
                    Messages.TREATMENTS_STARTED, 
                    treatment.Protocol, call.Title, user.Name);
                callStatus.Update(new ()
                {
                    Status = CallStatus.InProgress,
                    Description =  message
                });
                break;
            case TreatmentStatus.PartialFinished:
                message = string.Format(
                    Messages.TREATMENTS_PARTIAL_FINISHED, 
                    treatment.Protocol, 
                    call.Title, user.Name);
                callStatus.Update(new ()
                {
                    Status = CallStatus.InProgress,
                    Description =  message
                });
                break;
            case TreatmentStatus.Finished:
                message = string.Format(
                    Messages.TREATMENTS_FINISHED, treatment.Protocol, call.Title, user.Name);
                type = NotificationType.Success;
                callStatus.Update(new ()
                {
                    Status = CallStatus.Closed,
                    Description =  message
                });
                break;
            case TreatmentStatus.Scheduled:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        treatment.Update(props);
        unitOfWork.TreatmentsRepository.Update(treatment);
        unitOfWork.CallsStatusesRepository.Update(callStatus);
        await CreateNotification(
            treatment.Id  ?? Guid.Empty, 
            call.UserId  ?? Guid.Empty, 
            Titles.TREATMENTS_UPDATED, message, type);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = await FindOneAsync(parameters);
        await RemoveNotifications(parameters.Id);
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
            new NotificationProps
            {
                Title = title,
                Message = message,
                Type = type,
                Reference = NotificationReference.Treatment,
                UserId = userId,
                TreatmentId = referenceId
            });
        await unitOfWork.NotificationsRepository
            .CreateAsync(notification);
    }

    private async Task RemoveNotifications(Guid treatmentId)
    {
        var findManyParams = new FindManyRepositoryParams
        {
            FindManyProps =
            new NotificationProps { TreatmentId = treatmentId }
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
