using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Treatments.Interfaces;
using ITControl.Domain.Treatments.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Treatments.Repositories;

public class TreatmentsRepository(
    ApplicationDbContext context) : ITreatmentsRepository
{
    public async Task<Treatment?> FindOneAsync(FindOneTreatmentsRepositoryParams @params)
    {
        var query = context.Treatments.AsQueryable();
        if (@params.IncludeCall == true)
        {
            query = query
                .Include(t => t.Call)
                .ThenInclude(x => x!.User)
                .ThenInclude(x => x!.Unit)
                .Include(x => x.Call)
                .ThenInclude(x => x!.User)
                .ThenInclude(x => x!.Department)
                .Include(x => x.Call)
                .ThenInclude(x => x!.User)
                .ThenInclude(x => x!.Division);
        }
        if (@params.IncludeUser == true)
        {
            query = query.Include(t => t.User);
        }

        return await query
            .FirstOrDefaultAsync(t => t.Id == @params.Id);
    }

    public async Task<IEnumerable<Treatment>> FindManyAsync(FindManyTreatmentsRepositoryParams @params)
    {
        var (page, size) = @params;
        var query = context
            .Treatments
            .Include(t => t.Call)
            .Include(t => t.User)
            .AsNoTracking();
        query = BuildQuery(new()
        {
            Query = query,
            Params = @params
        });
        query = BuildOrderBy(new()
        {
            Query = query,
            Params = @params
        });
        if (page.HasValue && size.HasValue)
        {
            var skip = (page.Value - 1) * size.Value;
            query = query.Skip(skip).Take(size.Value);
        }

        return await query.ToListAsync();
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

    public async Task<int> CountAsync(CountTreatmentsRepositoryParams @params)
    {
        var query = context.Treatments.AsNoTracking();
        query = BuildQuery(new ()
        {
            Query = query,
            Params = @params
        });

        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsTreatmentsRepositoryParams @params)
    {
        var count = await CountAsync(@params);

        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(ExclusiveTreatmentsRepositoryParams @params)
    {
        var query = context.Treatments.AsNoTracking();
        query = query.Where(x => x.Id != @params.Id);
        query = BuildQuery(new ()
        {
            Query = query,
            Params = new ()
            {
                Protocol = @params.Protocol,
            }
        });

        var count = await query.CountAsync();

        return count > 0;
    }

    private static IQueryable<Treatment> BuildQuery(BuildQueryTreatmentsRepositoryParams @queryParams)
    {
        var (query, @params) = @queryParams;
        if (@params.Id != null) 
            query = query.Where(x => x.Id == @params.Id);
        if (@params.Description != null) 
            query = query.Where(x => x.Description.Contains(@params.Description));
        if (@params.Protocol != null) 
            query = query.Where(x => x.Protocol.Contains(@params.Protocol));
        if (@params.StartedAt != null) 
            query = query.Where(x => x.StartedAt == @params.StartedAt);
        if (@params.EndedAt != null)
            query = query.Where(x => x.EndedAt == @params.EndedAt);
        if (@params.StartedIn != null)
            query = query.Where(x => x.StartedIn == @params.StartedIn);
        if (@params.EndedIn != null)
            query = query.Where(x => x.EndedIn == @params.EndedIn);
        if (@params.Status != null)
            query = query.Where(x => x.Status == @params.Status);
        if (@params.Type != null)
            query = query.Where(x => x.Type == @params.Type);
        if (@params.Observation != null)
            query = query.Where(x => x.Observation.Contains(@params.Observation));
        if (@params.ExternalProtocol != null)
            query = query.Where(x => x.ExternalProtocol.Contains(@params.ExternalProtocol));
        if (@params.CallId != null)
            query = query.Where(x => x.CallId == @params.CallId);
        if (@params.UserId != null)
            query = query.Where(x => x.UserId == @params.UserId);

        return query;
    }

    private static IQueryable<Treatment> BuildOrderBy(BuildOrderByTreatmentsRepositoryParams @orderByParams)
    {
        var (query, @params) = @orderByParams;
        query = @params.OrderByDescription switch
        {
            "a" => query.OrderBy(x => x.Description),
            "d" => query.OrderByDescending(x => x.Description),
            _ => query
        };
        query = @params.OrderByProtocol switch
        {
            "a" => query.OrderBy(x => x.Protocol),
            "d" => query.OrderByDescending(x => x.Protocol),
            _ => query
        };
        query = @params.OrderByStartedAt switch
        {
            "a" => query.OrderBy(x => x.StartedAt),
            "d" => query.OrderByDescending(x => x.StartedAt),
            _ => query
        };
        query = @params.OrderByEndedAt switch
        {
            "a" => query.OrderBy(x => x.EndedAt),
            "d" => query.OrderByDescending(x => x.EndedAt),
            _ => query
        };
        query = @params.OrderByStartedIn switch
        {
            "a" => query.OrderBy(x => x.StartedIn),
            "d" => query.OrderByDescending(x => x.StartedIn),
            _ => query
        };
        query = @params.OrderByEndedIn switch
        {
            "a" => query.OrderBy(x => x.EndedIn),
            "d" => query.OrderByDescending(x => x.EndedIn),
            _ => query
        };
        query = @params.OrderByStatus switch
        {
            "a" => query.OrderBy(x => x.Status),
            "d" => query.OrderByDescending(x => x.Status),
            _ => query
        };
        query = @params.OrderByType switch
        {
            "a" => query.OrderBy(x => x.Type),
            "d" => query.OrderByDescending(x => x.Type),
            _ => query
        };
        query = @params.OrderByObservation switch
        {
            "a" => query.OrderBy(x => x.Observation),
            "d" => query.OrderByDescending(x => x.Observation),
            _ => query
        };
        query = @params.OrderByExternalProtocol switch
        {
            "a" => query.OrderBy(x => x.ExternalProtocol),
            "d" => query.OrderByDescending(x => x.ExternalProtocol),
            _ => query
        };
        query = @params.OrderByCall switch
        {
            "a" => query.OrderBy(x => x.Call!.Description),
            "d" => query.OrderByDescending(x => x.Call!.Description),
            _ => query
        };
        query = @params.OrderByUser switch
        {
            "a" => query.OrderBy(x => x.User!.Name),
            "d" => query.OrderByDescending(x => x.User!.Name),
            _ => query
        };

        return query;
    }
}
