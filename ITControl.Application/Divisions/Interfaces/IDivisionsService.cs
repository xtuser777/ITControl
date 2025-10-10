using ITControl.Communication.Divisions.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Divisions.Entities;

namespace ITControl.Application.Divisions.Interfaces;

public interface IDivisionsService
{
    Task<Division> FindOneAsync(FindOneDivisionsRequest request);
    Task<IEnumerable<Division>> FindManyAsync(FindManyDivisionsRequest request);
    Task<PaginationResponse?> FindManyPaginatedAsync(FindManyDivisionsRequest request);
    Task<Division?> CreateAsync(CreateDivisionsRequest request);
    Task UpdateAsync(Guid id, UpdateDivisionsRequest request);
    Task DeleteAsync(Guid id);
}