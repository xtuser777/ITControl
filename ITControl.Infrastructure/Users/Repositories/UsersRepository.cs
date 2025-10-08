using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Interfaces;
using ITControl.Domain.Users.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Users.Repositories;

public class UsersRepository(ApplicationDbContext context) : IUsersRepository
{
    public async Task<User?> FindOneAsync(FindOneUsersRepositoryParams @params)
    {
        var query = context.Users.AsQueryable();
        if (@params.IncludePosition is true)
        {
            query = query.Include(x => x.Position );
        }
        if (@params.IncludeRole is true)
        {
            query = query.Include(x => x.Role);
        }
        if (@params.IncludeUnit is true)
        {
            query = query.Include(x => x.Unit);
        }
        if (@params.IncludeDepartment is true)
        {
            query = query.Include(x => x.Department);
        }
        if (@params.IncludeDivision is true)
        {
            query = query.Include(x => x.Division);
        }
        if (@params.IncludeUsersEquipments is true)
        {
            query = query.Include(x => x.UsersEquipments);
        }
        if (@params.IncludeUsersSystems is true)
        {
            query = query.Include(x => x.UsersSystems);
        }
        var user = await query.SingleOrDefaultAsync(x => x.Id == @params.Id);
        
        return user;
    }

    public async Task<User?> FindOneByUsernameAsync(string username)
    {
        return await context
            .Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task<IEnumerable<User>> FindManyAsync(FindManyUsersRepositoryParams @params)
    {
        var query = context.Users.AsNoTracking();
        var (page, size) = @params;
        query = BuildQuery(new ()
        {
            Query = query,
            Username = @params.Username,
            Name = @params.Name,
            Email = @params.Email,
            Document = @params.Document,
            Enrollment = @params.Enrollment,
            Active = @params.Active,
            PositionId = @params.PositionId,
            RoleId = @params.RoleId,
            UnitId = @params.UnitId,
            DepartmentId = @params.DepartmentId,
            DivisionId = @params.DivisionId,
        });
        query = BuildOrderBy(new ()
        {
            Query = query,
            OrderByUsername = @params.Username,
            OrderByName = @params.Name,
            OrderByEmail = @params.Email,
            OrderByDocument = @params.Document,
            OrderByEnrollment = @params.OrderByEnrollment,
            OrderByActive = @params.OrderByActive,
            OrderByPosition = @params.OrderByPosition,
            OrderByRole = @params.OrderByRole,
            OrderByUnit = @params.OrderByUnit,
            OrderByDepartment = @params.OrderByDepartment,
            OrderByDivision = @params.OrderByDivision,
        });
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

    public async Task<int> CountAsync(CountUsersRepositoryParams @params)
    {
        var query = context.Users.AsNoTracking();
        query = BuildQuery(new()
        {
            Query = query,
            Id = @params.Id,
            Username = @params.Username,
            Name = @params.Name,
            Email = @params.Email,
            Document = @params.Document,
            Enrollment = @params.Enrollment,
            Active = @params.Active,
            PositionId = @params.PositionId,
            RoleId = @params.RoleId,
            UnitId = @params.UnitId,
            DepartmentId = @params.DepartmentId,
            DivisionId = @params.DivisionId,
        });
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistsAsync(ExistsUsersRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(ExclusiveUsersRepositoryParams @params)
    {
        var query = context.Users.AsNoTracking();
        query = query.Where(x => x.Id != @params.Id);
        query = BuildQuery(new ()
        {
            Query = query,
            Username = @params.Username,
            Email = @params.Email,
            Document = @params.Document,
        });
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private static IQueryable<User> BuildQuery(BuildQueryUsersRepositoryParams @params)
    {
        if (@params.Id != null) @params.Query = @params.Query.Where(x => x.Id == @params.Id);
        if (@params.Username != null) @params.Query = @params.Query.Where(x => x.Username.Contains(@params.Username));
        if (@params.Name != null) @params.Query = @params.Query.Where(x => x.Name.Contains(@params.Name));
        if (@params.Email != null) @params.Query = @params.Query.Where(x => x.Email.Contains(@params.Email));
        if (@params.Document != null) @params.Query = @params.Query.Where(x => x.Document.Contains(@params.Document));
        if (@params.Enrollment != null) @params.Query = @params.Query.Where(x => x.Enrollment == @params.Enrollment);
        if (@params.Active != null) @params.Query = @params.Query.Where(x => x.Active == @params.Active);
        if (@params.PositionId != null) @params.Query = @params.Query.Where(x => x.PositionId == @params.PositionId);
        if (@params.RoleId != null) @params.Query = @params.Query.Where(x => x.RoleId == @params.RoleId);
        if (@params.UnitId != null) @params.Query = @params.Query.Where(x => x.UnitId == @params.UnitId);
        if (@params.DepartmentId != null) @params.Query = @params.Query.Where(x => x.DepartmentId == @params.DepartmentId);
        if (@params.DivisionId != null) @params.Query = @params.Query.Where(x => x.DivisionId == @params.DivisionId);

        return @params.Query;
    }

    private static IQueryable<User> BuildOrderBy(BuildOrderByUsersRepositoryParams @params)
    {
        @params.Query = @params.OrderByUsername switch
        {
            "a" => @params.Query.OrderBy(p => p.Username),
            "d" => @params.Query.OrderByDescending(p => p.Username),
            _ => @params.Query
        };
        @params.Query = @params.OrderByName switch
        {
            "a" => @params.Query.OrderBy(p => p.Name),
            "d" => @params.Query.OrderByDescending(p => p.Name),
            _ => @params.Query
        };
        @params.Query = @params.OrderByEmail switch
        {
            "a" => @params.Query.OrderBy(p => p.Email),
            "d" => @params.Query.OrderByDescending(p => p.Email),
            _ => @params.Query
        };
        @params.Query = @params.OrderByDocument switch
        {
            "a" => @params.Query.OrderBy(p => p.Document),
            "d" => @params.Query.OrderByDescending(p => p.Document),
            _ => @params.Query
        };
        @params.Query = @params.OrderByEnrollment switch
        {
            "a" => @params.Query.OrderBy(p => p.Enrollment),
            "d" => @params.Query.OrderByDescending(p => p.Enrollment),
            _ => @params.Query
        };
        @params.Query = @params.OrderByActive switch
        {
            "a" => @params.Query.OrderBy(p => p.Active),
            "d" => @params.Query.OrderByDescending(p => p.Active),
            _ => @params.Query
        };
        @params.Query = @params.OrderByPosition switch
        {
            "a" => @params.Query.Include(x=>x.Position).OrderBy(p => p.Position!.Description),
            "d" => @params.Query.Include(x=>x.Position).OrderByDescending(p => p.Position!.Description),
            _ => @params.Query
        };
        @params.Query = @params.OrderByRole switch
        {
            "a" => @params.Query.Include(x => x.Role).OrderBy(p => p.Role!.Name),
            "d" => @params.Query.Include(x => x.Role).OrderByDescending(p => p.Role!.Name),
            _ => @params.Query
        };
        @params.Query = @params.OrderByUnit switch
        {
            "a" => @params.Query.Include(x => x.Unit).OrderBy(p => p.Unit!.Name),
            "d" => @params.Query.Include(x => x.Unit).OrderByDescending(p => p.Unit!.Name),
            _ => @params.Query
        };
        @params.Query = @params.OrderByDepartment switch
        {
            "a" => @params.Query.Include(x => x.Department).OrderBy(p => p.Department!.Alias),
            "d" => @params.Query.Include(x => x.Department).OrderByDescending(p => p.Department!.Alias),
            _ => @params.Query
        };
        @params.Query = @params.OrderByDivision switch
        {
            "a" => @params.Query.Include(x => x.Division).OrderBy(p => p.Division!.Name),
            "d" => @params.Query.Include(x => x.Division).OrderByDescending(p => p.Division!.Name),
            _ => @params.Query
        };

        return @params.Query;
    }
}