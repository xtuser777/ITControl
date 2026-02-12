using ITControl.Application.Contracts.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Contracts.Props;
using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.Systems.Params;

namespace ITControl.Application.Contracts.Services;

public class ContractsService(IUnitOfWork unitOfWork) : IContractsService
{
    public async Task<Contract> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
            .ContractsRepository
            .FindOneAsync(parameters) 
               ?? throw new NotFoundException(Errors.CONTRACT_NOT_FOUND);
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.ContractsRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.ContractsRepository
            .CountAsync(parameters.CountProps);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Contract?> CreateAsync(
        CreateServiceParams parameters)
    {
        var contract = new Contract((ContractProps)parameters.Props);
        var contractsContacts = 
            ((ContractProps)parameters.Props).ContractContacts!.ToList();
        contractsContacts.ForEach(cc => cc.ContractId = contract.Id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsRepository.CreateAsync(contract);
        await unitOfWork.ContractsContactsRepository
            .CreateManyAsync(contractsContacts);
        await unitOfWork.Commit(transaction);
        
        return contract;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var contract = await FindOneAsync(parameters);
        contract.Update((ContractProps)parameters.Props);
        var contractsContacts = 
            ((ContractProps)parameters.Props).ContractContacts!.ToList();
        contractsContacts.ForEach(cc => cc.ContractId = contract.Id);
        await unitOfWork.ContractsContactsRepository
            .DeleteManyByContractAsync(contract);
        await unitOfWork.ContractsContactsRepository
            .CreateManyAsync(contractsContacts);
        unitOfWork.ContractsRepository.Update(contract);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var contract = await FindOneAsync(parameters);
        await CheckDependenciesAsync(contract.Id ?? Guid.Empty);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ContractsContactsRepository
            .DeleteManyByContractAsync(contract);
        unitOfWork.ContractsRepository.Delete(contract);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(Guid contractId)
    {
        await CheckEquipmentDependenciesAsync(contractId);
        await CheckSystemDependenciesAsync(contractId);
    }

    private async Task CheckEquipmentDependenciesAsync(Guid contractId)
    {
        var equipments = await unitOfWork
            .EquipmentsRepository
            .CountAsync(
            new CountEquipmentsParams 
            { ContractId = contractId });
        if (equipments > 0)
        {
            throw new BadRequestException(
                $"O contrato possui vínculo com {equipments} equipamentos");
        }
    }

    private async Task CheckSystemDependenciesAsync(Guid contractId)
    {
        var systems = await unitOfWork
            .SystemsRepository
            .CountAsync(
            new CountSystemsParams
            { ContractId = contractId });
        if (systems > 0)
        {
            throw new BadRequestException(
                $"O contrato possui vínculo com {systems} sistemas");
        }
    }
}