using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITControl.Infrastructure.Repositories;

public class UsersRepository(ApplicationDbContext context) : IUsersRepository
{
    public async Task<User?> FindOneAsync(
        Guid id, 
        bool? includePosition, 
        bool? includeRole,
        bool? includeUsersEquipments,
        bool? includeUsersSystems)
    {
        var query = context.Users.AsQueryable();
        if (includePosition is true)
        {
            query = query.Include(x => x.Position );
        }
        if (includeRole is true)
        {
            query = query.Include(x => x.Role);
        }
        if (includeUsersEquipments is true)
        {
            query = query.Include(x => x.UsersEquipments);
        }
        if (includeUsersSystems is true)
        {
            query = query.Include(x => x.UsersSystems);
        }
        var user = await query.SingleOrDefaultAsync(x => x.Id == id);
        
        return user;
    }

    public async Task<User?> FindOneByUsernameAsync(string username)
    {
        return await context
            .Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task<IEnumerable<User>> FindManyAsync(
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
        int? size = null)
    {
        var query = context.Users.AsNoTracking();
        query = BuildQuery(
            query: query,
            username: username,
            name: name,
            email: email,
            enrollment: enrollment,
            active: active,
            positionId: positionId,
            roleId: roleId);
        query = BuildOrderBy(
            query: query,
            orderByUsername: orderByUsername,
            orderByName: orderByName,
            orderByEmail: orderByEmail,
            orderByEnrollment: orderByEnrollment,
            orderByActive: orderByActive,
            orderByPosition: orderByPosition);
        if (page != null && size != null) 
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(User user)
    {
        await context.Users.AddAsync(user);
    }

    public void Update(User user)
    {
        context.Users.Update(user);
    }

    public void Delete(User user)
    {
        context.Users.Remove(user);
    }

    public async Task<int> CountAsync(
        string? username = null, 
        string? name = null, 
        string? email = null, 
        int? enrollment = null,
        bool? active = null, 
        Guid? positionId = null,
        Guid? roleId = null)
    {
        var query = context.Users.AsNoTracking();
        query = BuildQuery(
            query,
            username: username,
            name: name,
            email: email,
            enrollment: enrollment,
            active: active,
            positionId: positionId,
            roleId: roleId);
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? username = null, 
        string? name = null, 
        string? email = null, 
        int? enrollment = null,
        bool? active = null, 
        Guid? positionId = null,
        Guid? roleId = null)
    {
        var query = context.Users.AsNoTracking();
        query = BuildQuery(
            query,
            id: id,
            username: username,
            name: name,
            email: email,
            enrollment: enrollment,
            active: active,
            positionId: positionId,
            roleId: roleId);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        Guid id, 
        string? username = null, 
        string? name = null, 
        string? email = null)
    {
        var query = context.Users.AsNoTracking();
        query = query.Where(x => x.Id != id);
        query = BuildQuery(query, username: username, name: name, email: email);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private IQueryable<User> BuildQuery(
        IQueryable<User> query,
        Guid? id = null, 
        string? username = null, 
        string? name = null, 
        string? email = null, 
        int? enrollment = null,
        bool? active = null, 
        Guid? positionId = null,
        Guid? roleId = null)
    {
        if (id != null) query = query.Where(x => x.Id == id);
        if (username != null) query = query.Where(x => x.Username.Contains(username));
        if (name != null) query = query.Where(x => x.Name.Contains(name));
        if (email != null) query = query.Where(x => x.Email.Contains(email));
        if (enrollment != null) query = query.Where(x => x.Enrollment == enrollment);
        if (active != null) query = query.Where(x => x.Active == active);
        if (positionId != null) query = query.Where(x => x.PositionId == positionId);
        if (roleId != null) query = query.Where(x => x.RoleId == roleId);
        
        return query;
    }

    private IQueryable<User> BuildOrderBy(
        IQueryable<User> query,
        string? orderByUsername = null,
        string? orderByName = null,
        string? orderByEmail = null,
        string? orderByEnrollment = null,
        string? orderByActive = null,
        string? orderByPosition = null)
    {
        query = orderByUsername switch
        {
            "a" => query.OrderBy(p => p.Username),
            "d" => query.OrderByDescending(p => p.Username),
            _ => query
        };
        query = orderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        query = orderByEmail switch
        {
            "a" => query.OrderBy(p => p.Email),
            "d" => query.OrderByDescending(p => p.Email),
            _ => query
        };
        query = orderByEnrollment switch
        {
            "a" => query.OrderBy(p => p.Enrollment),
            "d" => query.OrderByDescending(p => p.Enrollment),
            _ => query
        };
        query = orderByActive switch
        {
            "a" => query.OrderBy(p => p.Active),
            "d" => query.OrderByDescending(p => p.Active),
            _ => query
        };
        query = orderByPosition switch
        {
            "a" => query.Include(x=>x.Position).OrderBy(p => p.Position!.Description),
            "d" => query.Include(x=>x.Position).OrderByDescending(p => p.Position!.Description),
            _ => query
        };
        
        return query;
    }
}