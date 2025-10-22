using ITControl.Domain.Shared.Params2;
using ITControl.Domain.Supplements.Entities;
using ITControl.Domain.Supplements.Enums;
using ITControl.Domain.Supplements.Interfaces;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Supplements.Repositories;

public class SupplementsRepository(
    ApplicationDbContext context) : BaseRepository, ISupplementsRepository
{
    public async Task<Supplement?> FindOneAsync(
        FindOneRepositoryParams findOneParams)
    {
        return await context.Supplements
            .FindAsync(findOneParams.Id);
    }

    public async Task<IEnumerable<Supplement>> FindManyAsync(
        FindManyRepositoryParams findManyParams)
    {
        query = context.Supplements.AsNoTracking();
        BuildQuery(findManyParams.FindMany);
        BuildOrderBy(findManyParams.OrderBy);
        ApplyPagination(findManyParams.Pagination);
        return (await query.ToListAsync()).Cast<Supplement>();
    }

    public async Task CreateAsync(Supplement supplement)
    {
        await context.Supplements.AddAsync(supplement);
    }

    public void Update(Supplement supplement)
    {
        context.Supplements.Update(supplement);
    }

    public void Delete(Supplement supplement)
    {
        context.Supplements.Remove(supplement);
    }

    public async Task<int> CountAsync(FindManyParams @params)
    {
        query = context.Supplements.AsNoTracking();
        BuildQuery(@params);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(FindManyParams @params)
    {
        var count = await CountAsync(@params);
        return count > 0;
    }
}
