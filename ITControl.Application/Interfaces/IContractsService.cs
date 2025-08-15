using ITControl.Communication.Contracts.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IContractsService
{
    Task<Contract?> FindOneAsync(Guid id, bool? includeContractsContacts = null);
    Task<IEnumerable<Contract>> FindManyAsync(FindManyContractsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyContractsRequest request);
    Task<Contract?> CreateAsync(CreateContractsRequest request);
    Task UpdateAsync(Guid id, UpdateContractsRequest request);
    Task DeleteAsync(Guid id);
}