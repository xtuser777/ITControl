using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Units.Entities;

namespace ITControl.Application.Units.Interfaces;

public interface IUnitsService
{
    Task<Unit> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Unit>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<Unit?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(UpdateServiceParams parameters);
    Task DeleteAsync(DeleteServiceParams parameters);
}