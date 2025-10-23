using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Roles.Entities;

namespace ITControl.Application.Roles.Interfaces;

public interface IRolesService
{
    Task<Role> FindOneAsync(FindOneServiceParams parameters);
    Task<IEnumerable<Role>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationResponse?> FindManyPaginatedAsync(
        FindManyPaginationServiceParams parameters);
    Task<Role?> CreateAsync(CreateServiceParams parameters);
    Task UpdateAsync(UpdateServiceParams parameters);
    Task DeleteAsync(DeleteServiceParams parameters);
}