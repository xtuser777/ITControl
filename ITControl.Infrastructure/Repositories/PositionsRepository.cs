using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class PositionsRepository(ApplicationDbContext context) : IPositionsRepository
{
    public async Task<Position?> FindOneAsync(Guid id)
    {
        var position = await context.Positions.FindAsync(id);
        return position;
    }

    public async Task<IEnumerable<Position>> FindManyAsync(string? description = null, string? orderByDecription = null, int? page = null, int? size = null)
    {
        var query = context.Positions.AsNoTracking();
        if (description != null) query = query.Where(p => p.Description.Contains(description));
        query = orderByDecription switch
        {
            "a" => query.OrderBy(p => p.Description),
            "d" => query.OrderByDescending(p => p.Description),
            _ => query
        };
        if (page != null && size != null) query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Position position)
    {
        await context.Positions.AddAsync(position);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Position position)
    {
        context.Positions.Update(position);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Position position)
    {
        context.Positions.Remove(position);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(Guid? id = null, string? description = null)
    {
        var query = context.Positions.AsNoTracking();
        if (id != null) query = query.Where(p => p.Id == id);
        if (description != null) query = query.Where(p => p.Description.Contains(description));
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistsAsync(Guid? id = null, string? description = null)
    {
        var count = await CountAsync(id, description);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(Guid id, string? description = null)
    {
        var query = context.Positions
            .AsNoTracking()
            .Where(p => p.Id != id);
        if (description != null) query = query.Where(p => p.Description.Contains(description));
        var count = await query.CountAsync();
        
        return count > 0;
    }
}