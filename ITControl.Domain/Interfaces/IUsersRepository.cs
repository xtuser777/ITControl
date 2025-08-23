using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IUsersRepository
{
    Task<User?> FindOneAsync(
        Guid id, 
        bool? includePosition, 
        bool? includeRole,
        bool? includeUsersEquipments,
        bool? includeUsersSystems);
    Task<User?> FindOneByUsernameAsync(string username);
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
        Guid? id = null, 
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
        string? name = null, 
        string? email = null);
}