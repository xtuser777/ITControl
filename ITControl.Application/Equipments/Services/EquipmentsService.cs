using ITControl.Application.Equipments.Interfaces;
using ITControl.Application.Equipments.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Equipments.Services;

public class EquipmentsService(IUnitOfWork unitOfWork) : IEquipmentsService
{
    public async Task<Equipment> FindOneAsync(
        FindOneEquipmentsServiceParams @params)
    {
        return await unitOfWork
            .EquipmentsRepository
            .FindOneAsync(@params) 
               ?? throw new NotFoundException(Errors.EQUIPMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyEquipmentsServiceParams @params)
    {
        return await unitOfWork.EquipmentsRepository.FindManyAsync(
            @params.FindManyParams, 
            @params.OrderByParams, 
            @params.PaginationParams);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationEquipmentsServiceParams @params)
    {
        if (@params.Page == null || @params.Size == null) return null;
        
        var count = await unitOfWork.EquipmentsRepository
            .CountAsync(@params.CountParams);
        
        var pagination = Pagination.Build(@params.Page, @params.Size, count);
        
        return pagination;
    }

    public async Task<Equipment?> CreateAsync(
        CreateEquipmentsServiceParams @params)
    {
        var equipment = new Equipment(@params.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.EquipmentsRepository.CreateAsync(equipment);
        await unitOfWork.Commit(transaction);
        
        return equipment;
    }

    public async Task UpdateAsync(
        UpdateEquipmentsServiceParams @params)
    {
        var equipment = await FindOneAsync(@params);
        equipment.Update(@params.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Update(equipment);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteEquipmentsServiceParams @params)
    {
        var equipment = await FindOneAsync(@params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Delete(equipment);
        await unitOfWork.Commit(transaction);
    }
}