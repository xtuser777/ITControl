using ITControl.Application.Appointments.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Appointments.Params;
using ITControl.Domain.Appointments.Props;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Props;
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
            .CountAsync(parameters.CountProps);
        var pagination = Pagination.Build(parameters.PaginationParams, count);

        return pagination;
    }

    public async Task<Appointment?> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction; 
        var appointment = new Appointment(
            (AppointmentProps)parameters.Props);
        await unitOfWork.AppointmentsRepository.CreateAsync(appointment);
        var call = await unitOfWork.CallsRepository.FindOneAsync(
            new FindOneRepositoryParams
            {
                Id = ((AppointmentProps)parameters.Props).CallId ?? Guid.Empty
            })  
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        appointment.Call = call;
        var user = await unitOfWork.UsersRepository.FindOneAsync(
            new FindOneRepositoryParams
            {
                Id = ((AppointmentProps)parameters.Props).UserId ?? Guid.Empty
            }) 
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(
            Messages.APPOINTMENTS_CREATED, 
            call.Title, user.Name, 
            ((AppointmentProps)parameters.Props).ScheduledAt, 
            ((AppointmentProps)parameters.Props).ScheduledIn);
        await CreateNotification(
            appointment.Id,
            ((AppointmentProps)parameters.Props).UserId,
            Titles.APPOINTMENTS_STARTED,
            message,
            NotificationType.Info);
        await unitOfWork.Commit(transaction);
        
        return appointment;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var props = (AppointmentProps)parameters.Props;
        var findOneParams = new FindOneServiceParams
        {
            Id = parameters.Id,
            Includes = new IncludesAppointmentsParams
            {
                Call = true,
                User = true,
            },
        };
        var appointment = await FindOneAsync(findOneParams);
        appointment.Update((AppointmentProps)parameters.Props);
        unitOfWork.AppointmentsRepository.Update(appointment);
        var call = appointment.Call
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var user = appointment.User
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(
            Messages.APPOINTMENTS_UPDATED, 
            call.Title, user.Name, 
            ((AppointmentProps)parameters.Props).ScheduledAt, 
            ((AppointmentProps)parameters.Props).ScheduledIn);
        await CreateNotification(
            appointment.Id,
            call.UserId,
            Titles.APPOINTMENTS_UPDATED,
            message,
            NotificationType.Info);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var appointment = await FindOneAsync(parameters);
        await RemoveNotifications(parameters.Id);
        unitOfWork.AppointmentsRepository.Delete(appointment);
        await unitOfWork.Commit(transaction);
    }

    public async Task CheckTodaysAsync(Guid userId)
    {
        var findManyParams = new FindManyRepositoryParams
        {
            FindManyProps = new FindManyAppointmentsParams 
            {
                UserId = userId,
                ScheduledAt = DateOnly.FromDateTime(DateTime.Now)
            }
        };
        var appointments = 
            await unitOfWork.AppointmentsRepository.FindManyAsync(
                findManyParams);
        foreach (var appointment in appointments)
        {
            var message = string.Format(
                    Messages.APPOINTMENTS_REMINDER,
                appointment.ScheduledIn);
            var existsNotificationsParams = new FindManyRepositoryParams
            {
                FindManyProps = new NotificationProps
                {
                    AppointmentId = appointment.Id,
                    UserId = appointment.UserId,
                    Title = Titles.APPOINTMENTS_REMINDER,
                    Message = message,
                }
            };
            var existingNotifications = await unitOfWork
                .NotificationsRepository
                .FindManyAsync(existsNotificationsParams);
            if (!existingNotifications.Any())
                await CreateNotification(
                    appointment.Id,
                    appointment.UserId,
                    Titles.APPOINTMENTS_REMINDER,
                    message,
                    NotificationType.Warning);
        }
    }

    private async Task CreateNotification(
        Guid? referenceId,
        Guid? userId,
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
                Reference = NotificationReference.Appointment,
                UserId = userId,
                AppointmentId = referenceId
            });
        await unitOfWork.NotificationsRepository.CreateAsync(notification);
    }

    private async Task RemoveNotifications(Guid appointmentId)
    {
        var findManyParams = new FindManyRepositoryParams
        {
            FindManyProps =
            new NotificationProps { AppointmentId = appointmentId }
        };
        var notifications = await unitOfWork.NotificationsRepository
            .FindManyAsync(findManyParams);
        if (notifications.Any())
        {
            unitOfWork.NotificationsRepository.DeleteMany(notifications);
        }
    }
}