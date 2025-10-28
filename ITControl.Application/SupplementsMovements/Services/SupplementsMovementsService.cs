using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.SupplementsMovements.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.SupplementsMovements.Entities;
using ITControl.Domain.SupplementsMovements.Params;

namespace ITControl.Application.SupplementsMovements.Services;

public class SupplementsMovementsService(
    IUnitOfWork unitOfWork) : ISupplementsMovementsService
{
    public async Task<SupplementMovement> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork.SupplementsMovementsRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.SupplementMovimentNotFound);
    }

    public async Task<IEnumerable<SupplementMovement>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork
            .SupplementsMovementsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork
            .SupplementsMovementsRepository
            .CountAsync(parameters.CountParams);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<SupplementMovement> CreateAsync(
        CreateServiceParams parameters)
    {
        var supplementMovement = 
            new SupplementMovement((SupplementMovementParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SupplementsMovementsRepository
            .CreateAsync(supplementMovement);
        await DecrementSupplementStock(
            ((SupplementMovementParams)parameters.Params).SupplementId, 
            ((SupplementMovementParams)parameters.Params).Quantity);
        await unitOfWork.Commit(transaction);

        return supplementMovement;
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var supplementMovement = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        await AddSupplementStock(
            supplementMovement.SupplementId, 
            supplementMovement.Quantity);
        unitOfWork.SupplementsMovementsRepository
            .Delete(supplementMovement);
        await unitOfWork.Commit(transaction);
    }

    private async Task DecrementSupplementStock(Guid supplementId, int quantity)
    {
        var findOneParams = new FindOneRepositoryParams { Id = supplementId };
        var supplement = await unitOfWork
            .SupplementsRepository.FindOneAsync(findOneParams);
        if (supplement != null)
        {
            var newQuantity = supplement.QuantityInStock - quantity;
            supplement.Update(
                new () { QuantityInStock = newQuantity });
            unitOfWork.SupplementsRepository.Update(supplement);
        }
    }

    private async Task AddSupplementStock(Guid supplementId, int quantity)
    {
        var findOneParams = new FindOneRepositoryParams { Id = supplementId };
        var supplement = await unitOfWork
            .SupplementsRepository.FindOneAsync(findOneParams);
        if (supplement != null)
        {
            var newQuantity = supplement.QuantityInStock + quantity;
            supplement.Update(
                new () { QuantityInStock = newQuantity });
            unitOfWork.SupplementsRepository.Update(supplement);
        }
    }
}
