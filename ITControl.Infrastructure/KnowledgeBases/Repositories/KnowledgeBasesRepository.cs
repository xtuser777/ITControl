using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.KnowledgeBases.Interfaces;
using ITControl.Domain.KnowledgeBases.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.KnowledgeBases.Repositories;

public class KnowledgeBasesRepository(
    ApplicationDbContext context) : BaseRepository, IKnowledgeBasesRepository
{
    public async Task<KnowledgeBase?> FindOneAsync(
        FindOneKnowledgeBasesRepositoryParams @params)
    {
        var (id, includes) = @params;
        query = context.KnowledgeBases.AsQueryable();
        ApplyIncludes(includes);

        return (KnowledgeBase?)await query
            .FirstOrDefaultAsync(kb => kb.Id == id);
    }

    public async Task<IEnumerable<KnowledgeBase>> FindManyAsync(
        FindManyKnowledgeBasesRepositoryParams findManyParams,
        OrderByKnowledgeBasesRepositoryParams orderByParams,
        PaginationParams paginationParams)
    {
        query = context.KnowledgeBases
            .Include(kb => kb.User)
            .AsNoTracking();
        BuildQuery(findManyParams);
        BuildOrderBy(orderByParams);
        ApplyPagination(paginationParams);

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

    public async Task<int> CountAsync(CountKnowledgeBasesRepositoryParams @params)
    {
        query = context.KnowledgeBases.AsNoTracking();
        BuildQuery(@params);

        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsKnowledgeBasesRepositoryParams @params)
    {
        var count = await CountAsync(@params);

        return count > 0;
    }
}
