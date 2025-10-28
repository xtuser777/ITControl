using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Systems.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Systems.Params;

namespace ITControl.Application.Systems.Services;

public class SystemsService(IUnitOfWork unitOfWork) : ISystemsService
{
    public async Task<Domain.Systems.Entities.System> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork.SystemsRepository
            .FindOneAsync(parameters)
               ?? throw new NotFoundException(Errors.SYSTEM_NOT_FOUND);
    }

    public async Task<IEnumerable<Domain.Systems.Entities.System>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.SystemsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.SystemsRepository
            .CountAsync(parameters.CountParams);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Domain.Systems.Entities.System?> CreateAsync(
        CreateServiceParams parameters)
    {
        var system = 
            new Domain.Systems.Entities.System(
                (SystemParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SystemsRepository.CreateAsync(system);
        await unitOfWork.Commit(transaction);
        return system;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        var system = await FindOneAsync(parameters);
        system.Update((UpdateSystemParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Update(system);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var system = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Delete(system);
        await unitOfWork.Commit(transaction);
    }
}