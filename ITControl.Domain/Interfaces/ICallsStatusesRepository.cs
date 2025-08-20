using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface ICallsStatusesRepository
{
    Task<CallStatus?> FindOneAsync(Guid id);
    Task CreateAsync(CallStatus callStatus);
    void Update(CallStatus callStatus);
    void Delete(CallStatus callStatus);
}
