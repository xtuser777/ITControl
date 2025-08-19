using ITControl.Domain.Entities;
using System.Linq.Expressions;

namespace ITControl.Domain.Interfaces;

public interface IUsersRepository
{
    Task<User?> FindOneAsync(Expression<Func<User?, bool>> predicate, bool? includePosition, bool? includeRole);
    Task<IEnumerable<User>> FindManyAsync(
        string? username = null, 
        string? name = null, 
        string? email = null, 
        int? enrollment = null, 
        bool? active = null, 
        Guid? positionId = null, 
        Guid? roleId = null,
        string? orderByUsername = null, 
        string? orderByName = null, 
        string? orderByEmail = null, 
        string? orderByEnrollment = null,
        string? orderByActive = null,
        string? orderByPosition = null, 
        int? page = null, 
        int? size = null);
    Task CreateAsync(User user);
    void Update(User user);
    void Delete(User user);
    Task<int> CountAsync(
        string? username = null, 
        string? name = null, 
        string? email = null, 
        int? enrollment = null, 
        bool? active = null, 
        Guid? positionId = null, 
        Guid? roleId = null);
    Task<bool> ExistsAsync(
        Guid? id, 
        string? username = null, 
        string? name = null, 
        string? email = null, 
        int? enrollment = null, 
        bool? active = null, 
        Guid? positionId = null, 
        Guid? roleId = null);
    Task<bool> ExclusiveAsync(
        Guid id, 
        string? username = null, 
        string? email = null);
}