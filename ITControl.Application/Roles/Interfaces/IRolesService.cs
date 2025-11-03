using ITControl.Application.Shared.Params;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Application.Roles.Interfaces;

public interface IRolesService
{
    Task<Role> FindOneAsync(FindOneServiceParams parameters);
    Task<IEnumerable<Role>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginatedAsync(
        FindManyPaginationServiceParams parameters);
    Task<Role?> CreateAsync(CreateServiceParams parameters);
    Task UpdateAsync(UpdateServiceParams parameters);
    Task DeleteAsync(DeleteServiceParams parameters);
}