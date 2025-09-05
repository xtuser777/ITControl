using ITControl.Domain.Contracts.Entities;

namespace ITControl.Domain.Contracts.Interfaces;

public interface IContractsContactsRepository
{
    Task<IEnumerable<ContractContact>> FindManyByContractIdAsync(Guid contractId);
    Task CreateManyAsync(IEnumerable<ContractContact> contractContacts);
    Task DeleteManyByContractAsync(Contract contract);
}