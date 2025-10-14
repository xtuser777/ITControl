using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Systems.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Systems.Requests;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Systems.Services;

public class SystemsService(IUnitOfWork unitOfWork) : ISystemsService
{
    public async Task<Domain.Systems.Entities.System> FindOneAsync(FindOneSystemsRequest request)
    {
        return await unitOfWork.SystemsRepository
            .FindOneAsync(request)
               ?? throw new NotFoundException(Errors.SYSTEM_NOT_FOUND);
    }

    public async Task<IEnumerable<Domain.Systems.Entities.System>> FindManyAsync(
        FindManySystemsRequest request, OrderBySystemsRequest orderByRequest)
    {
        return await unitOfWork.SystemsRepository.FindManyAsync(request, orderByRequest, request);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManySystemsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.SystemsRepository.CountAsync(request);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Domain.Systems.Entities.System?> CreateAsync(CreateSystemsRequest request)
    {
        var system = new Domain.Systems.Entities.System(request);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SystemsRepository.CreateAsync(system);
        await unitOfWork.Commit(transaction);
        
        return system;
    }

    public async Task UpdateAsync(Guid id, UpdateSystemsRequest request)
    {
        var system = await FindOneAsync(new () { Id = id });
        system.Update(request);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Update(system);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var system = await FindOneAsync(new() { Id = id });
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Delete(system);
        await unitOfWork.Commit(transaction);
    }
}