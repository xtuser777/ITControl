using ITControl.Application.Appointments.Interfaces;
using ITControl.Application.Appointments.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Appointments.Services;

public class AppointmentsService(
    IUnitOfWork unitOfWork) : IAppointmentsService
{
    public async Task<Appointment> FindOneAsync(
        FindOneAppointmentsServiceParams @params)
    {
        return await unitOfWork
            .AppointmentsRepository
            .FindOneAsync(@params)
            ?? throw new NotFoundException(Errors.APPOINTMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Appointment>> FindManyAsync(
        FindManyAppointmentsServiceParams @params)
    {
        return await unitOfWork.AppointmentsRepository.FindManyAsync(
            @params.FindManyParams,
            @params.OrderByParams,
            @params.PaginationParams);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationAppointmentsServiceParams @params)
    {
        if (@params.Page == null || @params.Size == null) return null;

        var count = await unitOfWork.AppointmentsRepository
            .CountAsync(@params.CountParams);

        var pagination = Pagination.Build(@params.Page, @params.Size, count);

        return pagination;
    }

    public async Task<Appointment?> CreateAsync(CreateAppointmentsServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction; 
        var appointment = new Appointment(@params.Params);
        await unitOfWork.AppointmentsRepository.CreateAsync(appointment);
        var call = await unitOfWork.CallsRepository.FindOneAsync(
            new () { Id = @params.Params.CallId })  
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var user = await unitOfWork.UsersRepository.FindOneAsync(
            new() { Id = @params.Params.UserId }) 
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(
            Messages.APPOINTMENTS_CREATED, call.Title, user.Name, 
            @params.Params.ScheduledAt, @params.Params.ScheduledIn);
        await CreateNotification(
            appointment.Id,
            @params.Params.UserId,
            Titles.APPOINTMENTS_STARTED,
            message,
            NotificationType.Info);
        await unitOfWork.Commit(transaction);
        
        return appointment;
    }

    public async Task UpdateAsync(UpdateAppointmentsServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var appointment = await FindOneAsync(@params);
        appointment.Update(@params.Params);
        unitOfWork.AppointmentsRepository.Update(appointment);
        var call = appointment.Call
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var user = appointment.User
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(
            Messages.APPOINTMENTS_UPDATED, 
            call.Title, user.Name, @params.Params.ScheduledAt, @params.Params.ScheduledIn);
        await CreateNotification(
            appointment.Id,
            user.Id,
            Titles.APPOINTMENTS_UPDATED,
            message,
            NotificationType.Info);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteAppointmentsServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var appointment = await FindOneAsync(@params);
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