using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class AppointmentsRepository(
    ApplicationDbContext context) : IAppointmentsRepository
{
    public async Task<Appointment?> FindOneAsync(
        Guid id, 
        bool? includeUser = null, 
        bool? includeCall = null, 
        bool? includeLocation = null)
    {
        var query = context.Appointments.AsQueryable();
        if (includeUser != null)
        {
            query = query.Include(x => x.User);
        }

        if (includeCall != null)
        {
            query = query.Include(x => x.Call!).ThenInclude(c => c.User);
        }

        if (includeLocation != null)
        {
            query = query
                .Include(x => x.Location!)
                .ThenInclude(l => l.Unit)
                .Include(a => a.Location!)
                .ThenInclude(l => l.Department)
                .Include(a => a.Location!)
                .ThenInclude(l => l.Division);
        }
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Appointment>> FindManyAsync(
        string? description = null, 
        DateOnly? scheduledAt = null, 
        TimeOnly? scheduledIn = null,
        string? observation = null, 
        Guid? userId = null, 
        Guid? callId = null, 
        Guid? locationId = null,
        string? orderByDescription = null, 
        string? orderByScheduledAt = null, 
        string? orderByScheduledIn = null,
        string? orderByObservation = null, 
        string? orderByUser = null, 
        string? orderByCall = null,
        string? orderByLocation = null, 
        int? page = null, int? size = null)
    {
        var query = context
            .Appointments
            .Include(x => x.User)
            .Include(x => x.Call)
            .Include(x => x.Location)
            .AsNoTracking();
        query = BuildQuery(
            query, 
            null, 
            description, 
            scheduledAt, 
            scheduledIn, 
            observation, 
            userId, 
            callId, 
            locationId);
        query = BuildOrderBy(
            query, 
            orderByDescription, 
            orderByScheduledAt, 
            orderByScheduledIn, 
            orderByObservation,
            orderByUser, 
            orderByCall, 
            orderByLocation);
        if (page.HasValue && size.HasValue)
        {
            var skip = (page.Value - 1) * size.Value;
            query = query.Skip(skip).Take(size.Value);
        }

        return await query.ToListAsync();
    }

    public async Task CreateAsync(Appointment appointment)
    {
        await context.Appointments.AddAsync(appointment);
    }

    public void Update(Appointment appointment)
    {
        context.Appointments.Update(appointment);
    }

    public void Delete(Appointment appointment)
    {
        context.Appointments.Remove(appointment);
    }

    public async Task<int> CountAsync(
        Guid? id = null, 
        string? description = null, 
        DateOnly? scheduledAt = null, 
        TimeOnly? scheduledIn = null,
        string? observation = null, 
        Guid? userId = null, 
        Guid? callId = null, 
        Guid? locationId = null)
    {
        var query = context.Appointments.AsNoTracking();
        query = BuildQuery(
            query, 
            null, 
            description, 
            scheduledAt, 
            scheduledIn, 
            observation, 
            userId, 
            callId, 
            locationId);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? description = null, 
        DateOnly? scheduledAt = null, 
        TimeOnly? scheduledIn = null,
        string? observation = null, 
        Guid? userId = null, 
        Guid? callId = null, 
        Guid? locationId = null)
    {
        var count = await CountAsync(
            id, 
            description, 
            scheduledAt, 
            scheduledIn, 
            observation, 
            userId, 
            callId,
            locationId);
        
        return count > 0;
    }

    private IQueryable<Appointment> BuildQuery(
        IQueryable<Appointment> query,
        Guid? id = null, 
        string? description = null, 
        DateOnly? scheduledAt = null, 
        TimeOnly? scheduledIn = null,
        string? observation = null, 
        Guid? userId = null, 
        Guid? callId = null, 
        Guid? locationId = null)
    {
        if (id != null)
        {
            query = query.Where(x => x.Id == id);
        }
        if (description != null)
        {
            query = query.Where(x => x.Description.Contains(description));
        }
        if (scheduledAt != null)
        {
            query = query.Where(x => x.ScheduledAt == scheduledAt);
        }
        if (scheduledIn != null)
        {
            query = query.Where(x => x.ScheduledIn == scheduledIn);
        }
        if (observation != null)
        {
            query = query.Where(x => x.Observation.Contains(observation));
        }
        if (userId != null)
        {
            query = query.Where(x => x.UserId == userId);
        }
        if (callId != null)
        {
            query = query.Where(x => x.CallId == callId);
        }
        if (locationId != null)
        {
            query = query.Where(x => x.LocationId == locationId);
        }
        
        return query;
    }

    private IQueryable<Appointment> BuildOrderBy(
        IQueryable<Appointment> query,
        string? orderByDescription = null, 
        string? orderByScheduledAt = null, 
        string? orderByScheduledIn = null,
        string? orderByObservation = null, 
        string? orderByUser = null, 
        string? orderByCall = null,
        string? orderByLocation = null)
    {
        query = orderByDescription switch
        {
            "a" => query.OrderBy(x => x.Description),
            "d" => query.OrderByDescending(x => x.Description),
            _ => query
        };
        query = orderByScheduledAt switch
        {
            "a" => query.OrderBy(x => x.ScheduledAt),
            "d" => query.OrderByDescending(x => x.ScheduledAt),
            _ => query
        };
        query = orderByScheduledIn switch
        {
            "a" => query.OrderBy(x => x.ScheduledIn),
            "d" => query.OrderByDescending(x => x.ScheduledIn),
            _ => query
        };
        query = orderByObservation switch
        {
            "a" => query.OrderBy(x => x.Observation),
            "d" => query.OrderByDescending(x => x.Observation),
            _ => query
        };
        query = orderByUser switch
        {
            "a" => query.OrderBy(x => x.User!.Name),
            "d" => query.OrderByDescending(x => x.User!.Name),
            _ => query
        };
        query = orderByCall switch
        {
            "a" => query.OrderBy(x => x.Call!.Title),
            "d" => query.OrderByDescending(x => x.Call!.Title),
            _ => query
        };
        query = orderByLocation switch
        {
            "a" => query.OrderBy(x => x.Location!.Description),
            "d" => query.OrderByDescending(x => x.Location!.Description),
            _ => query
        };
        
        return query;
    }
}