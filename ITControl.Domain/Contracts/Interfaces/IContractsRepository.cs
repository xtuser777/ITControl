using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Contracts.Params;

namespace ITControl.Domain.Contracts.Interfaces;

public interface IContractsRepository
{
    Task<Contract?> FindOneAsync(FindOneContractsRepositoryParams @params);
    Task<IEnumerable<Contract>> FindManyAsync(
        FindManyContractsRepositoryParams findManyParams, 
        OrderByContractsRepositoryParams orderByParams);
    Task CreateAsync(Contract contract);
    void Update(Contract contract);
    void Delete(Contract contract);
    Task<int> CountAsync(CountContractsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsContractsRepositoryParams @params);
}