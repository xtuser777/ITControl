using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Contracts.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class ContractsService(IUnitOfWork unitOfWork) : IContractsService
{
    public async Task<Contract?> FindOneAsync(Guid id, bool? includeContractsContacts = null)
    {
        return await unitOfWork.ContractsRepository.FindOneAsync(id, includeContractsContacts);
    }

    public async Task<Contract> FindOneOrThrowAsync(Guid id, bool? includeContractsContacts = null)
    {
        var contract = await FindOneAsync(id, includeContractsContacts);
        if (contract == null)
            throw new NotFoundException("Contract not found");
        
        return contract;
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(FindManyContractsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.ContractsRepository.FindManyAsync(
            objectValue: request.Object,
            startedAt: request.StartedAt != null ? DateOnly.Parse(request.StartedAt) : null,
            endedAt: request.EndedAt != null ? DateOnly.Parse(request.EndedAt) : null,
            orderByObject: request.OrderByObject,
            orderByStartedAt: request.OrderByStartedAt,
            orderByEndedAt: request.OrderByEndedAt,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyContractsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.ContractsRepository.CountAsync(
            objectValue: request.Object,
            startedAt: request.StartedAt != null ? DateOnly.Parse(request.StartedAt) : null,
            endedAt: request.EndedAt != null ? DateOnly.Parse(request.EndedAt) : null);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Contract?> CreateAsync(CreateContractsRequest request)
    {
        var contract = new Contract(
            request.Object,
            DateOnly.Parse(request.StartedAt),
            request.EndedAt != null ? DateOnly.Parse(request.EndedAt) : null);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsRepository.CreateAsync(contract);
        await unitOfWork.Commit(transaction);
        
        return contract;
    }

    public async Task UpdateAsync(Guid id, UpdateContractsRequest request)
    {
        var contract = await FindOneOrThrowAsync(id);
        contract.Update(
            request.Object, 
            request.StartedAt != null ? DateOnly.Parse(request.StartedAt) : null, 
            request.EndedAt != null ? DateOnly.Parse(request.EndedAt) : null);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsRepository.UpdateAsync(contract);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var contract = await FindOneOrThrowAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsRepository.DeleteAsync(contract);
        await unitOfWork.Commit(transaction);
    }
}