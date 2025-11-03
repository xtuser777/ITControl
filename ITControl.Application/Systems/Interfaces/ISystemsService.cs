using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Application.Systems.Interfaces;

public interface ISystemsService
{
    Task<Domain.Systems.Entities.SystemEntity> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Domain.Systems.Entities.SystemEntity>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<Domain.Systems.Entities.SystemEntity?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}