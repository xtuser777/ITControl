using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Params;

namespace ITControl.Application.Divisions.Interfaces;

public interface IDivisionsService
{
    Task<Division> FindOneAsync(FindOneDivisionsRepositoryParams @params);
    Task<IEnumerable<Division>> FindManyAsync(FindManyDivisionsRepositoryParams @params);
    Task<PaginationResponse?> FindManyPaginatedAsync(FindManyDivisionsRepositoryParams @params);
    Task<Division?> CreateAsync(Division division);
    Task UpdateAsync(Guid id, UpdateDivisionParams @params);
    Task DeleteAsync(Guid id);
}