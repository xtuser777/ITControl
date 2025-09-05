using ITControl.Application.Equipments.Interfaces;
using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Equipments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Enums;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Equipments.Services;

public class EquipmentsService(IUnitOfWork unitOfWork) : IEquipmentsService
{
    public async Task<Equipment> FindOneAsync(Guid id, bool? includeContract = null)
    {
        return await unitOfWork
            .EquipmentsRepository
            .FindOneAsync(id, includeContract) 
               ?? throw new NotFoundException("Equipamento não encontrado");
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
            Parser.ToBoolOptional(request.Rented),
            Parser.ToEnumOptional<EquipmentType>(request.Type?.ToString()),
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
            Parser.ToBoolOptional(request.Rented),
            Parser.ToEnumOptional<EquipmentType>(request.Type?.ToString()));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Equipment?> CreateAsync(CreateEquipmentsRequest request)
    {
        await CheckExistence(request.ContractId);
        var equipment = new Equipment(
            request.Name, 
            request.Description,
            Parser.ToEnum<EquipmentType>(request.Type.ToString()), 
            request.Ip, 
            request.Mac, 
            request.Tag, 
            request.Rented, 
            request.ContractId);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.EquipmentsRepository.CreateAsync(equipment);
        await unitOfWork.Commit(transaction);
        
        return equipment;
    }

    public async Task UpdateAsync(Guid id, UpdateEquipmentsRequest request)
    {
        await CheckExistence(request.ContractId);
        var equipment = await FindOneAsync(id);
        equipment.Update(
            request.Name, 
            request.Description,
            Parser.ToEnumOptional<EquipmentType>(request.Type?.ToString()), 
            request.Ip, 
            request.Mac, 
            request.Tag, 
            request.Rented, 
            request.ContractId);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Update(equipment);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var equipment = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Delete(equipment);
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