using ITControl.Domain.Entities;
using System.Linq.Expressions;

namespace ITControl.Domain.Interfaces;

public interface IRolesRepository
{
    Task<Role?> FindOneAsync(Expression<Func<Role?, bool>> predicate, bool? includeRolesPages = null);
    Task<IEnumerable<Role>> FindManyAsync(
        string? name = null, bool? active = null, 
        string? orderByName = null, string? orderByActive = null, 
        int? page = null, int? size = null);
    Task CreateAsync(Role role);
    void Update(Role role);
    void Delete(Role role);
    Task<int> CountAsync(Guid? id = null, string? name = null, bool? active = null);
    Task<bool> ExistsAsync(Guid? id = null, string? name = null, bool? active = null);
    Task<bool> ExclusiveAsync(Guid id, string? name = null);
}