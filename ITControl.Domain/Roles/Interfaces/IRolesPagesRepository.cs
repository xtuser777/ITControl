using ITControl.Domain.Roles.Entities;

namespace ITControl.Domain.Roles.Interfaces;

public interface IRolesPagesRepository
{
    Task<IEnumerable<RolePage>> FindManyAsync(Guid? pageId = null, Guid? roleId = null);
    Task CreateManyAsync(IEnumerable<RolePage> rolePages);
    Task DeleteManyByRoleAsync(Role role);
}