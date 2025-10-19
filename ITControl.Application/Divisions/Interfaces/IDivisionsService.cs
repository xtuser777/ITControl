using ITControl.Application.Divisions.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Divisions.Entities;

namespace ITControl.Application.Divisions.Interfaces;

public interface IDivisionsService
{
    Task<Division> FindOneAsync(FindOneDivisionsServiceParams @params);
    Task<IEnumerable<Division>> FindManyAsync(
        FindManyDivisionsServiceParams @params);
    Task<PaginationResponse?> FindManyPaginatedAsync(
        FindManyPaginationDivisionsServiceParams @params);
    Task<Division?> CreateAsync(CreateDivisionsServiceParams @params);
    Task UpdateAsync(UpdateDivisionsServiceParams @params);
    Task DeleteAsync(DeleteDivisionsServiceParams @params);
}