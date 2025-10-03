using ITControl.Application.Appointments.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Messages.Notifications;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Appointments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Exceptions;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Enums;

namespace ITControl.Application.Appointments.Services;

public class AppointmentsService(
    IUnitOfWork unitOfWork) : IAppointmentsService
{
    public async Task<Appointment> FindOneAsync(
        Guid id, 
        bool? includeUser = null, 
        bool? includeCall = null, 
        bool? includeLocation = null)
    {
        return await unitOfWork
            .AppointmentsRepository
            .FindOneAsync(id, includeUser, includeCall, includeLocation)
            ?? throw new NotFoundException(Errors.APPOINTMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Appointment>> FindManyAsync(FindManyAppointmentsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.AppointmentsRepository.FindManyAsync(
            request.Description,
            request.ScheduledAt,
            request.ScheduledIn,
            request.Observation,
            request.UserId,
            request.CallId,
            request.LocationId,
            request.OrderByDescription,
            request.OrderByScheduledAt,
            request.OrderByScheduledIn,
            request.OrderByObservation,
            request.OrderByUser,
            request.OrderByCall,
            request.OrderByLocation,
            page,
            size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyAppointmentsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.AppointmentsRepository.CountAsync(
            null,
            request.Description,
            request.ScheduledAt,
            request.ScheduledIn,
            request.Observation,
            request.UserId,
            request.CallId,
            request.LocationId);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<Appointment?> CreateAsync(CreateAppointmentsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        await CheckExistenceAsync(request.CallId, request.UserId, request.LocationId);  
        var appointment = new Appointment(
            request.Description,
            request.ScheduledAt,
            request.ScheduledIn,
            request.Observation,
            request.UserId,
            request.CallId,
            request.LocationId);
        await unitOfWork.AppointmentsRepository.CreateAsync(appointment);
        var call = await unitOfWork.CallsRepository.FindOneAsync(request.CallId) 
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var user = await unitOfWork.UsersRepository.FindOneAsync(new()
        {
            Id = request.UserId,
            IncludeDepartment = false,
            IncludeUsersEquipments = false,
            IncludePosition = false,
            IncludeDivision = false,
            IncludeRole = false,
            IncludeUnit = false,
            IncludeUsersSystems = false
        }) 
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
        await CheckExistenceAsync(request.CallId, request.UserId, request.LocationId); 
        var appointment = await FindOneAsync(id, true, true);
        appointment.Update(
            request.Description,
            request.ScheduledAt,
            request.ScheduledIn,
            request.Observation,
            request.UserId,
            request.CallId,
            request.LocationId);
        unitOfWork.AppointmentsRepository.Update(appointment);
        var call = appointment.Call
            ?? throw new NotFoundException(Errors.CALL_NOT_FOUND);
        var user = appointment.User
            ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
        var message = string.Format(Messages.APPOINTMENTS_UPDATED, call.Title, user.Name, request.ScheduledAt, request.ScheduledIn);
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
        var appointment = await FindOneAsync(id);
        unitOfWork.AppointmentsRepository.Delete(appointment);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckExistenceAsync(Guid? callId = null, Guid? userId = null, Guid? locationId = null)
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

        if (locationId != null)
        {
            await CheckLocationExistenceAsync(locationId.Value, messages);  
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
        var user = await unitOfWork.UsersRepository.ExistsAsync(new() { Id = userId });
        if (user == false)
        {
            messages.Add(Errors.USER_NOT_FOUND);
        }
    }

    private async Task CheckLocationExistenceAsync(
        Guid locationId,
        List<string> messages)
    {
        var exists = await unitOfWork.LocationsRepository.ExistsAsync(id: locationId);
        if (exists == false)
        {
            messages.Add(Errors.LOCATION_NOT_FOUND);
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
            NotificationReference.Appointment,
            userId,
            null,
            null,
            referenceId);
        await unitOfWork.NotificationsRepository.CreateAsync(notification);
    }
}