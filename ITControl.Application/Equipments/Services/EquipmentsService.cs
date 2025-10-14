using ITControl.Application.Equipments.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Equipments.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Equipments.Services;

public class EquipmentsService(IUnitOfWork unitOfWork) : IEquipmentsService
{
    public async Task<Equipment> FindOneAsync(FindOneEquipmentsRequest request)
    {
        return await unitOfWork
            .EquipmentsRepository
            .FindOneAsync(request) 
               ?? throw new NotFoundException(Errors.EQUIPMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyEquipmentsRequest request, OrderByEquipmentsRequest orderByRequest)
    {
        return await unitOfWork.EquipmentsRepository.FindManyAsync(request, orderByRequest, request);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyEquipmentsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.EquipmentsRepository.CountAsync(request);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Equipment?> CreateAsync(CreateEquipmentsRequest request)
    {
        var equipment = new Equipment(request);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.EquipmentsRepository.CreateAsync(equipment);
        await unitOfWork.Commit(transaction);
        
        return equipment;
    }

    public async Task UpdateAsync(Guid id, UpdateEquipmentsRequest request)
    {
        var equipment = await FindOneAsync(new () { Id = id });
        equipment.Update(request);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Update(equipment);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var equipment = await FindOneAsync(new() { Id = id });
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Delete(equipment);
        await unitOfWork.Commit(transaction);
    }
}