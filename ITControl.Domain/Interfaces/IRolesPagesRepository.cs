using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IRolesPagesRepository
{
    Task<IEnumerable<RolePage>> FindMany(Guid? pageId = null, Guid? roleId = null);
    Task CreateMany(IEnumerable<RolePage> rolePages);
    Task DeleteMany(Role role);
}