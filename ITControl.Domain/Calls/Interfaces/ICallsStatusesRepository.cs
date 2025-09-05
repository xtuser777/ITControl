using ITControl.Domain.Calls.Entities;

namespace ITControl.Domain.Calls.Interfaces;

public interface ICallsStatusesRepository
{
    Task<CallStatus?> FindOneAsync(Guid id);
    Task CreateAsync(CallStatus callStatus);
    void Update(CallStatus callStatus);
    void Delete(CallStatus callStatus);
}
