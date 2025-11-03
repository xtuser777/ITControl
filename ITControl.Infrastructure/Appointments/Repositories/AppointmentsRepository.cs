using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Appointments.Interfaces;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Shared.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Appointments.Repositories;

public class AppointmentsRepository(ApplicationDbContext context) : 
    BaseRepository, IAppointmentsRepository
{
    public async Task<Appointment?> FindOneAsync(
        FindOneRepositoryParams @params)
    {
        query = context.Appointments.AsQueryable();
        ApplyIncludes(@params.Includes);
        return (Appointment?)await query
            .FirstOrDefaultAsync(x => x.Id == @params.Id);
    }

    public async Task<IEnumerable<Appointment>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context
            .Appointments
            .Include(x => x.User)
            .Include(x => x.Call)
            .AsNoTracking();
        BuildQuery(parameters.FindManyProps);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return (await query.ToListAsync()).Cast<Appointment>();
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

    public async Task<int> CountAsync(Entity parameters)
    {
        query = context.Appointments.AsNoTracking();
        BuildQuery(parameters);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(Entity parameters)
    {
        var count = await CountAsync(parameters);
        return count > 0;
    }
}