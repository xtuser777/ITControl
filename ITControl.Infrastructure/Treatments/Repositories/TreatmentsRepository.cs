using ITControl.Domain.Treatments.Entities;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Treatments.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Treatments.Repositories;

public class TreatmentsRepository(
    ApplicationDbContext context) : ITreatmentsRepository
{
    public async Task<Treatment?> FindOneAsync(
        Guid id, 
        bool? includeCall = null, 
        bool? includeUser = null)
    {
        var query = context.Treatments.AsQueryable();
        if (includeCall == true)
        {
            query = query
                .Include(t => t.Call)
                .ThenInclude(x => x!.Location)
                .ThenInclude(x => x!.Unit)
                .Include(x => x.Call)
                .ThenInclude(x => x!.Location)
                .ThenInclude(x => x!.Department)
                .Include(x => x.Call)
                .ThenInclude(x => x!.Location)
                .ThenInclude(x => x!.Division);
        }
        if (includeUser == true)
        {
            query = query.Include(t => t.User);
        }

        return await query
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Treatment>> FindManyAsync(
        string? description = null, 
        string? protocol = null, 
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null, 
        TimeOnly? startedIn = null, 
        TimeOnly? endedIn = null, 
        TreatmentStatus? status = null, 
        TreatmentType? type = null, 
        string? observation = null, 
        string? externalProtocol = null, 
        Guid? callId = null, 
        Guid? userId = null, 
        string? orderByDescription = null, 
        string? orderByProtocol = null,
        string? orderByStartedAt = null,
        string? orderByEndedAt = null, 
        string? orderByStartedIn = null, 
        string? orderByEndedIn = null, 
        string? orderByStatus = null, 
        string? orderByType = null, 
        string? orderByObservation = null, 
        string? orderByExternalProtocol = null, 
        string? orderByCall = null, 
        string? orderByUser = null, 
        int? page = null, int? size = null)
    {
        var query = context
            .Treatments
            .Include(t => t.Call)
            .Include(t => t.User)
            .AsNoTracking();
        query = BuildQuery(
            query, 
            null, 
            description, 
            protocol, 
            startedAt, 
            endedAt, 
            startedIn, 
            endedIn, 
            status, 
            type, 
            observation, 
            externalProtocol, 
            callId, 
            userId);
        query = BuildOrderBy(
            query, 
            orderByDescription, 
            orderByProtocol, 
            orderByStartedAt, 
            orderByEndedAt, 
            orderByStartedIn, 
            orderByEndedIn, 
            orderByStatus, 
            orderByType, 
            orderByObservation, 
            orderByExternalProtocol, 
            orderByCall, 
            orderByUser);
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

    public async Task<int> CountAsync(
        Guid? id = null, 
        string? description = null, 
        string? protocol = null, 
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null, 
        TimeOnly? startedIn = null, 
        TimeOnly? endedIn = null, 
        TreatmentStatus? status = null, 
        TreatmentType? type = null, 
        string? observation = null, 
        string? externalProtocol = null, 
        Guid? callId = null, 
        Guid? userId = null)
    {
        var query = context.Treatments.AsNoTracking();
        query = BuildQuery(
            query,
            id,
            description,
            protocol,
            startedAt,
            endedAt,
            startedIn,
            endedIn,
            status,
            type,
            observation,
            externalProtocol,
            callId,
            userId);

        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? description = null, 
        string? protocol = null, 
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null, 
        TimeOnly? startedIn = null, 
        TimeOnly? endedIn = null, 
        TreatmentStatus? status = null, 
        TreatmentType? type = null, 
        string? observation = null, 
        string? externalProtocol = null, 
        Guid? callId = null, 
        Guid? userId = null)
    {
        var count = await CountAsync(
            id, 
            description, 
            protocol, 
            startedAt, 
            endedAt, 
            startedIn, 
            endedIn, 
            status, 
            type, 
            observation, 
            externalProtocol, 
            callId, 
            userId);

        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(Guid id, string? protocol = null)
    {
        var query = context.Treatments.AsNoTracking();
        query = query.Where(x => x.Id != id);
        query = BuildQuery(
            query,
            protocol: protocol);

        var count = await query.CountAsync();

        return count > 0;
    }

    private IQueryable<Treatment> BuildQuery(
        IQueryable<Treatment> query,
        Guid? id = null,
        string? description = null,
        string? protocol = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null,
        TimeOnly? startedIn = null,
        TimeOnly? endedIn = null,
        TreatmentStatus? status = null,
        TreatmentType? type = null,
        string? observation = null,
        string? externalProtocol = null,
        Guid? callId = null,
        Guid? userId = null)
    {
        ArgumentNullException.ThrowIfNull(query);
        if (id != null) 
            query = query.Where(x => x.Id == id);
        if (description != null) 
            query = query.Where(x => x.Description.Contains(description));
        if (protocol != null) 
            query = query.Where(x => x.Protocol.Contains(protocol));
        if (startedAt != null) 
            query = query.Where(x => x.StartedAt == startedAt);
        if (endedAt != null)
            query = query.Where(x => x.EndedAt == endedAt);
        if (startedIn != null)
            query = query.Where(x => x.StartedIn == startedIn);
        if (endedIn != null)
            query = query.Where(x => x.EndedIn == endedIn);
        if (status != null)
            query = query.Where(x => x.Status == status);
        if (type != null)
            query = query.Where(x => x.Type == type);
        if (observation != null)
            query = query.Where(x => x.Observation.Contains(observation));
        if (externalProtocol != null)
            query = query.Where(x => x.ExternalProtocol.Contains(externalProtocol));
        if (callId != null)
            query = query.Where(x => x.CallId == callId);
        if (userId != null)
            query = query.Where(x => x.UserId == userId);

        return query;
    }

    private IQueryable<Treatment> BuildOrderBy(
        IQueryable<Treatment> query,
        string? orderByDescription = null,
        string? orderByProtocol = null,
        string? orderByStartedAt = null,
        string? orderByEndedAt = null,
        string? orderByStartedIn = null,
        string? orderByEndedIn = null,
        string? orderByStatus = null,
        string? orderByType = null,
        string? orderByObservation = null,
        string? orderByExternalProtocol = null,
        string? orderByCall = null,
        string? orderByUser = null)
    {
        query = orderByDescription switch
        {
            "a" => query.OrderBy(x => x.Description),
            "d" => query.OrderByDescending(x => x.Description),
            _ => query
        };
        query = orderByProtocol switch
        {
            "a" => query.OrderBy(x => x.Protocol),
            "d" => query.OrderByDescending(x => x.Protocol),
            _ => query
        };
        query = orderByStartedAt switch
        {
            "a" => query.OrderBy(x => x.StartedAt),
            "d" => query.OrderByDescending(x => x.StartedAt),
            _ => query
        };
        query = orderByEndedAt switch
        {
            "a" => query.OrderBy(x => x.EndedAt),
            "d" => query.OrderByDescending(x => x.EndedAt),
            _ => query
        };
        query = orderByStartedIn switch
        {
            "a" => query.OrderBy(x => x.StartedIn),
            "d" => query.OrderByDescending(x => x.StartedIn),
            _ => query
        };
        query = orderByEndedIn switch
        {
            "a" => query.OrderBy(x => x.EndedIn),
            "d" => query.OrderByDescending(x => x.EndedIn),
            _ => query
        };
        query = orderByStatus switch
        {
            "a" => query.OrderBy(x => x.Status),
            "d" => query.OrderByDescending(x => x.Status),
            _ => query
        };
        query = orderByType switch
        {
            "a" => query.OrderBy(x => x.Type),
            "d" => query.OrderByDescending(x => x.Type),
            _ => query
        };
        query = orderByObservation switch
        {
            "a" => query.OrderBy(x => x.Observation),
            "d" => query.OrderByDescending(x => x.Observation),
            _ => query
        };
        query = orderByExternalProtocol switch
        {
            "a" => query.OrderBy(x => x.ExternalProtocol),
            "d" => query.OrderByDescending(x => x.ExternalProtocol),
            _ => query
        };
        query = orderByCall switch
        {
            "a" => query.OrderBy(x => x.Call!.Description),
            "d" => query.OrderByDescending(x => x.Call!.Description),
            _ => query
        };
        query = orderByUser switch
        {
            "a" => query.OrderBy(x => x.User!.Name),
            "d" => query.OrderByDescending(x => x.User!.Name),
            _ => query
        };

        return query;
    }
}
