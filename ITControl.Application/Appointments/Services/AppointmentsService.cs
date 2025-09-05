using ITControl.Application.Appointments.Interfaces;
using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Appointments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Entities;
using ITControl.Domain.Enums;
using ITControl.Domain.Exceptions;

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
            ?? throw new NotFoundException("Agendamento não encontrado");
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
            ?? throw new NotFoundException("chamado não encontrado");
        var user = await unitOfWork.UsersRepository.FindOneAsync(request.UserId, null, null, null, null) 
            ?? throw new NotFoundException("Usuário não encontrado");
        var message = $"O agendamento foi criado para o chamado {call.Title} por {user.Name} para {request.ScheduledAt} às {request.ScheduledIn}.";
        await CreateNotification(
            appointment.Id,
            request.UserId,
            "Novo agendamento criado",
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
            ?? throw new NotFoundException("Chamado não encontrado");
        var user = appointment.User
            ?? throw new NotFoundException("Usuário não encontrado");
        var message = $"O agendamento foi atualizado para o chamado {call.Title} por {user.Name} para {request.ScheduledAt} às {request.ScheduledIn}.";
        await CreateNotification(
            appointment.Id,
            user.Id,
            "Agendamento atualizado",
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
            messages.Add("Chamado não encontrado");
        }
    }

    private async Task CheckUserExistenceAsync(Guid userId, List<string> messages)
    {
        var user = await unitOfWork.UsersRepository.ExistsAsync(id: userId);
        if (user == false)
        {
            messages.Add("Usuário não encontrado");
        }
    }

    private async Task CheckLocationExistenceAsync(
        Guid locationId,
        List<string> messages)
    {
        var exists = await unitOfWork.LocationsRepository.ExistsAsync(id: locationId);
        if (exists == false)
        {
            messages.Add("Local não encontrado");
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