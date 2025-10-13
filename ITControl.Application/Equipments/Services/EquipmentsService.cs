using ITControl.Application.Equipments.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Shared.Utils;
using ITControl.Communication.Equipments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Equipments.Services;

public class EquipmentsService(IUnitOfWork unitOfWork) : IEquipmentsService
{
    public async Task<Equipment> FindOneAsync(Guid id, bool? includeContract = null)
    {
        return await unitOfWork
            .EquipmentsRepository
            .FindOneAsync(id, includeContract) 
               ?? throw new NotFoundException(Errors.EQUIPMENT_NOT_FOUND);
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
        var equipment = new Equipment(
            request.Name, 
            request.Description,
            Parser.ToEnum<EquipmentType>(request.Type), 
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
        var equipment = await FindOneAsync(id);
        equipment.Update(
            request.Name, 
            request.Description,
            Parser.ToEnumOptional<EquipmentType>(request.Type), 
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
}