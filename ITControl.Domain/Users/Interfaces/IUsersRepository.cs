using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Params;

namespace ITControl.Domain.Users.Interfaces;

public interface IUsersRepository
{
    Task<User?> FindOneAsync(FindOneUsersRepositoryParams @params);
    Task<User?> FindOneByUsernameAsync(string username);
    Task<IEnumerable<User>> FindManyAsync(FindManyUsersRepositoryParams @params);
    Task CreateAsync(User user);
    void Update(User user);
    void SoftDelete(User user);
    void Delete(User user);
    Task<int> CountAsync(CountUsersRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsUsersRepositoryParams @params);
    Task<bool> ExclusiveAsync(ExclusiveUsersRepositoryParams @params);
}