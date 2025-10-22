using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.SupplementsMovements.Interfaces;
using ITControl.Application.SupplementsMovements.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.SupplementsMovements.Requests;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Shared.Params2;
using ITControl.Domain.SupplementsMovements.Entities;

namespace ITControl.Application.SupplementsMovements.Services;

public class SupplementsMovementsService(
    IUnitOfWork unitOfWork) : ISupplementsMovementsService
{
    public async Task<SupplementMovement> FindOneAsync(
        FindOneSupplementsMovementsServiceParams @params)
    {
        return await unitOfWork.SupplementsMovementsRepository
            .FindOneAsync(@params)
            ?? throw new NotFoundException(Errors.SupplementMovimentNotFound);
    }

    public async Task<IEnumerable<SupplementMovement>> FindManyAsync(
        FindManySupplementsMovementsServiceParams @params)
    {
        return await unitOfWork
            .SupplementsMovementsRepository
            .FindManyAsync(@params);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationSupplementsMovementsServiceParams @params)
    {
        var (page, size) = @params;
        if (page == null || size == null) return null;
        var count = await unitOfWork
            .SupplementsMovementsRepository
            .CountAsync(@params);
        var pagination = Pagination.Build(page, size, count);
        return pagination;
    }

    public async Task<SupplementMovement> CreateAsync(
        CreateSupplementsMovementsServiceParams @params)
    {
        var supplementMovement = new SupplementMovement(@params.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SupplementsMovementsRepository.CreateAsync(supplementMovement);
        await DecrementSupplementStock(
            @params.Params.SupplementId, 
            @params.Params.Quantity);
        await unitOfWork.Commit(transaction);

        return supplementMovement;
    }

    public async Task DeleteAsync(
        DeleteSupplementsMovementsServiceParams @params)
    {
        var supplementMovement = await FindOneAsync(@params);
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
