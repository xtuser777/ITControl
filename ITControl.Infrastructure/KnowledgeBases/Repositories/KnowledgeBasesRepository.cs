using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.KnowledgeBases.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.KnowledgeBases.Repositories;

public class KnowledgeBasesRepository(
    ApplicationDbContext context) : IKnowledgeBasesRepository
{
    public async Task<KnowledgeBase?> FindOneAsync(IFindOneKnowledgeBasesRepositoryParams @params)
    {
        var (id, includeUser) = (FindOneKnowledgeBasesRepositoryParams)@params;
        var query = context.KnowledgeBases.AsQueryable();
        if (includeUser == true)
        {
            query = query.Include(kb => kb.User);
        }

        return await query.FirstOrDefaultAsync(kb => kb.Id == id);
    }

    public async Task<IEnumerable<KnowledgeBase>> FindManyAsync(IFindManyKnowledgeBasesRepositoryParams @params)
    {
        var query = context.KnowledgeBases
            .Include(kb => kb.User)
            .AsNoTracking();
        var applyFiltersParams = (ApplyFiltersKnowledgeBasesRepositoryParams)
            (@params as FindManyKnowledgeBasesRepositoryParams)!;
        applyFiltersParams.Query = query;
        query = ApplyFilters(applyFiltersParams);
        var applySortingParams = (ApplySortingKnowledgeBasesRepositoryParams)
            (@params as FindManyKnowledgeBasesRepositoryParams)!;
        applySortingParams.Query = query;
        query = ApplySorting(applySortingParams);
        if (@params.Page.HasValue && @params.Size.HasValue)
        {
            var skip = (@params.Page.Value - 1) * @params.Size.Value;
            query = query.Skip(skip).Take(@params.Size.Value);
        }

        return await query.ToListAsync();
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

    public async Task<int> CountAsync(ICountKnowledgeBasesRepositoryParams @params)
    {
        var query = context.KnowledgeBases.AsNoTracking();
        var applyFiltersParams = (ApplyFiltersKnowledgeBasesRepositoryParams)
            (@params as CountKnowledgeBasesRepositoryParams)!;
        applyFiltersParams.Query = query;
        query = ApplyFilters(applyFiltersParams);

        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(IExistsKnowledgeBasesRepositoryParams existsParams)
    {
        var count = await CountAsync(existsParams);

        return count > 0;
    }

    private static IQueryable<KnowledgeBase> ApplyFilters(ApplyFiltersKnowledgeBasesRepositoryParams @params)
    {
        if (@params.Id.HasValue)
        {
            @params.Query = @params.Query.Where(kb => kb.Id == @params.Id.Value);
        }
        if (!string.IsNullOrWhiteSpace(@params.Title))
        {
            @params.Query = @params.Query.Where(kb => kb.Title.Contains(@params.Title));
        }
        if (!string.IsNullOrWhiteSpace(@params.Content))
        {
            @params.Query = @params.Query.Where(kb => kb.Content.Contains(@params.Content));
        }
        if (@params.EstimatedTime.HasValue)
        {
            @params.Query = @params.Query.Where(kb => kb.EstimatedTime == @params.EstimatedTime.Value);
        }
        if (@params.Reason.HasValue)
        {
            @params.Query = @params.Query.Where(kb => kb.Reason == @params.Reason.Value);
        }
        if (@params.UserId.HasValue)
        {
            @params.Query = @params.Query.Where(kb => kb.UserId == @params.UserId.Value);
        }
        return @params.Query;
    }

    private static IQueryable<KnowledgeBase> ApplySorting(ApplySortingKnowledgeBasesRepositoryParams @params)
    {
        if (!string.IsNullOrWhiteSpace(@params.OrderByTitle))
        {
            @params.Query = @params.OrderByTitle.ToLower() == "d"
                ? @params.Query.OrderByDescending(kb => kb.Title)
                : @params.Query.OrderBy(kb => kb.Title);
        }
        if (!string.IsNullOrWhiteSpace(@params.OrderByContent))
        {
            @params.Query = @params.OrderByContent.ToLower() == "d"
                ? @params.Query.OrderByDescending(kb => kb.Content)
                : @params.Query.OrderBy(kb => kb.Content);
        }
        if (!string.IsNullOrWhiteSpace(@params.OrderByEstimatedTime))
        {
            @params.Query = @params.OrderByEstimatedTime.ToLower() == "d"
                ? @params.Query.OrderByDescending(kb => kb.EstimatedTime)
                : @params.Query.OrderBy(kb => kb.EstimatedTime);
        }
        if (!string.IsNullOrWhiteSpace(@params.OrderByReason))
        {
            @params.Query = @params.OrderByReason.ToLower() == "d"
                ? @params.Query.OrderByDescending(kb => kb.Reason)
                : @params.Query.OrderBy(kb => kb.Reason);
        }
        if (!string.IsNullOrWhiteSpace(@params.OrderByUser))
        {
            @params.Query = @params.OrderByUser.ToLower() == "d"
                ? @params.Query.OrderByDescending(kb => kb.User!.Name)
                : @params.Query.OrderBy(kb => kb.User!.Name);
        }
        return @params.Query;
    }
}

public class FindOneKnowledgeBasesRepositoryParams : IFindOneKnowledgeBasesRepositoryParams
{
    public Guid Id { get; set; }
    public bool? IncludeUser { get; set; } = null;

    internal void Deconstruct(out Guid id, out bool? includeUser)
    {
        id = Id;
        includeUser = IncludeUser;
    }
}

public class FindManyKnowledgeBasesRepositoryParams : IFindManyKnowledgeBasesRepositoryParams
{
    public Guid? Id { get; set; } = null;
    public string? Title { get; set; } = null;
    public string? Content { get; set; } = null;
    public TimeOnly? EstimatedTime { get; set; } = null;
    public CallReason? Reason { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public string? OrderByTitle { get; set; } = null;
    public string? OrderByContent { get; set; } = null;
    public string? OrderByEstimatedTime { get; set; } = null;
    public string? OrderByReason { get; set; } = null;
    public string? OrderByUser { get; set; } = null;
    public int? Page { get; set; } = null;
    public int? Size { get; set; } = null;

    public static implicit operator ApplyFiltersKnowledgeBasesRepositoryParams(FindManyKnowledgeBasesRepositoryParams @params) =>
        new()
        {
            Id = @params.Id,
            Title = @params.Title,
            Content = @params.Content,
            EstimatedTime = @params.EstimatedTime,
            Reason = @params.Reason,
            UserId = @params.UserId
        };

    public static implicit operator ApplySortingKnowledgeBasesRepositoryParams(FindManyKnowledgeBasesRepositoryParams @params) =>
        new()
        {
            OrderByTitle = @params.OrderByTitle,
            OrderByContent = @params.OrderByContent,
            OrderByEstimatedTime = @params.OrderByEstimatedTime,
            OrderByReason = @params.OrderByReason,
            OrderByUser = @params.OrderByUser
        };

    public static implicit operator CountKnowledgeBasesRepositoryParams(FindManyKnowledgeBasesRepositoryParams @params) =>
        new()
        {
            Id = @params.Id,
            Title = @params.Title,
            Content = @params.Content,
            EstimatedTime = @params.EstimatedTime,
            Reason = @params.Reason,
            UserId = @params.UserId
        };
}

public class CountKnowledgeBasesRepositoryParams : ICountKnowledgeBasesRepositoryParams
{
    public Guid? Id { get; set; } = null;
    public string? Title { get; set; } = null;
    public string? Content { get; set; } = null;
    public TimeOnly? EstimatedTime { get; set; } = null;
    public CallReason? Reason { get; set; } = null;
    public Guid? UserId { get; set; } = null;

    public static implicit operator ApplyFiltersKnowledgeBasesRepositoryParams(CountKnowledgeBasesRepositoryParams @params) =>
        new()
        {
            Id = @params.Id,
            Title = @params.Title,
            Content = @params.Content,
            EstimatedTime = @params.EstimatedTime,
            Reason = @params.Reason,
            UserId = @params.UserId
        };
}

public class ExistsKnowledgeBasesRepositoryParams : CountKnowledgeBasesRepositoryParams, IExistsKnowledgeBasesRepositoryParams
{
}

public class ApplyFiltersKnowledgeBasesRepositoryParams
{
    public IQueryable<KnowledgeBase> Query { get; set; } = null!;
    public Guid? Id { get; set; } = null;
    public string? Title { get; set; } = null;
    public string? Content { get; set; } = null;
    public TimeOnly? EstimatedTime { get; set; } = null;
    public CallReason? Reason { get; set; } = null;
    public Guid? UserId { get; set; } = null;
}

public class ApplySortingKnowledgeBasesRepositoryParams
{
    public IQueryable<KnowledgeBase> Query { get; set; } = null!;
    public string? OrderByTitle { get; set; } = null;
    public string? OrderByContent { get; set; } = null;
    public string? OrderByEstimatedTime { get; set; } = null;
    public string? OrderByReason { get; set; } = null;
    public string? OrderByUser { get; set; } = null;
}
