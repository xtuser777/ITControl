using ITControl.Application.Appointments.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Appointments.Requests;
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
    public async Task<Appointment> FindOneAsync(FindOneAppointmentsRequest request)
    {
        return await unitOfWork
            .AppointmentsRepository
            .FindOneAsync(request)
            ?? throw new NotFoundException(Errors.APPOINTMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Appointment>> FindManyAsync(FindManyAppointmentsRequest request)
    {
        return await unitOfWork.AppointmentsRepository.FindManyAsync(request);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyAppointmentsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.AppointmentsRepository.CountAsync(request);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<Appointment?> CreateAsync(CreateAppointmentsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction; 
        var appointment = new Appointment(request);
        await unitOfWork.AppointmentsRepository.CreateAsync(appointment);
        var call = await unitOfWork.CallsRepository.FindOneAsync(new () { Id = request.CallId })  
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var user = await unitOfWork.UsersRepository.FindOneAsync(new() { Id = request.UserId }) 
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(Messages.APPOINTMENTS_CREATED, call.Title, user.Name, request.ScheduledAt, request.ScheduledIn);
        await CreateNotification(
            appointment.Id,
            request.UserId,
            Titles.APPOINTMENTS_STARTED,
            message,
            NotificationType.Info);
        await unitOfWork.Commit(transaction);
        
        return appointment;
    }

    public async Task UpdateAsync(Guid id, UpdateAppointmentsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var appointment = await FindOneAsync(new() { 
            Id = id, IncludeCall = true, IncludeUser = true 
        });
        appointment.Update(request);
        unitOfWork.AppointmentsRepository.Update(appointment);
        var call = appointment.Call
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var user = appointment.User
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(
            Messages.APPOINTMENTS_UPDATED, 
            call.Title, user.Name, request.ScheduledAt, request.ScheduledIn);
        await CreateNotification(
            appointment.Id,
            user.Id,
            Titles.APPOINTMENTS_UPDATED,
            message,
            NotificationType.Info);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var appointment = await FindOneAsync(new() { Id = id });
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