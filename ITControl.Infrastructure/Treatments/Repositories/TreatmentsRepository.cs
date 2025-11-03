using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Treatments.Interfaces;
using ITControl.Infrastructure.Shared.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Treatments.Repositories;

public class TreatmentsRepository(
    ApplicationDbContext context) : 
    BaseRepository, ITreatmentsRepository
{
    public async Task<Treatment?> FindOneAsync(
        FindOneRepositoryParams parameters)
    {
        query = context.Treatments.AsQueryable();
        ApplyIncludes(parameters.Includes);

        return (Treatment?)await query
            .FirstOrDefaultAsync(t => t.Id == parameters.Id);
    }

    public async Task<IEnumerable<Treatment>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context
            .Treatments
            .Include(t => t.Call)
            .Include(t => t.User)
            .AsNoTracking();
        BuildQuery(parameters.FindManyProps);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return (await query.ToListAsync()).Cast<Treatment>();
    }

    public async Task CreateAsync(Treatment treatment)
    {
        await context.Treatments.AddAsync(treatment);
    }

    public void Update(Treatment treatment)
    {
        context.Treatments.Update(treatment);
    }

    public void Delete(Treatment treatment)
    {
        context.Treatments.Remove(treatment);
    }

    public async Task<int> CountAsync(Entity parameters)
    {
        query = context.Treatments.AsNoTracking();
        BuildQuery(parameters);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(Entity parameters)
    {
        var count = await CountAsync(parameters);
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(Entity parameters)
    {
        query = context.Treatments.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        return count > 0;
    }
}
