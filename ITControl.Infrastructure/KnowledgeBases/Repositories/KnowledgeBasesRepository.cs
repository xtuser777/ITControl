using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.KnowledgeBases.Interfaces;
using ITControl.Domain.Shared.Params2;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.KnowledgeBases.Repositories;

public class KnowledgeBasesRepository(
    ApplicationDbContext context) : 
    BaseRepository, IKnowledgeBasesRepository
{
    public async Task<KnowledgeBase?> FindOneAsync(
        FindOneRepositoryParams parameters)
    {
        var (id, includes) = parameters;
        query = context.KnowledgeBases.AsQueryable();
        ApplyIncludes(includes);

        return (KnowledgeBase?)await query
            .FirstOrDefaultAsync(kb => kb.Id == id);
    }

    public async Task<IEnumerable<KnowledgeBase>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.KnowledgeBases
            .Include(kb => kb.User)
            .AsNoTracking();
        BuildQuery(parameters.FindMany);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();
        return entities.Cast<KnowledgeBase>();
    }

    public async Task CreateAsync(KnowledgeBase knowledgeBase)
    {
        await context.KnowledgeBases.AddAsync(knowledgeBase);
    }

    public void Update(KnowledgeBase knowledgeBase)
    {
        context.KnowledgeBases.Update(knowledgeBase);
    }

    public void Delete(KnowledgeBase knowledgeBase)
    {
        context.KnowledgeBases.Remove(knowledgeBase);
    }

    public async Task<int> CountAsync(FindManyParams parameters)
    {
        query = context.KnowledgeBases.AsNoTracking();
        BuildQuery(parameters);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(FindManyParams parameters)
    {
        var count = await CountAsync(parameters);
        return count > 0;
    }
}
