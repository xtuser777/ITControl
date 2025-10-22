using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Supplements.Interfaces;
using ITControl.Application.Supplements.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Supplements.Entities;

namespace ITControl.Application.Supplements.Services;

public class SupplementsService(
    IUnitOfWork unitOfWork) : ISupplementsService
{
    public async Task<Supplement> FindOneAsync(
        FindOneSupplementsServiceParams @params)
    {
        return await unitOfWork
                   .SupplementsRepository
                   .FindOneAsync(@params) 
            ?? throw new NotFoundException(Errors.SUPPLEMENT_NOT_FOUND);
    }

    public async Task<IEnumerable<Supplement>> FindManyAsync(
        FindManySupplementsServiceParams @params)
    {
        return await unitOfWork
            .SupplementsRepository
            .FindManyAsync(@params);
    }

    public async Task<PaginationResponse?> FindManyPagination(
        FindManyPaginationSupplementsServiceParams @params)
    {
        var (page, size) = @params;
        if (page == null || size == null) return null;
        var count = await unitOfWork
            .SupplementsRepository
            .CountAsync(@params);
        var pagination = Pagination.Build(page, size, count);
        return pagination;
    }

    public async Task<Supplement?> CreateAsync(
        CreateSupplementsServiceParams @params)
    {
        var supplement = new Supplement(@params.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SupplementsRepository.CreateAsync(supplement);
        await unitOfWork.Commit(transaction);

        return supplement;
    }

    public async Task UpdateAsync(
        UpdateSupplementsServiceParams @params)
    {
        var supplement = await FindOneAsync(@params);
        supplement.Update(@params.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SupplementsRepository.Update(supplement);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteSupplementsServiceParams @params)
    {
        var supplement = await FindOneAsync(@params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SupplementsRepository.Delete(supplement);
        await unitOfWork.Commit(transaction);
    }
}
