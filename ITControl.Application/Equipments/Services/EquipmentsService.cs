using ITControl.Application.Equipments.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Calls.Params;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Equipments.Props;
using ITControl.Domain.Shared.Entities;
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

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.EquipmentsRepository
            .CountAsync(parameters.CountProps);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Equipment?> CreateAsync(
        CreateServiceParams parameters)
    {
        var equipment = new Equipment((EquipmentProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.EquipmentsRepository.CreateAsync(equipment);
        await unitOfWork.Commit(transaction);
        
        return equipment;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        var equipment = await FindOneAsync(parameters);
        equipment.Update((EquipmentProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Update(equipment);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var equipment = await FindOneAsync(parameters);
        await CheckDependenciesAsync(equipment.Id ?? Guid.Empty);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.EquipmentsRepository.Delete(equipment);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(Guid equipmentId)
    {
        await CheckCallDependenciesAsync(equipmentId);
        await CheckUserEquipmentDependenciesAsync(equipmentId);
    }

    private async Task CheckCallDependenciesAsync(Guid equipmentId)
    {
        var callCount = await unitOfWork.CallsRepository
            .CountAsync(new FindManyCallsParams
            {
                EquipmentId = equipmentId
            });
        if (callCount > 0)
        {
            throw new BadRequestException(
                $"O equipamento tem {callCount} chamados");
        }
    }

    private async Task CheckUserEquipmentDependenciesAsync(Guid equipmentId)
    {
        var usersEquipments = await unitOfWork
            .UsersEquipmentsRepository
            .FindManyAsync(equipmentId: equipmentId);
        if (usersEquipments.Any())
        {
            throw new BadRequestException(
                $"O equipamento tem vínculo com {usersEquipments.Count()} usuários");
        }
    }
}