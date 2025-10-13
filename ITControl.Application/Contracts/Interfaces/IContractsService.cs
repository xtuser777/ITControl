using ITControl.Communication.Contracts.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Contracts.Entities;

namespace ITControl.Application.Contracts.Interfaces;

public interface IContractsService
{
    Task<Contract> FindOneAsync(FindOneContractsRequest request);
    Task<IEnumerable<Contract>> FindManyAsync(
        FindManyContractsRequest findManyRequest,
        OrderByContractsRequest orderByRequest);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyContractsRequest request);
    Task<Contract?> CreateAsync(CreateContractsRequest request);
    Task UpdateAsync(Guid id, UpdateContractsRequest request);
    Task DeleteAsync(Guid id);
}