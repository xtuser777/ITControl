using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class RolesPagesRepository(ApplicationDbContext context) : IRolesPagesRepository
{
    public async Task<IEnumerable<RolePage>> FindManyAsync(Guid? pageId = null, Guid? roleId = null)
    {
        var query = context.RolesPages.AsNoTracking();
        if (pageId != null) query = query.Where(r => r.PageId == pageId);
        if (roleId != null) query = query.Where(r => r.RoleId == roleId);
        
        return await query.ToListAsync();
    }

    public async Task CreateManyAsync(IEnumerable<RolePage> rolePages)
    {
        await context.RolesPages.AddRangeAsync(rolePages);
    }

    public async Task DeleteManyByRoleAsync(Role role)
    {
        await context.RolesPages.Where(x => x.RoleId == role.Id).ExecuteDeleteAsync();
    }
}