using ITControl.Application.Systems.Params;
using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Systems.Interfaces;

public interface ISystemsService
{
    Task<Domain.Systems.Entities.System> FindOneAsync(
        FindOneSystemsServiceParams parameters);
    Task<IEnumerable<Domain.Systems.Entities.System>> FindManyAsync(
        FindManySystemsServiceParams parameters);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationSystemsServiceParams parameters);
    Task<Domain.Systems.Entities.System?> CreateAsync(
        CreateSystemsServiceParams parameters);
    Task UpdateAsync(UpdateSystemsServiceParams parameters);
    Task DeleteAsync(DeleteSystemsServiceParams parameters);
}