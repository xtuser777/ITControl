using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Users.Interfaces;

public interface IUsersSystemsRepository
{
    Task<IEnumerable<UserSystem>> FindManyAsync(Guid? userId = null, Guid? systemId = null);
    Task CreateManyAsync(IEnumerable<UserSystem> userSystems);
    Task DeleteManyByUserAsync(User user);
}