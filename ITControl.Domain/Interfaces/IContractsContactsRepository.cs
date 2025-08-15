using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IContractsContactsRepository
{
    Task<IEnumerable<ContractContact>> FindManyByContractIdAsync(Guid contractId);
    Task CreateManyAsync(IEnumerable<ContractContact> contractContacts);
    Task DeleteManyByContractAsync(Contract contract);
}