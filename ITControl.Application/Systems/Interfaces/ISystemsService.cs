using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Systems.Interfaces;

public interface ISystemsService
{
    Task<Domain.Systems.Entities.System> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Domain.Systems.Entities.System>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<Domain.Systems.Entities.System?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}