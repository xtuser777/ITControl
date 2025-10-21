using ITControl.Application.Contracts.Interfaces;
using ITControl.Application.Contracts.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Contracts.Services;

public class ContractsService(IUnitOfWork unitOfWork) : IContractsService
{
    public async Task<Contract> FindOneAsync(
        FindOneContractsServiceParams findOneParams)
    {
        return await unitOfWork
            .ContractsRepository
            .FindOneAsync(findOneParams) 
               ?? throw new NotFoundException(Errors.CONTRACT_NOT_FOUND);
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(
        FindManyContractsServiceParams findManyParams)
    {
        return await unitOfWork.ContractsRepository.FindManyAsync(
            findManyParams.FindManyParams,
            findManyParams.OrderByParams,
            findManyParams.PaginationParams);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationContractsServiceParams paginationParams)
    {
        var (page, size) =  paginationParams;
        if (page == null || size == null) return null;
        
        var count = await unitOfWork.ContractsRepository
            .CountAsync(paginationParams);
        
        var pagination = Pagination.Build(page, size, count);
        
        return pagination;
    }

    public async Task<Contract?> CreateAsync(
        CreateContractsServiceParams createParams)
    {
        var contract = new Contract(createParams.Params);
        var contractsContacts = createParams.ContactsRequest
            .Select(x => new ContractContact(contract.Id, x)).ToList();
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsRepository.CreateAsync(contract);
        await unitOfWork.ContractsContactsRepository
            .CreateManyAsync(contractsContacts);
        await unitOfWork.Commit(transaction);
        
        return contract;
    }

    public async Task UpdateAsync(
        UpdateContractsServiceParams updateParams)
    {
        var contract = await FindOneAsync(updateParams);
        contract.Update(updateParams.Params);
        var contractsContacts = updateParams.ContactsRequest
            .Select(x => new ContractContact(
            contract.Id, x)).ToList();
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsContactsRepository
            .DeleteManyByContractAsync(contract);
        await unitOfWork.ContractsContactsRepository
            .CreateManyAsync(contractsContacts);
        unitOfWork.ContractsRepository.Update(contract);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteContractsServiceParams deleteParams)
    {
        var contract = await FindOneAsync(deleteParams);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsContactsRepository
            .DeleteManyByContractAsync(contract);
        unitOfWork.ContractsRepository.Delete(contract);
        await unitOfWork.Commit(transaction);
    }
}