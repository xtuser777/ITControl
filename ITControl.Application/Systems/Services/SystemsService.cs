using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Systems.Interfaces;
using ITControl.Domain.Calls.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Systems.Props;

namespace ITControl.Application.Systems.Services;

public class SystemsService(IUnitOfWork unitOfWork) : ISystemsService
{
    public async Task<Domain.Systems.Entities.SystemEntity> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork.SystemsRepository
            .FindOneAsync(parameters)
               ?? throw new NotFoundException(Errors.SYSTEM_NOT_FOUND);
    }

    public async Task<IEnumerable<Domain.Systems.Entities.SystemEntity>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.SystemsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.SystemsRepository
            .CountAsync(parameters.CountProps);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Domain.Systems.Entities.SystemEntity?> CreateAsync(
        CreateServiceParams parameters)
    {
        var system = 
            new Domain.Systems.Entities.SystemEntity(
                (SystemProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SystemsRepository.CreateAsync(system);
        await unitOfWork.Commit(transaction);
        return system;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        var system = await FindOneAsync(parameters);
        system.Update((SystemProps)parameters.Props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Update(system);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var system = await FindOneAsync(parameters);
        await CheckDependenciesAsync(system.Id ?? Guid.Empty);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Delete(system);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(Guid systemId)
    {
        await CheckCallDependenciesAsync(systemId);
        await CheckUserSystemDependenciesAsync(systemId);
    }

    private async Task CheckCallDependenciesAsync(Guid systemId)
    {
        var callCount = await unitOfWork.CallsRepository
            .CountAsync(new FindManyCallsParams
            {
                SystemId = systemId
            });
        if (callCount > 0)
        {
            throw new BadRequestException(
                $"O sistema tem relação com {callCount} chamados");
        }
    }

    private async Task CheckUserSystemDependenciesAsync(Guid systemId)
    {
        var userSystemCount = await unitOfWork.UsersSystemsRepository
            .FindManyAsync(systemId: systemId);
        if (userSystemCount.Any())
        {
            throw new BadRequestException(
                $"O sistema tem relação com {userSystemCount.Count()} usuários");
        }
    }
}