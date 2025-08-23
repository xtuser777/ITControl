using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Systems.Requests;

namespace ITControl.Application.Interfaces;

public interface ISystemsService
{
    Task<Domain.Entities.System> FindOneAsync(
        Guid id, 
        bool? includeContractsContacts = null);
    Task<IEnumerable<Domain.Entities.System>> FindManyAsync(FindManySystemsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManySystemsRequest request);
    Task<Domain.Entities.System?> CreateAsync(CreateSystemsRequest request);
    Task UpdateAsync(Guid id, UpdateSystemsRequest request);
    Task DeleteAsync(Guid id);
}