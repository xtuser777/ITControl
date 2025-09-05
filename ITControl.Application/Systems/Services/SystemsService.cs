using ITControl.Application.Interfaces;
using ITControl.Application.Systems.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Systems.Requests;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Systems.Services;

public class SystemsService(IUnitOfWork unitOfWork) : ISystemsService
{
    public async Task<Domain.Systems.Entities.System> FindOneAsync(
        Guid id, bool? includeContractsContacts = null)
    {
        return await unitOfWork.SystemsRepository
            .FindOneAsync(id, includeContractsContacts)
               ?? throw new NotFoundException("System not found");
    }

    public async Task<IEnumerable<Domain.Systems.Entities.System>> FindManyAsync(FindManySystemsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.SystemsRepository.FindManyAsync(
            name: request.Name,
            version: request.Version,
            implementedAt: request.ImplementedAt,
            endedAt: request.EndedAt,
            own: Parser.ToBoolOptional(request.Own),
            orderByName: request.OrderByName,
            orderByVersion: request.OrderByVersion,
            orderByImplementedAt: request.OrderByImplementedAt,
            orderByEndedAt: request.OrderByEndedAt,
            orderByOwn: request.OrderByOwn,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManySystemsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.SystemsRepository.CountAsync(
            name: request.Name,
            version: request.Version,
            implementedAt: request.ImplementedAt,
            endedAt: request.EndedAt,
            own: Parser.ToBoolOptional(request.Own));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Domain.Systems.Entities.System?> CreateAsync(CreateSystemsRequest request)
    {
        await CheckExistence(request.ContractId);
        var system = new Domain.Entities.System(
            request.Name,
            request.Version,
            implementedAt: request.ImplementedAt,
            endedAt: request.EndedAt,
            request.Own,
            request.ContractId);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SystemsRepository.CreateAsync(system);
        await unitOfWork.Commit(transaction);
        
        return system;
    }

    public async Task UpdateAsync(Guid id, UpdateSystemsRequest request)
    {
        await CheckExistence(request.ContractId);
        var system = await FindOneAsync(id);
        system.Update(
            name: request.Name,
            version: request.Version,
            implementedAt: request.ImplementedAt,
            endedAt: request.EndedAt,
            own: request.Own,
            request.ContractId);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Update(system);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var system = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Delete(system);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckExistence(Guid? contractId)
    {
        var messages = new List<string>();

        if (contractId != null) await CheckContractExistence((Guid)contractId, messages);
        
        if (messages.Count > 0) throw new NotFoundException(string.Join(",", messages));
    }

    private async Task CheckContractExistence(Guid contractId, List<string> messages)
    {
        var exists = await unitOfWork.ContractsRepository.ExistsAsync(contractId);
        if (!exists)
            messages.Add("Contract not found");
    }
}