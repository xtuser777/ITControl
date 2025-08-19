using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Systems.Requests;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class SystemsService(IUnitOfWork unitOfWork) : ISystemsService
{
    public async Task<Domain.Entities.System?> FindOneAsync(
        Guid id, bool? includeContractsContacts = null)
    {
        return await unitOfWork.SystemsRepository
            .FindOneAsync( x => x.Id == id, includeContractsContacts);
    }

    public async Task<Domain.Entities.System> FindOneOrThrowAsync(
        Guid id, bool? includeContractsContacts = null)
    {
        return await FindOneAsync(id) 
            ?? throw new NotFoundException("System not found");
    }

    public async Task<IEnumerable<Domain.Entities.System>> FindManyAsync(FindManySystemsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.SystemsRepository.FindManyAsync(
            name: request.Name,
            version: request.Version,
            implementedAt: Parser.ToDateOnlyOptional(request.ImplementedAt),
            endedAt: Parser.ToDateOnlyOptional(request.EndedAt),
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
            implementedAt: Parser.ToDateOnlyOptional(request.ImplementedAt),
            endedAt: Parser.ToDateOnlyOptional(request.EndedAt),
            own: Parser.ToBoolOptional(request.Own));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Domain.Entities.System?> CreateAsync(CreateSystemsRequest request)
    {
        await CheckExistence(request.ContractId != null ? Guid.Parse(request.ContractId) : null);
        var system = new Domain.Entities.System(
            request.Name,
            request.Version,
            implementedAt: Parser.ToDateOnly(request.ImplementedAt),
            endedAt: Parser.ToDateOnlyOptional(request.EndedAt),
            request.Own,
            Parser.ToGuidOptional(request.ContractId));
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SystemsRepository.CreateAsync(system);
        await unitOfWork.Commit(transaction);
        
        return system;
    }

    public async Task UpdateAsync(Guid id, UpdateSystemsRequest request)
    {
        await CheckExistence(request.ContractId != null ? Guid.Parse(request.ContractId) : null);
        var system = await FindOneOrThrowAsync(id);
        system.Update(
            name: request.Name,
            version: request.Version,
            implementedAt: Parser.ToDateOnlyOptional(request.ImplementedAt),
            endedAt: Parser.ToDateOnlyOptional(request.EndedAt),
            own: request.Own,
            Parser.ToGuidOptional(request.ContractId));
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SystemsRepository.Update(system);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var system = await FindOneOrThrowAsync(id);
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