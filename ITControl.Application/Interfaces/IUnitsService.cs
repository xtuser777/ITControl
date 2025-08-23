using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Units.Requests;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IUnitsService
{
    Task<Unit> FindOneAsync(Guid id);
    Task<IEnumerable<Unit>> FindManyAsync(FindManyUnitsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyUnitsRequest request);
    Task<Unit?> CreateAsync(CreateUnitsRequest request);
    Task UpdateAsync(Guid id, UpdateUnitsRequest request);
    Task DeleteAsync(Guid id);
}