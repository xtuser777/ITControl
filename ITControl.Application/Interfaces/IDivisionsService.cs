using ITControl.Communication.Divisions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IDivisionsService
{
    Task<Division> FindOneAsync(
        Guid id, 
        bool? includeDepartment = null, 
        bool? includeUser = null);
    Task<IEnumerable<Division>> FindManyAsync(FindManyDivisionsRequest request);
    Task<PaginationResponse?> FindManyPaginatedAsync(FindManyDivisionsRequest request);
    Task<Division?> CreateAsync(CreateDivisionsRequest request);
    Task UpdateAsync(Guid id, UpdateDivisionsRequest request);
    Task DeleteAsync(Guid id);
}