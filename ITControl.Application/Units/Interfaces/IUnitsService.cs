using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Units.Requests;
using ITControl.Domain.Units.Entities;

namespace ITControl.Application.Units.Interfaces;

public interface IUnitsService
{
    Task<Unit> FindOneAsync(FindOneUnitsRequest request);
    Task<IEnumerable<Unit>> FindManyAsync(
        FindManyUnitsRequest request,
        OrderByUnitsRequest orderByRequest);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyUnitsRequest request);
    Task<Unit?> CreateAsync(CreateUnitsRequest request);
    Task UpdateAsync(Guid id, UpdateUnitsRequest request);
    Task DeleteAsync(Guid id);
}