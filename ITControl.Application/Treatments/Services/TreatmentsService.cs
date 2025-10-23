﻿using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Params;
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
using ITControl.Domain.Treatments.Params;
using ITControl.Domain.Users.Params;
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

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.TreatmentsRepository
            .CountAsync(parameters.CountParams);
        var pagination = Pagination.Build(parameters.PaginationParams, count);

        return pagination;
    }

    public async Task<Treatment?> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = new Treatment((TreatmentParams)parameters.Params);
        var findOneCallParams = new FindOneRepositoryParams
        {
            Id = ((TreatmentParams)parameters.Params).CallId
        };
        var call = await unitOfWork.CallsRepository
                       .FindOneAsync(findOneCallParams) 
                   ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var callStatus = call.CallStatus!;
        var user = await unitOfWork.UsersRepository
                       .FindOneAsync(
            new FindOneUsersRepositoryParams
            {
                Id = ((TreatmentParams)parameters.Params).UserId,
            }) 
                   ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(
            Messages.TREATMENTS_STARTED, 
            treatment.Protocol, call.Title, user.Name);
        callStatus.Update(
            status: CallStatus.InProgress,
            description: message);
        await unitOfWork.TreatmentsRepository.CreateAsync(treatment);
        unitOfWork.CallsStatusesRepository.Update(callStatus);
        await CreateNotification(
            treatment.Id, 
            ((TreatmentParams)parameters.Params).UserId, 
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
        var treatment = await FindOneAsync(parameters);
        var call = treatment.Call
                   ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var callStatus = call.CallStatus!;
        var user = treatment.User
                   ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = "";
        var type = NotificationType.Info;
        if (treatment.Status == TreatmentStatus.Started)
        {
            message = string.Format(
                Messages.TREATMENTS_STARTED, 
                treatment.Protocol, call.Title, user.Name);
            callStatus.Update(
                status: CallStatus.InProgress,
                description: message);
        }

        if (treatment.Status == TreatmentStatus.PartialFinished)
        {
            message = string.Format(
                Messages.TREATMENTS_PARTIAL_FINISHED, 
                treatment.Protocol, 
                call.Title, user.Name);
            callStatus.Update(
                status: CallStatus.InProgress,
                description: message);
        }

        if (treatment.Status == TreatmentStatus.Finished)
        {
            message = string.Format(
                Messages.TREATMENTS_FINISHED, call.Title, user.Name);
            type = NotificationType.Success;
            callStatus.Update(
                status: CallStatus.Closed,
                description: message);
        }
        treatment.Update((UpdateTreatmentParams)parameters.Params);
        unitOfWork.TreatmentsRepository.Update(treatment);
        unitOfWork.CallsStatusesRepository.Update(callStatus);
        await CreateNotification(
            treatment.Id, 
            call.UserId, 
            Titles.TREATMENTS_UPDATED, message, type);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var treatment = await FindOneAsync(parameters);
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
        await unitOfWork.NotificationsRepository
            .CreateAsync(notification);
    }
}
