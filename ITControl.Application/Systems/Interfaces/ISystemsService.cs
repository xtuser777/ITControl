using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Systems.Requests;

namespace ITControl.Application.Systems.Interfaces;

public interface ISystemsService
{
    Task<Domain.Systems.Entities.System> FindOneAsync(FindOneSystemsRequest request);
    Task<IEnumerable<Domain.Systems.Entities.System>> FindManyAsync(
        FindManySystemsRequest request, OrderBySystemsRequest orderByRequest);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManySystemsRequest request);
    Task<Domain.Systems.Entities.System?> CreateAsync(CreateSystemsRequest request);
    Task UpdateAsync(Guid id, UpdateSystemsRequest request);
    Task DeleteAsync(Guid id);
}