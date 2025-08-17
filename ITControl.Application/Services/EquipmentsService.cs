using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Equipments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Enums;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class EquipmentsService(IUnitOfWork unitOfWork) : IEquipmentsService
{
    public async Task<Equipment?> FindOneAsync(Guid id, bool? includeContract = null)
    {
        return await unitOfWork.EquipmentsRepository.FindOneAsync(id, includeContract);
    }

    private async Task<Equipment> FindOneOrThrowAsync(Guid id, bool? includeContract = null)
    {
        var equipment = await FindOneAsync(id, includeContract);
        if (equipment == null)
            throw new NotFoundException("Equipamento não encontrado");
        
        return equipment;
    }

    public async Task<IEnumerable<Equipment>> FindManyAsync(FindManyEquipmentsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.EquipmentsRepository.FindManyAsync(
            request.Name,
            request.Description,
            request.Ip,
            request.Mac,
            request.Tag,
            request.Rented == "true",
            request.Type != null ? (EquipmentType)request.Type : null,
            request.OrderByName,
            request.OrderByDescription,
            request.OrderByIp,
            request.OrderByMac,
            request.OrderByTag,
            request.OrderByRented,
            request.OrderByType,
            page,
            size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyEquipmentsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.EquipmentsRepository.CountAsync(
            null,
            request.Name,
            request.Description,
            request.Ip,
            request.Mac,
            request.Tag,
            request.Rented == "true",
            request.Type != null ? (EquipmentType)request.Type : null);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Equipment?> CreateAsync(CreateEquipmentsRequest request)
    {
        await CheckExistence(request.ContractId != null ? Guid.Parse(request.ContractId) : null);
        var equipment = new Equipment(
            request.Name, 
            request.Description, 
            (EquipmentType)request.Type, 
            request.Ip, 
            request.Mac, 
            request.Tag, 
            request.Rented, 
            request.ContractId != null ? Guid.Parse((ReadOnlySpan<char>)request.ContractId) : null);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.EquipmentsRepository.CreateAsync(equipment);
        await unitOfWork.Commit(transaction);
        
        return equipment;
    }

    public async Task UpdateAsync(Guid id, UpdateEquipmentsRequest request)
    {
        await CheckExistence(request.ContractId != null ? Guid.Parse(request.ContractId) : null);
        var equipment = await FindOneOrThrowAsync(id);
        equipment.Update(
            request.Name, 
            request.Description, 
            request.Type != null ? (EquipmentType)request.Type : null, 
            request.Ip, 
            request.Mac, 
            request.Tag, 
            request.Rented, 
            request.ContractId != null ? Guid.Parse((ReadOnlySpan<char>)request.ContractId) : null);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.EquipmentsRepository.UpdateAsync(equipment);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var equipment = await FindOneOrThrowAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.EquipmentsRepository.DeleteAsync(equipment);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckExistence(Guid? contractId)
    {
        var messages = new List<string>();

        if (contractId != null) await CheckContractExistence((Guid)contractId, messages);
        
        if (messages.Count > 0) throw new NotFoundException(string.Join(",", messages));
    }

    private async Task CheckContractExistence(Guid contractId, List<string> messages)
    {
        var exists = await unitOfWork.ContractsRepository.ExistsAsync(contractId);
        if (!exists)
            messages.Add("Contract not found");
    }
}