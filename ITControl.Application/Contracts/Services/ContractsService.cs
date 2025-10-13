using ITControl.Application.Contracts.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Contracts.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Contracts.Services;

public class ContractsService(IUnitOfWork unitOfWork) : IContractsService
{
    public async Task<Contract> FindOneAsync(FindOneContractsRequest request)
    {
        return await unitOfWork
            .ContractsRepository
            .FindOneAsync(request) 
               ?? throw new NotFoundException(Errors.CONTRACT_NOT_FOUND);
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(
        FindManyContractsRequest findManyRequest,
        OrderByContractsRequest orderByRequest)
    {
        return await unitOfWork.ContractsRepository.FindManyAsync(findManyRequest, orderByRequest);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyContractsRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.ContractsRepository.CountAsync(request);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Contract?> CreateAsync(CreateContractsRequest request)
    {
        var contract = new Contract(request);
        var contractsContacts = request
            .Contacts
            .Select(x => new ContractContact(contract.Id, x)).ToList();
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsRepository.CreateAsync(contract);
        await unitOfWork.ContractsContactsRepository.CreateManyAsync(contractsContacts);
        await unitOfWork.Commit(transaction);
        
        return contract;
    }

    public async Task UpdateAsync(Guid id, UpdateContractsRequest request)
    {
        var contract = await FindOneAsync(new () { Id = id });
        contract.Update(request);
        var contractsContacts = request.Contacts.Select(x => new ContractContact(
            contract.Id, x)).ToList();
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsContactsRepository.DeleteManyByContractAsync(contract);
        await unitOfWork.ContractsContactsRepository.CreateManyAsync(contractsContacts);
        unitOfWork.ContractsRepository.Update(contract);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var contract = await FindOneAsync(new() { Id = id });
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsContactsRepository.DeleteManyByContractAsync(contract);
        unitOfWork.ContractsRepository.Delete(contract);
        await unitOfWork.Commit(transaction);
    }
}