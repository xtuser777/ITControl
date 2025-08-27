using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Treatments.Requests;
using ITControl.Domain.Entities;
using ITControl.Domain.Enums;
using ITControl.Domain.Exceptions;
using CallStatus = ITControl.Domain.Enums.CallStatus;

namespace ITControl.Application.Services;

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
            ?? throw new NotFoundException("Atendimento não encontrado");
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
                   ?? throw new NotFoundException("Chamado não encontrado");
        var callStatus = call.CallStatus!;
        var user = await unitOfWork.UsersRepository.FindOneAsync(
            request.UserId, null, null, null, null) 
                   ?? throw new NotFoundException("Usuário não encontrado");
        var message = $"O atendimento com o protocolo {treatment.Protocol} foi iniciado para o chamado {call.Title} por {user.Name}.";
        callStatus.Update(
            status: CallStatus.InProgress,
            description: message);
        await unitOfWork.TreatmentsRepository.CreateAsync(treatment);
        unitOfWork.CallsStatusesRepository.Update(callStatus);
        await CreateNotification(treatment.Id, request.UserId, "Atendimento Iniciado", message, NotificationType.Info);
        await unitOfWork.Commit(transaction);

        return treatment;
    }

    public async Task UpdateAsync(Guid id, UpdateTreatmentsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        await CheckExistenceAsync(request.CallId, request.UserId);
        var treatment = await FindOneAsync(id, true, true);
        var call = treatment.Call
                   ?? throw new NotFoundException("Chamado não encontrado");
        var callStatus = call.CallStatus!;
        var user = treatment.User
                   ?? throw new NotFoundException("Usuário não encontrado");
        var message = "";
        var type = NotificationType.Info;
        if (treatment.Status == TreatmentStatus.Started)
        {
            message = $"O atendimento com o protocolo {treatment.Protocol} foi iniciado para o chamado {call.Title} por {user.Name}.";
            callStatus.Update(
                status: CallStatus.InProgress,
                description: message);
        }

        if (treatment.Status == TreatmentStatus.PartialFinished)
        {
            message = $"O atendimento com o protocolo {treatment.Protocol} foi finalizado parcialmente para o chamado {call.Title} por {user.Name}.";
            callStatus.Update(
                status: CallStatus.InProgress,
                description: message);
        }

        if (treatment.Status == TreatmentStatus.Finished)
        {
            message = $"O atendimento com o protocolo {treatment.Protocol} foi finalizado para o chamado {call.Title} por {user.Name}.";
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
        await CreateNotification(treatment.Id, call.UserId, "Atendimento Atualizado", message, type);
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
