using ITControl.Communication.Roles.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Roles.Entities;

namespace ITControl.Application.Roles.Interfaces;

public interface IRolesService
{
    Task<Role> FindOneAsync(FindOneRolesRequest request);
    Task<IEnumerable<Role>> FindManyAsync(
        FindManyRolesRequest request, OrderByRolesRequest orderByRolesRequest);
    Task<PaginationResponse?> FindManyPaginatedAsync(FindManyRolesRequest request);
    Task<Role?> CreateAsync(CreateRolesRequest request);
    Task UpdateAsync(Guid id, UpdateRolesRequest request);
    Task DeleteAsync(Guid id);
}