using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Calls.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Enums;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;
public class CallsService(
    IUnitOfWork unitOfWork) : ICallsService
{
    public async Task<Call> FindOneAsync(
        Guid id, 
        bool? includeUser = null, 
        bool? includeLocation = null, 
        bool? includeEquipment = null, 
        bool? includeSystem = null)
    {
        return await unitOfWork
            .CallsRepository
            .FindOneAsync(id, includeUser, includeLocation, includeEquipment, includeSystem)
            ?? throw new NotFoundException("Chamado não encontrado");
    }

    public async Task<IEnumerable<Call>> FindManyAsync(FindManyCallsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.CallsRepository.FindManyAsync(
            request.Title,
            request.Description,
            Parser.ToEnumOptional<CallReason>(request.Reason),
            Parser.ToEnumOptional<Domain.Enums.CallStatus>(request.Status),
            request.UserId,
            request.LocationId,
            request.OrderByTitle,
            request.OrderByDescription,
            request.OrderByReason,
            request.OrderByStatus,
            request.OrderByUserId,
            request.OrderByLocationId,
            page,
            size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyCallsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;

        var count = await unitOfWork.CallsRepository.CountAsync(
            null,
            request.Title,
            request.Description,
            Parser.ToEnumOptional<CallReason>(request.Reason),
            Parser.ToEnumOptional<Domain.Enums.CallStatus>(request.Status),
            request.UserId,
            request.LocationId);

        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<Call?> CreateAsync(CreateCallsRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        await CheckExistence(
            userId: request.UserId,
            locationId: request.LocationId,
            equipmentId: request.EquipmentId,
            systemId: request.SystemId);
        var call = new Call(
            request.Title,
            request.Description,
            Parser.ToEnum<CallReason>(request.Reason),
            request.UserId,
            request.LocationId,
            request.SystemId,
            request.EquipmentId);
        var callStatus = new Domain.Entities.CallStatus(
            Domain.Enums.CallStatus.Open,
            $"Abertura do chamado em {DateTime.Now}",
            call.Id);
        await unitOfWork.CallsRepository.CreateAsync(call);
        await unitOfWork.CallsStatusesRepository.CreateAsync(callStatus);
        await unitOfWork.Commit(transaction);

        return call;
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var call = await FindOneAsync(id);
        unitOfWork.CallsStatusesRepository.Delete(call.CallStatus!);
        unitOfWork.CallsRepository.Delete(call);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckExistence(
        Guid? userId = null,
        Guid? locationId = null,
        Guid? equipmentId = null,
        Guid? systemId = null)
    {
        var messages = new List<string>();
        if (userId.HasValue)
        {
            await CheckUserExistence(userId.Value, messages);
        }
        if (locationId.HasValue)
        {
            await CheckLocationExistence(locationId.Value, messages);
        }
        if (equipmentId.HasValue)
        {
            await CheckEquipmentExistence(equipmentId.Value, messages);
        }
        if (systemId.HasValue)
        {
            await CheckSystemExistence(systemId.Value, messages);
        }
        if (messages.Count > 0)
        {
            throw new BadRequestException(string.Join(", ", messages));
        }
    }

    private async Task CheckUserExistence(Guid userId, List<string> messages)
    {
        var user = await unitOfWork.UsersRepository.ExistsAsync(id: userId);
        if (user == false)
        {
            messages.Add("the user does not exist");
        }
    }

    private async Task CheckLocationExistence(Guid locationId, List<string> messages)
    {
        var location = await unitOfWork.LocationsRepository.ExistsAsync(id: locationId);
        if (location == false)
        {
            messages.Add("the location does not exist");
        }
    }

    private async Task CheckEquipmentExistence(Guid equipmentId, List<string> messages)
    {
        var equipment = await unitOfWork.EquipmentsRepository.ExistsAsync(id: equipmentId);
        if (equipment == false)
        {
            messages.Add("the equipment does not exist");
        }
    }

    private async Task CheckSystemExistence(Guid systemId, List<string> messages)
    {
        var system = await unitOfWork.SystemsRepository.ExistsAsync(id: systemId);
        if (system == false)
        {
            messages.Add("the system does not exist");
        }
    }
}
