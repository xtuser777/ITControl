using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Supplies.Interfaces;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Supplies.Entities;
using ITControl.Domain.Supplies.Props;
using ITControl.Domain.SuppliesMovements.Params;

namespace ITControl.Application.Supplies.Services;

public class SuppliesService(
    IUnitOfWork unitOfWork) : ISuppliesService
{
    public async Task<Supply> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
                   .SuppliesRepository
                   .FindOneAsync(parameters) 
            ?? throw new NotFoundException(Errors.SUPPLY_NOT_FOUND);
    }

    public async Task<IEnumerable<Supply>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork
            .SuppliesRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPagination(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork
            .SuppliesRepository
            .CountAsync(parameters.CountProps);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Supply?> CreateAsync(
        CreateServiceParams parameters)
    {
        var supply = 
            new Supply((SupplyProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SuppliesRepository.CreateAsync(supply);
        await unitOfWork.Commit(transaction);

        return supply;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        var supply = await FindOneAsync(parameters);
        supply.Update((SupplyProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SuppliesRepository.Update(supply);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var supply = await FindOneAsync(parameters);
        await CheckDependenciesAsync(supply.Id ?? Guid.Empty);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SuppliesRepository.Delete(supply);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(
        Guid supplyId)
    {
        await CheckSupplyMovementDependenciesAsync(supplyId);
    }

    private async Task CheckSupplyMovementDependenciesAsync(
        Guid supplyId)
    {
        var supplyMovementCount = await unitOfWork.SuppliesMovementsRepository
            .CountAsync(new FindManySuppliesMovementsParams
            {
                SupplyId = supplyId
            });
        if (supplyMovementCount > 0)
        {
            throw new BadRequestException(
                $"O suplemento possui {supplyMovementCount} movimentações de suplemento");
        }
    }
}
