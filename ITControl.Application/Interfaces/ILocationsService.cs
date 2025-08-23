using ITControl.Communication.Locations.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface ILocationsService
{
    Task<Location> FindOneAsync(
        Guid id,
        bool? includeUnit = null,
        bool? includeUser = null,
        bool? includeDepartment = null,
        bool? includeDivision = null);
    Task<IEnumerable<Location>> FindManyAsync(FindManyLocationsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyLocationsRequest request);
    Task<Location?> CreateAsync(CreateLocationsRequest request);
    Task UpdateAsync(Guid id, UpdateLocationsRequest request);
    Task DeleteAsync(Guid id);
}