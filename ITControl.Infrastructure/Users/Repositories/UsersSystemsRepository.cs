using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Interfaces;
using ITControl.Infrastructure.Shared.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Users.Repositories;

public class UsersSystemsRepository(
    ApplicationDbContext context) : IUsersSystemsRepository
{
    public async Task<IEnumerable<UserSystem>> FindManyAsync(
        Guid? userId = null, Guid? systemId = null)
    {
        var query = context.UsersSystems.AsNoTracking();
        if (userId != null) 
            query = query.Where(x => x.UserId == userId.Value);
        if (systemId != null) 
            query = query.Where(x => x.SystemId == systemId.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateManyAsync(IEnumerable<UserSystem> userSystems)
    {
        await context.UsersSystems.AddRangeAsync(userSystems);
    }

    public async Task DeleteManyByUserAsync(User user)
    {
        var uss = await context.UsersSystems
            .AsQueryable()
            .Where(x => x.UserId == user.Id)
            .ExecuteDeleteAsync();
    }
}