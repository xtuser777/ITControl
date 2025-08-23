using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IRolesPagesRepository
{
    Task<IEnumerable<RolePage>> FindManyAsync(Guid? pageId = null, Guid? roleId = null);
    Task CreateManyAsync(IEnumerable<RolePage> rolePages);
    Task DeleteManyByRoleAsync(Role role);
}