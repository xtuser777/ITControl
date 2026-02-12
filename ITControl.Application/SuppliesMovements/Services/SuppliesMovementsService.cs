using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Application.SuppliesMovements.Interfaces;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.SuppliesMovements.Entities;
using ITControl.Domain.SuppliesMovements.Props;

namespace ITControl.Application.SuppliesMovements.Services;

public class SuppliesMovementsService(
    IUnitOfWork unitOfWork) : ISuppliesMovementsService
{
    public async Task<SupplyMovement> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork.SuppliesMovementsRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.SupplyMovimentNotFound);
    }

    public async Task<IEnumerable<SupplyMovement>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork
            .SuppliesMovementsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork
            .SuppliesMovementsRepository
            .CountAsync(parameters.CountProps);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<SupplyMovement> CreateAsync(
        CreateServiceParams parameters)
    {
        var supplyMovement = 
            new SupplyMovement((SupplyMovementProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SuppliesMovementsRepository
            .CreateAsync(supplyMovement);
        await DecrementSupplyStock(
            (Guid)((SupplyMovementProps)parameters.Props).SupplyId!, 
            (int)((SupplyMovementProps)parameters.Props).Quantity!);
        await unitOfWork.Commit(transaction);

        return supplyMovement;
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var supplyMovement = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        await AddSupplyStock(
            (Guid)supplyMovement.SupplyId!, 
            (int)supplyMovement.Quantity!);
        unitOfWork.SuppliesMovementsRepository
            .Delete(supplyMovement);
        await unitOfWork.Commit(transaction);
    }

    private async Task DecrementSupplyStock(Guid supplyId, int quantity)
    {
        var findOneParams = new FindOneRepositoryParams { Id = supplyId };
        var supply = await unitOfWork
            .SuppliesRepository.FindOneAsync(findOneParams);
        if (supply != null)
        {
            var newQuantity = supply.QuantityInStock - quantity;
            supply.Update(
                new () { QuantityInStock = newQuantity });
            unitOfWork.SuppliesRepository.Update(supply);
        }
    }

    private async Task AddSupplyStock(Guid supplyId, int quantity)
    {
        var findOneParams = new FindOneRepositoryParams { Id = supplyId };
        var supply = await unitOfWork
            .SuppliesRepository.FindOneAsync(findOneParams);
        if (supply != null)
        {
            var newQuantity = supply.QuantityInStock + quantity;
            supply.Update(
                new () { QuantityInStock = newQuantity });
            unitOfWork.SuppliesRepository.Update(supply);
        }
    }
}
