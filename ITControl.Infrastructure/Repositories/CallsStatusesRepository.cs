using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;

namespace ITControl.Infrastructure.Repositories;

public class CallsStatusesRepository(
    ApplicationDbContext context) : ICallsStatusesRepository
{
    public async Task CreateAsync(CallStatus callStatus)
    {
        await context.CallsStatuses.AddAsync(callStatus);
    }

    public void Delete(CallStatus callStatus)
    {
        context.CallsStatuses.Remove(callStatus);
    }

    public async Task<CallStatus?> FindOneAsync(Guid id)
    {
        return await context.CallsStatuses.FindAsync(id);
    }

    public void Update(CallStatus callStatus)
    {
        context.CallsStatuses.Update(callStatus);
    }
}
