using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Appointments.Interfaces;
using ITControl.Domain.Appointments.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Appointments.Repositories;

public class AppointmentsRepository(
    ApplicationDbContext context) : IAppointmentsRepository
{
    public async Task<Appointment?> FindOneAsync(FindOneAppointmentsRepositoryParams @params)
    {
        var query = context.Appointments.AsQueryable();
        if (@params.IncludeUser != null)
        {
            query = query.Include(x => x.User);
        }
        if (@params.IncludeCall != null)
        {
            query = query
                .Include(x => x.Call!).ThenInclude(c => c.User!).ThenInclude(u => u.Unit)
                .Include(x => x.Call!).ThenInclude(c => c.User!).ThenInclude(u => u.Department)
                .Include(x => x.Call!).ThenInclude(c => c.User!).ThenInclude(u => u.Division);
        }
        
        return await query.FirstOrDefaultAsync(x => x.Id == @params.Id);
    }

    public async Task<IEnumerable<Appointment>> FindManyAsync(FindManyAppointmentsRepositoryParams @params)
    {
        var (page, size) = @params;
        var query = context
            .Appointments
            .Include(x => x.User)
            .Include(x => x.Call)
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

    public async Task<int> CountAsync(CountAppointmentsRepositoryParams @params)
    {
        var query = context.Appointments.AsNoTracking();
        query = BuildQuery(new ()
        {
            Query = query,
            Params = @params
        });
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsAppointmentsRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    private static IQueryable<Appointment> BuildQuery(BuildQueryAppointmentsRepositoryParams @queryParams)
    {
        var (query, @params) = @queryParams;
        if (@params.Id != null)
        {
            query = query.Where(x => x.Id == @params.Id);
        }
        if (@params.Description != null)
        {
            query = query.Where(x => x.Description.Contains(@params.Description));
        }
        if (@params.ScheduledAt  != null)
        {
            query = query.Where(x => x.ScheduledAt == @params.ScheduledAt );
        }
        if (@params.ScheduledIn  != null)
        {
            query = query.Where(x => x.ScheduledIn == @params.ScheduledIn );
        }
        if (@params.Observation != null)
        {
            query = query.Where(x => x.Observation.Contains(@params.Observation));
        }
        if (@params.UserId  != null)
        {
            query = query.Where(x => x.UserId == @params.UserId );
        }
        if (@params.CallId  != null)
        {
            query = query.Where(x => x.CallId == @params.CallId );
        }
        
        return query;
    }

    private static IQueryable<Appointment> BuildOrderBy(BuildOrderByAppointmentsRepositoryParams @orderByParams)
    {
        var (query, @params) = @orderByParams;
        query = @params.OrderByDescription switch
        {
            "a" => query.OrderBy(x => x.Description),
            "d" => query.OrderByDescending(x => x.Description),
            _ => query
        };
        query = @params.OrderByScheduledAt switch
        {
            "a" => query.OrderBy(x => x.ScheduledAt),
            "d" => query.OrderByDescending(x => x.ScheduledAt),
            _ => query
        };
        query = @params.OrderByScheduledIn switch
        {
            "a" => query.OrderBy(x => x.ScheduledIn),
            "d" => query.OrderByDescending(x => x.ScheduledIn),
            _ => query
        };
        query = @params.OrderByObservation switch
        {
            "a" => query.OrderBy(x => x.Observation),
            "d" => query.OrderByDescending(x => x.Observation),
            _ => query
        };
        query = @params.OrderByUser switch
        {
            "a" => query.OrderBy(x => x.User!.Name),
            "d" => query.OrderByDescending(x => x.User!.Name),
            _ => query
        };
        query = @params.OrderByCall switch
        {
            "a" => query.OrderBy(x => x.Call!.Title),
            "d" => query.OrderByDescending(x => x.Call!.Title),
            _ => query
        };
        
        return query;
    }
}