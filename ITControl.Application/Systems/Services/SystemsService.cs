using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Systems.Interfaces;
using ITControl.Application.Systems.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Systems.Services;

public class SystemsService(IUnitOfWork unitOfWork) : ISystemsService
{
    public async Task<Domain.Systems.Entities.System> FindOneAsync(
        FindOneSystemsServiceParams parameters)
    {
        return await unitOfWork.SystemsRepository
            .FindOneAsync(parameters)
               ?? throw new NotFoundException(Errors.SYSTEM_NOT_FOUND);
    }

    public async Task<IEnumerable<Domain.Systems.Entities.System>> FindManyAsync(
        FindManySystemsServiceParams parameters)
    {
        return await unitOfWork.SystemsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationSystemsServiceParams parameters)
    {
        var (page, size) = parameters;
        if (page == null || size == null) return null;
        
        var count = await unitOfWork.SystemsRepository
            .CountAsync(parameters);
        
        var pagination = Pagination.Build(page, size, count);
        
        return pagination;
    }

    public async Task<Domain.Systems.Entities.System?> CreateAsync(
        CreateSystemsServiceParams parameters)
    {
        var system = new Domain.Systems.Entities.System(
            parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SystemsRepository.CreateAsync(system);
        await unitOfWork.Commit(transaction);
        
        return system;
    }

    public async Task UpdateAsync(UpdateSystemsServiceParams parameters)
    {
        var system = await FindOneAsync(parameters);
        system.Update(parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Update(system);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteSystemsServiceParams parameters)
    {
        var system = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Delete(system);
        await unitOfWork.Commit(transaction);
    }
}