using ITControl.Application.Appointments.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Appointments.Params;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Appointments.Services;

public class AppointmentsService(
    IUnitOfWork unitOfWork) : IAppointmentsService
{
    public async Task<Appointment> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
            .AppointmentsRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.APPOINTMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Appointment>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.AppointmentsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.AppointmentsRepository
            .CountAsync(parameters.CountParams);
        var pagination = Pagination.Build(parameters.PaginationParams, count);

        return pagination;
    }

    public async Task<Appointment?> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction; 
        var appointment = new Appointment(
            (AppointmentParams)parameters.Params);
        await unitOfWork.AppointmentsRepository.CreateAsync(appointment);
        var call = await unitOfWork.CallsRepository.FindOneAsync(
            new FindOneRepositoryParams
            {
                Id = ((AppointmentParams)parameters.Params).CallId
            })  
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var user = await unitOfWork.UsersRepository.FindOneAsync(
            new FindOneRepositoryParams
            {
                Id = ((AppointmentParams)parameters.Params).UserId
            }) 
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(
            Messages.APPOINTMENTS_CREATED, 
            call.Title, user.Name, 
            ((AppointmentParams)parameters.Params).ScheduledAt, 
            ((AppointmentParams)parameters.Params).ScheduledIn);
        await CreateNotification(
            appointment.Id,
            ((AppointmentParams)parameters.Params).UserId,
            Titles.APPOINTMENTS_STARTED,
            message,
            NotificationType.Info);
        await unitOfWork.Commit(transaction);
        
        return appointment;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var appointment = await FindOneAsync(parameters);
        appointment.Update((UpdateAppointmentParams)parameters.Params);
        unitOfWork.AppointmentsRepository.Update(appointment);
        var call = appointment.Call
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var user = appointment.User
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(
            Messages.APPOINTMENTS_UPDATED, 
            call.Title, user.Name, 
            ((UpdateAppointmentParams)parameters.Params).ScheduledAt, 
            ((UpdateAppointmentParams)parameters.Params).ScheduledIn);
        await CreateNotification(
            appointment.Id,
            user.Id,
            Titles.APPOINTMENTS_UPDATED,
            message,
            NotificationType.Info);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var appointment = await FindOneAsync(parameters);
        unitOfWork.AppointmentsRepository.Delete(appointment);
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
                Reference = NotificationReference.Appointment,
                UserId = userId,
                AppointmentId = referenceId
            });
        await unitOfWork.NotificationsRepository.CreateAsync(notification);
    }
}