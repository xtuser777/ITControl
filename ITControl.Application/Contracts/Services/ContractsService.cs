using ITControl.Application.Contracts.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Contracts.Services;

public class ContractsService(IUnitOfWork unitOfWork) : IContractsService
{
    public async Task<Contract> FindOneAsync(
        FindOneServiceParams findOneParams)
    {
        return await unitOfWork
            .ContractsRepository
            .FindOneAsync(findOneParams) 
               ?? throw new NotFoundException(Errors.CONTRACT_NOT_FOUND);
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(
        FindManyServiceParams findManyParams)
    {
        return await unitOfWork.ContractsRepository
            .FindManyAsync(findManyParams);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams paginationParams)
    {
        var count = await unitOfWork.ContractsRepository
            .CountAsync(paginationParams.CountParams);
        var pagination = 
            Pagination.Build(paginationParams.PaginationParams, count);
        return pagination;
    }

    public async Task<Contract?> CreateAsync(
        CreateServiceParams createParams)
    {
        var contract = new Contract((ContractParams)createParams.Params);
        var contractsContacts = 
            ((ContractParams)createParams.Params).ContractContacts.ToList();
        contractsContacts.ForEach(cc => cc.ContractId = contract.Id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsRepository.CreateAsync(contract);
        await unitOfWork.ContractsContactsRepository
            .CreateManyAsync(contractsContacts);
        await unitOfWork.Commit(transaction);
        
        return contract;
    }

    public async Task UpdateAsync(
        UpdateServiceParams updateParams)
    {
        var contract = await FindOneAsync(updateParams);
        contract.Update((UpdateContractParams)updateParams.Params);
        var contractsContacts = 
            ((UpdateContractParams)updateParams.Params).ContractContacts.ToList();
        contractsContacts.ForEach(cc => cc.ContractId = contract.Id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsContactsRepository
            .DeleteManyByContractAsync(contract);
        await unitOfWork.ContractsContactsRepository
            .CreateManyAsync(contractsContacts);
        unitOfWork.ContractsRepository.Update(contract);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams deleteParams)
    {
        var contract = await FindOneAsync(deleteParams);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsContactsRepository
            .DeleteManyByContractAsync(contract);
        unitOfWork.ContractsRepository.Delete(contract);
        await unitOfWork.Commit(transaction);
    }
}