using ITControl.Application.Equipments.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Equipments.Services;

public class EquipmentsService(IUnitOfWork unitOfWork) : IEquipmentsService
{
    public async Task<Equipment> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
            .EquipmentsRepository
            .FindOneAsync(parameters) 
               ?? throw new NotFoundException(Errors.EQUIPMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.EquipmentsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.EquipmentsRepository
            .CountAsync(parameters.CountParams);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Equipment?> CreateAsync(
        CreateServiceParams parameters)
    {
        var equipment = new Equipment((EquipmentParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.EquipmentsRepository.CreateAsync(equipment);
        await unitOfWork.Commit(transaction);
        
        return equipment;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        var equipment = await FindOneAsync(parameters);
        equipment.Update((UpdateEquipmentParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Update(equipment);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var equipment = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Delete(equipment);
        await unitOfWork.Commit(transaction);
    }
}