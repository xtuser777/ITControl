using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Application.Utils;
using ITControl.Communication.Contracts.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class ContractsService(IUnitOfWork unitOfWork) : IContractsService
{
    public async Task<Contract?> FindOneAsync(Guid id, bool? includeContractsContacts = null)
    {
        return await unitOfWork
            .ContractsRepository
            .FindOneAsync(x => x.Id == id, includeContractsContacts);
    }

    public async Task<Contract> FindOneOrThrowAsync(Guid id, bool? includeContractsContacts = null)
    {
        return await FindOneAsync(id, includeContractsContacts) 
            ?? throw new NotFoundException("Contract not found");
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(FindManyContractsRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        return await unitOfWork.ContractsRepository.FindManyAsync(
            objectName: request.ObjectName,
            startedAt: Parser.ToDateOnlyOptional(request.StartedAt),
            endedAt: Parser.ToDateOnlyOptional(request.EndedAt),
            orderByObjectName: request.OrderByObjectName,
            orderByStartedAt: request.OrderByStartedAt,
            orderByEndedAt: request.OrderByEndedAt,
            page: page,
            size: size);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyContractsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.ContractsRepository.CountAsync(
            objectName: request.ObjectName,
            startedAt: Parser.ToDateOnlyOptional(request.StartedAt),
            endedAt: Parser.ToDateOnlyOptional(request.EndedAt));
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Contract?> CreateAsync(CreateContractsRequest request)
    {
        var contract = new Contract(
            request.ObjectName,
            Parser.ToDateOnly(request.StartedAt),
            Parser.ToDateOnlyOptional(request.EndedAt));
        var contractsContacts = request.Contacts.Select(x => new ContractContact(
            x.Name,
            x.Email,
            x.Phone,
            x.Cellphone,
            contract.Id)).ToList();
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsRepository.CreateAsync(contract);
        await unitOfWork.ContractsContactsRepository.CreateManyAsync(contractsContacts);
        await unitOfWork.Commit(transaction);
        
        return contract;
    }

    public async Task UpdateAsync(Guid id, UpdateContractsRequest request)
    {
        var contract = await FindOneOrThrowAsync(id);
        contract.Update(
            request.ObjectName,
            Parser.ToDateOnlyOptional(request.StartedAt),
            Parser.ToDateOnlyOptional(request.EndedAt));
        var contractsContacts = request.Contacts.Select(x => new ContractContact(
            x.Name,
            x.Email,
            x.Phone,
            x.Cellphone,
            contract.Id)).ToList();
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsContactsRepository.DeleteManyByContractAsync(contract);
        await unitOfWork.ContractsContactsRepository.CreateManyAsync(contractsContacts);
        unitOfWork.ContractsRepository.Update(contract);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var contract = await FindOneOrThrowAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsContactsRepository.DeleteManyByContractAsync(contract);
        unitOfWork.ContractsRepository.Delete(contract);
        await unitOfWork.Commit(transaction);
    }
}