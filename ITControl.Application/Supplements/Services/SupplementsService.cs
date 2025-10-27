using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Supplements.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Supplements.Entities;
using ITControl.Domain.Supplements.Params;

namespace ITControl.Application.Supplements.Services;

public class SupplementsService(
    IUnitOfWork unitOfWork) : ISupplementsService
{
    public async Task<Supplement> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
                   .SupplementsRepository
                   .FindOneAsync(parameters) 
            ?? throw new NotFoundException(Errors.SUPPLEMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Supplement>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork
            .SupplementsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationResponse?> FindManyPagination(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork
            .SupplementsRepository
            .CountAsync(parameters.CountParams);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Supplement?> CreateAsync(
        CreateServiceParams parameters)
    {
        var supplement = 
            new Supplement((SupplementParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SupplementsRepository.CreateAsync(supplement);
        await unitOfWork.Commit(transaction);

        return supplement;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        var supplement = await FindOneAsync(parameters);
        supplement.Update((UpdateSupplementParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SupplementsRepository.Update(supplement);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var supplement = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SupplementsRepository.Delete(supplement);
        await unitOfWork.Commit(transaction);
    }
}
