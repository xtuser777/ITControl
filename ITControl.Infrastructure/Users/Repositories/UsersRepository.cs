using ITControl.Domain.Shared.Params;
using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Interfaces;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Users.Repositories;

public class UsersRepository(ApplicationDbContext context) : 
    BaseRepository, IUsersRepository
{
    public async Task<User?> FindOneAsync(
        FindOneRepositoryParams parameters)
    {
        query = context.Users.AsQueryable();
        ApplyIncludes(parameters.Includes);
        return (User?)await query
            .SingleOrDefaultAsync(x => x.Id == parameters.Id);
    }

    public async Task<User?> FindOneByUsernameAsync(string username)
    {
        return await context
            .Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task<IEnumerable<User>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.Users.AsNoTracking();
        BuildQuery(parameters.FindMany);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return (await query.ToListAsync()).Cast<User>();
    }

    public async Task CreateAsync(User user)
    {
        await context.Users.AddAsync(user);
    }

    public void Update(User user)
    {
        context.Users.Update(user);
    }

    public void SoftDelete(User user)
    {
        user.Active = false;
        user.UpdatedAt = DateTime.Now;
        context.Users.Update(user);
    }

    public void Delete(User user)
    {
        context.Users.Remove(user);
    }

    public async Task<int> CountAsync(
        FindManyParams parameters)
    {
        query = context.Users.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        return count;
    }

    public async Task<bool> ExistsAsync(
        FindManyParams parameters)
    {
        var count = await CountAsync(parameters);
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        FindManyParams parameters)
    {
        query = context.Users.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        return count > 0;
    }
}