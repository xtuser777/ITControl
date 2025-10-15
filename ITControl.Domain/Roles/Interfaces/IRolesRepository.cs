using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Roles.Interfaces;

public interface IRolesRepository
{
    Task<Role?> FindOneAsync(FindOneRolesRepositoryParams @params);
    Task<IEnumerable<Role>> FindManyAsync(
        FindManyRolesRepositoryParams findManyRolesParams,
        OrderByRolesRepositoryParams? orderByRolesParams = null,
        PaginationParams? paginationParams = null);
    Task CreateAsync(Role role);
    void Update(Role role);
    void Delete(Role role);
    Task<int> CountAsync(CountRolesRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsRolesRepositoryParams @params);
    Task<bool> ExclusiveAsync(ExclusiveRolesRepositoryParams @params);
}